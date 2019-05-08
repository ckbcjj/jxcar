using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmReg : XtraForm
    {
 
        public FrmReg()
        {
            this.InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text) || string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text))
            {
                MessageBox.Show("必填项不能为空");
                return;
            }
            string text = this.textEdit1.Text.Trim();
            string realName = this.textEdit2.Text.Trim();
            string userName = this.textEdit3.Text.Trim();
            string pwd = this.textEdit4.Text.Trim();
            string text2 = this.textEdit6.Text.Trim();
            bool isMan = this.comboBoxEdit1.SelectedIndex == 0;
            if (!Regex.IsMatch(text2, "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$"))
            {
                MessageBox.Show("请填写正确的邮箱");
                return;
            }
            UserManager userManager = new UserManager();
            if (userManager.CheckNO(text))
            {
                MessageBox.Show("该用户编号已存在");
                return;
            }
            if (userManager.CheckUser(userName))
            {
                MessageBox.Show("该用户名已存在");
                return;
            }
            if (!userManager.Registry(text, realName, isMan, userName, pwd, text2))
            {
                MessageBox.Show("信息不合法，注册失败");
            }
            else
            {
                MessageBox.Show("注册成功,可以登录");
            }
            base.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["samll-01.png"];
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small.png"];
        }

        private void pictureEdit2_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close-01.png"];
        }

        private void pictureEdit2_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close.png"];
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
