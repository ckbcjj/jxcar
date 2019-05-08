using DevExpress.XtraEditors;
using System;
using System.Drawing;

namespace ConfigDB
{
    partial class ConfigDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private DesManager des = new DesManager();
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;

        private void InitializeComponent()
        {
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl4 = new LabelControl();
            this.textEdit4 = new TextEdit();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(60, 0x62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x30, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "登录名：";
            this.labelControl2.Location = new Point(0x48, 0x87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x24, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "密码：";
            this.labelControl3.Location = new Point(0x30, 0x1b);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "服务器名：";
            this.textEdit1.Location = new Point(0x7d, 0x1b);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit2.Location = new Point(0x7d, 0x5c);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 4;
            this.textEdit3.Location = new Point(0x7d, 0x84);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(100, 20);
            this.textEdit3.TabIndex = 5;
            this.simpleButton1.Location = new Point(0x30, 0xb0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "测试连接";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(150, 0xb0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "保存更改";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl4.Location = new Point(0x30, 0x40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "数据库名：";
            this.textEdit4.Location = new Point(0x7d, 0x3d);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =   System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(0x127, 0xe0);
            base.Controls.Add(this.textEdit4);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.textEdit3);
            base.Controls.Add(this.textEdit2);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.Name = "ConfigDB";
            this.Text = "配置数据库";
            base.Load += new EventHandler(this.ConfigDB_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
