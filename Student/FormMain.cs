using BLL.Common;
using BLL.Core;
using BLL.Service;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Student
{
    public partial class FormMain : XtraForm
    {
        private const string alert = "当前未连接任何系统模块,无法操作";

        private Communication comm1;

        private Communication comm2;

        private RTData data;

        private DataTable dt;

        private TimeSpan TS = TimeSpan.Zero;

        private DateTime time;

        private static Image img;

        private List<int> PrePointList = new List<int>();

        private Thread ReadModuleThraed;

        

        public FormMain()
        {
            this.InitializeComponent();
            this.LoadSkin();
            this.dt = this.GetSysModule();
            FormMain.img = this.GetScematicById(ClientSystemInfo.ModuleId);
            this.timer1.Start();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.ReadModule();
            ClientSystemInfo.ValueChangeEvent += new SocketDelegate(this.Module_StateChangeEvent);
            ClientListenManager.ListenEvent += new ListenDelegate(this.LM_ListenEvent);
            this.LoadState();
            this.ReadConfig();
        }

        public void ReadConfig()
        {
            SecurityHelper securityHelper = new SecurityHelper();
            string strPath = ClientSystemInfo.strPath;
            try
            {
                string key = securityHelper.ReadFile("检测板", "SerialCom", strPath);
                int value = int.Parse(securityHelper.ReadFile("检测板", "BaudRate", strPath));
                SerialComConfig serialComConfig = new SerialComConfig(1, new KeyValuePair<string, int>(key, value));
                serialComConfig.SerialComConfigChange += new SerialComConfigDelegate(this.SerialComConfigChange_SerialComConfigChange);
                ClientSystemInfo.SerialComInfoList = new List<SerialComConfig>
				{
					serialComConfig
				};
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SerialComConfigChange_SerialComConfigChange(int type, object args)
        {
            KeyValuePair<string, int> keyvalue = (KeyValuePair<string, int>)args;
            if (type > 0)
            {
                SerialComConfig serialComConfig = (from t in ClientSystemInfo.SerialComInfoList
                                                   where t.SerialComInfo.Key == keyvalue.Key
                                                   select t).FirstOrDefault<SerialComConfig>();
                if (serialComConfig != null)
                {
                    switch (serialComConfig.SerialComType)
                    {
                        case 1:
                            this.closeMyCom(this.comm1);
                            break;
                        case 2:
                            this.closeMyCom(this.comm2);
                            break;
                    }
                }
            }
            switch (type)
            {
                case -2:
                case 2:
                    this.closeMyCom(this.comm2);
                    this.comm2 = new Communication(keyvalue.Key, keyvalue.Value);
                    break;
                case -1:
                case 1:
                    this.closeMyCom(this.comm1);
                    this.comm1 = new Communication(keyvalue.Key, keyvalue.Value);
                    return;
                case 0:
                    break;
                default:
                    return;
            }
        }

        public void closeMyCom(Communication comm)
        {
            if (comm != null && comm._serialPort.IsOpen)
            {
                comm.closePort();
                comm = null;
            }
        }

        public void ReadModule()
        {
            SocketInfo SI = new SocketInfo
            {
                Name = LoginInfo.UserName,
                Type = SocketInfoType.SysModule
            };
            this.ReadModuleThraed = new Thread(new ThreadStart( delegate
            {
                while (true)
                {
                    bool flag = TcpClient.SendMessage(SI);
                    if (!flag || !TcpClient.client.Connected)
                    {
                        ClientSystemInfo.ModuleIdBuff = 0;
                        ClientSystemInfo.SysPatternBuff = 0;
                        try
                        {
                            TcpClient.client.Disconnect(true);
                        }
                        catch
                        {
                        }
                        while (!TcpClient.asyncTag)
                        {
                            if (ClientSystemInfo.readyToExit)
                            {
                                TcpClient.client.Close();
                                goto IL_6C;
                            }
                            TcpClient.SynConnect();
                            Thread.Sleep(1000);
                        }
                        TcpClient.asyncTag = false;
                    }
                IL_6C:
                    if (ClientSystemInfo.readyToExit)
                    {
                        break;
                    }
                    Thread.Sleep(3000);
                }
                TcpClient.client.Close();
            }));
            this.ReadModuleThraed.IsBackground = true;
            this.ReadModuleThraed.Start();
        }

        private void Module_StateChangeEvent(object sender, SocketEventArgs e)
        {
            if (e._eventType == SocketInfoType.SysModule)
            {
                this.labelControl5.Invoke(new MethodInvoker(delegate
                {
                    this.labelControl5.Text = ((int.Parse(e._value.ToString()) == 0) ? "当前未连接任何模块" : this.dt.Select(" id=" + int.Parse(e._value.ToString())).First<DataRow>()["modulename"].ToString());
                    FormMain.img = this.GetScematicById(int.Parse(e._value.ToString()));
                    this.pictureEdit9.Image = FormMain.img;
                }));
                return;
            }
            this.labelControl6.Invoke(new MethodInvoker(delegate
            {
                this.labelControl6.Text = ((int.Parse(e._value.ToString()) == 0) ? "自由训练模式" : "实训考核模式");
            }));
        }

        public void LoadState()
        {
            this.barStaticItem1.Caption = string.Format("当前登录用户：{0}", LoginInfo.UserName);
            this.barStaticItem2.Caption = string.Format("系统时间：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            this.labelControl5.Text = ((ClientSystemInfo.ModuleId == 0) ? "当前未连接任何模块" : this.dt.Select(" id=" + ClientSystemInfo.ModuleId).First<DataRow>()["modulename"].ToString());
            this.labelControl6.Text = ((ClientSystemInfo.SysPattern == 0) ? "自由训练模式" : "实训考核模式");
            this.pictureEdit9.Image = FormMain.img;
            this.panelControl6.Height = this.navBarControl1.Height;
            this.panelControl6.Visible = true;
        }

        public DataTable GetSysModule()
        {
            DataAccess dataAccess = new DataAccess();
            this.dt = dataAccess.GetList("select * from sysmodule");
            return this.dt;
        }

        public Image GetScematicById(int id)
        {
            Image result = this.imageCollection1.Images["NoSchematic.png"];
            if (id != 0 && this.dt != null)
            {
                string text = Environment.CurrentDirectory + "\\images\\Schematic\\" + this.dt.Select(" id=" + id).FirstOrDefault<DataRow>()["schematic"].ToString();
                if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
                {
                    result = this.imageCollection1.Images["NoSchematic.png"];
                }
                else
                {
                    result = Image.FromFile(text);
                }
            }
            return result;
        }

        private void LM_ListenEvent(object sender, ListenEventArgs e)
        {
            SocketInfoType eventType = e._eventType;
            if (eventType != SocketInfoType.CheckItem)
            {
                if (eventType != SocketInfoType.RealTimeData)
                {
                    return;
                }
                RTData data = e.value as RTData;
                base.Invoke(new MethodInvoker(delegate
                {
                    this.labelControl1.Text = string.Format("发动机冷却液温度:{0}", data.FDJLQYWD);
                    this.labelControl2.Text = string.Format("发动机转速:{0}", data.FDJZS);
                }));
            }
            else
            {
                CheckInfo.PcCheckState = true;
                this.time = DateTime.Now;
                if (MessageBox.Show("教师已发考题。\n 立即答题点击是；\n 稍后答题点击否。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    base.Invoke(new MethodInvoker(delegate
                    {
                        base.WindowState = FormWindowState.Maximized;
                        this.panelControl6.Height = this.navBarControl1.Height * 4 / 5;
                        this.panelControl6.Visible = true;
                        this.xtraTabbedMdiManager1.Pages.Clear();
                        new FrmCheck(this.time)
                        {
                            MdiParent = this
                        }.Show();
                    }));
                    return;
                }
            }
        }

        public void LoadSkin()
        {
            SkinHelper.InitSkinGallery(this.ribbonGalleryBarItem1, false);
            StringBuilder stringBuilder = new StringBuilder(255);
            SecurityHelper.GetPrivateProfileString("Skin", "name", "McSkin", stringBuilder, 255, ClientSystemInfo.strPath);
            string skinStyle = (stringBuilder.Length == 0) ? "McSkin" : stringBuilder.ToString();
            UserLookAndFeel.Default.SetSkinStyle(skinStyle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.barStaticItem2.Caption = string.Format("系统时间：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            if (DateTime.Now > this.time + TimeSpan.FromMinutes((double)ClientSystemInfo.TimeCount))
            {
                CheckInfo.PcCheckState = false;
            }
        }

        private void navBarItem8_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClientSystemInfo.ModuleId != 0)
            {
                XtraMdiTabPage xtraMdiTabPage = (from XtraMdiTabPage t in this.xtraTabbedMdiManager1.Pages
                                                 where t.MdiChild.GetType() == typeof(FrmCheck)
                                                 select t).SingleOrDefault<XtraMdiTabPage>();
                if (xtraMdiTabPage != null)
                {
                    this.xtraTabbedMdiManager1.Pages.Clear();
                    this.xtraTabbedMdiManager1.Pages.Add(xtraMdiTabPage);
                    xtraMdiTabPage.MdiChild.Hide();
                }
                else
                {
                    this.xtraTabbedMdiManager1.Pages.Clear();
                }
                string text = this.dt.Select(" id=" + ClientSystemInfo.ModuleId).First<DataRow>()["modulename"].ToString();
                FrmModuleInfo frmModuleInfo = new FrmModuleInfo();
                frmModuleInfo.Text = text;
                this.panelControl6.Hide();
                frmModuleInfo.MdiParent = this;
                frmModuleInfo.Show();
                return;
            }
            MessageBox.Show("当前未连接任何系统模块,无法操作");
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            XtraMdiTabPage xtraMdiTabPage = (from XtraMdiTabPage t in this.xtraTabbedMdiManager1.Pages
                                             where t.MdiChild.GetType() == typeof(FrmCheck)
                                             select t).SingleOrDefault<XtraMdiTabPage>();
            if (xtraMdiTabPage != null)
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
                this.xtraTabbedMdiManager1.Pages.Add(xtraMdiTabPage);
                xtraMdiTabPage.MdiChild.Hide();
            }
            else
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
            }
            FrmData frmData = new FrmData();
            this.panelControl6.Hide();
            frmData.MdiParent = this;
            frmData.Show();
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClientSystemInfo.ModuleId == 0)
            {
                MessageBox.Show("当前未连接任何系统模块,无法操作");
                return;
            }
            if (!CheckInfo.PcCheckState)
            {
                MessageBox.Show("现在不处于答题考核状态,无法答题");
                return;
            }
            this.panelControl6.Height = this.navBarControl1.Height * 4 / 5;
            this.panelControl6.Visible = true;
            XtraMdiTabPage xtraMdiTabPage = (from XtraMdiTabPage t in this.xtraTabbedMdiManager1.Pages
                                             where t.MdiChild.GetType() == typeof(FrmCheck)
                                             select t).SingleOrDefault<XtraMdiTabPage>();
            if (xtraMdiTabPage != null)
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
                this.xtraTabbedMdiManager1.Pages.Add(xtraMdiTabPage);
                xtraMdiTabPage.MdiChild.Show();
                return;
            }
            this.xtraTabbedMdiManager1.Pages.Clear();
            new FrmCheck(this.time)
            {
                MdiParent = this
            }.Show();
        }

        private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            XtraMdiTabPage xtraMdiTabPage = (from XtraMdiTabPage t in this.xtraTabbedMdiManager1.Pages
                                             where t.MdiChild.GetType() == typeof(FrmCheck)
                                             select t).SingleOrDefault<XtraMdiTabPage>();
            if (xtraMdiTabPage != null)
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
                this.xtraTabbedMdiManager1.Pages.Add(xtraMdiTabPage);
                xtraMdiTabPage.MdiChild.Hide();
            }
            else
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
            }
            FrmOscillogram frmOscillogram = new FrmOscillogram();
            this.panelControl6.Hide();
            frmOscillogram.MdiParent = this;
            frmOscillogram.Show();
        }

        private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            XtraMdiTabPage xtraMdiTabPage = (from XtraMdiTabPage t in this.xtraTabbedMdiManager1.Pages
                                             where t.MdiChild.GetType() == typeof(FrmCheck)
                                             select t).SingleOrDefault<XtraMdiTabPage>();
            if (xtraMdiTabPage != null)
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
                this.xtraTabbedMdiManager1.Pages.Add(xtraMdiTabPage);
                xtraMdiTabPage.MdiChild.Hide();
            }
            else
            {
                this.xtraTabbedMdiManager1.Pages.Clear();
            }
            FrmHisOscillogram frmHisOscillogram = new FrmHisOscillogram();
            this.panelControl6.Hide();
            frmHisOscillogram.MdiParent = this;
            frmHisOscillogram.Show();
        }

        private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            DataAccess dataAccess = new DataAccess();
            DataTable list = dataAccess.GetList("select shareaddress from serverinfo where id=1");
            if (list != null && list.Rows.Count != 0)
            {
                string arguments = list.Rows[0][0].ToString();
                try
                {
                    Process.Start("Explorer.exe", arguments);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void navBarItem6_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            new FrmSetting
            {
                StartPosition = FormStartPosition.CenterScreen
            }.ShowDialog();
        }

        private void navBarItem7_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.panelControl6.Height = this.navBarControl1.Height;
            this.panelControl6.Visible = true;
        }

        private void navBarControl1_NavPaneStateChanged(object sender, EventArgs e)
        {
            if (this.panelControl6.Visible)
            {
                if (this.xtraTabbedMdiManager1.Pages.Count != 0 && this.xtraTabbedMdiManager1.Pages[0].MdiChild.GetType() == typeof(FrmCheck))
                {
                    if (this.navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Expanded)
                    {
                        this.panelControl6.Width = (base.Width - this.navBarControl1.OptionsNavPane.ExpandedWidth) * 4 / 5;
                        return;
                    }
                    this.panelControl6.Width = (base.Width - this.navBarControl1.CalcCollapsedPaneWidth()) * 4 / 5;
                    return;
                }
                else
                {
                    if (this.navBarControl1.OptionsNavPane.NavPaneState == NavPaneState.Expanded)
                    {
                        this.panelControl6.Width = base.Width - this.navBarControl1.OptionsNavPane.ExpandedWidth;
                        return;
                    }
                    this.panelControl6.Width = base.Width - this.navBarControl1.CalcCollapsedPaneWidth();
                }
            }
        }

        private void comm_DataRecived(object sender, SerialDataReceivedEventArgs e, byte[] buff)
        {
            List<int> list = new List<int>();
            for (int i = 1; i < buff.Length; i++)
            {
                if (buff[i] != 251 && buff[i] != 250)
                {
                    list.Add((int)buff[i]);
                }
                else if (buff[i] == 251 && list != this.PrePointList)
                {
                    this.DrawPoint(list);
                    this.PrePointList = list;
                    list.Clear();
                }
            }
        }

        public void DrawPoint(List<int> PointList)
        {
            if (PointList.Count == 0)
            {
                return;
            }
            try
            {
                base.Invoke(new MethodInvoker(delegate
                {
                    this.pictureEdit9.Image = FormMain.img;
                    int num = 12;
                    int num2 = 0;
                    int num3 = 0;
                    int width = this.pictureEdit9.Width;
                    int height = this.pictureEdit9.Height;
                    if (height == 0 || width == 0)
                    {
                        return;
                    }
                    Image original = FormMain.img;
                    Bitmap image = new Bitmap(original, width, height);
                    Graphics graphics = Graphics.FromImage(image);
                    foreach (int current in PointList)
                    {
                        PointF location = MapLocation.GetLocation(this.pictureEdit9.Location, width, height, current);
                        graphics.FillRectangle(new SolidBrush(Color.Red), location.X - (float)num - (float)num2, location.Y - (float)num - (float)num3, (float)(num * 2), (float)(num * 2));
                    }
                    this.pictureEdit9.Image = image;
                    graphics.Dispose();
                }));
            }
            catch
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.closeMyCom(this.comm1);
            this.closeMyCom(this.comm2);
            ClientSystemInfo.readyToExit = true;
            this.ReadModuleThraed.Abort();
            Application.Exit();
        }

        private void panelControl3_Resize(object sender, EventArgs e)
        {
            this.labelControl5.Location = new Point((this.panelControl3.Width - this.labelControl5.Width) / 2 - 20, this.panelControl3.Location.Y + 5);
            this.labelControl6.Location = new Point((this.panelControl3.Width - this.labelControl6.Width) / 2 - 10, this.panelControl3.Location.Y + 30);
        }

        private void ribbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            SecurityHelper.WritePrivateProfileString("Skin", "name", e.Item.Caption, ClientSystemInfo.strPath);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.comm1 == null && ClientSystemInfo.SerialComInfoList != null && ClientSystemInfo.SerialComInfoList.Count != 0)
            {
                SerialComConfig serialComConfig = (from t in ClientSystemInfo.SerialComInfoList
                                                   where t.SerialComType == 1
                                                   select t).FirstOrDefault<SerialComConfig>();
                if (serialComConfig != null)
                {
                    this.comm1 = new Communication(serialComConfig.SerialComInfo.Key, serialComConfig.SerialComInfo.Value);
                    this.comm1.DataRecived += new Communication.MyDataRecivedDelegate(this.comm_DataRecived);
                }
            }
            if (this.comm1.openPort())
            {
                this.simpleButton4.Enabled = true;
                MessageBox.Show("串口打开成功");
                this.simpleButton3.Enabled = false;
                return;
            }
            MessageBox.Show("串口打开失败");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.pictureEdit9.Image = FormMain.img;
            if (this.comm1 != null)
            {
                this.comm1.closePort();
            }
            this.simpleButton3.Enabled = true;
            this.simpleButton4.Enabled = false;
            MessageBox.Show("串口已关闭");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lock (ClientListenManager.NewData)
            {
                this.data = ClientListenManager.NewData;
            }
            if (this.data != null)
            {
                byte[] bytes = this.GetBytes(this.data);
                this.comm2.SendData(bytes, 0, bytes.Length);
            }
        }

        private byte[] GetBytes(RTData data)
        {
            byte[] array = new byte[]
			{
				250,
				0,
				0,
				0,
				251
			};
            if (!string.IsNullOrEmpty(data.FDJZS))
            {
                byte[] bytesFromStr = this.GetBytesFromStr(data.FDJZS, 2);
                byte[] bytesFromStr2 = this.GetBytesFromStr(data.FDJLQYWD, 1);
                array[1] = bytesFromStr[0];
                array[2] = bytesFromStr[1];
                array[3] = bytesFromStr2[0];
            }
            return array;
        }

        private byte[] GetBytesFromStr(string str, int typeid)
        {
            byte[] array = null;
            switch (typeid)
            {
                case 1:
                    array = new byte[1];
                    if (string.IsNullOrEmpty(str))
                    {
                        return array;
                    }
                    try
                    {
                        int num = Convert.ToInt32(str.Substring(0, str.IndexOf('.')));
                        array[0] = (byte)num;
                        return array;
                    }
                    catch
                    {
                        return array;
                    }
                    break;
                case 2:
                    break;
                default:
                    return array;
            }
            array = new byte[2];
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    int num2 = Convert.ToInt32(str.Substring(0, str.IndexOf('.')));
                    if (num2 > 0 && num2 <= 255)
                    {
                        array[0] = 0;
                        array[1] = (byte)num2;
                    }
                    else if (num2 > 255 && num2 <= 65535)
                    {
                        array[0] = (byte)(num2 / 256);
                        array[1] = (byte)(num2 % 256);
                    }
                }
                catch
                {
                }
            }
            return array;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.comm2 == null && ClientSystemInfo.SerialComInfoList != null && ClientSystemInfo.SerialComInfoList.Count != 0)
            {
                SerialComConfig serialComConfig = (from t in ClientSystemInfo.SerialComInfoList
                                                   where t.SerialComType == 2
                                                   select t).FirstOrDefault<SerialComConfig>();
                if (serialComConfig != null)
                {
                    this.comm2 = new Communication(serialComConfig.SerialComInfo.Key, serialComConfig.SerialComInfo.Value);
                }
            }
            if (this.comm2.openPort())
            {
                this.simpleButton5.Enabled = true;
                MessageBox.Show("串口打开成功");
                this.simpleButton2.Enabled = false;
                this.timer2.Enabled = true;
                return;
            }
            MessageBox.Show("串口打开失败");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.timer2.Enabled = false;
            if (this.comm2 != null)
            {
                this.comm2.closePort();
            }
            this.simpleButton2.Enabled = true;
            this.simpleButton5.Enabled = false;
        }
    }
}
