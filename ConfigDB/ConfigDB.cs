using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ConfigDB
{

    public class ConfigDB : Form
    {
        private IContainer components;
        private DesManager des = new DesManager();
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;

        public ConfigDB()
        {
            this.InitializeComponent();
        }

        private void ConfigDB_Load(object sender, EventArgs e)
        {
            this.simpleButton2.Enabled = false;
            string strPath = Environment.CurrentDirectory + @"\Sysconfig.ini";
            string str2 = this.ReadFile("Sql Server", "Server", strPath);
            string str3 = this.ReadFile("Sql Server", "DataBase", strPath);
            string str4 = this.ReadFile("Sql Server", "UserName", strPath);
            string str5 = string.Empty;
            try
            {
                str5 = this.ReadFile("Sql Server", "PassWord", strPath);
            }
            catch
            {
            }
            this.textEdit1.Text = str2;
            this.textEdit4.Text = str3;
            this.textEdit2.Text = str4;
            this.textEdit3.Text = str5;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl4 = new LabelControl();
            this.textEdit4 = new TextEdit();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(60, 0x62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x30, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "登录名：";
            this.labelControl2.Location = new Point(0x48, 0x87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密码：";
            this.labelControl3.Location = new Point(0x30, 0x1b);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "服务器名：";
            this.textEdit1.Location = new Point(0x7d, 0x1b);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit2.Location = new Point(0x7d, 0x5c);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 4;
            this.textEdit3.Location = new Point(0x7d, 0x84);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(100, 20);
            this.textEdit3.TabIndex = 5;
            this.simpleButton1.Location = new Point(0x30, 0xb0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(150, 0xb0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "保存更改";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl4.Location = new Point(0x30, 0x40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "数据库名：";
            this.textEdit4.Location = new Point(0x7d, 0x3d);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x127, 0xe0);
            base.Controls.Add(this.textEdit4);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.textEdit3);
            base.Controls.Add(this.textEdit2);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.Name = "ConfigDB";
            this.Text = "配置数据库";
            base.Load += new EventHandler(this.ConfigDB_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public string ReadFile(string Header, string Key, string strPath)
        {
            StringBuilder lpReturnedString = new StringBuilder(0xff);
            DesManager.GetPrivateProfileString(Header, Key, "", lpReturnedString, 0xff, strPath);
            string str = string.Empty;
            if (lpReturnedString.Length == 0)
            {
                return str;
            }
            if (Key == "PassWord")
            {
                return this.des.Decrypt(lpReturnedString.ToString(), "iloveyou");
            }
            return lpReturnedString.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text)) || string.IsNullOrEmpty(this.textEdit4.Text))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                string str = this.textEdit1.Text.Trim();
                string str2 = this.textEdit4.Text.Trim();
                string str3 = this.textEdit2.Text.Trim();
                string str4 = this.textEdit3.Text.Trim();
                DbManager manager = new DbManager("server='" + str + "';database='" + str2 + "';uid='" + str3 + "';pwd='" + str4 + "';");
                if (manager.ConnectTest())
                {
                    MessageBox.Show("连接成功");
                    this.simpleButton2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("连接失败");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string srPath = Environment.CurrentDirectory + @"\SysConfig.ini";
            this.WriteFile("Sql Server", this.textEdit1.Text, this.textEdit4.Text, this.textEdit2.Text, this.textEdit3.Text, srPath);
            base.Close();
        }

        public void WriteFile(string Header, string Server, string DataBase, string UserName, string PassWord, string srPath)
        {
            if ((UserName != null) && (PassWord != null))
            {
                new StringBuilder();
                try
                {
                    DesManager.WritePrivateProfileString("Sql Server", "Server", Server, srPath);
                    DesManager.WritePrivateProfileString("Sql Server", "DataBase", DataBase, srPath);
                    DesManager.WritePrivateProfileString("Sql Server", "UserName", UserName, srPath);
                    string lpString = this.des.Encrypt(PassWord, "iloveyou");
                    DesManager.WritePrivateProfileString("Sql Server", "PassWord", lpString, srPath);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}

