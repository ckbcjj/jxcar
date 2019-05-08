using BLL.Common;
using BLL.Core;
using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Student
{
    public partial class Login : XtraForm
    {
        private UserManager um = new UserManager();

        private string strPath = ClientSystemInfo.strPath;

        private SynchronizationContext _context;

        public Login()
        {
            this.InitializeComponent();
            this._context = SynchronizationContext.Current;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> loginerList = this.um.GetLoginerList(this.strPath);
            if (loginerList.Count != 0)
            {
                foreach (KeyValuePair<string, string> current in loginerList)
                {
                    this.comboBoxEdit1.Properties.Items.Add(current.Key.ToString());
                }
            }
        }

        public void LoginSuccess(object obj)
        {
            Thread thread = obj as Thread;
            thread.Abort();
            FormMain formMain = new FormMain();
            base.Hide();
            formMain.Show();
        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> loginerList = this.um.GetLoginerList(this.strPath);
            string selectedText = (sender as ComboBoxEdit).SelectedText;
            if (loginerList.Keys.Contains(selectedText))
            {
                this.textPwd.Text = loginerList[selectedText];
            }
        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            string text = this.comboBoxEdit1.Text;
            string text2 = this.textPwd.Text;
            bool isRemember = this.checkRemenber.CheckState == CheckState.Checked;
            if (text == null || text2 == null)
            {
                MessageBox.Show("用户名和密码不能为空");
                return;
            }
            if (!this.um.Login(text, text2, 2, isRemember))
            {
                MessageBox.Show("输入信息不正确或未通过审核");
                return;
            }
            if (TcpClient.Connect())
            {
                FormMain formMain = new FormMain();
                formMain.Show();
                base.Hide();
                return;
            }
            if (MessageBox.Show("网络上没有服务器运行，是否重试？\n 点击是将不间断尝试和服务器建立连接；\n 点击否放弃连接。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.pictureEdit5.Enabled = false;
                this.splashScreenManager1.SplashFormLocation = new Point(base.Location.X, base.Location.Y - base.Height / 2);
                new Thread(new ThreadStart( delegate
                {
                    this.splashScreenManager1.ShowWaitForm();
                    while (!TcpClient.Connect())
                    {
                        Thread.Sleep(1000);
                    }
                    this.splashScreenManager1.CloseWaitForm();
                    MessageBox.Show("连接服务器成功");
                    this._context.Post(new SendOrPostCallback(this.LoginSuccess), Thread.CurrentThread);
                }))
                {
                    IsBackground = true,
                    Name = "ConnectServer"
                }.Start();
            }
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            FrmReg frmReg = new FrmReg();
            frmReg.ShowDialog(this);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureEdit3_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small-01.png"];
        }

        private void pictureEdit3_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["small.png"];
        }

        private void pictureEdit4_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close-01.png"];
        }

        private void pictureEdit4_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureEdit).Image = this.imageCollection1.Images["close.png"];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmChangePwd frmChangePwd = new FrmChangePwd();
            frmChangePwd.ShowDialog(this);
        }
    }
}
