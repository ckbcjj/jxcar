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
    public class FrmBlock : XtraForm
    {
        public static IntPtr NavHandle;

        public static IntPtr Mainhandle;

        private Dictionary<int, int> dicA = new Dictionary<int, int>();

        private Timer timer1 = new Timer();

        private IContainer components;

        private PanelControl panelControl1;

        private LabelControl labelControl1;

        private SimpleButton simpleButton1;

        public FrmBlock()
        {
            this.InitializeComponent();
            this.BindData();
        }

        private void FrmBlock_Load(object sender, EventArgs e)
        {
            PaidComm.ChangeModle += new Action<int>(this.btnClick);
            this.dicA.Add(1, 2);
            this.dicA.Add(2, 2);
            this.dicA.Add(3, 2);
            this.dicA.Add(4, 1);
        }

        public void BindData()
        {
            DataAccess da = new DataAccess();
            DataTable dt = da.GetList("select * from sysmodule");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SimpleButton sb = new SimpleButton();
                    sb.Text = dt.Rows[i]["modulename"].ToString();
                    sb.Tag = dt.Rows[i];
                    sb.Name = i.ToString();
                    sb.Click += new EventHandler(this.sb_Click);
                    sb.Width = 270;
                    sb.Height = 30;
                    int j = 8;
                    float a = (float)((this.panelControl1.Width - 2 * j - 2 * sb.Width) / 2);
                    float b = (float)((this.panelControl1.Height - sb.Height * 10 - 2 * j) / 10);
                    if (i < 10)
                    {
                        PointF p = new PointF((float)j, (float)i * ((float)sb.Height + b) + (float)j);
                        sb.Location = Point.Round(p);
                    }
                    else
                    {
                        PointF p2 = new PointF(2f * a + (float)j + (float)sb.Width, (float)(i - 10) * ((float)sb.Height + b) + (float)j);
                        sb.Location = Point.Round(p2);
                    }
                    this.panelControl1.Controls.Add(sb);
                }
            }
        }

        private void sb_Click(object sender, EventArgs e)
        {
            DataRow dr = (DataRow)(sender as SimpleButton).Tag;
            if (FrmBlock.Mainhandle != IntPtr.Zero)
            {
                FormMain fm = (FormMain)Control.FromHandle(FrmBlock.Mainhandle);
                fm._dr = dr;
                fm.LoadState();
                PaidComm.ConnetctModels += new Action<Socket, byte[], int>(fm.btnConnects);
                PaidComm.ChangePattern += new Action<int>(fm.SetPattern);
                fm.Show();
            }
            else
            {
                FormMain fm2 = new FormMain(dr);
                PaidComm.ConnetctModels += new Action<Socket, byte[], int>(fm2.btnConnects);
                PaidComm.ChangePattern += new Action<int>(fm2.SetPattern);
                fm2.Show();
            }
            FrmBlock.NavHandle = base.Handle;
            base.Hide();
        }

        private void FrmBlock_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmBlock.Mainhandle != IntPtr.Zero)
            {
                FormMain fm = (FormMain)Control.FromHandle(FrmBlock.Mainhandle);
                FormMain.closeMyCom(fm.SwitchModuleSM);
                FormMain.closeMyCom(fm.GetRTDataSM);
                FormMain.closeMyCom(SysManager._comm);
                fm.Close();
            }
            int code = Environment.ExitCode;
            Environment.Exit(code);
        }

        private void btnClick(int iA)
        {
            base.Invoke(new MethodInvoker((this.panelControl1.Controls[iA - 1] as SimpleButton).PerformClick));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Start();
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            MessageBox.Show("模块切换成功！", "模块切换", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            SendKeys.Send("Y");
        }

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
