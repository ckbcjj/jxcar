﻿namespace Teacher
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

    public class FrmReg : XtraForm
    {
        private ComboBoxEdit comboBoxEdit1;
        private ComboBoxEdit comboBoxEdit2;
        private IContainer components;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private LabelControl labelControl1;
        private LabelControl labelControl10;
        private LabelControl labelControl11;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private LabelControl labelControl9;
        private PanelControl panelControl1;
        private PictureEdit pictureEdit1;
        private PictureEdit pictureEdit2;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit6;

        public FrmReg()
        {
            this.InitializeComponent();
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmReg));
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.labelControl11 = new LabelControl();
            this.labelControl10 = new LabelControl();
            this.labelControl9 = new LabelControl();
            this.labelControl8 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.textEdit6 = new TextEdit();
            this.labelControl6 = new LabelControl();
            this.comboBoxEdit2 = new ComboBoxEdit();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.textEdit4 = new TextEdit();
            this.labelControl4 = new LabelControl();
            this.textEdit3 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit1 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.pictureEdit1 = new PictureEdit();
            this.pictureEdit2 = new PictureEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new PanelControl();
            this.labelControl5 = new LabelControl();
            this.textEdit6.Properties.BeginInit();
            this.comboBoxEdit2.Properties.BeginInit();
            this.comboBoxEdit1.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.pictureEdit1.Properties.BeginInit();
            this.pictureEdit2.Properties.BeginInit();
            this.imageCollection1.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.simpleButton2.Image = (Image) manager.GetObject("simpleButton2.Image");
            this.simpleButton2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new Point(0xc7, 0x121);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image) manager.GetObject("simpleButton1.Image");
            this.simpleButton1.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new Point(0x5b, 0x121);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 0x13;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.labelControl11.Appearance.ForeColor = Color.Red;
            this.labelControl11.Location = new Point(0x109, 0xea);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new Size(7, 14);
            this.labelControl11.TabIndex = 0x12;
            this.labelControl11.Text = "*";
            this.labelControl10.Appearance.ForeColor = Color.Red;
            this.labelControl10.Location = new Point(0x109, 0xbb);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new Size(7, 14);
            this.labelControl10.TabIndex = 0x11;
            this.labelControl10.Text = "*";
            this.labelControl9.Appearance.ForeColor = Color.Red;
            this.labelControl9.Location = new Point(0x109, 0x90);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(7, 14);
            this.labelControl9.TabIndex = 0x10;
            this.labelControl9.Text = "*";
            this.labelControl8.Appearance.ForeColor = Color.Red;
            this.labelControl8.Location = new Point(0x109, 0x67);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(7, 14);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "*";
            this.labelControl7.Appearance.ForeColor = Color.Red;
            this.labelControl7.Location = new Point(0x109, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(7, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "*";
            this.textEdit6.Location = new Point(0x85, 0xe9);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Size = new Size(0x7f, 20);
            this.textEdit6.TabIndex = 13;
            this.labelControl6.Location = new Point(0x59, 0xea);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x24, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "邮箱：";
            this.comboBoxEdit2.EditValue = "学生";
            this.comboBoxEdit2.Location = new Point(0x123, 0x3b);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit2.Properties.Items.AddRange(new object[] { "管理员", "教师", "学生" });
            this.comboBoxEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new Size(0x39, 20);
            this.comboBoxEdit2.TabIndex = 11;
            this.comboBoxEdit1.EditValue = "男";
            this.comboBoxEdit1.Location = new Point(0x123, 0x66);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] { "男", "女" });
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(0x39, 20);
            this.comboBoxEdit1.TabIndex = 10;
            this.textEdit4.Location = new Point(0x85, 0xba);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(0x7f, 20);
            this.textEdit4.TabIndex = 8;
            this.labelControl4.Location = new Point(0x41, 0xbb);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "登录密码：";
            this.textEdit3.Location = new Point(0x85, 0x8f);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0x7f, 20);
            this.textEdit3.TabIndex = 5;
            this.textEdit2.Location = new Point(0x85, 0x66);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(0x7f, 20);
            this.textEdit2.TabIndex = 4;
            this.textEdit1.Location = new Point(0x85, 0x3b);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(0x7f, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl3.Location = new Point(0x4d, 0x93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x30, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "用户名：";
            this.labelControl2.Location = new Point(0x59, 0x6a);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "姓名：";
            this.labelControl1.Location = new Point(0x41, 0x3f);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "人员编号：";
            this.pictureEdit1.EditValue = manager.GetObject("pictureEdit1.EditValue");
            this.pictureEdit1.Location = new Point(0x12f, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new Size(0x2d, 0x19);
            this.pictureEdit1.TabIndex = 0x16;
            this.pictureEdit1.Click += new EventHandler(this.pictureEdit1_Click);
            this.pictureEdit1.MouseEnter += new EventHandler(this.pictureEdit1_MouseEnter);
            this.pictureEdit1.MouseLeave += new EventHandler(this.pictureEdit1_MouseLeave);
            this.pictureEdit2.EditValue = manager.GetObject("pictureEdit2.EditValue");
            this.pictureEdit2.Location = new Point(0x15a, 0);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new Size(0x2c, 0x19);
            this.pictureEdit2.TabIndex = 0x17;
            this.pictureEdit2.Click += new EventHandler(this.pictureEdit2_Click);
            this.pictureEdit2.MouseEnter += new EventHandler(this.pictureEdit2_MouseEnter);
            this.pictureEdit2.MouseLeave += new EventHandler(this.pictureEdit2_MouseLeave);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) manager.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "close.png");
            this.imageCollection1.Images.SetKeyName(1, "close-01.png");
            this.imageCollection1.Images.SetKeyName(2, "lock.png");
            this.imageCollection1.Images.SetKeyName(3, "login.png");
            this.imageCollection1.Images.SetKeyName(4, "login-02.png");
            this.imageCollection1.Images.SetKeyName(5, "point_03.png");
            this.imageCollection1.Images.SetKeyName(6, "quxiao-01_03.png");
            this.imageCollection1.Images.SetKeyName(7, "quxiao-02_03.png");
            this.imageCollection1.Images.SetKeyName(8, "samll-01.png");
            this.imageCollection1.Images.SetKeyName(9, "small.png");
            this.imageCollection1.Images.SetKeyName(10, "sure-01_03.png");
            this.imageCollection1.Images.SetKeyName(11, "sure-02_03.png");
            this.imageCollection1.Images.SetKeyName(12, "user.png");
            this.imageCollection1.Images.SetKeyName(13, "zhuce.png");
            this.imageCollection1.Images.SetKeyName(14, "登录界面背景.png");
            this.imageCollection1.Images.SetKeyName(15, "注册界面背景.png");
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.ContentImage = (Image) manager.GetObject("panelControl1.ContentImage");
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.pictureEdit2);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.comboBoxEdit2);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.textEdit4);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.textEdit6);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x187, 0x162);
            this.panelControl1.TabIndex = 0x18;
            this.labelControl5.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl5.Dock = DockStyle.Left;
            this.labelControl5.Location = new Point(0, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x34, 14);
            this.labelControl5.TabIndex = 0x18;
            this.labelControl5.Text = "用户注册";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x187, 0x162);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmReg";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "FrmReg";
            this.textEdit6.Properties.EndInit();
            this.comboBoxEdit2.Properties.EndInit();
            this.comboBoxEdit1.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            this.pictureEdit1.Properties.EndInit();
            this.pictureEdit2.Properties.EndInit();
            this.imageCollection1.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
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

