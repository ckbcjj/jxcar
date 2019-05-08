using BLL.Service;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Teacher
{


    public partial class FrmChangePwd : XtraForm
    {

        public FrmChangePwd()
        {
            this.InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text)) || (string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text)))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                DataAccess access = new DataAccess();
                string str = this.textEdit1.Text.Trim();
                DataTable list = access.GetList("select count(*) from UserInfo where StudyNO='" + str + "' and StudyName='" + this.textEdit2.Text.Trim() + "' and Password='" + this.textEdit3.Text.Trim() + "'");
                if (((list == null) || (list.Rows.Count == 0)) || (list.Rows[0][0].ToString() == "0"))
                {
                    MessageBox.Show("该用户不存在");
                }
                else
                {
                    string sql = "update UserInfo set Password='" + this.textEdit4.Text.Trim() + "' where StudyNO='" + str + "'";
                    if (access.SqlCommand(sql))
                    {
                        MessageBox.Show("修改密码成功");
                    }
                    base.Close();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

