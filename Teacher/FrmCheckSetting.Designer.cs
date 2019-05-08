using BLL.Core;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Teacher
{


    partial class FrmCheckSetting
    {
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private MemoEdit memoEdit1;
        private PanelControl panelControl1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SimpleButton simpleButton3;
        private SpinEdit spinEdit1;
        private SpinEdit spinEdit2;
        private SpinEdit spinEdit3;

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
            this.labelControl1 = new LabelControl();
            this.spinEdit1 = new SpinEdit();
            this.labelControl2 = new LabelControl();
            this.spinEdit2 = new SpinEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl3 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.labelControl5 = new LabelControl();
            this.memoEdit1 = new MemoEdit();
            this.labelControl6 = new LabelControl();
            this.spinEdit3 = new SpinEdit();
            this.labelControl7 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.simpleButton3 = new SimpleButton();
            this.spinEdit1.Properties.BeginInit();
            this.spinEdit2.Properties.BeginInit();
            this.memoEdit1.Properties.BeginInit();
            this.spinEdit3.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(20, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x54, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "允许答题次数：";
            int[] bits = new int[4];
            bits[0] = 1;
            this.spinEdit1.EditValue = new decimal(bits);
            this.spinEdit1.Location = new Point(110, 0x40);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            int[] numArray2 = new int[4];
            numArray2[0] = 100;
            this.spinEdit1.Properties.MaxValue = new decimal(numArray2);
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.spinEdit1.Properties.MinValue = new decimal(numArray3);
            this.spinEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.spinEdit1.Size = new Size(100, 20);
            this.spinEdit1.TabIndex = 1;
            this.labelControl2.Location = new Point(0x2c, 0x68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "答题时间：";
            int[] numArray4 = new int[4];
            numArray4[0] = 60;
            this.spinEdit2.EditValue = new decimal(numArray4);
            this.spinEdit2.Location = new Point(110, 100);
            this.spinEdit2.Name = "spinEdit2";
            this.spinEdit2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.spinEdit2.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.spinEdit2.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.spinEdit2.Properties.IsFloatValue = false;
            this.spinEdit2.Properties.Mask.EditMask = "N00";
            int[] numArray5 = new int[4];
            numArray5[0] = 200;
            this.spinEdit2.Properties.MaxValue = new decimal(numArray5);
            int[] numArray6 = new int[4];
            numArray6[0] = 1;
            this.spinEdit2.Properties.MinValue = new decimal(numArray6);
            this.spinEdit2.Size = new Size(100, 20);
            this.spinEdit2.TabIndex = 3;
            this.simpleButton1.Location = new Point(0x2d, 0xe7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(60, 0x1d);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "保存更改";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0x80, 0xe7);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(60, 0x1d);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "恢复默认";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl3.Location = new Point(0xd8, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(12, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "次";
            this.labelControl4.Location = new Point(0xd8, 0x68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x18, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "分钟";
            this.labelControl5.Location = new Point(0x2c, 0xac);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 14);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "考题提示：";
            this.memoEdit1.Location = new Point(110, 170);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new Size(160, 0x27);
            this.memoEdit1.TabIndex = 9;
            this.memoEdit1.UseOptimizedRendering = true;
            this.labelControl6.Location = new Point(0x2c, 0x8a);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(60, 14);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "每题分值：";
            int[] numArray7 = new int[4];
            numArray7[0] = 1;
            this.spinEdit3.EditValue = new decimal(numArray7);
            this.spinEdit3.Location = new Point(110, 0x87);
            this.spinEdit3.Name = "spinEdit3";
            this.spinEdit3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            int[] numArray8 = new int[4];
            numArray8[0] = 100;
            this.spinEdit3.Properties.MaxValue = new decimal(numArray8);
            int[] numArray9 = new int[4];
            numArray9[0] = 1;
            this.spinEdit3.Properties.MinValue = new decimal(numArray9);
            this.spinEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.spinEdit3.Size = new Size(100, 20);
            this.spinEdit3.TabIndex = 11;
            this.labelControl7.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl7.Dock = DockStyle.Top;
            this.labelControl7.Location = new Point(2, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x52, 14);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "labelControl7";
            this.panelControl1.Appearance.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.spinEdit1);
            this.panelControl1.Controls.Add(this.spinEdit3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.spinEdit2);
            this.panelControl1.Controls.Add(this.memoEdit1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x13f, 0x123);
            this.panelControl1.TabIndex = 13;
            this.simpleButton3.Location = new Point(210, 0xe7);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new Size(60, 0x1d);
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "取消";
            this.simpleButton3.Click += new EventHandler(this.simpleButton3_Click);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x13f, 0x123);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmCheckSetting";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "考核发题设置";
            base.Load += new EventHandler(this.FrmCheckSetting_Load);
            this.spinEdit1.Properties.EndInit();
            this.spinEdit2.Properties.EndInit();
            this.memoEdit1.Properties.EndInit();
            this.spinEdit3.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }

    }
}

