using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Teacher
{


    public partial class FrmChangeBlock : SplashScreen
    {

        public FrmChangeBlock()
        {
            this.InitializeComponent();
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

