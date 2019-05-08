using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Teacher
{
    partial class FrmBlock 
    {

        private IContainer components;

        private PanelControl panelControl1;

        private LabelControl labelControl1;

        private SimpleButton simpleButton1;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBlock));
            this.panelControl1 = new PanelControl();
            this.labelControl1 = new LabelControl();
            this.simpleButton1 = new SimpleButton();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
            this.panelControl1.Appearance.BackColor = Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.Location = new Point(442, 150);
            this.panelControl1.LookAndFeel.SkinName = "Sharp Plus";
            this.panelControl1.Margin = new Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(649, 537);
            this.panelControl1.TabIndex = 1;
            this.labelControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.labelControl1.Appearance.Font = new Font("宋体", 24f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.labelControl1.Appearance.ForeColor = Color.Lime;
            this.labelControl1.Location = new Point(418, 15);
            this.labelControl1.Margin = new Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(410, 40);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "整车设故考核实训系统";
            this.simpleButton1.Location = new Point(734, 90);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RightToLeft = RightToLeft.No;
            this.simpleButton1.Size = new Size(195, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            base.AutoScaleDimensions = new SizeF(8f, 18f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.BackgroundImageLayoutStore = ImageLayout.Stretch;
            base.BackgroundImageStore = (Image)resources.GetObject("$this.BackgroundImageStore");
            base.ClientSize = new Size(1145, 716);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            base.FormBorderEffect = FormBorderEffect.Glow;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.LookAndFeel.SkinName = "McSkin";
            base.LookAndFeel.UseDefaultLookAndFeel = false;
            base.Margin = new Padding(3, 4, 3, 4);
            base.MaximizeBox = false;
            base.Name = "FrmBlock";
            base.StartPosition = FormStartPosition.CenterScreen;
            base.FormClosed += new FormClosedEventHandler(this.FrmBlock_FormClosed);
            base.Load += new EventHandler(this.FrmBlock_Load);
            ((ISupportInitialize)this.panelControl1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
