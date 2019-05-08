using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Teacher;

namespace Teacher
{
    public partial class FrmUser : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DataTable dt2;

        public FrmUser()
        {
            this.InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.timer1.Start();
        }

        public void BindData()
        {
            string sql = "select StudyNO,StudyName,(case IsMan when 0 then '女' else '男' end) as IsMan,UserName,PassWord,Mail,'离线'as IsOnline from UserInfo where RoleId=2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEditUser feu = new FrmEditUser(null);
            if (feu.ShowDialog(this) == DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            if (dr != null)
            {
                FrmEditUser fem = new FrmEditUser(dr);
                if (fem.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要删除的项");
                return;
            }
            if (MessageBox.Show("确定删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            string sql = "delete userinfo where StudyNO='" + dr["studyno"].ToString() + "'";
            bool Result = this.da.SqlCommand(sql);
            if (Result)
            {
                string msg = string.Format("删除用户[{0}]成功", dr["UserName"].ToString());
                this.da.WriteLog(LoginInfo.UserName, msg);
                MessageBox.Show(msg);
                this.BindData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            string no = this.textEdit1.Text.ToString().Trim();
            string name = this.textEdit2.Text.ToString().Trim();
            if (string.IsNullOrEmpty(no))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append("  studyname like '%" + name + "%'");
                }
            }
            else if (!string.IsNullOrEmpty(name))
            {
                sql.Append(string.Concat(new string[]
				{
					"  studyno like '%",
					no,
					"%' and studyname like '%",
					name,
					"%'"
				}));
            }
            else
            {
                sql.Append("  studyno like '%" + no + "%'");
            }
            DataRow[] drs = this.dt.Select(sql.ToString());
            this.dt2 = this.dt.Clone();
            DataRow[] array = drs;
            for (int i = 0; i < array.Length; i++)
            {
                DataRow item = array[i];
                this.dt2.Rows.Add(item.ItemArray);
            }
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = this.dt2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TcpService.clientPool.Count != 0)
            {
                IEnumerator enumerator = this.dt.Rows.GetEnumerator();
                try
                {
                    DataRow item;
                    while (enumerator.MoveNext())
                    {
                        item = (DataRow)enumerator.Current;
                        if ((from t in TcpService.clientPool
                             where t.UserName == item["UserName"].ToString()
                             select t).Count<ClientInfo>() != 0)
                        {
                            item["IsOnline"] = "上线";
                            if (this.dt2 == null)
                            {
                                continue;
                            }
                            using (IEnumerator<DataRow> enumerator2 = (from DataRow t in this.dt2.Rows
                                                                       where t["StudyNO"].ToString() == item["StudyNO"].ToString()
                                                                       select t).GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    DataRow dr = enumerator2.Current;
                                    dr["IsOnline"] = "上线";
                                }
                                continue;
                            }
                        }
                        item["IsOnline"] = "离线";
                    }
                    goto IL_1C8;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            foreach (DataRow item3 in this.dt.Rows)
            {
                item3["IsOnline"] = "离线";
            }
            if (this.dt2 != null)
            {
                foreach (DataRow item2 in this.dt2.Rows)
                {
                    item2["IsOnline"] = "离线";
                }
            }
        IL_1C8:
            this.gridControl1.RefreshDataSource();
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "";
            this.textEdit2.Text = "";
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = this.dt;
        }
    }
}
