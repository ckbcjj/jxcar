using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCreate
{
    partial class FrmCreateDB
    {
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private ButtonEdit buttonEdit1;

        private IContainer components=null;

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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmCreateDB));
            SerializableAppearanceObject appearance = new SerializableAppearanceObject();
            this.labelControl2 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.textEdit2 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl4 = new LabelControl();
            this.textEdit3 = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.textEdit4 = new TextEdit();
            this.labelControl5 = new LabelControl();
            this.buttonEdit1 = new ButtonEdit();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.buttonEdit1.Properties.BeginInit();
            base.SuspendLayout();
            this.labelControl2.Location = new Point(0x42, 0x40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x30, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "登录名：";
            this.textEdit1.Location = new Point(120, 0x3d);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl3.Location = new Point(0x4e, 0x63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x24, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "密码：";
            this.textEdit2.Location = new Point(120, 0x60);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 5;
            this.simpleButton1.Location = new Point(0x35, 0xd3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0x94, 210);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "创建";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl4.Location = new Point(0x36, 0x86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "数据库名：";
            this.textEdit3.Location = new Point(120, 0x83);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(100, 20);
            this.textEdit3.TabIndex = 9;
            this.labelControl1.Location = new Point(50, 0x1c);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x40, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = " 服务器名：";
            this.textEdit4.Location = new Point(120, 0x19);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 11;
            this.labelControl5.Location = new Point(0x36, 0xac);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 14);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "备份文件：";
            this.buttonEdit1.Location = new Point(120, 0xa7);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, (Image)manager.GetObject("buttonEdit1.Properties.Buttons"), new KeyShortcut(Keys.None), appearance, "", null, null, true) });
            this.buttonEdit1.Size = new Size(100, 0x16);
            this.buttonEdit1.TabIndex = 13;
            this.buttonEdit1.ButtonClick += new ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =   System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x115, 0x110);
            base.Controls.Add(this.buttonEdit1);
            base.Controls.Add(this.labelControl5);
            base.Controls.Add(this.textEdit4);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.textEdit3);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.textEdit2);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.labelControl2);
            base.Name = "FrmCreateDB";
            this.Text = "创建数据库";
            base.Load += new EventHandler(this.FrmCreateDB_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.buttonEdit1.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
