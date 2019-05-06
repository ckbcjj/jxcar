using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Teacher
{


    public class FrmEditManager : XtraForm
    {
        private DataRow _dr;
        private ComboBoxEdit comboBoxEdit1;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private PanelControl panelControl1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit5;
        private TextEdit textEdit6;

        public FrmEditManager(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmEditManager_Load(object sender, EventArgs e)
        {
            if (this._dr != null)
            {
                this.textEdit1.Text = this._dr["RoleName"].ToString();
                this.textEdit6.Text = this._dr["StudyNO"].ToString();
                this.textEdit3.Text = this._dr["UserName"].ToString();
                this.textEdit4.Text = this._dr["PassWord"].ToString();
                this.textEdit5.Text = this._dr["StudyName"].ToString();
                this.comboBoxEdit1.Text = this._dr["Userable"].ToString();
                if (LoginInfo.StudyNO == this._dr["StudyNO"].ToString())
                {
                    this.comboBoxEdit1.Enabled = false;
                }
                if (LoginInfo.RoleId != 0)
                {
                    this.comboBoxEdit1.Enabled = false;
                }
                this.textEdit2.Text = this._dr["mail"].ToString();
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmEditManager));
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.textEdit4 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.labelControl4 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.labelControl6 = new LabelControl();
            this.textEdit6 = new TextEdit();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.labelControl7 = new LabelControl();
            this.textEdit2 = new TextEdit();
            this.labelControl8 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.textEdit5 = new TextEdit();
            this.labelControl5 = new LabelControl();
            this.textEdit4.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.textEdit6.Properties.BeginInit();
            this.comboBoxEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.textEdit5.Properties.BeginInit();
            base.SuspendLayout();
            this.simpleButton2.Image = (Image) manager.GetObject("simpleButton2.Image");
            this.simpleButton2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new Point(0xaf, 0x10f);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 0x1c;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image) manager.GetObject("simpleButton1.Image");
            this.simpleButton1.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new Point(0x47, 0x10f);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 0x1b;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.textEdit4.Location = new Point(0x86, 0xab);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(0x80, 20);
            this.textEdit4.TabIndex = 0x16;
            this.textEdit3.Location = new Point(0x86, 0x8b);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0x80, 20);
            this.textEdit3.TabIndex = 0x15;
            this.labelControl4.Location = new Point(0x3b, 0xb1);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x34, 14);
            this.labelControl4.TabIndex = 0x13;
            this.labelControl4.Text = "登录密码:";
            this.labelControl3.Location = new Point(0x47, 0x8f);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(40, 14);
            this.labelControl3.TabIndex = 0x12;
            this.labelControl3.Text = "用户名:";
            this.labelControl1.Location = new Point(0x3b, 0x2c);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x34, 14);
            this.labelControl1.TabIndex = 0x10;
            this.labelControl1.Text = "当前身份:";
            this.labelControl2.Location = new Point(0x3b, 0xce);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "状态设置：";
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new Point(0x86, 40);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(0x80, 20);
            this.textEdit1.TabIndex = 0x22;
            this.labelControl6.Location = new Point(0x53, 0x4c);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x1c, 14);
            this.labelControl6.TabIndex = 0x25;
            this.labelControl6.Text = "编号:";
            this.textEdit6.Enabled = false;
            this.textEdit6.Location = new Point(0x86, 0x4a);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Size = new Size(0x80, 20);
            this.textEdit6.TabIndex = 0x26;
            this.comboBoxEdit1.Location = new Point(0x86, 0xcb);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] { "正常使用", "待审核..." });
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(0x80, 20);
            this.comboBoxEdit1.TabIndex = 0x27;
            this.labelControl7.Location = new Point(0x53, 0xec);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x1c, 14);
            this.labelControl7.TabIndex = 40;
            this.labelControl7.Text = "邮箱:";
            this.textEdit2.Location = new Point(0x86, 0xe9);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(0x80, 20);
            this.textEdit2.TabIndex = 0x29;
            this.labelControl8.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl8.Dock = DockStyle.Top;
            this.labelControl8.Location = new Point(2, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new Size(0x68, 14);
            this.labelControl8.TabIndex = 0x2a;
            this.labelControl8.Text = "特权用户信息编辑";
            this.panelControl1.Appearance.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.textEdit5);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.textEdit4);
            this.panelControl1.Controls.Add(this.textEdit6);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x151, 0x135);
            this.panelControl1.TabIndex = 0x2b;
            this.textEdit5.Enabled = false;
            this.textEdit5.Location = new Point(0x86, 0x6b);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Size = new Size(0x80, 20);
            this.textEdit5.TabIndex = 0x2c;
            this.labelControl5.Location = new Point(0x53, 0x6d);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x1c, 14);
            this.labelControl5.TabIndex = 0x2b;
            this.labelControl5.Text = "姓名:";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x151, 0x135);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmEditManager";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "特权用户编辑";
            base.Load += new EventHandler(this.FrmEditManager_Load);
            this.textEdit4.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            this.textEdit6.Properties.EndInit();
            this.comboBoxEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.textEdit5.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit6.Text)) || ((string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text)) || string.IsNullOrEmpty(this.textEdit5.Text)))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                string userName = this.textEdit3.Text.Trim();
                string str2 = this.textEdit4.Text.Trim();
                string str3 = this.textEdit5.Text.Trim();
                int num = (this.comboBoxEdit1.SelectedIndex == 0) ? 1 : 0;
                string input = this.textEdit2.Text.Trim();
                UserManager manager = new UserManager();
                if ((userName != this._dr["UserName"].ToString().Trim()) && manager.CheckUser(userName))
                {
                    MessageBox.Show("该用户名已存在");
                }
                else if (!Regex.IsMatch(input, @"^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$"))
                {
                    MessageBox.Show("请填写正确的邮箱");
                }
                else
                {
                    string sql = string.Concat(new object[] { "update userinfo set username='", userName, "',password='", str2, "',StudyName='", str3, "',userable=", num, ",mail='", input, "' where studyno='", this._dr["studyno"], "'" });
                    if (this.da.SqlCommand(sql))
                    {
                        string msg = string.Format("修改编号为[{0}]的用户信息成功", this._dr["StudyNO"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show(msg);
                        base.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

