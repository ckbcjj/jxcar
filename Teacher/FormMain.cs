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


    public class FormMain : XtraForm
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
        private IContainer components;
        private DataAccess da;
        public SysManager GetRTDataSM;
        private bool HasECUSelect;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private static object InvokeLock = new object();
        public bool IsRTDataRun;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private NavBarControl navBarControl1;
        private NavBarGroup navBarGroup1;
        private NavBarGroup navBarGroup2;
        private NavBarGroup navBarGroup3;
        private NavBarGroup navBarGroup4;
        private NavBarGroup navBarGroup5;
        private NavBarItem navBarItem1;
        private NavBarItem navBarItem10;
        private NavBarItem navBarItem11;
        private NavBarItem navBarItem12;
        private NavBarItem navBarItem14;
        private NavBarItem navBarItem2;
        private NavBarItem navBarItem3;
        private NavBarItem navBarItem4;
        private NavBarItem navBarItem5;
        private NavBarItem navBarItem6;
        private NavBarItem navBarItem7;
        private NavBarItem navBarItem8;
        private NavBarItem navBarItem9;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl5;
        private PanelControl PCschematic;
        private PictureEdit PEschematic;
        private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private GridView repositoryItemGridLookUpEdit1View;
        private RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private GridView repositoryItemSearchLookUpEdit1View;
        private RibbonControl ribbonControl1;
        private RibbonGalleryBarItem ribbonGalleryBarItem1;
        private RibbonPage ribbonPage1;
        private RibbonPageGroup ribbonPageGroup1;
        private RibbonPageGroup ribbonPageGroup2;
        private RibbonPageGroup ribbonPageGroup3;
        private SimpleButton simpleButton1;
        public SysManager SwitchModuleSM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerShow = new System.Windows.Forms.Timer();
        private ToggleSwitch toggleSwitch1;
        private XtraTabbedMdiManager xtraTabbedMdiManager1;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormMain));
            this.panelControl2 = new PanelControl();
            this.simpleButton1 = new SimpleButton();
            this.ribbonControl1 = new RibbonControl();
            this.ribbonGalleryBarItem1 = new RibbonGalleryBarItem();
            this.barStaticItem5 = new BarStaticItem();
            this.barStaticItem6 = new BarStaticItem();
            this.ribbonPage1 = new RibbonPage();
            this.ribbonPageGroup1 = new RibbonPageGroup();
            this.ribbonPageGroup2 = new RibbonPageGroup();
            this.ribbonPageGroup3 = new RibbonPageGroup();
            this.repositoryItemGridLookUpEdit1 = new RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new GridView();
            this.repositoryItemSearchLookUpEdit1 = new RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new GridView();
            this.navBarControl1 = new NavBarControl();
            this.navBarGroup3 = new NavBarGroup();
            this.navBarItem9 = new NavBarItem();
            this.navBarItem11 = new NavBarItem();
            this.navBarItem8 = new NavBarItem();
            this.navBarItem10 = new NavBarItem();
            this.navBarGroup1 = new NavBarGroup();
            this.navBarItem1 = new NavBarItem();
            this.navBarItem2 = new NavBarItem();
            this.navBarGroup2 = new NavBarGroup();
            this.navBarItem3 = new NavBarItem();
            this.navBarItem5 = new NavBarItem();
            this.navBarItem6 = new NavBarItem();
            this.navBarGroup5 = new NavBarGroup();
            this.navBarItem12 = new NavBarItem();
            this.navBarGroup4 = new NavBarGroup();
            this.navBarItem14 = new NavBarItem();
            this.navBarItem4 = new NavBarItem();
            this.navBarItem7 = new NavBarItem();
            this.panelControl1 = new PanelControl();
            this.button1 = new Button();
            this.labelControl2 = new LabelControl();
            this.toggleSwitch1 = new ToggleSwitch();
            this.labelControl1 = new LabelControl();
            this.xtraTabbedMdiManager1 = new XtraTabbedMdiManager(this.components);
            this.barManager2 = new BarManager(this.components);
            this.bar3 = new Bar();
            this.barStaticItem1 = new BarStaticItem();
            this.barStaticItem2 = new BarStaticItem();
            this.bar1 = new Bar();
            this.barLargeButtonItem2 = new BarLargeButtonItem();
            this.barLargeButtonItem3 = new BarLargeButtonItem();
            this.barStaticItem4 = new BarStaticItem();
            this.barStaticItem3 = new BarStaticItem();
            this.barLargeButtonItem4 = new BarLargeButtonItem();
            this.barLargeButtonItem5 = new BarLargeButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.PCschematic = new PanelControl();
            this.panelControl5 = new PanelControl();
            this.PEschematic = new PictureEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.ribbonControl1.BeginInit();
            this.repositoryItemGridLookUpEdit1.BeginInit();
            this.repositoryItemGridLookUpEdit1View.BeginInit();
            this.repositoryItemSearchLookUpEdit1.BeginInit();
            this.repositoryItemSearchLookUpEdit1View.BeginInit();
            this.navBarControl1.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.toggleSwitch1.Properties.BeginInit();
            ((ISupportInitialize) this.xtraTabbedMdiManager1).BeginInit();
            this.barManager2.BeginInit();
            this.PCschematic.BeginInit();
            this.PCschematic.SuspendLayout();
            this.panelControl5.BeginInit();
            this.panelControl5.SuspendLayout();
            this.PEschematic.Properties.BeginInit();
            this.imageCollection1.BeginInit();
            base.SuspendLayout();
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Controls.Add(this.ribbonControl1);
            this.panelControl2.Dock = DockStyle.Top;
            this.panelControl2.Location = new Point(0, 60);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x327, 0x62);
            this.panelControl2.TabIndex = 7;
            this.simpleButton1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.simpleButton1.Appearance.BackColor = Color.Lime;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.simpleButton1.ButtonStyle = BorderStyles.Style3D;
            this.simpleButton1.Location = new Point(0x2fc, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x29, 0x57);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Tag = "关闭状态";
            this.simpleButton1.Text = "打开实时数据通道";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.ribbonControl1.AllowKeyTips = false;
            this.ribbonControl1.AllowMdiChildButtons = false;
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.AllowTrimPageText = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new BarItem[] { this.ribbonControl1.ExpandCollapseItem, this.ribbonGalleryBarItem1, this.barStaticItem5, this.barStaticItem6 });
            this.ribbonControl1.Location = new Point(2, 2);
            this.ribbonControl1.MaxItemId = 0x5c;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new RibbonPage[] { this.ribbonPage1 });
            this.ribbonControl1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemGridLookUpEdit1, this.repositoryItemSearchLookUpEdit1 });
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new Size(0x323, 0x62);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
            this.ribbonGalleryBarItem1.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.ribbonGalleryBarItem1.Gallery.ItemClick += new GalleryItemClickEventHandler(this.ribbonGalleryBarItem1_GalleryItemClick);
            this.ribbonGalleryBarItem1.Id = 0x49;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            this.barStaticItem5.Caption = "无数据";
            this.barStaticItem5.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barStaticItem5.Id = 90;
            this.barStaticItem5.ItemAppearance.Normal.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.barStaticItem5.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.RibbonStyle = RibbonItemStyles.Large;
            this.barStaticItem5.TextAlignment = StringAlignment.Near;
            this.barStaticItem6.Caption = "无数据";
            this.barStaticItem6.CategoryGuid = new Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barStaticItem6.Id = 0x5b;
            this.barStaticItem6.ItemAppearance.Normal.Font = new Font("Tahoma", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.barStaticItem6.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem6.Name = "barStaticItem6";
            this.barStaticItem6.RibbonStyle = RibbonItemStyles.Large;
            this.barStaticItem6.TextAlignment = StringAlignment.Near;
            this.ribbonPage1.Groups.AddRange(new RibbonPageGroup[] { this.ribbonPageGroup1, this.ribbonPageGroup2, this.ribbonPageGroup3 });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            this.ribbonPageGroup1.ItemLinks.Add(this.ribbonGalleryBarItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "换肤";
            this.ribbonPageGroup2.ItemLinks.Add(this.barStaticItem5);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "发动机冷却液温度";
            this.ribbonPageGroup3.ItemLinks.Add(this.barStaticItem6);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "发动机转速";
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.View = this.repositoryItemSearchLookUpEdit1View;
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.navBarControl1.ActiveGroup = this.navBarGroup3;
            this.navBarControl1.AllowDrop = false;
            this.navBarControl1.Dock = DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new NavBarGroup[] { this.navBarGroup1, this.navBarGroup2, this.navBarGroup5, this.navBarGroup3, this.navBarGroup4 });
            this.navBarControl1.Items.AddRange(new NavBarItem[] { this.navBarItem1, this.navBarItem2, this.navBarItem3, this.navBarItem5, this.navBarItem6, this.navBarItem8, this.navBarItem10, this.navBarItem14, this.navBarItem4, this.navBarItem7, this.navBarItem11, this.navBarItem9, this.navBarItem12 });
            this.navBarControl1.Location = new Point(0, 0x9e);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 0xac;
            this.navBarControl1.OptionsNavPane.ShowGroupImageInHeader = true;
            this.navBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl1.PaintStyleKind = NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new Size(0xac, 0x198);
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 3;
            this.navBarControl1.Text = "功能列表";
            this.navBarControl1.LinkClicked += new NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            this.navBarGroup3.Caption = "设故考核";
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup3.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem9), new NavBarItemLink(this.navBarItem11), new NavBarItemLink(this.navBarItem8), new NavBarItemLink(this.navBarItem10) });
            this.navBarGroup3.LargeImage = (Image) manager.GetObject("navBarGroup3.LargeImage");
            this.navBarGroup3.Name = "navBarGroup3";
            this.navBarItem9.Caption = "故障点";
            this.navBarItem9.LargeImage = (Image) manager.GetObject("navBarItem9.LargeImage");
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.LinkClicked += new NavBarLinkEventHandler(this.navBarItem9_LinkClicked);
            this.navBarItem11.Caption = "系统模块";
            this.navBarItem11.LargeImage = (Image) manager.GetObject("navBarItem11.LargeImage");
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.LinkClicked += new NavBarLinkEventHandler(this.navBarItem11_LinkClicked);
            this.navBarItem8.Caption = "设故考核";
            this.navBarItem8.LargeImage = (Image) manager.GetObject("navBarItem8.LargeImage");
            this.navBarItem8.Name = "navBarItem8";
            this.navBarItem8.LinkClicked += new NavBarLinkEventHandler(this.navBarItem8_LinkClicked);
            this.navBarItem10.Caption = "考核成绩查询";
            this.navBarItem10.LargeImage = (Image) manager.GetObject("navBarItem10.LargeImage");
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.LinkClicked += new NavBarLinkEventHandler(this.navBarItem10_LinkClicked);
            this.navBarGroup1.Caption = "用户管理";
            this.navBarGroup1.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem1), new NavBarItemLink(this.navBarItem2) });
            this.navBarGroup1.LargeImage = (Image) manager.GetObject("navBarGroup1.LargeImage");
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarItem1.Caption = "特权用户";
            this.navBarItem1.LargeImage = (Image) manager.GetObject("navBarItem1.LargeImage");
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            this.navBarItem2.Caption = "普通用户";
            this.navBarItem2.LargeImage = (Image) manager.GetObject("navBarItem2.LargeImage");
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            this.navBarGroup2.Caption = "数据显示";
            this.navBarGroup2.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem3), new NavBarItemLink(this.navBarItem5), new NavBarItemLink(this.navBarItem6) });
            this.navBarGroup2.LargeImage = (Image) manager.GetObject("navBarGroup2.LargeImage");
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.TopVisibleLinkIndex = 1;
            this.navBarGroup2.Visible = false;
            this.navBarItem3.Caption = "历史数据";
            this.navBarItem3.LargeImage = (Image) manager.GetObject("navBarItem3.LargeImage");
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.LinkClicked += new NavBarLinkEventHandler(this.navBarItem3_LinkClicked);
            this.navBarItem5.Caption = "历史波形";
            this.navBarItem5.LargeImage = (Image) manager.GetObject("navBarItem5.LargeImage");
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.LinkClicked += new NavBarLinkEventHandler(this.navBarItem5_LinkClicked);
            this.navBarItem6.Caption = "波形监控";
            this.navBarItem6.LargeImage = (Image) manager.GetObject("navBarItem6.LargeImage");
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.LinkClicked += new NavBarLinkEventHandler(this.navBarItem6_LinkClicked);
            this.navBarGroup5.Caption = "实时数据";
            this.navBarGroup5.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup5.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem12) });
            this.navBarGroup5.LargeImage = (Image) manager.GetObject("navBarGroup5.LargeImage");
            this.navBarGroup5.Name = "navBarGroup5";
            this.navBarItem12.Caption = "实时数据";
            this.navBarItem12.LargeImage = (Image) manager.GetObject("navBarItem12.LargeImage");
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.LinkClicked += new NavBarLinkEventHandler(this.navBarItem12_LinkClicked);
            this.navBarGroup4.Caption = "系统功能";
            this.navBarGroup4.GroupStyle = NavBarGroupStyle.LargeIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new NavBarItemLink[] { new NavBarItemLink(this.navBarItem14), new NavBarItemLink(this.navBarItem4), new NavBarItemLink(this.navBarItem7) });
            this.navBarGroup4.LargeImage = (Image) manager.GetObject("navBarGroup4.LargeImage");
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarItem14.Caption = "参数设置";
            this.navBarItem14.LargeImage = (Image) manager.GetObject("navBarItem14.LargeImage");
            this.navBarItem14.Name = "navBarItem14";
            this.navBarItem14.LinkClicked += new NavBarLinkEventHandler(this.navBarItem14_LinkClicked);
            this.navBarItem4.Caption = "共享资料";
            this.navBarItem4.LargeImage = (Image) manager.GetObject("navBarItem4.LargeImage");
            this.navBarItem4.Name = "navBarItem4";
            this.navBarItem4.Visible = false;
            this.navBarItem4.LinkClicked += new NavBarLinkEventHandler(this.navBarItem4_LinkClicked);
            this.navBarItem7.Caption = "操作日志";
            this.navBarItem7.LargeImage = (Image) manager.GetObject("navBarItem7.LargeImage");
            this.navBarItem7.Name = "navBarItem7";
            this.navBarItem7.LinkClicked += new NavBarLinkEventHandler(this.navBarItem7_LinkClicked);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.toggleSwitch1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0xac, 0x9e);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x27b, 40);
            this.panelControl1.TabIndex = 7;
            this.button1.BackColor = Color.Transparent;
            this.button1.ForeColor = Color.Transparent;
            this.button1.Location = new Point(-1584, 13);
            this.button1.Margin = new Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x42, 0x12);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.labelControl2.Appearance.BackColor = Color.White;
            this.labelControl2.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = Color.Red;
            this.labelControl2.Location = new Point(3, 0x15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x41, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "连接模块：";
            this.toggleSwitch1.Dock = DockStyle.Right;
            this.toggleSwitch1.EditValue = true;
            this.toggleSwitch1.Location = new Point(0x222, 2);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.AutoHeight = false;
            this.toggleSwitch1.Properties.BorderStyle = BorderStyles.Default;
            this.toggleSwitch1.Properties.GlyphAlignment = HorzAlignment.Default;
            this.toggleSwitch1.Properties.OffText = "关";
            this.toggleSwitch1.Properties.OnText = "开";
            this.toggleSwitch1.Size = new Size(0x57, 0x24);
            this.toggleSwitch1.TabIndex = 1;
            this.toggleSwitch1.Toggled += new EventHandler(this.toggleSwitch1_Toggled);
            this.labelControl1.Appearance.BackColor = Color.White;
            this.labelControl1.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = Color.Blue;
            this.labelControl1.Dock = DockStyle.Left;
            this.labelControl1.Location = new Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x41, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "当前模块：";
            this.xtraTabbedMdiManager1.HeaderButtons = TabButtons.None;
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = TabButtonShowMode.Never;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.barManager2.AllowMoveBarOnToolbar = false;
            this.barManager2.AllowQuickCustomization = false;
            this.barManager2.AllowShowToolbarsPopup = false;
            this.barManager2.Bars.AddRange(new Bar[] { this.bar3, this.bar1 });
            this.barManager2.DockControls.Add(this.barDockControlTop);
            this.barManager2.DockControls.Add(this.barDockControlBottom);
            this.barManager2.DockControls.Add(this.barDockControlLeft);
            this.barManager2.DockControls.Add(this.barDockControlRight);
            this.barManager2.Form = this;
            this.barManager2.HideBarsWhenMerging = false;
            this.barManager2.Items.AddRange(new BarItem[] { this.barStaticItem1, this.barStaticItem2, this.barStaticItem3, this.barLargeButtonItem1, this.barLargeButtonItem2, this.barLargeButtonItem3, this.barLargeButtonItem4, this.barLargeButtonItem5, this.barStaticItem4 });
            this.barManager2.MainMenu = this.bar1;
            this.barManager2.MaxItemId = 20;
            this.barManager2.MdiMenuMergeStyle = BarMdiMenuMergeStyle.Never;
            this.barManager2.StatusBar = this.bar3;
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barStaticItem1), new LinkPersistInfo(this.barStaticItem2) });
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
            this.bar1.BarName = "Custom 3";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem2, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem3, "", true, true, true, 0, null, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle | BarLinkUserDefines.Caption, this.barStaticItem4, "整车考核设故系统", true, true, true, 0, null, BarItemPaintStyle.Standard), new LinkPersistInfo(this.barStaticItem3), new LinkPersistInfo(this.barLargeButtonItem4, true), new LinkPersistInfo(this.barLargeButtonItem5, true) });
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            this.barLargeButtonItem2.Caption = "返回";
            this.barLargeButtonItem2.Glyph = (Image) manager.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 6;
            this.barLargeButtonItem2.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barLargeButtonItem3.Caption = "模块连接";
            this.barLargeButtonItem3.Glyph = (Image) manager.GetObject("barLargeButtonItem3.Glyph");
            this.barLargeButtonItem3.Id = 7;
            this.barLargeButtonItem3.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem3.LargeGlyph");
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            this.barStaticItem4.Caption = "整车考核设故系统";
            this.barStaticItem4.Id = 0x13;
            this.barStaticItem4.ItemAppearance.Normal.BackColor = Color.FromArgb(0xff, 0xff, 0x80);
            this.barStaticItem4.ItemAppearance.Normal.Font = new Font("Tahoma", 18f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.barStaticItem4.ItemAppearance.Normal.ForeColor = Color.Orange;
            this.barStaticItem4.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barStaticItem4.ItemAppearance.Normal.Options.UseBorderColor = true;
            this.barStaticItem4.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem4.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = StringAlignment.Near;
            this.barStaticItem3.Alignment = BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "当前模式：";
            this.barStaticItem3.Id = 4;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = StringAlignment.Near;
            this.barLargeButtonItem4.Caption = "最小化";
            this.barLargeButtonItem4.Glyph = (Image) manager.GetObject("barLargeButtonItem4.Glyph");
            this.barLargeButtonItem4.Id = 10;
            this.barLargeButtonItem4.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem4.LargeGlyph");
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barLargeButtonItem4.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            this.barLargeButtonItem5.Caption = "关闭";
            this.barLargeButtonItem5.Glyph = (Image) manager.GetObject("barLargeButtonItem5.Glyph");
            this.barLargeButtonItem5.Id = 11;
            this.barLargeButtonItem5.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem5.LargeGlyph");
            this.barLargeButtonItem5.Name = "barLargeButtonItem5";
            this.barLargeButtonItem5.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem5_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(0x327, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x236);
            this.barDockControlBottom.Size = new Size(0x327, 0x1b);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 0x1fa);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x327, 60);
            this.barDockControlRight.Size = new Size(0, 0x1fa);
            this.barLargeButtonItem1.Caption = "返回";
            this.barLargeButtonItem1.Id = 5;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.PCschematic.Controls.Add(this.panelControl5);
            this.PCschematic.Dock = DockStyle.Fill;
            this.PCschematic.Location = new Point(0xac, 0xc6);
            this.PCschematic.Name = "PCschematic";
            this.PCschematic.Size = new Size(0x27b, 0x170);
            this.PCschematic.TabIndex = 12;
            this.panelControl5.Controls.Add(this.PEschematic);
            this.panelControl5.Dock = DockStyle.Fill;
            this.panelControl5.Location = new Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(0x277, 0x16c);
            this.panelControl5.TabIndex = 2;
            this.PEschematic.Dock = DockStyle.Fill;
            this.PEschematic.Location = new Point(2, 2);
            this.PEschematic.MenuManager = this.barManager2;
            this.PEschematic.Name = "PEschematic";
            this.PEschematic.Properties.Appearance.BackColor = Color.White;
            this.PEschematic.Properties.Appearance.Options.UseBackColor = true;
            this.PEschematic.Properties.ShowMenu = false;
            this.PEschematic.Properties.SizeMode = PictureSizeMode.Stretch;
            this.PEschematic.Size = new Size(0x273, 360);
            this.PEschematic.TabIndex = 0;
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "NoSchematic.png");
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x327, 0x251);
            base.Controls.Add(this.PCschematic);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.navBarControl1);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.IsMdiContainer = true;
            base.Name = "FormMain";
            this.Text = "整车考核设故系统";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.FormMain_Load);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ribbonControl1.EndInit();
            this.repositoryItemGridLookUpEdit1.EndInit();
            this.repositoryItemGridLookUpEdit1View.EndInit();
            this.repositoryItemSearchLookUpEdit1.EndInit();
            this.repositoryItemSearchLookUpEdit1View.EndInit();
            this.navBarControl1.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toggleSwitch1.Properties.EndInit();
            ((ISupportInitialize) this.xtraTabbedMdiManager1).EndInit();
            this.barManager2.EndInit();
            this.PCschematic.EndInit();
            this.PCschematic.ResumeLayout(false);
            this.panelControl5.EndInit();
            this.panelControl5.ResumeLayout(false);
            this.PEschematic.Properties.EndInit();
            this.imageCollection1.EndInit();
            base.ResumeLayout(false);
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

