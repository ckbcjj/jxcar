using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BLL.Core;
using DevExpress.Data;

namespace Teacher
{


    public partial class FrmManager : XtraForm
    {

        public FrmManager()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else
            {
                FrmEditManager manager = new FrmEditManager(this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]));
                if (manager.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要注销的项");
            }
            else if (MessageBox.Show("确定注销该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (int.Parse(dataRow["RoleId"].ToString()) == 0)
                {
                    MessageBox.Show("管理员用户不可注销");
                }
                else
                {
                    string sql = "delete UserInfo where StudyNO='" + dataRow["StudyNO"].ToString() + "'";
                    if (this.da.SqlCommand(sql))
                    {
                        string msg = string.Format("注销用户[{0}]成功", dataRow["UserName"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show(msg);
                        this.BindData();
                    }
                }
            }
        }

        private void barLargeButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            string sql = "select StudyNO,StudyName,UserName,PassWord,RoleId,RoleName,mail,(case Userable when 0 then '待审核...' else '正常使用' end) as Userable from UserInfo where RoleId<>2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}

