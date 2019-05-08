using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Teacher;

namespace Teacher
{
    public partial class FrmCheckScore : XtraForm
    {

        public FrmCheckScore()
        {
            this.InitializeComponent();
        }

        private void FrmCheckScore_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.timer1.Start();
        }

        public void BindData()
        {
            string sql = "select StudyNO, StudyName,(case IsMan when 0 then '女' else '男' end) as IsMan,UserName,'' as AnswerList,'' as score, '' as testtimes,'' as usetime,'' as begintime,'未开始考核' as CheckState from UserInfo  where RoleId=2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataMember = "dt";
            this.gridControl1.DataSource = this.dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow[] drs;
            switch (this.comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    drs = this.dt.Select(" studyno like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
                case 1:
                    drs = this.dt.Select(" StudyName like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
                default:
                    drs = this.dt.Select(" username like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
            }
            this.dt2 = this.dt.Clone();
            DataRow[] array = drs;
            for (int i = 0; i < array.Length; i++)
            {
                DataRow item = array[i];
                this.dt2.Rows.Add(item.ItemArray);
            }
            this.gridControl1.DataSource = null;
            this.gridControl1.DataMember = "dt2";
            this.gridControl1.DataSource = this.dt2;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "";
            this.gridControl1.DataSource = null;
            this.gridControl1.DataMember = "dt";
            this.gridControl1.DataSource = this.dt;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataRow dr = this.gridView1.GetDataRow(e.RowHandle);
                if (dr != null && dr["StudyNO"] != null)
                {
                    string testerno = dr["StudyNO"].ToString();
                    string sql = "select TesterNO,TesterName,score,begintime from checkinfo where testerno='" + testerno + "'";
                    DataTable dt = this.da.GetList(sql);
                    this.gridControl2.DataSource = dt;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CacheInvoke.CheckPool != null && CacheInvoke.CheckPool.Count != 0)
            {
                IEnumerator enumerator = this.dt.Rows.GetEnumerator();
                try
                {
                    DataRow item;
                    while (enumerator.MoveNext())
                    {
                        item = (DataRow)enumerator.Current;
                        List<CheckInfo> CIlist = (from t in CacheInvoke.CheckPool
                                                  where t.UserName == item["UserName"].ToString()
                                                  select t).ToList<CheckInfo>();
                        if (CIlist.Count != 0)
                        {
                            CheckInfo CI = CIlist.FirstOrDefault<CheckInfo>();
                            item["AnswerList"] = CI.AnswerList;
                            item["score"] = CI.Score;
                            item["testtimes"] = CI.Times;
                            item["usetime"] = CI.UseTime;
                            item["begintime"] = CI.BeginTime;
                            item["CheckState"] = ((CI.State == 0) ? "未开始考核" : ((CI.State == 1) ? "正在答题" : "答题结束"));
                            if (this.dt2 != null)
                            {
                                foreach (DataRow dr in from DataRow t in this.dt2.Rows
                                                       where t["StudyNO"].ToString() == item["StudyNO"].ToString()
                                                       select t)
                                {
                                    dr["score"] = CI.Score;
                                    dr["testtimes"] = CI.Times;
                                    dr["usetime"] = CI.UseTime;
                                    dr["begintime"] = CI.BeginTime;
                                    dr["CheckState"] = ((CI.State == 0) ? "未开始考核" : ((CI.State == 1) ? "正在答题" : "答题结束"));
                                }
                            }
                            lock (CacheInvoke.CheckPool)
                            {
                                CacheInvoke.CheckPool.Remove(CI);
                            }
                        }
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintingSystem print = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(print);
            print.Links.Add(link);
            link.Component = this.gridControl1;
            string _PrintHeader = "学生成绩";
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[]
			{
				"",
				_PrintHeader,
				""
			});
            phf.Header.Font = new Font("宋体", 14f, FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;
            link.CreateDocument();
            print.PreviewFormEx.Show();
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                new XlsExportOptions();
                this.gridControl1.ExportToXls(fileDialog.FileName);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要查看的学员");
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            if (dr["CheckState"].ToString() == "未开始考核" || dr["CheckState"].ToString() == "正在答题")
            {
                MessageBox.Show(string.Format("该生{0},无法查看详情", dr["CheckState"].ToString()));
                return;
            }
            if (dr != null)
            {
                new FrmCheckResult(dr)
                {
                    StartPosition = FormStartPosition.CenterParent
                }.ShowDialog(this);
            }
        }
    }
}
