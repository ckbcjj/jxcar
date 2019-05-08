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
    partial class FrmReg 
    {
        private IContainer components;

        private TextEdit textEdit1;

        private LabelControl labelControl3;

        private LabelControl labelControl2;

        private LabelControl labelControl1;

        private ComboBoxEdit comboBoxEdit1;

        private TextEdit textEdit4;

        private LabelControl labelControl4;

        private TextEdit textEdit3;

        private TextEdit textEdit2;

        private TextEdit textEdit6;

        private LabelControl labelControl6;

        private SimpleButton simpleButton2;

        private SimpleButton simpleButton1;

        private LabelControl labelControl11;

        private LabelControl labelControl10;

        private LabelControl labelControl9;

        private LabelControl labelControl8;

        private LabelControl labelControl7;

        private PictureEdit pictureEdit1;

        private PictureEdit pictureEdit2;

        private ImageCollection imageCollection1;

        private PanelControl panelControl1;

        private LabelControl labelControl5;

        private LabelControl labelControl12;

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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmReg));
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.labelControl11 = new LabelControl();
            this.labelControl10 = new LabelControl();
            this.labelControl9 = new LabelControl();
            this.labelControl8 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.textEdit6 = new TextEdit();
            this.labelControl6 = new LabelControl();
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
            this.imageCollection1 = new ImageCollection(this.components);
            this.panelControl1 = new PanelControl();
            this.labelControl12 = new LabelControl();
            this.labelControl5 = new LabelControl();
            ((ISupportInitialize)this.textEdit6.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit4.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit3.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.pictureEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.imageCollection1).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.simpleButton2.Image = (Image)componentResourceManager.GetObject("simpleButton2.Image");
            this.simpleButton2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new Point(199, 307);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(75, 23);
            this.simpleButton2.TabIndex = 20;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image)componentResourceManager.GetObject("simpleButton1.Image");
            this.simpleButton1.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new Point(91, 307);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(75, 23);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.labelControl11.Appearance.ForeColor = Color.Red;
            this.labelControl11.Location = new Point(265, 231);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new Size(7, 14);
            this.labelControl11.TabIndex = 18;
            this.labelControl11.Text = "*";
            this.labelControl10.Appearance.ForeColor = Color.Red;
            this.labelControl10.Location = new Point(265, 187);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new Size(7, 14);
            this.labelControl10.TabIndex = 17;
            this.labelControl10.Text = "*";
            this.labelControl9.Appearance.ForeColor = Color.Red;
            this.labelControl9.Location = new Point(265, 144);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(7, 14);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "*";
            this.labelControl8.Appearance.ForeColor = Color.Red;
            this.labelControl8.Location = new Point(265, 103);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(7, 14);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "*";
            this.labelControl7.Appearance.ForeColor = Color.Red;
            this.labelControl7.Location = new Point(265, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(7, 14);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "*";
            this.textEdit6.Location = new Point(133, 230);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Size = new Size(127, 20);
            this.textEdit6.TabIndex = 13;
            this.labelControl6.Location = new Point(89, 231);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(36, 14);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "邮箱：";
            this.comboBoxEdit1.EditValue = "男";
            this.comboBoxEdit1.Location = new Point(133, 268);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[]
			{
				"男",
				"女"
			});
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(57, 20);
            this.comboBoxEdit1.TabIndex = 10;
            this.textEdit4.Location = new Point(133, 186);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(127, 20);
            this.textEdit4.TabIndex = 8;
            this.labelControl4.Location = new Point(65, 187);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "登录密码：";
            this.textEdit3.Location = new Point(133, 143);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(127, 20);
            this.textEdit3.TabIndex = 5;
            this.textEdit2.Location = new Point(133, 102);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(127, 20);
            this.textEdit2.TabIndex = 4;
            this.textEdit1.Location = new Point(133, 59);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(127, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl3.Location = new Point(77, 147);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(48, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "用户名：";
            this.labelControl2.Location = new Point(89, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "姓名：";
            this.labelControl1.Location = new Point(65, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "人员编号：";
            this.pictureEdit1.EditValue = componentResourceManager.GetObject("pictureEdit1.EditValue");
            this.pictureEdit1.Location = new Point(263, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new Size(45, 25);
            this.pictureEdit1.TabIndex = 22;
            this.pictureEdit1.Click += new EventHandler(this.pictureEdit1_Click);
            this.pictureEdit1.MouseEnter += new EventHandler(this.pictureEdit1_MouseEnter);
            this.pictureEdit1.MouseLeave += new EventHandler(this.pictureEdit1_MouseLeave);
            this.pictureEdit2.EditValue = componentResourceManager.GetObject("pictureEdit2.EditValue");
            this.pictureEdit2.Location = new Point(309, 0);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.SizeMode = PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new Size(44, 25);
            this.pictureEdit2.TabIndex = 23;
            this.pictureEdit2.Click += new EventHandler(this.pictureEdit2_Click);
            this.pictureEdit2.MouseEnter += new EventHandler(this.pictureEdit2_MouseEnter);
            this.pictureEdit2.MouseLeave += new EventHandler(this.pictureEdit2_MouseLeave);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer)componentResourceManager.GetObject("imageCollection1.ImageStream");
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
            this.panelControl1.ContentImage = (Image)componentResourceManager.GetObject("panelControl1.ContentImage");
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.pictureEdit2);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.pictureEdit1);
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
            this.panelControl1.Size = new Size(355, 354);
            this.panelControl1.TabIndex = 24;
            this.labelControl12.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl12.Dock = DockStyle.Left;
            this.labelControl12.Location = new Point(0, 0);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new Size(52, 14);
            this.labelControl12.TabIndex = 25;
            this.labelControl12.Text = "用户注册";
            this.labelControl5.Location = new Point(89, 271);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(36, 14);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "性别：";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(355, 354);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmReg";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "FrmReg";
            ((ISupportInitialize)this.textEdit6.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
            ((ISupportInitialize)this.textEdit4.Properties).EndInit();
            ((ISupportInitialize)this.textEdit3.Properties).EndInit();
            ((ISupportInitialize)this.textEdit2.Properties).EndInit();
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit1.Properties).EndInit();
            ((ISupportInitialize)this.pictureEdit2.Properties).EndInit();
            ((ISupportInitialize)this.imageCollection1).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
