using DevExpress.XtraWaitForm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmWait : WaitForm
    {
        public enum WaitFormCommand
        {

        }

        public FrmWait()
        {
            this.InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            bool visible = (bool)arg;
            base.Visible = visible;
            base.ProcessCommand(cmd, arg);
        }
    }
}
