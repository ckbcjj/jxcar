using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Teacher
{


    public partial class FrmEditManager : XtraForm
    {
        private DataRow _dr;
        private ComboBoxEdit comboBoxEdit1;

        public FrmEditManager(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
        }

        private void FrmEditManager_Load(object sender, EventArgs e)
        {
            if (this._dr != null)
            {
                this.textEdit1.Text = this._dr["RoleName"].ToString();
                this.textEdit6.Text = this._dr["StudyNO"].ToString();
                this.textEdit3.Text = this._dr["UserName"].ToString();
                this.textEdit4.Text = this._dr["PassWord"].ToString();
                this.textEdit5.Text = this._dr["StudyName"].ToString();
                this.comboBoxEdit1.Text = this._dr["Userable"].ToString();
                if (LoginInfo.StudyNO == this._dr["StudyNO"].ToString())
                {
                    this.comboBoxEdit1.Enabled = false;
                }
                if (LoginInfo.RoleId != 0)
                {
                    this.comboBoxEdit1.Enabled = false;
                }
                this.textEdit2.Text = this._dr["mail"].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit6.Text)) || ((string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text)) || string.IsNullOrEmpty(this.textEdit5.Text)))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                string userName = this.textEdit3.Text.Trim();
                string str2 = this.textEdit4.Text.Trim();
                string str3 = this.textEdit5.Text.Trim();
                int num = (this.comboBoxEdit1.SelectedIndex == 0) ? 1 : 0;
                string input = this.textEdit2.Text.Trim();
                UserManager manager = new UserManager();
                if ((userName != this._dr["UserName"].ToString().Trim()) && manager.CheckUser(userName))
                {
                    MessageBox.Show("该用户名已存在");
                }
                else if (!Regex.IsMatch(input, @"^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$"))
                {
                    MessageBox.Show("请填写正确的邮箱");
                }
                else
                {
                    string sql = string.Concat(new object[] { "update userinfo set username='", userName, "',password='", str2, "',StudyName='", str3, "',userable=", num, ",mail='", input, "' where studyno='", this._dr["studyno"], "'" });
                    if (this.da.SqlCommand(sql))
                    {
                        string msg = string.Format("修改编号为[{0}]的用户信息成功", this._dr["StudyNO"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show(msg);
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

