using BLL.Core;
using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Teacher
{
    

    public partial class Login : XtraForm
    {
        private UserManager um = new UserManager();

        public Login()
        {
            this.InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            new FrmReg().ShowDialog(this);
        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> loginerList = this.um.GetLoginerList(ServerSystemInfo.strPath);
            string selectedText = (sender as ComboBoxEdit).SelectedText;
            if (loginerList.Keys.Contains<string>(selectedText))
            {
                this.textPwd.Text = loginerList[selectedText];
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmChangePwd().ShowDialog(this);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> loginerList = this.um.GetLoginerList(ServerSystemInfo.strPath);
            if (loginerList.Count != 0)
            {
                foreach (KeyValuePair<string, string> pair in loginerList)
                {
                    this.comboBoxEdit1.Properties.Items.Add(pair.Key.ToString());
                }
            }
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void pictureEdit3_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small-01.png"];
        }

        private void pictureEdit3_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small.png"];
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureEdit4_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close-01.png"];
        }

        private void pictureEdit4_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close.png"];
        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            string text = this.comboBoxEdit1.Text;
            string password = this.textPwd.Text;
            int selectedIndex = this.selectUser.SelectedIndex;
            bool isRemember = this.checkRemenber.CheckState == CheckState.Checked;
            if ((text == null) || (password == null))
            {
                MessageBox.Show("用户名和密码不能为空");
            }
            else if (!this.um.Login(text, password, selectedIndex, isRemember))
            {
                MessageBox.Show("输入信息不正确或未通过审核");
            }
            else
            {
                new FrmBlock().Show();
                base.Hide();
            }
        }
    }
}

