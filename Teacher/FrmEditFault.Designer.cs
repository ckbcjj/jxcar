using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Teacher
{
    partial class FrmEditFault 
    {

        private IContainer components;

        private LabelControl labelControl1;

        private LabelControl labelControl2;

        private TextEdit textEdit1;

        private MemoEdit memoEdit1;

        private SimpleButton simpleButton1;

        private SimpleButton simpleButton2;

        private TextEdit textEdit2;

        private LabelControl labelControl3;

        private LabelControl labelControl4;

        private CheckedListBoxControl checkedListBoxControl1;

        private LabelControl labelControl5;

        private PanelControl panelControl1;

        private CheckEdit checkEdit1;

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
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.memoEdit1 = new MemoEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.textEdit2 = new TextEdit();
            this.labelControl3 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.checkedListBoxControl1 = new CheckedListBoxControl();
            this.labelControl5 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.checkEdit1 = new CheckEdit();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.memoEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.checkedListBoxControl1).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.checkEdit1.Properties).BeginInit();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(48, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "编号：";
            this.labelControl2.Location = new Point(24, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "故障点名：";
            this.textEdit1.Location = new Point(100, 48);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.memoEdit1.Location = new Point(100, 213);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new Size(173, 39);
            this.memoEdit1.TabIndex = 4;
            this.memoEdit1.UseOptimizedRendering = true;
            this.simpleButton1.Location = new Point(48, 274);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "保存";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(186, 274);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(75, 23);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.textEdit2.Location = new Point(100, 79);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(173, 20);
            this.textEdit2.TabIndex = 8;
            this.labelControl3.Location = new Point(24, 215);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "备注说明：";
            this.labelControl4.Location = new Point(24, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "可设指令：";
            this.checkedListBoxControl1.Location = new Point(100, 114);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new Size(173, 59);
            this.checkedListBoxControl1.TabIndex = 11;
            this.labelControl5.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl5.Dock = DockStyle.Top;
            this.labelControl5.Location = new Point(2, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(82, 14);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "labelControl5";
            this.panelControl1.Appearance.BackColor = Color.FromArgb(192, 255, 192);
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.checkedListBoxControl1);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.memoEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(312, 310);
            this.panelControl1.TabIndex = 13;
            this.checkEdit1.Location = new Point(100, 184);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "默认状态为断开";
            this.checkEdit1.Size = new Size(114, 19);
            this.checkEdit1.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(312, 310);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmEditFault";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "故障点编辑";
            base.Load += new EventHandler(this.FrmEditFault_Load);
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.memoEdit1.Properties).EndInit();
            ((ISupportInitialize)this.textEdit2.Properties).EndInit();
            ((ISupportInitialize)this.checkedListBoxControl1).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((ISupportInitialize)this.checkEdit1.Properties).EndInit();
            base.ResumeLayout(false);
        }
    }
}
