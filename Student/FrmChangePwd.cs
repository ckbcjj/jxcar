using BLL.Service;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmChangePwd : XtraForm
    {

        public FrmChangePwd()
        {
            this.InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text) || string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text))
            {
                MessageBox.Show("信息不能为空");
                return;
            }
            DataAccess dataAccess = new DataAccess();
            string text = this.textEdit1.Text.Trim();
            DataTable list = dataAccess.GetList(string.Concat(new string[]
			{
				"select count(*) from UserInfo where StudyNO='",
				text,
				"' and StudyName='",
				this.textEdit2.Text.Trim(),
				"' and Password='",
				this.textEdit3.Text.Trim(),
				"' and RoleId=2"
			}));
            if (list == null || list.Rows.Count == 0 || list.Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("该普通用户不存在");
                return;
            }
            string sql = string.Concat(new string[]
			{
				"update UserInfo set Password='",
				this.textEdit4.Text.Trim(),
				"' where StudyNO='",
				text,
				"'"
			});
            if (dataAccess.SqlCommand(sql))
            {
                MessageBox.Show("修改密码成功");
            }
            base.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
