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
    

    public class Login : XtraForm
    {
        private SimpleButton btnReg;
        private CheckEdit checkRemenber;
        private ComboBoxEdit comboBoxEdit1;
        private IContainer components;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private LinkLabel linkLabel1;
        private PanelControl panelControl1;
        private PictureEdit pictureEdit1;
        private PictureEdit pictureEdit2;
        private PictureEdit pictureEdit3;
        private PictureEdit pictureEdit4;
        private PictureEdit pictureEdit5;
        private ComboBoxEdit selectUser;
        private TextEdit textPwd;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Login));
            this.pictureEdit2 = new PictureEdit();
            this.pictureEdit1 = new PictureEdit();
            this.checkRemenber = new CheckEdit();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.selectUser = new ComboBoxEdit();
            this.btnReg = new SimpleButton();
            this.textPwd = new TextEdit();
            this.pictureEdit3 = new PictureEdit();
            this.pictureEdit4 = new PictureEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.pictureEdit5 = new PictureEdit();
            this.panelControl1 = new PanelControl();
            this.linkLabel1 = new LinkLabel();
            this.pictureEdit2.Properties.BeginInit();
            this.pictureEdit1.Properties.BeginInit();
            this.checkRemenber.Properties.BeginInit();
            this.comboBoxEdit1.Properties.BeginInit();
            this.selectUser.Properties.BeginInit();
            this.textPwd.Properties.BeginInit();
            this.pictureEdit3.Properties.BeginInit();
            this.pictureEdit4.Properties.BeginInit();
            this.imageCollection1.BeginInit();
            this.pictureEdit5.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.pictureEdit2.EditValue = manager.GetObject("pictureEdit2.EditValue");
            this.pictureEdit2.Enabled = false;
            this.pictureEdit2.Location = new Point(0x95, 0xdb);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new Size(0x2a, 0x19);
            this.pictureEdit2.TabIndex = 10;
            this.pictureEdit1.EditValue = manager.GetObject("pictureEdit1.EditValue");
            this.pictureEdit1.Enabled = false;
            this.pictureEdit1.Location = new Point(0x95, 0xab);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new Size(0x2a, 0x1a);
            this.pictureEdit1.TabIndex = 9;
            this.checkRemenber.EditValue = true;
            this.checkRemenber.Location = new Point(0x93, 0x107);
            this.checkRemenber.Name = "checkRemenber";
            this.checkRemenber.Properties.Caption = "记住密码?";
            this.checkRemenber.Size = new Size(0x57, 0x13);
            this.checkRemenber.TabIndex = 6;
            this.comboBoxEdit1.Location = new Point(0xcf, 0xb1);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit1.Size = new Size(0x85, 20);
            this.comboBoxEdit1.TabIndex = 8;
            this.comboBoxEdit1.SelectedValueChanged += new EventHandler(this.comboBoxEdit1_SelectedValueChanged);
            this.selectUser.EditValue = "教师";
            this.selectUser.Location = new Point(0x169, 0xb1);
            this.selectUser.Name = "selectUser";
            this.selectUser.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.selectUser.Properties.Items.AddRange(new object[] { "管理员", "教师" });
            this.selectUser.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.selectUser.Size = new Size(0x40, 20);
            this.selectUser.TabIndex = 7;
            this.btnReg.Appearance.BackColor = Color.White;
            this.btnReg.Appearance.ForeColor = Color.White;
            this.btnReg.Appearance.Options.UseBackColor = true;
            this.btnReg.Appearance.Options.UseForeColor = true;
            this.btnReg.Image = (Image) manager.GetObject("btnReg.Image");
            this.btnReg.Location = new Point(0x151, 0x102);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new Size(0x58, 0x1b);
            this.btnReg.TabIndex = 5;
            this.btnReg.Click += new EventHandler(this.btnReg_Click);
            this.textPwd.Location = new Point(0xcf, 0xe0);
            this.textPwd.Name = "textPwd";
            this.textPwd.Properties.UseSystemPasswordChar = true;
            this.textPwd.Size = new Size(0x85, 20);
            this.textPwd.TabIndex = 1;
            this.pictureEdit3.EditValue = manager.GetObject("pictureEdit3.EditValue");
            this.pictureEdit3.Location = new Point(0x1eb, 4);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit3.Size = new Size(0x2e, 0x21);
            this.pictureEdit3.TabIndex = 1;
            this.pictureEdit3.Click += new EventHandler(this.pictureEdit3_Click);
            this.pictureEdit3.MouseEnter += new EventHandler(this.pictureEdit3_MouseEnter);
            this.pictureEdit3.MouseLeave += new EventHandler(this.pictureEdit3_MouseLeave);
            this.pictureEdit4.EditValue = manager.GetObject("pictureEdit4.EditValue");
            this.pictureEdit4.Location = new Point(0x21d, 4);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit4.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit4.Size = new Size(0x2e, 0x21);
            this.pictureEdit4.TabIndex = 2;
            this.pictureEdit4.Click += new EventHandler(this.pictureEdit4_Click);
            this.pictureEdit4.MouseEnter += new EventHandler(this.pictureEdit4_MouseEnter);
            this.pictureEdit4.MouseLeave += new EventHandler(this.pictureEdit4_MouseLeave);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection1.ImageStream");
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
            this.pictureEdit5.EditValue = manager.GetObject("pictureEdit5.EditValue");
            this.pictureEdit5.Location = new Point(0x95, 0x138);
            this.pictureEdit5.Name = "pictureEdit5";
            this.pictureEdit5.Size = new Size(0x114, 0x26);
            this.pictureEdit5.TabIndex = 11;
            this.pictureEdit5.Click += new EventHandler(this.pictureEdit5_Click);
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.ContentImage = (Image) manager.GetObject("panelControl1.ContentImage");
            this.panelControl1.Controls.Add(this.linkLabel1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.pictureEdit4);
            this.panelControl1.Controls.Add(this.pictureEdit5);
            this.panelControl1.Controls.Add(this.pictureEdit3);
            this.panelControl1.Controls.Add(this.btnReg);
            this.panelControl1.Controls.Add(this.pictureEdit2);
            this.panelControl1.Controls.Add(this.textPwd);
            this.panelControl1.Controls.Add(this.selectUser);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.checkRemenber);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(590, 0x1af);
            this.panelControl1.TabIndex = 12;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.Location = new Point(0x169, 0xe5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(0x37, 14);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修改密码";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(590, 0x1af);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Login";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";
            base.Load += new EventHandler(this.Login_Load);
            this.pictureEdit2.Properties.EndInit();
            this.pictureEdit1.Properties.EndInit();
            this.checkRemenber.Properties.EndInit();
            this.comboBoxEdit1.Properties.EndInit();
            this.selectUser.Properties.EndInit();
            this.textPwd.Properties.EndInit();
            this.pictureEdit3.Properties.EndInit();
            this.pictureEdit4.Properties.EndInit();
            this.imageCollection1.EndInit();
            this.pictureEdit5.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
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

