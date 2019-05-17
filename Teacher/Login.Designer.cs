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


    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.checkRemenber = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.selectUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnReg = new DevExpress.XtraEditors.SimpleButton();
            this.textPwd = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit4 = new DevExpress.XtraEditors.PictureEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.pictureEdit5 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRemenber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Enabled = false;
            this.pictureEdit2.Location = new System.Drawing.Point(149, 219);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(42, 25);
            this.pictureEdit2.TabIndex = 10;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Enabled = false;
            this.pictureEdit1.Location = new System.Drawing.Point(149, 171);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(42, 26);
            this.pictureEdit1.TabIndex = 9;
            // 
            // checkRemenber
            // 
            this.checkRemenber.EditValue = true;
            this.checkRemenber.Location = new System.Drawing.Point(147, 263);
            this.checkRemenber.Name = "checkRemenber";
            this.checkRemenber.Properties.Caption = "记住密码?";
            this.checkRemenber.Size = new System.Drawing.Size(87, 19);
            this.checkRemenber.TabIndex = 6;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(207, 177);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(133, 20);
            this.comboBoxEdit1.TabIndex = 8;
            this.comboBoxEdit1.SelectedValueChanged += new System.EventHandler(this.comboBoxEdit1_SelectedValueChanged);
            // 
            // selectUser
            // 
            this.selectUser.EditValue = "教师";
            this.selectUser.Location = new System.Drawing.Point(361, 177);
            this.selectUser.Name = "selectUser";
            this.selectUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.selectUser.Properties.Items.AddRange(new object[] {
            "管理员",
            "教师"});
            this.selectUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.selectUser.Size = new System.Drawing.Size(64, 20);
            this.selectUser.TabIndex = 7;
            // 
            // btnReg
            // 
            this.btnReg.Appearance.BackColor = System.Drawing.Color.White;
            this.btnReg.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnReg.Appearance.Options.UseBackColor = true;
            this.btnReg.Appearance.Options.UseForeColor = true;
            this.btnReg.Location = new System.Drawing.Point(337, 258);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(88, 27);
            this.btnReg.TabIndex = 5;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(207, 224);
            this.textPwd.Name = "textPwd";
            this.textPwd.Properties.UseSystemPasswordChar = true;
            this.textPwd.Size = new System.Drawing.Size(133, 20);
            this.textPwd.TabIndex = 1;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.Location = new System.Drawing.Point(491, 4);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit3.Size = new System.Drawing.Size(46, 33);
            this.pictureEdit3.TabIndex = 1;
            this.pictureEdit3.Click += new System.EventHandler(this.pictureEdit3_Click);
            this.pictureEdit3.MouseEnter += new System.EventHandler(this.pictureEdit3_MouseEnter);
            this.pictureEdit3.MouseLeave += new System.EventHandler(this.pictureEdit3_MouseLeave);
            // 
            // pictureEdit4
            // 
            this.pictureEdit4.Location = new System.Drawing.Point(541, 4);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit4.Size = new System.Drawing.Size(46, 33);
            this.pictureEdit4.TabIndex = 2;
            this.pictureEdit4.Click += new System.EventHandler(this.pictureEdit4_Click);
            this.pictureEdit4.MouseEnter += new System.EventHandler(this.pictureEdit4_MouseEnter);
            this.pictureEdit4.MouseLeave += new System.EventHandler(this.pictureEdit4_MouseLeave);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // pictureEdit5
            // 
            this.pictureEdit5.Location = new System.Drawing.Point(149, 312);
            this.pictureEdit5.Name = "pictureEdit5";
            this.pictureEdit5.Size = new System.Drawing.Size(276, 38);
            this.pictureEdit5.TabIndex = 11;
            this.pictureEdit5.Click += new System.EventHandler(this.pictureEdit5_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
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
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(590, 431);
            this.panelControl1.TabIndex = 12;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(361, 229);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 14);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修改密码";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 431);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRemenber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

