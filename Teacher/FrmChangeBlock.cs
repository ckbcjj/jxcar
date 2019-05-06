using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Teacher
{


    public class FrmChangeBlock : SplashScreen
    {
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private MarqueeProgressBarControl marqueeProgressBarControl1;
        private PictureEdit pictureEdit1;
        private PictureEdit pictureEdit2;

        public FrmChangeBlock()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmChangeBlock));
            this.marqueeProgressBarControl1 = new MarqueeProgressBarControl();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.pictureEdit2 = new PictureEdit();
            this.pictureEdit1 = new PictureEdit();
            this.marqueeProgressBarControl1.Properties.BeginInit();
            this.pictureEdit2.Properties.BeginInit();
            this.pictureEdit1.Properties.BeginInit();
            base.SuspendLayout();
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new Point(0x17, 0xd5);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new Size(0x194, 11);
            this.marqueeProgressBarControl1.TabIndex = 5;
            this.labelControl1.BorderStyle = BorderStyles.NoBorder;
            this.labelControl1.Location = new Point(0x17, 0x108);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x83, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Copyright \x00a9 1998-2013";
            this.labelControl2.Location = new Point(0x17, 190);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x37, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Starting...";
            this.pictureEdit2.EditValue = manager.GetObject("pictureEdit2.EditValue");
            this.pictureEdit2.Location = new Point(12, 11);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Size = new Size(0x1aa, 0xa6);
            this.pictureEdit2.TabIndex = 9;
            this.pictureEdit1.EditValue = manager.GetObject("pictureEdit1.EditValue");
            this.pictureEdit1.Location = new Point(0x116, 0xf6);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Size = new Size(160, 0x2c);
            this.pictureEdit1.TabIndex = 8;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c1, 0x129);
            base.Controls.Add(this.pictureEdit2);
            base.Controls.Add(this.pictureEdit1);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.marqueeProgressBarControl1);
            base.Name = "FrmChangeBlock";
            this.Text = "Form1";
            this.marqueeProgressBarControl1.Properties.EndInit();
            this.pictureEdit2.Properties.EndInit();
            this.pictureEdit1.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        public enum SplashScreenCommand
        {
        }
    }
}

