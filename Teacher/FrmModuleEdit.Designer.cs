using BLL.Core;
using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Teacher
{

    partial class FrmModuleEdit 
    {
        private DataRow _dr;
        private ButtonEdit buttonEdit1;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private PanelControl panelControl1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;

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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmModuleEdit));
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl5 = new LabelControl();
            this.buttonEdit1 = new ButtonEdit();
            this.labelControl4 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.buttonEdit1.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(0x55, 0x31);
            this.labelControl1.Margin = new Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x2d, 0x12);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "编号：";
            this.labelControl2.Location = new Point(0x2b, 0x66);
            this.labelControl2.Margin = new Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(90, 0x12);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "系统模块名：";
            this.labelControl3.Location = new Point(0x39, 0x9c);
            this.labelControl3.Margin = new Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x4b, 0x12);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "整车名称：";
            this.textEdit1.Location = new Point(0x8d, 0x2d);
            this.textEdit1.Margin = new Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(80, 0x18);
            this.textEdit1.TabIndex = 3;
            this.textEdit2.Location = new Point(0x8d, 0x62);
            this.textEdit2.Margin = new Padding(3, 4, 3, 4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(0xa9, 0x18);
            this.textEdit2.TabIndex = 4;
            this.textEdit3.Location = new Point(0x8d, 0x98);
            this.textEdit3.Margin = new Padding(3, 4, 3, 4);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0xa9, 0x18);
            this.textEdit3.TabIndex = 5;
            this.simpleButton1.Location = new Point(0x49, 280);
            this.simpleButton1.Margin = new Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x56, 30);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0xc1, 280);
            this.simpleButton2.Margin = new Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x56, 30);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl5.Location = new Point(0x2b, 0xce);
            this.labelControl5.Margin = new Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(90, 0x12);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "模块电路图：";
            this.buttonEdit1.EditValue = "";
            this.buttonEdit1.Location = new Point(0x8d, 0xc9);
            this.buttonEdit1.Margin = new Padding(3, 4, 3, 4);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image) manager.GetObject("buttonEdit1.Properties.Buttons"), new KeyShortcut(Keys.None), appearance, "", null, null, true) });
            this.buttonEdit1.Properties.NullText = "[EditValue is null]";
            this.buttonEdit1.Size = new Size(0xa9, 0x18);
            this.buttonEdit1.TabIndex = 11;
            this.buttonEdit1.ButtonClick += new ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            this.labelControl4.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl4.Dock = DockStyle.Top;
            this.labelControl4.Location = new Point(2, 2);
            this.labelControl4.Margin = new Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x66, 0x12);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "labelControl4";
            this.panelControl1.Appearance.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.buttonEdit1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Margin = new Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x16e, 0x163);
            this.panelControl1.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(8f, 18f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x16e, 0x163);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Margin = new Padding(3, 4, 3, 4);
            base.Name = "FrmModuleEdit";
            base.StartPosition = FormStartPosition.CenterParent;
            base.Load += new EventHandler(this.FrmModuleEdit_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.buttonEdit1.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}

