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


    public partial class FrmEditUser : XtraForm
    {
        private DataRow _dr;
        private ComboBoxEdit comboBoxEdit2;
        
        public FrmEditUser(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            if (this._dr == null)
            {
                this.labelControl7.Text = "增加普通用户";
            }
            else
            {
                this.labelControl7.Text = "普通用户编辑";
                this.textEdit1.Text = this._dr["StudyNO"].ToString();
                this.textEdit1.Enabled = false;
                this.textEdit2.Enabled = false;
                this.textEdit2.Text = this._dr["StudyName"].ToString();
                this.textEdit3.Text = this._dr["UserName"].ToString();
                this.textEdit4.Text = this._dr["PassWord"].ToString();
                this.textEdit5.Text = this._dr["Mail"].ToString();
                if (this._dr["isman"].ToString() == "男")
                {
                    this.comboBoxEdit2.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxEdit2.SelectedIndex = 1;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UserManager manager = new UserManager();
            DataAccess access = new DataAccess();
            string studyNO = this.textEdit1.Text.ToString().Trim();
            string str2 = this.textEdit2.Text.ToString().Trim();
            string userName = this.textEdit3.Text.ToString().Trim();
            string str4 = this.textEdit4.Text.ToString().Trim();
            string input = this.textEdit5.Text.ToString().Trim();
            int num = (this.comboBoxEdit2.SelectedIndex == 0) ? 1 : 0;
            string str6 = "学生";
            int num2 = 1;
            int num3 = 2;
            string sql = null;
            if (!Regex.IsMatch(input, @"^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$"))
            {
                MessageBox.Show("请填写正确的邮箱");
            }
            else
            {
                if (this._dr == null)
                {
                    if (manager.CheckUser(userName))
                    {
                        MessageBox.Show("该用户名已存在");
                        return;
                    }
                    if (manager.CheckNO(studyNO))
                    {
                        MessageBox.Show("该用户编号已存在");
                        return;
                    }
                    if ((!string.IsNullOrEmpty(studyNO) && !string.IsNullOrEmpty(str2)) && (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(str4)))
                    {
                        sql = string.Concat(new object[] { 
                            "insert into userinfo values('", studyNO, "','", str2, "',", num, ",'", userName, "','", str4, "',", num3, ",'", str6, "','", input, 
                            "',", num2, ")"
                         });
                    }
                }
                else
                {
                    if ((userName != this._dr["UserName"].ToString().Trim()) && manager.CheckUser(userName))
                    {
                        MessageBox.Show("该用户名已存在");
                        return;
                    }
                    if ((!string.IsNullOrEmpty(studyNO) && !string.IsNullOrEmpty(str2)) && (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(str4)))
                    {
                        sql = string.Concat(new object[] { 
                            "update userinfo set username='", userName, "',password='", str4, "',mail='", input, "',isman=", num, ",roleid=", num3, ",rolename='", str6, "',userable=", num2, " where studyno='", studyNO, 
                            "'"
                         });
                    }
                }
                if (access.SqlCommand(sql))
                {
                    string msg = string.Empty;
                    if (this._dr != null)
                    {
                        msg = string.Format("修改编号为[{0}]的用户信息成功", this._dr["StudyNO"].ToString());
                    }
                    else
                    {
                        msg = string.Format("增加编号为[{0}]的用户成功", studyNO);
                    }
                    access.WriteLog(LoginInfo.UserName, msg);
                    MessageBox.Show(msg);
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

