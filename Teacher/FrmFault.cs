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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LYcar;
using DevExpress.XtraGrid.Views.Base;

namespace Teacher
{


    public partial class FrmFault : XtraForm
    {

        public FrmFault()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEditFault fault = new FrmEditFault(null);
            if (fault.ShowDialog(this) == DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    FrmEditFault fault = new FrmEditFault(dataRow);
                    if (fault.ShowDialog(this) == DialogResult.OK)
                    {
                        this.BindData();
                    }
                }
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else if (MessageBox.Show("确定删除该故障点吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    string sql = string.Concat(new object[] { "delete faultpoint where id=", int.Parse(dataRow["id"].ToString()), " and moduleid=", ServerSystemInfo.SoftModuleId });
                    if (this.da.SqlCommand(sql))
                    {
                        string msg = string.Format("删除故障点[{0}]成功", dataRow["name"]);
                        this.da.WriteLog(LoginInfo.UserName, msg);
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
            string sql = "select Id,Name,ModuleId,PointMemo,(case NormalIsBreak when 1 then '断路' else '通路' end) as NormalIsBreak,'' as Pattern from FaultPoint  where ModuleId=" + ServerSystemInfo.SoftModuleId;
            this.dt = this.da.GetList(sql);
            foreach (DataRow row in this.dt.Rows)
            {
                row["Pattern"] = this.GetPatternStr(int.Parse(row["ModuleId"].ToString()), int.Parse(row["Id"].ToString()));
            }
            this.gridControl1.DataSource = this.dt;
        }

        private void FrmFault_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private string GetPatternStr(int ModuleId, int FaultPointId)
        {
            StringBuilder builder = new StringBuilder();
            DataTable list = this.da.GetList(string.Concat(new object[] { "select PatternList,NormalIsBreak from FaultPoint where Id=", FaultPointId, " and ModuleId=", ModuleId }));
            if ((list != null) && (list.Rows.Count != 0))
            {
                string str = list.Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ',' });
                    DataTable table2 = this.da.GetList("select * from FaultPattern");
                    foreach (string str2 in strArray)
                    {
                        string str3 = table2.Select(" OrderId=" + int.Parse(str2)).First<DataRow>()["OrderName"].ToString();
                        if (!string.IsNullOrEmpty(str3))
                        {
                            builder.Append(str3 + ",");
                        }
                    }
                    builder = builder.Remove(builder.ToString().LastIndexOf(','), 1);
                }
            }
            return builder.ToString();
        }
    }
}

