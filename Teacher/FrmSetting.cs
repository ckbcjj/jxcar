namespace Teacher
{
    using BLL.Common;
    using BLL.Core;
    using BLL.Service;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO.Ports;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public class FrmSetting : XtraForm
    {
        private bool _isRTDataRun;
        private ComboBoxEdit comboBoxEdit1;
        private ComboBoxEdit comboBoxEdit2;
        private ComboBoxEdit comboBoxEdit3;
        private ComboBoxEdit comboBoxEdit4;
        private ComboBoxEdit comboBoxEdit5;
        private ComboBoxEdit comboBoxEdit6;
        private ComboBoxEdit comboBoxEdit7;
        private IContainer components;
        private DataAccess da;
        private LabelControl labelControl1;
        private LabelControl labelControl10;
        private LabelControl labelControl11;
        private LabelControl labelControl12;
        private LabelControl labelControl13;
        private LabelControl labelControl14;
        private LabelControl labelControl15;
        private LabelControl labelControl16;
        private LabelControl labelControl17;
        private LabelControl labelControl18;
        private LabelControl labelControl19;
        private LabelControl labelControl2;
        private LabelControl labelControl20;
        private LabelControl labelControl21;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl5;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private DataTable Test;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit5;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;

        public FrmSetting(bool state)
        {
            this.InitializeComponent();
            this._isRTDataRun = state;
            this.Test = this.GetTable();
        }

        public IPStatus CheckNet(string ip)
        {
            string[] strArray = ip.Split(new char[] { '.' });
            byte[] buffer = new byte[] { byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2]), byte.Parse(strArray[3]) };
            IPAddress address = new IPAddress(buffer);
            Ping ping = new Ping();
            return ping.Send(address).Status;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            this.labelControl3.Text = (ServerSystemInfo.SysPattern == 0) ? "自由训练模式" : "实训考核模式";
            this.textEdit1.Text = this.GetIpv4().FirstOrDefault<string>();
            this.textEdit1.Enabled = false;
            if ((this.Test != null) && (this.Test.Rows.Count != 0))
            {
                this.textEdit2.Text = this.Test.Rows[0]["Port1"].ToString();
                this.textEdit5.Text = this.Test.Rows[0]["Port2"].ToString();
            }
            string[] comList = this.GetComList();
            this.comboBoxEdit1.SelectedIndex = ServerSystemInfo.SysPattern;
            this.comboBoxEdit2.Properties.Items.AddRange(comList);
            this.comboBoxEdit5.Properties.Items.AddRange(comList);
            this.comboBoxEdit7.Properties.Items.AddRange(comList);
            SerialComConfig config = null;
            SerialComConfig config2 = null;
            SerialComConfig config3 = null;
            if ((ServerSystemInfo.SerialComInfoList != null) && (ServerSystemInfo.SerialComInfoList.Count != 0))
            {
                config = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 1
                    select t).FirstOrDefault<SerialComConfig>();
                config2 = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 2
                    select t).FirstOrDefault<SerialComConfig>();
                config3 = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 3
                    select t).FirstOrDefault<SerialComConfig>();
            }
            if (config != null)
            {
                this.comboBoxEdit2.SelectedIndex = this.comboBoxEdit2.Properties.Items.IndexOf(config.SerialComInfo.Key);
                this.comboBoxEdit3.SelectedIndex = this.comboBoxEdit3.Properties.Items.IndexOf(config.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit2.SelectedItem = "COM1";
                this.comboBoxEdit3.SelectedItem = "19200";
            }
            if (config2 != null)
            {
                this.comboBoxEdit5.SelectedIndex = this.comboBoxEdit5.Properties.Items.IndexOf(config2.SerialComInfo.Key);
                this.comboBoxEdit4.SelectedIndex = this.comboBoxEdit4.Properties.Items.IndexOf(config2.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit5.SelectedItem = "COM1";
                this.comboBoxEdit4.SelectedItem = "19200";
            }
            if (config3 != null)
            {
                this.comboBoxEdit7.SelectedIndex = this.comboBoxEdit7.Properties.Items.IndexOf(config3.SerialComInfo.Key);
                this.comboBoxEdit6.SelectedIndex = this.comboBoxEdit6.Properties.Items.IndexOf(config3.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit7.SelectedItem = "COM1";
                this.comboBoxEdit6.SelectedItem = "19200";
            }
        }

        public string[] GetComList()
        {
            return SerialPort.GetPortNames();
        }

        public string[] GetIpv4()
        {
            StringCollection strings = new StringCollection();
            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    strings.Add(address.ToString());
                }
            }
            string[] array = new string[strings.Count];
            strings.CopyTo(array, 0);
            return array;
        }

        private DataTable GetTable()
        {
            this.da = new DataAccess();
            return this.da.GetList("select * from serverinfo where id=1");
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.xtraTabPage2 = new XtraTabPage();
            this.panelControl2 = new PanelControl();
            this.labelControl19 = new LabelControl();
            this.comboBoxEdit6 = new ComboBoxEdit();
            this.labelControl20 = new LabelControl();
            this.comboBoxEdit7 = new ComboBoxEdit();
            this.labelControl21 = new LabelControl();
            this.labelControl16 = new LabelControl();
            this.comboBoxEdit4 = new ComboBoxEdit();
            this.labelControl17 = new LabelControl();
            this.comboBoxEdit5 = new ComboBoxEdit();
            this.labelControl18 = new LabelControl();
            this.labelControl15 = new LabelControl();
            this.comboBoxEdit3 = new ComboBoxEdit();
            this.labelControl13 = new LabelControl();
            this.comboBoxEdit2 = new ComboBoxEdit();
            this.labelControl8 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.textEdit5 = new TextEdit();
            this.labelControl12 = new LabelControl();
            this.textEdit2 = new TextEdit();
            this.textEdit1 = new TextEdit();
            this.labelControl6 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.xtraTabPage3 = new XtraTabPage();
            this.labelControl10 = new LabelControl();
            this.simpleButton2 = new SimpleButton();
            this.textEdit4 = new TextEdit();
            this.labelControl9 = new LabelControl();
            this.xtraTabPage4 = new XtraTabPage();
            this.textEdit3 = new TextEdit();
            this.labelControl11 = new LabelControl();
            this.panelControl5 = new PanelControl();
            this.simpleButton3 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.labelControl14 = new LabelControl();
            this.panelControl3 = new PanelControl();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.comboBoxEdit1.Properties.BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.comboBoxEdit6.Properties.BeginInit();
            this.comboBoxEdit7.Properties.BeginInit();
            this.comboBoxEdit4.Properties.BeginInit();
            this.comboBoxEdit5.Properties.BeginInit();
            this.comboBoxEdit3.Properties.BeginInit();
            this.comboBoxEdit2.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.textEdit5.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.textEdit4.Properties.BeginInit();
            this.xtraTabPage4.SuspendLayout();
            this.textEdit3.Properties.BeginInit();
            this.panelControl5.BeginInit();
            this.panelControl5.SuspendLayout();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            base.SuspendLayout();
            this.xtraTabControl1.Location = new Point(0, 0x1c);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(330, 0x107);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4 });
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.comboBoxEdit1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new Size(0x144, 0xea);
            this.xtraTabPage1.Text = "运行模式";
            this.labelControl3.Location = new Point(0x81, 0x43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(12, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "...";
            this.labelControl2.Location = new Point(0x26, 0x44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x54, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "当前运行模式：";
            this.labelControl1.Location = new Point(0x26, 0x76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x54, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "切换运行模式：";
            this.comboBoxEdit1.EditValue = "自由训练模式";
            this.comboBoxEdit1.Location = new Point(0x81, 0x74);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] { "自由训练模式", "实训考核模式" });
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(100, 20);
            this.comboBoxEdit1.TabIndex = 0;
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Controls.Add(this.panelControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(0x144, 0xea);
            this.xtraTabPage2.Text = "通信配置";
            this.panelControl2.Controls.Add(this.labelControl19);
            this.panelControl2.Controls.Add(this.comboBoxEdit6);
            this.panelControl2.Controls.Add(this.labelControl20);
            this.panelControl2.Controls.Add(this.comboBoxEdit7);
            this.panelControl2.Controls.Add(this.labelControl21);
            this.panelControl2.Controls.Add(this.labelControl16);
            this.panelControl2.Controls.Add(this.comboBoxEdit4);
            this.panelControl2.Controls.Add(this.labelControl17);
            this.panelControl2.Controls.Add(this.comboBoxEdit5);
            this.panelControl2.Controls.Add(this.labelControl18);
            this.panelControl2.Controls.Add(this.labelControl15);
            this.panelControl2.Controls.Add(this.comboBoxEdit3);
            this.panelControl2.Controls.Add(this.labelControl13);
            this.panelControl2.Controls.Add(this.comboBoxEdit2);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 0x76);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x144, 0x74);
            this.panelControl2.TabIndex = 3;
            this.labelControl19.Location = new Point(0x106, 0x54);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new Size(0x41, 14);
            this.labelControl19.TabIndex = 0x12;
            this.labelControl19.Text = "(实时数据）";
            this.comboBoxEdit6.Location = new Point(0xb5, 0x52);
            this.comboBoxEdit6.Name = "comboBoxEdit6";
            this.comboBoxEdit6.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit6.Properties.Items.AddRange(new object[] { "300", "600", "1200", "1800", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000" });
            this.comboBoxEdit6.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit6.Size = new Size(0x4a, 20);
            this.comboBoxEdit6.TabIndex = 0x11;
            this.labelControl20.Location = new Point(130, 0x54);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new Size(0x30, 14);
            this.labelControl20.TabIndex = 0x10;
            this.labelControl20.Text = "波特率：";
            this.comboBoxEdit7.Location = new Point(0x33, 0x51);
            this.comboBoxEdit7.Name = "comboBoxEdit7";
            this.comboBoxEdit7.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit7.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit7.Size = new Size(0x47, 20);
            this.comboBoxEdit7.TabIndex = 15;
            this.labelControl21.Location = new Point(7, 0x53);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new Size(0x30, 14);
            this.labelControl21.TabIndex = 14;
            this.labelControl21.Text = "串口号：";
            this.labelControl16.Location = new Point(0x106, 0x3a);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new Size(0x2e, 14);
            this.labelControl16.TabIndex = 13;
            this.labelControl16.Text = "(设故板)";
            this.comboBoxEdit4.Location = new Point(0xb5, 0x38);
            this.comboBoxEdit4.Name = "comboBoxEdit4";
            this.comboBoxEdit4.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit4.Properties.Items.AddRange(new object[] { "300", "600", "1200", "1800", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000" });
            this.comboBoxEdit4.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit4.Size = new Size(0x4a, 20);
            this.comboBoxEdit4.TabIndex = 12;
            this.labelControl17.Location = new Point(130, 0x3a);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new Size(0x30, 14);
            this.labelControl17.TabIndex = 11;
            this.labelControl17.Text = "波特率：";
            this.comboBoxEdit5.Location = new Point(0x33, 0x37);
            this.comboBoxEdit5.Name = "comboBoxEdit5";
            this.comboBoxEdit5.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit5.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit5.Size = new Size(0x47, 20);
            this.comboBoxEdit5.TabIndex = 10;
            this.labelControl18.Location = new Point(7, 0x39);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new Size(0x30, 14);
            this.labelControl18.TabIndex = 9;
            this.labelControl18.Text = "串口号：";
            this.labelControl15.Location = new Point(0x105, 30);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new Size(0x2e, 14);
            this.labelControl15.TabIndex = 8;
            this.labelControl15.Text = "(切换板)";
            this.comboBoxEdit3.Location = new Point(180, 0x1b);
            this.comboBoxEdit3.Name = "comboBoxEdit3";
            this.comboBoxEdit3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit3.Properties.Items.AddRange(new object[] { "300", "600", "1200", "1800", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "128000" });
            this.comboBoxEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit3.Size = new Size(0x4b, 20);
            this.comboBoxEdit3.TabIndex = 7;
            this.labelControl13.Location = new Point(0x81, 0x1d);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new Size(0x30, 14);
            this.labelControl13.TabIndex = 6;
            this.labelControl13.Text = "波特率：";
            this.comboBoxEdit2.Location = new Point(0x33, 0x1a);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new Size(0x47, 20);
            this.comboBoxEdit2.TabIndex = 5;
            this.labelControl8.Location = new Point(6, 0x1c);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(0x30, 14);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "串口号：";
            this.labelControl7.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl7.Location = new Point(5, 6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x41, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "与硬件通信";
            this.panelControl1.Controls.Add(this.textEdit5);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x144, 0x76);
            this.panelControl1.TabIndex = 2;
            this.textEdit5.Location = new Point(0x7d, 0x54);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Size = new Size(100, 20);
            this.textEdit5.TabIndex = 6;
            this.labelControl12.Location = new Point(0x20, 0x57);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new Size(0x54, 14);
            this.labelControl12.TabIndex = 5;
            this.labelControl12.Text = "平板通信端口：";
            this.textEdit2.Location = new Point(0x7d, 0x38);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 4;
            this.textEdit1.Location = new Point(0x7d, 0x19);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl6.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl6.Location = new Point(6, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x4e, 14);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "与客户端通信";
            this.labelControl4.Location = new Point(0x2d, 0x1f);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x47, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "本机IP地址：";
            this.labelControl5.Location = new Point(20, 0x3b);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x60, 14);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "工位机通信端口：";
            this.xtraTabPage3.Controls.Add(this.labelControl10);
            this.xtraTabPage3.Controls.Add(this.simpleButton2);
            this.xtraTabPage3.Controls.Add(this.textEdit4);
            this.xtraTabPage3.Controls.Add(this.labelControl9);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(0x144, 0xea);
            this.xtraTabPage3.Text = "网络检查";
            this.labelControl10.Location = new Point(0x97, 0x81);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new Size(12, 14);
            this.labelControl10.TabIndex = 3;
            this.labelControl10.Text = "...";
            this.simpleButton2.Location = new Point(0x3b, 0x7d);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "测试连接";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.textEdit4.Location = new Point(0x7b, 0x37);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 1;
            this.labelControl9.Location = new Point(0x3b, 0x3d);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(0x2f, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "IP地址：";
            this.xtraTabPage4.Controls.Add(this.textEdit3);
            this.xtraTabPage4.Controls.Add(this.labelControl11);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.PageVisible = false;
            this.xtraTabPage4.Size = new Size(0x144, 0xea);
            this.xtraTabPage4.Text = "共享设置";
            this.textEdit3.Location = new Point(0x38, 110);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0xa7, 20);
            this.textEdit3.TabIndex = 1;
            this.labelControl11.Location = new Point(0x38, 0x4b);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new Size(60, 14);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "共享地址：";
            this.panelControl5.Controls.Add(this.simpleButton3);
            this.panelControl5.Controls.Add(this.simpleButton1);
            this.panelControl5.Dock = DockStyle.Bottom;
            this.panelControl5.Location = new Point(2, 0x125);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(0x146, 0x24);
            this.panelControl5.TabIndex = 1;
            this.simpleButton3.Location = new Point(0xa6, 3);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(0x43, 30);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "取消";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButton1.Location = new Point(0x4c, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x45, 30);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "保存更改";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.labelControl14.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl14.Dock = DockStyle.Top;
            this.labelControl14.Location = new Point(2, 2);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new Size(0x34, 14);
            this.labelControl14.TabIndex = 2;
            this.labelControl14.Text = "参数设置";
            this.panelControl3.Appearance.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = BorderStyles.Style3D;
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Controls.Add(this.labelControl14);
            this.panelControl3.Controls.Add(this.xtraTabControl1);
            this.panelControl3.Dock = DockStyle.Fill;
            this.panelControl3.Location = new Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(330, 0x14b);
            this.panelControl3.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(330, 0x14b);
            base.Controls.Add(this.panelControl3);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmSetting";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "参数设置";
            base.Load += new EventHandler(this.FrmSetting_Load);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.comboBoxEdit1.Properties.EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.comboBoxEdit6.Properties.EndInit();
            this.comboBoxEdit7.Properties.EndInit();
            this.comboBoxEdit4.Properties.EndInit();
            this.comboBoxEdit5.Properties.EndInit();
            this.comboBoxEdit3.Properties.EndInit();
            this.comboBoxEdit2.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.textEdit5.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            this.textEdit4.Properties.EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            this.textEdit3.Properties.EndInit();
            this.panelControl5.EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.comboBoxEdit2.SelectedItem.ToString();
                int num = int.Parse(this.comboBoxEdit3.SelectedItem.ToString().Trim());
                string str2 = this.comboBoxEdit5.SelectedItem.ToString();
                int num2 = int.Parse(this.comboBoxEdit4.SelectedItem.ToString().Trim());
                string str3 = this.comboBoxEdit7.SelectedItem.ToString();
                int num3 = int.Parse(this.comboBoxEdit6.SelectedItem.ToString().Trim());
                if (((str == str2) || (str2 == str3)) || (str == str3))
                {
                    MessageBox.Show("请选择正确的串口");
                }
                else
                {
                    if (this._isRTDataRun)
                    {
                        SerialComConfig config = (from t in ServerSystemInfo.SerialComInfoList
                            where t.SerialComType == 3
                            select t).FirstOrDefault<SerialComConfig>();
                        if ((config != null) && ((config.SerialComInfo.Key != str3) || (config.SerialComInfo.Value != num3)))
                        {
                            MessageBox.Show("实时数据正在获取中,不能更改相应的串口通信配置");
                            return;
                        }
                    }
                    if (CheckInfo.PcCheckState && (this.comboBoxEdit1.SelectedIndex == 1))
                    {
                        MessageBox.Show("考核过程中不能切换为自由训练模式");
                    }
                    else
                    {
                        string str4 = this.textEdit1.Text.Trim();
                        string str5 = this.textEdit3.Text.Trim();
                        int num4 = Convert.ToInt32(this.textEdit2.Text.Trim());
                        int num5 = Convert.ToInt32(this.textEdit5.Text.Trim());
                        ServerSystemInfo.SysPatternBuff = this.comboBoxEdit1.SelectedIndex;
                        string sql = null;
                        if ((this.Test != null) && (this.Test.Rows.Count != 0))
                        {
                            sql = string.Concat(new object[] { "update serverinfo set ip='", str4, "',port1=", num4, ",port2=", num5 });
                            if (!string.IsNullOrWhiteSpace(str5))
                            {
                                sql = sql + ",shareaddress='" + str5 + "'";
                            }
                            sql = sql + " where id=1";
                        }
                        else
                        {
                            sql = string.Concat(new object[] { "insert into serverinfo values('", str4, "',", num4, ",", num5, "," });
                            if (!string.IsNullOrWhiteSpace(str5))
                            {
                                sql = sql + "'" + str5 + "',";
                            }
                            else
                            {
                                sql = sql + "null,";
                            }
                            sql = sql + "null)";
                        }
                        if (this.da.SqlCommand(sql))
                        {
                            SecurityHelper helper = new SecurityHelper();
                            string strPath = ServerSystemInfo.strPath;
                            helper.WriteFile("切换板", "SerialCom", str, strPath);
                            helper.WriteFile("切换板", "BaudRate", num.ToString(), strPath);
                            helper.WriteFile("设故板", "SerialCom", str2, strPath);
                            helper.WriteFile("设故板", "BaudRate", num2.ToString(), strPath);
                            helper.WriteFile("实时数据", "SerialCom", str3, strPath);
                            helper.WriteFile("实时数据", "BaudRate", num3.ToString(), strPath);
                            if ((ServerSystemInfo.SerialComInfoList != null) && (ServerSystemInfo.SerialComInfoList.Count != 0))
                            {
                                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(str, num);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 1
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair;
                                KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>(str2, num2);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 2
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair2;
                                KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>(str3, num3);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 3
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair3;
                            }
                            MessageBox.Show("信息保存成功！");
                            if ((this.textEdit2.Text.Trim() != this.Test.Rows[0]["Port1"].ToString()) || (this.textEdit5.Text.Trim() != this.Test.Rows[0]["Port2"].ToString()))
                            {
                                MessageBox.Show("通信端口已更改,需重启服务器才能生效");
                            }
                            base.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("请输入合法参数");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string input = this.textEdit4.Text.Trim();
            if (!Regex.IsMatch(input, @"^(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$"))
            {
                MessageBox.Show("请输入合法的ip地址");
            }
            else
            {
                switch (this.CheckNet(input))
                {
                    case IPStatus.DestinationNetworkUnreachable:
                        this.labelControl10.Text = "无法访问目标计算机的网络";
                        return;

                    case IPStatus.DestinationHostUnreachable:
                        this.labelControl10.Text = "无法访问目标主机";
                        return;

                    case IPStatus.DestinationProtocolUnreachable:
                        this.labelControl10.Text = "目标管理员已禁止访问主机";
                        return;

                    case IPStatus.TimedOut:
                        this.labelControl10.Text = "请求超时";
                        return;

                    case IPStatus.Success:
                        this.labelControl10.Text = "连接成功";
                        return;
                }
                this.labelControl10.Text = "连接失败";
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

