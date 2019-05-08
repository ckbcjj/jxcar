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


    public partial class FrmCreateDB : Form
    {
        
        private DbManager db;
        

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



        private void FrmCreateDB_Load(object sender, EventArgs e)
        {
            this.textEdit4.Text = ".";
            this.simpleButton2.Enabled = false;
            this.textEdit3.Enabled = false;
            this.buttonEdit1.Enabled = false;
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

