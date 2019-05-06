using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DBCreate
{


    public class FrmCreateDB : Form
    {
        private ButtonEdit buttonEdit1;
        private IContainer components;
        private DbManager db;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;

        public FrmCreateDB()
        {
            this.InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "备份文件|*.bak",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
                {
                    this.buttonEdit1.Text = fileName;
                }
                else
                {
                    MessageBox.Show("该文件不存在");
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmCreateDB_Load(object sender, EventArgs e)
        {
            this.textEdit4.Text = ".";
            this.simpleButton2.Enabled = false;
            this.textEdit3.Enabled = false;
            this.buttonEdit1.Enabled = false;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmCreateDB));
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            this.labelControl2 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.textEdit2 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl4 = new LabelControl();
            this.textEdit3 = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.textEdit4 = new TextEdit();
            this.labelControl5 = new LabelControl();
            this.buttonEdit1 = new ButtonEdit();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.buttonEdit1.Properties.BeginInit();
            base.SuspendLayout();
            this.labelControl2.Location = new Point(0x42, 0x40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x30, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "登录名：";
            this.textEdit1.Location = new Point(120, 0x3d);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl3.Location = new Point(0x4e, 0x63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x24, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "密码：";
            this.textEdit2.Location = new Point(120, 0x60);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 5;
            this.simpleButton1.Location = new Point(0x35, 0xd3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0x94, 210);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "创建";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl4.Location = new Point(0x36, 0x86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "数据库名：";
            this.textEdit3.Location = new Point(120, 0x83);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(100, 20);
            this.textEdit3.TabIndex = 9;
            this.labelControl1.Location = new Point(50, 0x1c);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x40, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = " 服务器名：";
            this.textEdit4.Location = new Point(120, 0x19);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 11;
            this.labelControl5.Location = new Point(0x36, 0xac);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 14);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "备份文件：";
            this.buttonEdit1.Location = new Point(120, 0xa7);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image) manager.GetObject("buttonEdit1.Properties.Buttons"), new KeyShortcut(Keys.None), appearance, "", null, null, true) });
            this.buttonEdit1.Size = new Size(100, 0x16);
            this.buttonEdit1.TabIndex = 13;
            this.buttonEdit1.ButtonClick += new ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x115, 0x110);
            base.Controls.Add(this.buttonEdit1);
            base.Controls.Add(this.labelControl5);
            base.Controls.Add(this.textEdit4);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.textEdit3);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.textEdit2);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.labelControl2);
            base.Name = "FrmCreateDB";
            this.Text = "创建数据库";
            base.Load += new EventHandler(this.FrmCreateDB_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.buttonEdit1.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text)) || string.IsNullOrEmpty(this.textEdit4.Text))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                string str = this.textEdit4.Text.Trim();
                string str2 = this.textEdit1.Text.Trim();
                string str3 = this.textEdit2.Text.Trim();
                string connStr = "server='" + str + "';database=master;uid='" + str2 + "';pwd='" + str3 + "';";
                this.db = new DbManager(connStr);
                if (this.db.ConnectTest())
                {
                    MessageBox.Show("连接成功");
                    this.simpleButton2.Enabled = true;
                    this.textEdit3.Enabled = true;
                    this.buttonEdit1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("连接失败");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit3.Text))
            {
                MessageBox.Show("数据库名不能为空");
            }
            else if (string.IsNullOrEmpty(this.buttonEdit1.Text))
            {
                MessageBox.Show("请选择要还原的备份文件");
            }
            else
            {
                string str;
                string databasename = this.textEdit3.Text.Trim();
                string databasefile = this.buttonEdit1.Text.Trim();
                if (this.db.RestoreDataBase(databasename, databasefile, out str))
                {
                    MessageBox.Show("数据库创建成功");
                    string srPath = Environment.CurrentDirectory + @"\SysConfig.ini";
                    this.WriteFile("Sql Server", this.textEdit4.Text, this.textEdit3.Text, this.textEdit1.Text, this.textEdit2.Text, srPath);
                }
                else if (!string.IsNullOrEmpty(str))
                {
                    MessageBox.Show(str);
                }
                else
                {
                    MessageBox.Show("数据库创建失败");
                }
            }
        }

        public void WriteFile(string Header, string Server, string DataBase, string UserName, string PassWord, string srPath)
        {
            if ((UserName != null) && (PassWord != null))
            {
                new StringBuilder();
                try
                {
                    DbManager.WritePrivateProfileString(Header, "Server", Server, srPath);
                    DbManager.WritePrivateProfileString(Header, "DataBase", DataBase, srPath);
                    DbManager.WritePrivateProfileString(Header, "UserName", UserName, srPath);
                    string lpString = this.db.Encrypt(PassWord, "iloveyou");
                    DbManager.WritePrivateProfileString(Header, "PassWord", lpString, srPath);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }
}

