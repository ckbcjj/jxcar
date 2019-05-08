using BLL.Common;
using BLL.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student
{
    partial class FrmSetting
    {
        private IContainer components;

        private XtraTabControl xtraTabControl1;

        private XtraTabPage xtraTabPage2;

        private PanelControl panelControl2;

        private LabelControl labelControl8;

        private LabelControl labelControl7;

        private PanelControl panelControl5;

        private SimpleButton simpleButton1;

        private SimpleButton simpleButton3;

        private XtraTabPage xtraTabPage3;

        private LabelControl labelControl10;

        private SimpleButton simpleButton2;

        private TextEdit textEdit4;

        private LabelControl labelControl9;

        private ComboBoxEdit comboBoxEdit2;

        private ComboBoxEdit comboBoxEdit1;

        private LabelControl labelControl1;

        private LabelControl labelControl2;

        private LabelControl labelControl4;

        private ComboBoxEdit comboBoxEdit3;

        private LabelControl labelControl5;

        private ComboBoxEdit comboBoxEdit4;

        private LabelControl labelControl6;

        private LabelControl labelControl3;

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
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage2 = new XtraTabPage();
            this.panelControl2 = new PanelControl();
            this.labelControl4 = new LabelControl();
            this.comboBoxEdit3 = new ComboBoxEdit();
            this.labelControl5 = new LabelControl();
            this.comboBoxEdit4 = new ComboBoxEdit();
            this.labelControl6 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.labelControl1 = new LabelControl();
            this.comboBoxEdit2 = new ComboBoxEdit();
            this.labelControl8 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.xtraTabPage3 = new XtraTabPage();
            this.labelControl10 = new LabelControl();
            this.simpleButton2 = new SimpleButton();
            this.textEdit4 = new TextEdit();
            this.labelControl9 = new LabelControl();
            this.panelControl5 = new PanelControl();
            this.simpleButton3 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.labelControl2 = new LabelControl();
            ((ISupportInitialize)this.xtraTabControl1).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.comboBoxEdit3.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit4.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit2.Properties).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((ISupportInitialize)this.textEdit4.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl5).BeginInit();
            this.panelControl5.SuspendLayout();
            base.SuspendLayout();
            this.xtraTabControl1.Location = new Point(0, 31);
            this.xtraTabControl1.Margin = new Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new Size(346, 339);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[]
			{
				this.xtraTabPage2,
				this.xtraTabPage3
			});
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Margin = new Padding(3, 4, 3, 4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new Size(340, 306);
            this.xtraTabPage2.Text = "通信配置";
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.comboBoxEdit3);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.comboBoxEdit4);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.comboBoxEdit1);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.comboBoxEdit2);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 0);
            this.panelControl2.Margin = new Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(340, 306);
            this.panelControl2.TabIndex = 3;
            this.labelControl4.Location = new Point(223, 159);
            this.labelControl4.Margin = new Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(117, 18);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "(检测板仪表显示)";
            this.labelControl4.Visible = false;
            this.comboBoxEdit3.Location = new Point(86, 203);
            this.comboBoxEdit3.Margin = new Padding(3, 4, 3, 4);
            this.comboBoxEdit3.Name = "comboBoxEdit3";
            this.comboBoxEdit3.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit3.Properties.Items.AddRange(new object[]
			{
				"300",
				"600",
				"1200",
				"1800",
				"2400",
				"4800",
				"7200",
				"9600",
				"14400",
				"19200",
				"38400",
				"57600",
				"115200",
				"128000"
			});
            this.comboBoxEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit3.Size = new Size(114, 24);
            this.comboBoxEdit3.TabIndex = 12;
            this.comboBoxEdit3.Visible = false;
            this.labelControl5.Location = new Point(21, 207);
            this.labelControl5.Margin = new Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 18);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "波特率：";
            this.labelControl5.Visible = false;
            this.comboBoxEdit4.Location = new Point(86, 156);
            this.comboBoxEdit4.Margin = new Padding(3, 4, 3, 4);
            this.comboBoxEdit4.Name = "comboBoxEdit4";
            this.comboBoxEdit4.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit4.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit4.Size = new Size(114, 24);
            this.comboBoxEdit4.TabIndex = 10;
            this.comboBoxEdit4.Visible = false;
            this.labelControl6.Location = new Point(21, 158);
            this.labelControl6.Margin = new Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(60, 18);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "串口号：";
            this.labelControl6.Visible = false;
            this.labelControl3.Location = new Point(223, 59);
            this.labelControl3.Margin = new Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(117, 18);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "(检测板检测信号)";
            this.comboBoxEdit1.Location = new Point(86, 103);
            this.comboBoxEdit1.Margin = new Padding(3, 4, 3, 4);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[]
			{
				"300",
				"600",
				"1200",
				"1800",
				"2400",
				"4800",
				"7200",
				"9600",
				"14400",
				"19200",
				"38400",
				"57600",
				"115200",
				"128000"
			});
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(114, 24);
            this.comboBoxEdit1.TabIndex = 7;
            this.labelControl1.Location = new Point(21, 107);
            this.labelControl1.Margin = new Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(60, 18);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "波特率：";
            this.comboBoxEdit2.Location = new Point(86, 55);
            this.comboBoxEdit2.Margin = new Padding(3, 4, 3, 4);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new Size(114, 24);
            this.comboBoxEdit2.TabIndex = 5;
            this.labelControl8.Location = new Point(21, 58);
            this.labelControl8.Margin = new Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(60, 18);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "串口号：";
            this.labelControl7.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.labelControl7.Location = new Point(6, 8);
            this.labelControl7.Margin = new Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(80, 18);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "与硬件通信";
            this.xtraTabPage3.Controls.Add(this.labelControl10);
            this.xtraTabPage3.Controls.Add(this.simpleButton2);
            this.xtraTabPage3.Controls.Add(this.textEdit4);
            this.xtraTabPage3.Controls.Add(this.labelControl9);
            this.xtraTabPage3.Margin = new Padding(3, 4, 3, 4);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new Size(340, 306);
            this.xtraTabPage3.Text = "网络检查";
            this.labelControl10.Location = new Point(173, 166);
            this.labelControl10.Margin = new Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new Size(15, 18);
            this.labelControl10.TabIndex = 3;
            this.labelControl10.Text = "...";
            this.simpleButton2.Location = new Point(67, 161);
            this.simpleButton2.Margin = new Padding(3, 4, 3, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(86, 30);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "测试连接";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.textEdit4.Location = new Point(141, 71);
            this.textEdit4.Margin = new Padding(3, 4, 3, 4);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(114, 24);
            this.textEdit4.TabIndex = 1;
            this.labelControl9.Location = new Point(67, 78);
            this.labelControl9.Margin = new Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new Size(59, 18);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "IP地址：";
            this.panelControl5.Controls.Add(this.simpleButton3);
            this.panelControl5.Controls.Add(this.simpleButton1);
            this.panelControl5.Dock = DockStyle.Bottom;
            this.panelControl5.Location = new Point(0, 317);
            this.panelControl5.Margin = new Padding(3, 4, 3, 4);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(346, 53);
            this.panelControl5.TabIndex = 1;
            this.simpleButton3.Location = new Point(190, 10);
            this.simpleButton3.Margin = new Padding(3, 4, 3, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(66, 30);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "取消";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            this.simpleButton1.Location = new Point(87, 12);
            this.simpleButton1.Margin = new Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(67, 30);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "保存更改";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.labelControl2.Appearance.Font = new Font("Tahoma", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl2.Dock = DockStyle.Top;
            this.labelControl2.Location = new Point(0, 0);
            this.labelControl2.Margin = new Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(80, 23);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "参数设置";
            base.AutoScaleDimensions = new SizeF(8f, 18f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(346, 370);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.panelControl5);
            base.Controls.Add(this.xtraTabControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Margin = new Padding(3, 4, 3, 4);
            base.Name = "FrmSetting";
            this.Text = "参数设置";
            base.Load += new EventHandler(this.FrmSetting_Load);
            ((ISupportInitialize)this.xtraTabControl1).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((ISupportInitialize)this.comboBoxEdit3.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit4.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit2.Properties).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((ISupportInitialize)this.textEdit4.Properties).EndInit();
            ((ISupportInitialize)this.panelControl5).EndInit();
            this.panelControl5.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
