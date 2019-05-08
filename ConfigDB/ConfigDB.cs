using System;
using System.Text;
using System.Windows.Forms;


namespace ConfigDB
{

    public partial class ConfigDB : Form
    {
      

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

