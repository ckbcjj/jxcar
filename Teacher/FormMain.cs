using BLL.Common;
using BLL.Core;
using BLL.OtherInfo;
using BLL.Service;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Teacher
{


    public partial class FormMain : XtraForm
    {
        public DataRow _dr;
        private Thread _RTthread;
        private Bar bar1;
        private Bar bar3;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarLargeButtonItem barLargeButtonItem1;
        private BarLargeButtonItem barLargeButtonItem2;
        private BarLargeButtonItem barLargeButtonItem3;
        private BarLargeButtonItem barLargeButtonItem4;
        private BarLargeButtonItem barLargeButtonItem5;
        private BarManager barManager2;
        private BarStaticItem barStaticItem1;
        private BarStaticItem barStaticItem2;
        private BarStaticItem barStaticItem3;
        private BarStaticItem barStaticItem4;
        private BarStaticItem barStaticItem5;
        private BarStaticItem barStaticItem6;
        private byte[] buffer;
        private Button button1;
        private Socket client;
      

        public FormMain(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
            this.da = new DataAccess();
            this.LoadSkin();
            this.ReadConfig();
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBlock block;
            if (FrmBlock.NavHandle != IntPtr.Zero)
            {
                block = (FrmBlock) Control.FromHandle(FrmBlock.NavHandle);
            }
            else
            {
                block = new FrmBlock();
            }
            if (block != null)
            {
                PanelControl control = (PanelControl) block.Controls.Find("panelControl1", false).First<Control>();
                if ((control != null) && (control.Controls.Count != 0))
                {
                    foreach (Control control2 in control.Controls)
                    {
                        if (control2.Text == ServerSystemInfo.ModuleName)
                        {
                            control2.ForeColor = Color.Red;
                        }
                        else
                        {
                            control2.ForeColor = Color.Black;
                        }
                    }
                }
                block.Show();
            }
            if (this.SwitchModuleSM != null)
            {
                this.SwitchModuleSM.DisConnectModule(int.Parse(this._dr["Id"].ToString()));
                ServerSystemInfo.ModuleIdBuff = -1;
            }
            FrmBlock.Mainhandle = base.Handle;
            base.Hide();
            PaidComm.ConnetctModels -= new Action<Socket, byte[], int>(this.btnConnects);
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((this.SwitchModuleSM == null) && (ServerSystemInfo.SerialComInfoList != null)) && (ServerSystemInfo.SerialComInfoList.Count != 0))
            {
                SerialComConfig config = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 1
                    select t).FirstOrDefault<SerialComConfig>();
                if (config != null)
                {
                    this.SwitchModuleSM = new SysManager(config.SerialComInfo.Key, config.SerialComInfo.Value);
                }
            }
            if (ServerSystemInfo.ModuleId == ServerSystemInfo.SoftModuleId)
            {
                CMessageInfo.ShowMessage("该模块已连接！", "模块切换", 1);
                if ((this.client != null) && (this.buffer != null))
                {
                    PaidComm.SendBack(this.client, this.buffer, 0);
                }
            }
            else if (CheckInfo.PcCheckState)
            {
                CMessageInfo.ShowMessage("学生机考核进行中，无法操作！", "模块切换", 1);
            }
            else if (CheckInfo.PaidCheckState)
            {
                CMessageInfo.ShowMessage("平板用户考核进行中，无法操作！", "模块切换", 1);
            }
            else
            {
                string msg = string.Empty;
                if (this.SwitchModuleSM.ConnectModule(int.Parse(this._dr["Id"].ToString())))
                {
                    ServerSystemInfo.ModuleName = this._dr["ModuleName"].ToString();
                    ServerSystemInfo.ModuleIdBuff = int.Parse(this._dr["Id"].ToString());
                    CMessageInfo.ShowMessage("模块切换成功！", "模块切换", 1);
                    if ((this.client != null) && (this.buffer != null))
                    {
                        PaidComm.SendBack(this.client, this.buffer, 0);
                    }
                    SysManager.ModuleId = ServerSystemInfo.ModuleId;
                    SysManager.ResetFaultPoint();
                    msg = string.Format("切换模块[{0}]成功", ServerSystemInfo.ModuleName);
                }
                else
                {
                    CMessageInfo.ShowMessage("模块连接失败，请重试！", "模块切换", 1);
                    msg = string.Format("切换模块[{0}]失败", this._dr["ModuleName"].ToString());
                    if ((this.client != null) && (this.buffer != null))
                    {
                        PaidComm.SendBack(this.client, this.buffer, 1);
                    }
                }
                this.da.WriteLog(LoginInfo.UserName, msg);
            }
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void barLargeButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FrmBlock.NavHandle != IntPtr.Zero)
            {
                ((FrmBlock) Control.FromHandle(FrmBlock.NavHandle)).Show();
            }
            else
            {
                new FrmBlock().Show();
            }
            if (this.SwitchModuleSM != null)
            {
                this.SwitchModuleSM.DisConnectModule(int.Parse(this._dr["Id"].ToString()));
                ServerSystemInfo.ModuleIdBuff = -1;
            }
            FrmBlock.Mainhandle = base.Handle;
            base.Hide();
        }

        public void btnBack(int iA)
        {
            base.Invoke(new MethodInvoker(this.barLargeButtonItem2.PerformClick));
        }

        public void btnConnect()
        {
            base.Invoke(new MethodInvoker(this.barLargeButtonItem3.PerformClick));
        }

        public void btnConnects(Socket client, byte[] buffer, int iNum)
        {
            this.client = client;
            this.buffer = buffer;
            base.Invoke(new MethodInvoker(this.barLargeButtonItem3.PerformClick));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.PCschematic.Visible)
            {
                this.PCschematic.Hide();
                if (this.toggleSwitch1.IsOn)
                {
                    this.toggleSwitch1.IsOn = false;
                }
            }
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmSetFault)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
                ((FrmSetFault) page.MdiChild).BindData();
            }
            else
            {
                FrmSetFault fault = new FrmSetFault();
                PaidComm.SetFaults += new System.Action<Socket, byte[], int, int, int>(fault.SetFaultEvents);
                PaidComm.SetCheckEvent += new Action<int, int, int, int>(fault.SetCheckEvent);
                fault.MdiParent = this;
                fault.Show();
            }
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string str = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    str = str + bytes[i].ToString("X2");
                }
            }
            return str;
        }

        public static void closeMyCom(Communication comm)
        {
            if ((comm != null) && comm._serialPort.IsOpen)
            {
                comm.closePort();
                comm = null;
            }
        }

        public static void closeMyCom(SysManager sm)
        {
            if ((sm != null) && sm.comm._serialPort.IsOpen)
            {
                sm.comm.closePort();
                sm.comm = null;
            }
        }

        private void ConnectOBD()
        {
            if (((this.GetRTDataSM == null) && (ServerSystemInfo.SerialComInfoList != null)) && (ServerSystemInfo.SerialComInfoList.Count != 0))
            {
                SerialComConfig config = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 3
                    select t).FirstOrDefault<SerialComConfig>();
                if (config != null)
                {
                    this.GetRTDataSM = new SysManager(config.SerialComInfo.Key, config.SerialComInfo.Value);
                    if (!this.GetRTDataSM.comm._serialPort.IsOpen)
                    {
                        return;
                    }
                }
            }
            this._RTthread = new Thread(new ThreadStart(delegate {
                MethodInvoker method = null;
                if (this.GetRTDataSM.ConnectOBD())
                {
                    this.HasECUSelect = true;
                    MessageBox.Show("连接通道打开成功,开始获取实时数据");
                    if (this.simpleButton1.InvokeRequired)
                    {
                        if (method == null)
                        {
                            method = delegate {
                                this.simpleButton1.Tag = "开启状态";
                                this.simpleButton1.Appearance.BackColor = Color.Red;
                                this.simpleButton1.Text = "关闭实时数据通道";
                                this.IsRTDataRun = true;
                            };
                        }
                        this.simpleButton1.Invoke(method);
                    }
                    while (true)
                    {
                        while ((this.GetRTDataSM != null) && this.IsRTDataRun)
                        {
                            RTData allRTData = this.GetRTDataSM.GetAllRTData();
                            if (allRTData != null)
                            {
                                this.barStaticItem5.Caption = allRTData.FDJLQYWD;
                                this.barStaticItem6.Caption = allRTData.FDJZS;
                            }
                            Thread.Sleep(0x3e8);
                        }
                        Thread.CurrentThread.Suspend();
                    }
                }
                MessageBox.Show("连接通道打开失败,请检查串口配置");
            }));
            this._RTthread.IsBackground = true;
            this._RTthread.Start();
        }

        public void DrawPoint(int PointNO)
        {
            throw new NotImplementedException();
        }

        public void FaultConfig()
        {
            base.Invoke(new MethodInvoker(this.button1.PerformClick));
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ServerSystemInfo.ValueChangeEvent += new SocketDelegate(this.SystemInfo_ValueChangeEvent);
            this.timer1.Start();
            this.LoadState();
            PaidComm.DefaultConfig += new Action(this.FaultConfig);
            PaidComm.BackModel += new Action<int>(this.btnBack);
        }

        public Image GetScematic()
        {
            Image image = this.imageCollection1.Images["NoSchematic.png"];
            if (this._dr == null)
            {
                return image;
            }
            string str = Environment.CurrentDirectory + @"\images\Schematic\" + this._dr["schematic"].ToString();
            if (string.IsNullOrWhiteSpace(str) || !File.Exists(str))
            {
                return this.imageCollection1.Images["NoSchematic.png"];
            }
            return Image.FromFile(str);
        }

        private void HidePages()
        {
            int count = this.xtraTabbedMdiManager1.Pages.Count;
            for (int i = 0; i < count; i++)
            {
                this.xtraTabbedMdiManager1.Pages[i].MdiChild.Hide();
            }
        }

        public void LoadSkin()
        {
            SkinHelper.InitSkinGallery(this.ribbonGalleryBarItem1, false);
            StringBuilder lpReturnedString = new StringBuilder(0xff);
            SecurityHelper.GetPrivateProfileString("Skin", "name", "Pumpkin", lpReturnedString, 0xff, ServerSystemInfo.strPath);
            string skinName = (lpReturnedString.Length == 0) ? "Pumpkin" : lpReturnedString.ToString();
            UserLookAndFeel.Default.SetSkinStyle(skinName);
        }

        public void LoadState()
        {
            this.barStaticItem4.LeftIndent = (base.Width - 350) / 2;
            ServerSystemInfo.SoftModuleId = int.Parse(this._dr["Id"].ToString());
            ServerSystemInfo.SoftModuleName = this._dr["ModuleName"].ToString();
            this.labelControl1.Text = string.Format("当前模块：{0}", ServerSystemInfo.SoftModuleName);
            this.labelControl2.Text = string.Format("连接模块：{0}", ServerSystemInfo.ModuleName);
            this.barStaticItem3.Caption = string.Format("运行模式：{0}", (ServerSystemInfo.SysPattern == 0) ? "自由训练模式" : "实训考核模式");
            this.barStaticItem1.Caption = string.Format("当前登录用户：{0}", LoginInfo.UserName);
            this.barStaticItem2.Caption = string.Format("系统时间：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            this.PEschematic.Image = this.GetScematic();
            this.toggleSwitch1.IsOn = true;
        }

        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (this.PCschematic.Visible)
            {
                this.PCschematic.Hide();
                if (this.toggleSwitch1.IsOn)
                {
                    this.toggleSwitch1.IsOn = false;
                }
            }
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmManager)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmManager { MdiParent = this }.Show();
            }
        }

        private void navBarItem10_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmCheckScore)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmCheckScore { MdiParent = this }.Show();
            }
        }

        private void navBarItem11_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmModule)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmModule { MdiParent = this }.Show();
            }
        }

        private void navBarItem12_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string fileName = ConfigurationManager.AppSettings["SoftWarePath"];
            Process.Start(fileName);
            SendMessage message2 = new SendMessage {
                ClientList = TcpService.clientPool
            };
            SocketInfo info = new SocketInfo {
                Type = SocketInfoType.OpenSoftWare
            };
            message2.socketInfo = info;
            SendMessage item = message2;
            TcpService.SendMsgPool.Add(item);
        }

        private void navBarItem14_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            new FrmSetting(this.IsRTDataRun).ShowDialog(this);
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmUser)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmUser { MdiParent = this }.Show();
            }
        }

        private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmData)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmData { MdiParent = this }.Show();
            }
        }

        private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            DataTable list = this.da.GetList("select shareaddress from serverinfo where id=1");
            if ((list != null) && (list.Rows.Count != 0))
            {
                string arguments = list.Rows[0][0].ToString();
                try
                {
                    Process.Start("Explorer.exe", arguments);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("请先配置共享地址");
            }
        }

        private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmHisOscillogram)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmHisOscillogram { MdiParent = this }.Show();
            }
        }

        private void navBarItem6_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmOscillogram)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmOscillogram { MdiParent = this }.Show();
            }
        }

        private void navBarItem7_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmOperateLog)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
            }
            else
            {
                new FrmOperateLog { MdiParent = this }.Show();
            }
        }

        private void navBarItem8_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            base.Invoke(new MethodInvoker(this.button1.PerformClick));
        }

        private void navBarItem9_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.HidePages();
            XtraMdiTabPage page = (from t in this.xtraTabbedMdiManager1.Pages.Cast<XtraMdiTabPage>()
                where t.MdiChild.GetType() == typeof(FrmFault)
                select t).SingleOrDefault<XtraMdiTabPage>();
            if (page != null)
            {
                page.MdiChild.Show();
                ((FrmFault) page.MdiChild).BindData();
            }
            else
            {
                new FrmFault { MdiParent = this }.Show();
            }
        }

        public void ReadConfig()
        {
            SecurityHelper helper = new SecurityHelper();
            string strPath = ServerSystemInfo.strPath;
            try
            {
                string key = helper.ReadFile("切换板", "SerialCom", strPath);
                int num = int.Parse(helper.ReadFile("切换板", "BaudRate", strPath));
                string str3 = helper.ReadFile("设故板", "SerialCom", strPath);
                int num2 = int.Parse(helper.ReadFile("设故板", "BaudRate", strPath));
                string str4 = helper.ReadFile("实时数据", "SerialCom", strPath);
                int num3 = int.Parse(helper.ReadFile("实时数据", "BaudRate", strPath));
                SerialComConfig config = new SerialComConfig(1, new KeyValuePair<string, int>(key, num));
                config.SerialComConfigChange += new SerialComConfigDelegate(this.SerialComConfigChange_SerialComConfigChange);
                SerialComConfig config2 = new SerialComConfig(3, new KeyValuePair<string, int>(str3, num2));
                config2.SerialComConfigChange += new SerialComConfigDelegate(this.SerialComConfigChange_SerialComConfigChange);
                SerialComConfig config3 = new SerialComConfig(2, new KeyValuePair<string, int>(str4, num3));
                config3.SerialComConfigChange += new SerialComConfigDelegate(this.SerialComConfigChange_SerialComConfigChange);
                ServerSystemInfo.SerialComInfoList = new List<SerialComConfig> { config, config2, config3 };
            }
            catch
            {
                MessageBox.Show("读取配置文件错误");
            }
        }

        private void ribbonGalleryBarItem1_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            SecurityHelper.WritePrivateProfileString("Skin", "name", e.Item.Caption, ServerSystemInfo.strPath);
        }

        private void SerialComConfigChange_SerialComConfigChange(int type, object args)
        {
            Func<SerialComConfig, bool> predicate = null;
            KeyValuePair<string, int> keyvalue = (KeyValuePair<string, int>) args;
            if (type > 0)
            {
                if (predicate == null)
                {
                    predicate = t => t.SerialComInfo.Key == keyvalue.Key;
                }
                SerialComConfig config = ServerSystemInfo.SerialComInfoList.Where<SerialComConfig>(predicate).FirstOrDefault<SerialComConfig>();
                if (config != null)
                {
                    switch (config.SerialComType)
                    {
                        case 1:
                            closeMyCom(this.SwitchModuleSM);
                            break;

                        case 2:
                            closeMyCom(SysManager._comm);
                            break;

                        case 3:
                            closeMyCom(this.GetRTDataSM);
                            break;
                    }
                }
            }
            switch (type)
            {
                case -3:
                case 3:
                    closeMyCom(this.GetRTDataSM);
                    this.GetRTDataSM = new SysManager(keyvalue.Key, keyvalue.Value);
                    break;

                case -2:
                case 2:
                    closeMyCom(SysManager._comm);
                    SysManager._comm = new Communication(keyvalue.Key, keyvalue.Value);
                    return;

                case -1:
                case 1:
                    closeMyCom(this.SwitchModuleSM);
                    this.SwitchModuleSM = new SysManager(keyvalue.Key, keyvalue.Value);
                    return;

                case 0:
                    break;

                default:
                    return;
            }
        }

        public void SetPattern(int iPattern)
        {
            ServerSystemInfo.SysPatternBuff = iPattern;
        }

        public void ShowMessage(byte[] byBuff)
        {
            MessageBox.Show(byteToHexStr(byBuff));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.simpleButton1.Tag.ToString() == "开启状态")
            {
                MessageBox.Show("实时数据获取通道已关闭");
                this.IsRTDataRun = false;
                this.simpleButton1.Tag = "关闭状态";
                this.simpleButton1.Appearance.BackColor = Color.Lime;
                this.simpleButton1.Text = "开启实时数据通道";
            }
            else if (!this.HasECUSelect)
            {
                MessageBox.Show("第一次通道连接可能需要几秒钟，请稍等。");
                this.ConnectOBD();
            }
            else
            {
                MessageBox.Show("连接通道打开成功,开始获取实时数据");
                this.simpleButton1.Tag = "开启状态";
                this.simpleButton1.Appearance.BackColor = Color.Red;
                this.simpleButton1.Text = "关闭实时数据通道";
                this.IsRTDataRun = true;
                if (((this._RTthread != null) && (this._RTthread.ThreadState != System.Threading.ThreadState.Stopped)) && (this._RTthread.ThreadState != System.Threading.ThreadState.Aborted))
                {
                    this._RTthread.Resume();
                }
            }
        }

        private void SystemInfo_ValueChangeEvent(object sender, SocketEventArgs e)
        {
            MethodInvoker method = null;
            if (e._eventType == SocketInfoType.SysModule)
            {
                lock (CacheInvoke.FaultDic)
                {
                    CacheInvoke.FaultDic.Clear();
                }
                if (method == null)
                {
                    method = () => this.labelControl2.Text = string.Format("连接模块：{0}", ServerSystemInfo.ModuleName);
                }
                this.labelControl1.Invoke(method);
            }
            else if (e._eventType == SocketInfoType.SysPattern)
            {
                this.barStaticItem3.Caption = string.Format("运行模式：{0}", (int.Parse(e._value.ToString()) == 0) ? "自由训练模式" : "实训考核模式");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.barStaticItem2.Caption = string.Format("系统时间：{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            if ((DateTime.Now > (CheckInfo.PcCheckTime + TimeSpan.FromMinutes((double) ServerSystemInfo.PcTimeCount))) && CheckInfo.PcCheckState)
            {
                CheckInfo.PcCheckState = false;
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if ((sender as ToggleSwitch).IsOn)
            {
                this.PCschematic.Visible = true;
            }
            else
            {
                this.PCschematic.Hide();
            }
        }
    }
}

