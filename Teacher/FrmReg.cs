namespace Teacher
{
    using BLL.Service;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class FrmReg : XtraForm
    {

        public FrmReg()
        {
            this.InitializeComponent();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["samll-01.png"];
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small.png"];
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void pictureEdit2_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close-01.png"];
        }

        private void pictureEdit2_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close.png"];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text)) || (string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text)))
            {
                MessageBox.Show("必填项不能为空");
            }
            else
            {
                string studyNO = this.textEdit1.Text.Trim();
                string realName = this.textEdit2.Text.Trim();
                string userName = this.textEdit3.Text.Trim();
                string str4 = this.textEdit4.Text.Trim();
                string input = this.textEdit6.Text.Trim();
                int selectedIndex = this.comboBoxEdit2.SelectedIndex;
                string roleName = string.Empty;
                switch (this.comboBoxEdit2.SelectedIndex)
                {
                    case 0:
                        roleName = "管理员";
                        break;

                    case 1:
                        roleName = "教师";
                        break;

                    default:
                        roleName = "学生";
                        break;
                }
                bool isMan = this.comboBoxEdit1.SelectedIndex == 0;
                bool userable = selectedIndex == 2;
                if (!Regex.IsMatch(input, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                {
                    MessageBox.Show("请填写正确的邮箱");
                }
                else
                {
                    UserManager manager = new UserManager();
                    if (manager.CheckNO(studyNO))
                    {
                        MessageBox.Show("该用户编号已存在");
                    }
                    else if (manager.CheckUser(userName))
                    {
                        MessageBox.Show("该用户名已存在");
                    }
                    else
                    {
                        if (!manager.Registry(studyNO, realName, isMan, userName, str4, selectedIndex, roleName, input, userable))
                        {
                            MessageBox.Show("信息不合法，注册失败");
                        }
                        else if (selectedIndex == 2)
                        {
                            MessageBox.Show("注册成功,可以登录");
                        }
                        else
                        {
                            MessageBox.Show("注册成功,等待管理员审核通过方可使用");
                        }
                        base.Close();
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

