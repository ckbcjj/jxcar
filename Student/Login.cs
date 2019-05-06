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
    public class Login : XtraForm
    {
        private UserManager um = new UserManager();

        private string strPath = ClientSystemInfo.strPath;

        private SynchronizationContext _context;

        private IContainer components;

        private TextEdit textPwd;

        private CheckEdit checkRemenber;

        private ComboBoxEdit comboBoxEdit1;

        private PictureEdit pictureEdit1;

        private PictureEdit pictureEdit2;

        private PictureEdit pictureEdit3;

        private PictureEdit pictureEdit4;

        private ImageCollection imageCollection1;

        private PictureEdit pictureEdit5;

        private PictureEdit pictureEdit6;

        private PanelControl panelControl1;

        private LinkLabel linkLabel1;

        private SplashScreenManager splashScreenManager1;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Login));
            this.checkRemenber = new CheckEdit();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.textPwd = new TextEdit();
            this.splashScreenManager1 = new SplashScreenManager(this, typeof(FrmWait), true, true);
            this.pictureEdit1 = new PictureEdit();
            this.pictureEdit2 = new PictureEdit();
            this.pictureEdit3 = new PictureEdit();
            this.pictureEdit4 = new PictureEdit();
            this.imageCollection1 = new ImageCollection(this.components);
            this.pictureEdit5 = new PictureEdit();
            this.pictureEdit6 = new PictureEdit();
            this.panelControl1 = new PanelControl();
            this.linkLabel1 = new LinkLabel();
            ((ISupportInitialize)this.checkRemenber.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.textPwd.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit3.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit4.Properties).BeginInit();
            ((ISupportInitialize)this.imageCollection1).BeginInit();
            ((ISupportInitialize)this.pictureEdit5.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit6.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.checkRemenber.EditValue = true;
            this.checkRemenber.Location = new Point(130, 235);
            this.checkRemenber.Name = "checkRemenber";
            this.checkRemenber.Properties.Caption = "记住密码?";
            this.checkRemenber.Size = new Size(87, 19);
            this.checkRemenber.TabIndex = 6;
            this.comboBoxEdit1.Location = new Point(195, 140);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit1.Size = new Size(142, 20);
            this.comboBoxEdit1.TabIndex = 8;
            this.comboBoxEdit1.SelectedValueChanged += new EventHandler(this.comboBoxEdit1_SelectedValueChanged);
            this.textPwd.Location = new Point(195, 187);
            this.textPwd.Name = "textPwd";
            this.textPwd.Properties.UseSystemPasswordChar = true;
            this.textPwd.Size = new Size(142, 20);
            this.textPwd.TabIndex = 1;
            this.pictureEdit1.EditValue = componentResourceManager.GetObject("pictureEdit1.EditValue");
            this.pictureEdit1.Enabled = false;
            this.pictureEdit1.Location = new Point(132, 134);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new Size(45, 26);
            this.pictureEdit1.TabIndex = 9;
            this.pictureEdit2.EditValue = componentResourceManager.GetObject("pictureEdit2.EditValue");
            this.pictureEdit2.Enabled = false;
            this.pictureEdit2.Location = new Point(132, 180);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new Size(45, 27);
            this.pictureEdit2.TabIndex = 10;
            this.pictureEdit3.EditValue = componentResourceManager.GetObject("pictureEdit3.EditValue");
            this.pictureEdit3.Location = new Point(390, 2);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit3.Size = new Size(40, 26);
            this.pictureEdit3.TabIndex = 11;
            this.pictureEdit3.Click += new EventHandler(this.pictureEdit3_Click);
            this.pictureEdit3.MouseEnter += new EventHandler(this.pictureEdit3_MouseEnter);
            this.pictureEdit3.MouseLeave += new EventHandler(this.pictureEdit3_MouseLeave);
            this.pictureEdit4.EditValue = componentResourceManager.GetObject("pictureEdit4.EditValue");
            this.pictureEdit4.Location = new Point(436, 2);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit4.Size = new Size(41, 26);
            this.pictureEdit4.TabIndex = 12;
            this.pictureEdit4.Click += new EventHandler(this.pictureEdit4_Click);
            this.pictureEdit4.MouseEnter += new EventHandler(this.pictureEdit4_MouseEnter);
            this.pictureEdit4.MouseLeave += new EventHandler(this.pictureEdit4_MouseLeave);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer)componentResourceManager.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "close.png");
            this.imageCollection1.Images.SetKeyName(1, "close-01.png");
            this.imageCollection1.Images.SetKeyName(2, "lock.png");
            this.imageCollection1.Images.SetKeyName(3, "login.png");
            this.imageCollection1.Images.SetKeyName(4, "login-02.png");
            this.imageCollection1.Images.SetKeyName(5, "point_03.png");
            this.imageCollection1.Images.SetKeyName(6, "quxiao-01_03.png");
            this.imageCollection1.Images.SetKeyName(7, "quxiao-02_03.png");
            this.imageCollection1.Images.SetKeyName(8, "small-01.png");
            this.imageCollection1.Images.SetKeyName(9, "small.png");
            this.imageCollection1.Images.SetKeyName(10, "sure-01_03.png");
            this.imageCollection1.Images.SetKeyName(11, "sure-02_03.png");
            this.imageCollection1.Images.SetKeyName(12, "user.png");
            this.imageCollection1.Images.SetKeyName(13, "zhuce.png");
            this.imageCollection1.Images.SetKeyName(14, "登录界面背景.png");
            this.imageCollection1.Images.SetKeyName(15, "注册界面背景.png");
            this.pictureEdit5.EditValue = componentResourceManager.GetObject("pictureEdit5.EditValue");
            this.pictureEdit5.Location = new Point(132, 276);
            this.pictureEdit5.Name = "pictureEdit5";
            this.pictureEdit5.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit5.Size = new Size(205, 35);
            this.pictureEdit5.TabIndex = 13;
            this.pictureEdit5.Click += new EventHandler(this.pictureEdit5_Click);
            this.pictureEdit6.EditValue = componentResourceManager.GetObject("pictureEdit6.EditValue");
            this.pictureEdit6.Location = new Point(237, 229);
            this.pictureEdit6.Name = "pictureEdit6";
            this.pictureEdit6.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit6.Size = new Size(100, 25);
            this.pictureEdit6.TabIndex = 14;
            this.pictureEdit6.Click += new EventHandler(this.pictureEdit6_Click);
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.ContentImage = (Image)componentResourceManager.GetObject("panelControl1.ContentImage");
            this.panelControl1.Controls.Add(this.linkLabel1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.pictureEdit4);
            this.panelControl1.Controls.Add(this.pictureEdit6);
            this.panelControl1.Controls.Add(this.pictureEdit3);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.pictureEdit5);
            this.panelControl1.Controls.Add(this.textPwd);
            this.panelControl1.Controls.Add(this.checkRemenber);
            this.panelControl1.Controls.Add(this.pictureEdit2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(479, 371);
            this.panelControl1.TabIndex = 15;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.Location = new Point(343, 190);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(55, 14);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修改密码";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(479, 371);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            base.Name = "Login";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";
            base.Load += new EventHandler(this.Login_Load);
            ((ISupportInitialize)this.checkRemenber.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
            ((ISupportInitialize)this.textPwd.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit1.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit2.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit3.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit4.Properties).EndInit();
            ((ISupportInitialize)this.imageCollection1).EndInit();
            ((ISupportInitialize)this.pictureEdit5.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit6.Properties).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
