using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace Teacher
{


    public partial class FrmModule : XtraForm
    {
        private string alertMsg = "系统已连接当前模块,请先断开连接再尝试";

        public FrmModule()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else
            {
                FrmModuleEdit edit = new FrmModuleEdit(null);
                if (edit.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    if (dataRow["id"].ToString() == ServerSystemInfo.ModuleId.ToString())
                    {
                        MessageBox.Show(this.alertMsg);
                    }
                    else
                    {
                        FrmModuleEdit edit = new FrmModuleEdit(dataRow);
                        if (edit.ShowDialog(this) == DialogResult.OK)
                        {
                            this.BindData();
                        }
                    }
                }
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要删除的项");
            }
            else if (MessageBox.Show("确定删除该模块吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    if (dataRow["id"].ToString() == ServerSystemInfo.ModuleId.ToString())
                    {
                        MessageBox.Show(this.alertMsg);
                    }
                    else if (this.da.SqlCommand("delete sysmodule where id=" + int.Parse(dataRow["id"].ToString())))
                    {
                        string msg = string.Format("系统模块[{0}]成功删除", dataRow["modulename"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show("删除成功");
                        this.BindData();
                    }
                }
            }
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            DataTable list = new DataTable();
            string sql = "select * from sysmodule";
            list = this.da.GetList(sql);
            this.gridControl1.DataSource = list;
        }

        private void FrmModule_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}

