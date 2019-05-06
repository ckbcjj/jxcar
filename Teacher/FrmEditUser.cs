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


    public class FrmEditUser : XtraForm
    {
        private DataRow _dr;
        private ComboBoxEdit comboBoxEdit2;
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private PanelControl panelControl1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;
        private TextEdit textEdit5;

        public FrmEditUser(DataRow dr)
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

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            if (this._dr == null)
            {
                this.labelControl7.Text = "增加普通用户";
            }
            else
            {
                this.labelControl7.Text = "普通用户编辑";
                this.textEdit1.Text = this._dr["StudyNO"].ToString();
                this.textEdit1.Enabled = false;
                this.textEdit2.Enabled = false;
                this.textEdit2.Text = this._dr["StudyName"].ToString();
                this.textEdit3.Text = this._dr["UserName"].ToString();
                this.textEdit4.Text = this._dr["PassWord"].ToString();
                this.textEdit5.Text = this._dr["Mail"].ToString();
                if (this._dr["isman"].ToString() == "男")
                {
                    this.comboBoxEdit2.SelectedIndex = 0;
                }
                else
                {
                    this.comboBoxEdit2.SelectedIndex = 1;
                }
            }
        }

        private void InitializeComponent()
        {
            this.textEdit1 = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.textEdit2 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.textEdit4 = new TextEdit();
            this.labelControl5 = new LabelControl();
            this.textEdit5 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.comboBoxEdit2 = new ComboBoxEdit();
            this.labelControl6 = new LabelControl();
            this.labelControl7 = new LabelControl();
            this.panelControl1 = new PanelControl();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            this.textEdit5.Properties.BeginInit();
            this.comboBoxEdit2.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.textEdit1.Location = new Point(0x71, 0x33);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(0x80, 20);
            this.textEdit1.TabIndex = 0;
            this.labelControl1.Location = new Point(0x3e, 0x36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x1c, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "编号:";
            this.labelControl2.Location = new Point(0x3e, 0x58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x1c, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "姓名:";
            this.labelControl3.Location = new Point(50, 120);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(40, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "用户名:";
            this.labelControl4.Location = new Point(0x26, 0x99);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x34, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "登录密码:";
            this.textEdit2.Location = new Point(0x71, 0x52);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(0x80, 20);
            this.textEdit2.TabIndex = 5;
            this.textEdit3.Location = new Point(0x71, 0x72);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0x80, 20);
            this.textEdit3.TabIndex = 6;
            this.textEdit4.Location = new Point(0x71, 0x93);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(0x80, 20);
            this.textEdit4.TabIndex = 7;
            this.labelControl5.Location = new Point(0x3e, 0xbd);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x1c, 14);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "邮箱:";
            this.textEdit5.Location = new Point(0x71, 0xb7);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Size = new Size(0x80, 20);
            this.textEdit5.TabIndex = 9;
            this.simpleButton1.Location = new Point(0x3e, 0x10f);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.Location = new Point(0xa6, 0x10f);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 13;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.comboBoxEdit2.EditValue = "男";
            this.comboBoxEdit2.Location = new Point(0x71, 0xdf);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit2.Properties.Items.AddRange(new object[] { "男", "女" });
            this.comboBoxEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new Size(0x80, 20);
            this.comboBoxEdit2.TabIndex = 15;
            this.labelControl6.Location = new Point(0x36, 0xe2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(0x24, 14);
            this.labelControl6.TabIndex = 0x10;
            this.labelControl6.Text = "性别：";
            this.labelControl7.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl7.Dock = DockStyle.Top;
            this.labelControl7.Location = new Point(2, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new Size(0x52, 14);
            this.labelControl7.TabIndex = 0x11;
            this.labelControl7.Text = "labelControl7";
            this.panelControl1.Appearance.BackColor = Color.FromArgb(0xc0, 0xff, 0xc0);
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = BorderStyles.Style3D;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.comboBoxEdit2);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.textEdit5);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.textEdit4);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x134, 0x131);
            this.panelControl1.TabIndex = 0x12;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x134, 0x131);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmEditUser";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "普通用户编辑";
            base.Load += new EventHandler(this.FrmEditUser_Load);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            this.textEdit5.Properties.EndInit();
            this.comboBoxEdit2.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UserManager manager = new UserManager();
            DataAccess access = new DataAccess();
            string studyNO = this.textEdit1.Text.ToString().Trim();
            string str2 = this.textEdit2.Text.ToString().Trim();
            string userName = this.textEdit3.Text.ToString().Trim();
            string str4 = this.textEdit4.Text.ToString().Trim();
            string input = this.textEdit5.Text.ToString().Trim();
            int num = (this.comboBoxEdit2.SelectedIndex == 0) ? 1 : 0;
            string str6 = "学生";
            int num2 = 1;
            int num3 = 2;
            string sql = null;
            if (!Regex.IsMatch(input, @"^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$"))
            {
                MessageBox.Show("请填写正确的邮箱");
            }
            else
            {
                if (this._dr == null)
                {
                    if (manager.CheckUser(userName))
                    {
                        MessageBox.Show("该用户名已存在");
                        return;
                    }
                    if (manager.CheckNO(studyNO))
                    {
                        MessageBox.Show("该用户编号已存在");
                        return;
                    }
                    if ((!string.IsNullOrEmpty(studyNO) && !string.IsNullOrEmpty(str2)) && (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(str4)))
                    {
                        sql = string.Concat(new object[] { 
                            "insert into userinfo values('", studyNO, "','", str2, "',", num, ",'", userName, "','", str4, "',", num3, ",'", str6, "','", input, 
                            "',", num2, ")"
                         });
                    }
                }
                else
                {
                    if ((userName != this._dr["UserName"].ToString().Trim()) && manager.CheckUser(userName))
                    {
                        MessageBox.Show("该用户名已存在");
                        return;
                    }
                    if ((!string.IsNullOrEmpty(studyNO) && !string.IsNullOrEmpty(str2)) && (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(str4)))
                    {
                        sql = string.Concat(new object[] { 
                            "update userinfo set username='", userName, "',password='", str4, "',mail='", input, "',isman=", num, ",roleid=", num3, ",rolename='", str6, "',userable=", num2, " where studyno='", studyNO, 
                            "'"
                         });
                    }
                }
                if (access.SqlCommand(sql))
                {
                    string msg = string.Empty;
                    if (this._dr != null)
                    {
                        msg = string.Format("修改编号为[{0}]的用户信息成功", this._dr["StudyNO"].ToString());
                    }
                    else
                    {
                        msg = string.Format("增加编号为[{0}]的用户成功", studyNO);
                    }
                    access.WriteLog(LoginInfo.UserName, msg);
                    MessageBox.Show(msg);
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

