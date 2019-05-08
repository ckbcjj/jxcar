using BLL.Core;
using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Teacher
{

    public partial class FrmModuleEdit : XtraForm
    {

        public FrmModuleEdit(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                InitialDirectory = Environment.CurrentDirectory + @"\images\Schematic",
                Filter = "所有图片|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
                {
                    this.buttonEdit1.Text = "images" + fileName.Substring(fileName.LastIndexOf('\\'));
                }
                else
                {
                    MessageBox.Show("该文件不存在");
                }
            }
        }

        private void FrmModuleEdit_Load(object sender, EventArgs e)
        {
            if (this._dr != null)
            {
                this.labelControl4.Text = "编辑模块";
                this.textEdit1.Text = this._dr["id"].ToString();
                this.textEdit1.Enabled = false;
                this.textEdit2.Text = this._dr["modulename"].ToString();
                this.textEdit3.Text = this._dr["carclass"].ToString();
                this.buttonEdit1.Text = this._dr["schematic"].ToString();
            }
            else
            {
                this.labelControl4.Text = "增加模块";
                this.textEdit1.Visible = false;
                this.labelControl1.Visible = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string str = this.textEdit2.Text.Trim();
            string str2 = this.textEdit3.Text.Trim();
            string str3 = this.buttonEdit1.Text.Trim();
            if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(str2))
            {
                MessageBox.Show("信息不能为空");
            }
            else
            {
                string sql = null;
                if (this._dr != null)
                {
                    sql = "update sysmodule set modulename='" + str + "',carclass='" + str2 + "'";
                    if (!string.IsNullOrWhiteSpace(str3))
                    {
                        sql = sql + ",schematic='" + str3 + "'";
                    }
                    else
                    {
                        sql = sql + ",schematic=null";
                    }
                    sql = sql + " where id=" + int.Parse(this._dr["id"].ToString());
                }
                else
                {
                    sql = "insert into sysmodule values('" + str + "','" + str2 + "'";
                    if (!string.IsNullOrWhiteSpace(str3))
                    {
                        sql = sql + ",'" + str3 + "'";
                    }
                    else
                    {
                        sql = sql + ",null";
                    }
                    sql = sql + ")";
                }
                if (this.da.SqlCommand(sql))
                {
                    string msg = string.Empty;
                    if (this._dr != null)
                    {
                        msg = string.Format("修改编号为[{0}]的模块信息成功", this._dr["id"].ToString());
                    }
                    else
                    {
                        msg = string.Format("增加模块[{0}]成功", str);
                    }
                    this.da.WriteLog(LoginInfo.UserName, msg);
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

