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


    public partial class FrmCheckSetting : XtraForm
    {
        private int _count;
        

        public FrmCheckSetting(int count)
        {
            this.InitializeComponent();
            this._count = count;
        }


        private void FrmCheckSetting_Load(object sender, EventArgs e)
        {
            this.spinEdit1.Text = this._count.ToString();
            this.labelControl7.Text = "考核参数设置";
            this.spinEdit2.Text = ServerSystemInfo.PcTimeCount.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ServerSystemInfo.Counts = int.Parse(this.spinEdit1.Text.ToString());
            ServerSystemInfo.PcTimeCount = int.Parse(this.spinEdit2.Text.ToString());
            ServerSystemInfo.Memo = this.memoEdit1.Text.Trim();
            ServerSystemInfo.ScorePoint = int.Parse(this.spinEdit3.Text.Trim());
            MessageBox.Show("保存成功");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.spinEdit1.Text = this._count.ToString();
            this.spinEdit2.Text = "60";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

