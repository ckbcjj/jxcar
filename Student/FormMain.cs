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
    public class FormMain : XtraForm
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

        private IContainer components;

        private PanelControl panelControl1;

        private PictureEdit pictureEdit9;

        private ImageCollection imageCollection1;

        private System.Windows.Forms.Timer timer1;

        private PanelControl panelControl6;

        private PanelControl panelControl4;

        private NavBarControl navBarControl1;

        private NavBarGroup navBarGroup1;

        private NavBarItem navBarItem1;

        private NavBarItem navBarItem2;

        private NavBarItem navBarItem3;

        private NavBarItem navBarItem4;

        private NavBarItem navBarItem5;

        private NavBarItem navBarItem6;

        private PanelControl panelControl2;

        private NavBarItem navBarItem7;

        private XtraTabbedMdiManager xtraTabbedMdiManager1;

        private RibbonControl ribbonControl1;

        private RibbonGalleryBarItem ribbonGalleryBarItem1;

        private RibbonPage ribbonPage1;

        private RibbonPageGroup ribbonPageGroup1;

        private RepositoryItemPictureEdit repositoryItemPictureEdit1;

        private RepositoryItemPictureEdit repositoryItemPictureEdit2;

        private RepositoryItemPictureEdit repositoryItemPictureEdit3;

        private RepositoryItemPictureEdit repositoryItemPictureEdit4;

        private BarButtonItem barButtonItem1;

        private BarButtonItem barButtonItem2;

        private RibbonPageGroup ribbonPageGroup2;

        private LabelControl labelControl5;

        private PanelControl panelControl3;

        private LabelControl labelControl6;

        private SimpleButton simpleButton3;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlTop;

        private BarManager barManager1;

        private Bar bar3;

        private BarStaticItem barStaticItem1;

        private BarStaticItem barStaticItem2;

        private SimpleButton simpleButton4;

        private NavBarItem navBarItem8;

        private PanelControl panelControl5;

        private LabelControl labelControl2;

        private LabelControl labelControl1;

        private SimpleButton simpleButton1;

        private TextEdit textEdit1;

        private System.Windows.Forms.Timer timer2;

        private SimpleButton simpleButton5;

        private SimpleButton simpleButton2;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormMain));
            this.panelControl1 = new PanelControl();
            this.panelControl5 = new PanelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.panelControl3 = new PanelControl();
            this.labelControl6 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.ribbonControl1 = new RibbonControl();
            this.ribbonGalleryBarItem1 = new RibbonGalleryBarItem();
            this.barButtonItem1 = new BarButtonItem();
            this.barButtonItem2 = new BarButtonItem();
            this.ribbonPage1 = new RibbonPage();
            this.ribbonPageGroup1 = new RibbonPageGroup();
            this.ribbonPageGroup2 = new RibbonPageGroup();
            this.repositoryItemPictureEdit1 = new RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit2 = new RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit3 = new RepositoryItemPictureEdit();
            this.repositoryItemPictureEdit4 = new RepositoryItemPictureEdit();
            this.panelControl6 = new PanelControl();
            this.panelControl2 = new PanelControl();
            this.pictureEdit9 = new PictureEdit();
            this.panelControl4 = new PanelControl();
            this.simpleButton5 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.textEdit1 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton4 = new SimpleButton();
            this.simpleButton3 = new SimpleButton();
            this.imageCollection1 = new ImageCollection(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.navBarControl1 = new NavBarControl();
            this.navBarGroup1 = new NavBarGroup();
            this.navBarItem8 = new NavBarItem();
            this.navBarItem1 = new NavBarItem();
            this.navBarItem2 = new NavBarItem();
            this.navBarItem3 = new NavBarItem();
            this.navBarItem4 = new NavBarItem();
            this.navBarItem5 = new NavBarItem();
            this.navBarItem6 = new NavBarItem();
            this.navBarItem7 = new NavBarItem();
            this.xtraTabbedMdiManager1 = new XtraTabbedMdiManager(this.components);
            this.barManager1 = new BarManager(this.components);
            this.bar3 = new Bar();
            this.barStaticItem1 = new BarStaticItem();
            this.barStaticItem2 = new BarStaticItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.panelControl5).BeginInit();
            this.panelControl5.SuspendLayout();
            ((ISupportInitialize)this.panelControl3).BeginInit();
            this.panelControl3.SuspendLayout();
            ((ISupportInitialize)this.ribbonControl1).BeginInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit2).BeginInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit3).BeginInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit4).BeginInit();
            ((ISupportInitialize)this.panelControl6).BeginInit();
            this.panelControl6.SuspendLayout();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.pictureEdit9.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl4).BeginInit();
            this.panelControl4.SuspendLayout();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.imageCollection1).BeginInit();
            ((ISupportInitialize)this.navBarControl1).BeginInit();
            ((ISupportInitialize)this.xtraTabbedMdiManager1).BeginInit();
            ((ISupportInitialize)this.barManager1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.ribbonControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(826, 99);
            this.panelControl1.TabIndex = 3;
            this.panelControl5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            this.panelControl5.Controls.Add(this.labelControl2);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Location = new Point(635, 6);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(167, 88);
            this.panelControl5.TabIndex = 8;
            this.labelControl2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl2.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
            this.labelControl2.Location = new Point(24, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(84, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "发动机转速：无";
            this.labelControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl1.Location = new Point(22, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(120, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "发动机冷却液温度：无";
            this.panelControl3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Location = new Point(319, 5);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(225, 88);
            this.panelControl3.TabIndex = 2;
            this.panelControl3.Resize += new EventHandler(this.panelControl3_Resize);
            this.labelControl6.Appearance.Font = new Font("Tahoma", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.labelControl6.Location = new Point(83, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(79, 17);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "labelControl6";
            this.labelControl5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl5.Appearance.Font = new Font("Tahoma", 15f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl5.Appearance.ForeColor = Color.Orange;
            this.labelControl5.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            this.labelControl5.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.labelControl5.Location = new Point(60, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(135, 24);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "labelControl5";
            this.ribbonControl1.AllowKeyTips = false;
            this.ribbonControl1.AllowMdiChildButtons = false;
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.AllowTrimPageText = false;
            this.ribbonControl1.ApplicationButtonDropDownControl = this.barDockControlRight;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new BarItem[]
			{
				this.ribbonControl1.ExpandCollapseItem,
				this.ribbonGalleryBarItem1,
				this.barButtonItem1,
				this.barButtonItem2
			});
            this.ribbonControl1.Location = new Point(2, 2);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new RibbonPage[]
			{
				this.ribbonPage1
			});
            this.ribbonControl1.RepositoryItems.AddRange(new RepositoryItem[]
			{
				this.repositoryItemPictureEdit1,
				this.repositoryItemPictureEdit2,
				this.repositoryItemPictureEdit3,
				this.repositoryItemPictureEdit4
			});
            this.ribbonControl1.RightToLeft = RightToLeft.Yes;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new Size(822, 98);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.ribbonGalleryBarItem1.Gallery.ItemClick += new GalleryItemClickEventHandler(this.ribbonGalleryBarItem1_GalleryItemClick);
            this.ribbonGalleryBarItem1.Id = 1;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.GalleryItemClick += new GalleryItemClickEventHandler(this.ribbonGalleryBarItem1_GalleryItemClick);
            this.barButtonItem1.Caption = "最小化";
            this.barButtonItem1.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem1.Glyph = (Image)componentResourceManager.GetObject("barButtonItem1.Glyph");
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.LargeGlyph = (Image)componentResourceManager.GetObject("barButtonItem1.LargeGlyph");
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new ItemClickEventHandler(this.barButtonItem1_ItemClick);
            this.barButtonItem2.Caption = "关闭";
            this.barButtonItem2.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem2.Glyph = (Image)componentResourceManager.GetObject("barButtonItem2.Glyph");
            this.barButtonItem2.Id = 13;
            this.barButtonItem2.LargeGlyph = (Image)componentResourceManager.GetObject("barButtonItem2.LargeGlyph");
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new ItemClickEventHandler(this.barButtonItem2_ItemClick);
            this.ribbonPage1.Groups.AddRange(new RibbonPageGroup[]
			{
				this.ribbonPageGroup1,
				this.ribbonPageGroup2
			});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonGalleryBarItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "换肤";
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            this.repositoryItemPictureEdit3.PictureAlignment = ContentAlignment.MiddleLeft;
            this.repositoryItemPictureEdit4.Name = "repositoryItemPictureEdit4";
            this.panelControl6.Controls.Add(this.panelControl2);
            this.panelControl6.Controls.Add(this.panelControl4);
            this.panelControl6.Dock = DockStyle.Bottom;
            this.panelControl6.Location = new Point(167, 189);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new Size(659, 391);
            this.panelControl6.TabIndex = 2;
            this.panelControl6.Visible = false;
            this.panelControl2.Controls.Add(this.pictureEdit9);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(655, 348);
            this.panelControl2.TabIndex = 2;
            this.pictureEdit9.BackgroundImage = (Image)componentResourceManager.GetObject("pictureEdit9.BackgroundImage");
            this.pictureEdit9.Dock = DockStyle.Fill;
            this.pictureEdit9.Location = new Point(2, 2);
            this.pictureEdit9.Name = "pictureEdit9";
            this.pictureEdit9.Properties.ShowMenu = false;
            this.pictureEdit9.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit9.Size = new Size(651, 344);
            this.pictureEdit9.TabIndex = 0;
            this.panelControl4.Controls.Add(this.simpleButton5);
            this.panelControl4.Controls.Add(this.simpleButton2);
            this.panelControl4.Controls.Add(this.textEdit1);
            this.panelControl4.Controls.Add(this.simpleButton1);
            this.panelControl4.Controls.Add(this.simpleButton4);
            this.panelControl4.Controls.Add(this.simpleButton3);
            this.panelControl4.Dock = DockStyle.Bottom;
            this.panelControl4.Location = new Point(2, 350);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(655, 39);
            this.panelControl4.TabIndex = 1;
            this.simpleButton5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
            this.simpleButton5.Enabled = false;
            this.simpleButton5.Location = new Point(81, 2);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new Size(78, 35);
            this.simpleButton5.TabIndex = 16;
            this.simpleButton5.Text = "关闭仪表显示";
            this.simpleButton5.Visible = false;
            this.simpleButton5.Click += new EventHandler(this.simpleButton5_Click);
            this.simpleButton2.Dock = DockStyle.Left;
            this.simpleButton2.Location = new Point(2, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(78, 35);
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "打开仪表显示";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.textEdit1.Location = new Point(224, 1);
            this.textEdit1.MenuManager = this.ribbonControl1;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(90, 20);
            this.textEdit1.TabIndex = 14;
            this.textEdit1.Visible = false;
            this.simpleButton1.Location = new Point(320, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(86, 23);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "定位（测试）";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton4.Dock = DockStyle.Right;
            this.simpleButton4.Enabled = false;
            this.simpleButton4.Location = new Point(570, 2);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new Size(83, 35);
            this.simpleButton4.TabIndex = 12;
            this.simpleButton4.Text = "关闭检测显示";
            this.simpleButton4.Click += new EventHandler(this.simpleButton4_Click);
            this.simpleButton3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            this.simpleButton3.Location = new Point(491, 2);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(78, 35);
            this.simpleButton3.TabIndex = 11;
            this.simpleButton3.Text = "打开检测显示";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer)componentResourceManager.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "close.png");
            this.imageCollection1.Images.SetKeyName(1, "close-01.png");
            this.imageCollection1.Images.SetKeyName(2, "small.png");
            this.imageCollection1.Images.SetKeyName(3, "small-01.png");
            this.imageCollection1.Images.SetKeyName(4, "NoSchematic.png");
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new NavBarGroup[]
			{
				this.navBarGroup1
			});
            this.navBarControl1.Items.AddRange(new NavBarItem[]
			{
				this.navBarItem1,
				this.navBarItem2,
				this.navBarItem3,
				this.navBarItem4,
				this.navBarItem5,
				this.navBarItem6,
				this.navBarItem7,
				this.navBarItem8
			});
            this.navBarControl1.Location = new Point(0, 99);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 167;
            this.navBarControl1.OptionsNavPane.ShowGroupImageInHeader = true;
            this.navBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl1.PaintStyleKind = NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new Size(167, 481);
            this.navBarControl1.TabIndex = 7;
            this.navBarControl1.Text = " ";
            this.navBarGroup1.Caption = "功能导航";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new NavBarItemLink[]
			{
				new NavBarItemLink(this.navBarItem8),
				new NavBarItemLink(this.navBarItem1),
				new NavBarItemLink(this.navBarItem2),
				new NavBarItemLink(this.navBarItem3),
				new NavBarItemLink(this.navBarItem4),
				new NavBarItemLink(this.navBarItem5),
				new NavBarItemLink(this.navBarItem6),
				new NavBarItemLink(this.navBarItem7)
			});
            this.navBarGroup1.LargeImage = (Image)componentResourceManager.GetObject("navBarGroup1.LargeImage");
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 1;
            this.navBarItem8.Caption = "模块信息";
            this.navBarItem8.LargeImage = (Image)componentResourceManager.GetObject("navBarItem8.LargeImage");
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.LinkClicked += new NavBarLinkEventHandler(this.navBarItem8_LinkClicked);
            this.navBarItem1.Appearance.Image = (Image)componentResourceManager.GetObject("navBarItem1.Appearance.Image");
            this.navBarItem1.Appearance.Options.UseImage = true;
            this.navBarItem1.Caption = "历史数据";
            this.navBarItem1.LargeImage = (Image)componentResourceManager.GetObject("navBarItem1.LargeImage");
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            this.navBarItem2.Caption = "实训考核";
            this.navBarItem2.LargeImage = (Image)componentResourceManager.GetObject("navBarItem2.LargeImage");
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            this.navBarItem3.Caption = "波形监控";
            this.navBarItem3.LargeImage = (Image)componentResourceManager.GetObject("navBarItem3.LargeImage");
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.Visible = false;
            this.navBarItem3.LinkClicked += new NavBarLinkEventHandler(this.navBarItem3_LinkClicked);
            this.navBarItem4.Caption = "历史波形";
            this.navBarItem4.LargeImage = (Image)componentResourceManager.GetObject("navBarItem4.LargeImage");
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.Visible = false;
            this.navBarItem4.LinkClicked += new NavBarLinkEventHandler(this.navBarItem4_LinkClicked);
            this.navBarItem5.Caption = "资料共享";
            this.navBarItem5.LargeImage = (Image)componentResourceManager.GetObject("navBarItem5.LargeImage");
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.Visible = false;
            this.navBarItem5.LinkClicked += new NavBarLinkEventHandler(this.navBarItem5_LinkClicked);
            this.navBarItem6.Caption = "参数设置";
            this.navBarItem6.LargeImage = (Image)componentResourceManager.GetObject("navBarItem6.LargeImage");
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.LinkClicked += new NavBarLinkEventHandler(this.navBarItem6_LinkClicked);
            this.navBarItem7.Caption = "查看电路图";
            this.navBarItem7.LargeImage = (Image)componentResourceManager.GetObject("navBarItem7.LargeImage");
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.LinkClicked += new NavBarLinkEventHandler(this.navBarItem7_LinkClicked);
            this.xtraTabbedMdiManager1.HeaderButtons = TabButtons.None;
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = TabButtonShowMode.Never;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.barManager1.Bars.AddRange(new Bar[]
			{
				this.bar3
			});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[]
			{
				this.barStaticItem1,
				this.barStaticItem2
			});
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.barStaticItem1),
				new LinkPersistInfo(this.barStaticItem2)
			});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.barStaticItem1.Caption = "当前登录用户：";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = StringAlignment.Near;
            this.barStaticItem2.Alignment = BarItemLinkAlignment.Right;
            this.barStaticItem2.Caption = "系统时间：";
            this.barStaticItem2.Id = 1;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = StringAlignment.Near;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(826, 0);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 580);
            this.barDockControlBottom.Size = new Size(826, 27);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 0);
            this.barDockControlLeft.Size = new Size(0, 580);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(826, 0);
            this.barDockControlRight.Size = new Size(0, 580);
            this.timer2.Interval = 500;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(826, 607);
            base.Controls.Add(this.panelControl6);
            base.Controls.Add(this.navBarControl1);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.IsMdiContainer = true;
            base.Name = "FormMain";
            this.Text = "整车设故考核系统";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FrmMain_Load);
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl5).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((ISupportInitialize)this.panelControl3).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((ISupportInitialize)this.ribbonControl1).EndInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit2).EndInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit3).EndInit();
            ((ISupportInitialize)this.repositoryItemPictureEdit4).EndInit();
            ((ISupportInitialize)this.panelControl6).EndInit();
            this.panelControl6.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((ISupportInitialize)this.pictureEdit9.Properties).EndInit();
            ((ISupportInitialize)this.panelControl4).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.imageCollection1).EndInit();
            ((ISupportInitialize)this.navBarControl1).EndInit();
            ((ISupportInitialize)this.xtraTabbedMdiManager1).EndInit();
            ((ISupportInitialize)this.barManager1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
