using BLL.Service;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Teacher
{


    public class FrmChangePwd : XtraForm
    {
        private IContainer components;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;

        public FrmChangePwd()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmChangePwd));
            this.labelControl1 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl4 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.textEdit4 = new TextEdit();
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.labelControl5 = new LabelControl();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit4.Properties.BeginInit();
            base.SuspendLayout();
            this.labelControl1.Location = new Point(0x40, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "编号：";
            this.labelControl2.Location = new Point(0x34, 0x87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x30, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "原密码：";
            this.labelControl3.Location = new Point(0x34, 0xb2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x30, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "新密码：";
            this.labelControl4.Location = new Point(0x40, 0x5c);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(0x24, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "姓名：";
            this.textEdit1.Location = new Point(0x6b, 0x2c);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 4;
            this.textEdit2.Location = new Point(0x6b, 0x56);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 5;
            this.textEdit3.Location = new Point(0x6b, 0x81);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(100, 20);
            this.textEdit3.TabIndex = 6;
            this.textEdit4.Location = new Point(0x6a, 0xac);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(100, 20);
            this.textEdit4.TabIndex = 7;
            this.simpleButton1.BackgroundImageLayout = ImageLayout.Stretch;
            this.simpleButton1.Image = (Image) manager.GetObject("simpleButton1.Image");
            this.simpleButton1.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new Point(0x2b, 0xdd);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x4b, 0x17);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.simpleButton2.BackgroundImageLayout = ImageLayout.Stretch;
            this.simpleButton2.Image = (Image) manager.GetObject("simpleButton2.Image");
            this.simpleButton2.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new Point(0x92, 0xdd);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x4b, 0x17);
            this.simpleButton2.TabIndex = 9;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl5.Appearance.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelControl5.Dock = DockStyle.Left;
            this.labelControl5.Location = new Point(0, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x34, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "修改密码";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.BackgroundImageLayoutStore = ImageLayout.Stretch;
            base.BackgroundImageStore = (Image) manager.GetObject("$this.BackgroundImageStore");
            base.ClientSize = new Size(0x10a, 0x100);
            base.Controls.Add(this.labelControl5);
            base.Controls.Add(this.simpleButton2);
            base.Controls.Add(this.simpleButton1);
            base.Controls.Add(this.textEdit4);
            base.Controls.Add(this.textEdit3);
            base.Controls.Add(this.textEdit2);
            base.Controls.Add(this.textEdit1);
            base.Controls.Add(this.labelControl4);
            base.Controls.Add(this.labelControl3);
            base.Controls.Add(this.labelControl2);
            base.Controls.Add(this.labelControl1);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FrmChangePwd";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit4.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(this.textEdit1.Text) || string.IsNullOrEmpty(this.textEdit2.Text)) || (string.IsNullOrEmpty(this.textEdit3.Text) || string.IsNullOrEmpty(this.textEdit4.Text)))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                DataAccess access = new DataAccess();
                string str = this.textEdit1.Text.Trim();
                DataTable list = access.GetList("select count(*) from UserInfo where StudyNO='" + str + "' and StudyName='" + this.textEdit2.Text.Trim() + "' and Password='" + this.textEdit3.Text.Trim() + "'");
                if (((list == null) || (list.Rows.Count == 0)) || (list.Rows[0][0].ToString() == "0"))
                {
                    MessageBox.Show("该用户不存在");
                }
                else
                {
                    string sql = "update UserInfo set Password='" + this.textEdit4.Text.Trim() + "' where StudyNO='" + str + "'";
                    if (access.SqlCommand(sql))
                    {
                        MessageBox.Show("修改密码成功");
                    }
                    base.Close();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

