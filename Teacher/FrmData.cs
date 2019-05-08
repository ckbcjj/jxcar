using BLL.Service;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace Teacher
{


    public partial class FrmData : XtraForm
    {

        public FrmData()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink val = new PrintableComponentLink(ps);
            ps.Links.Add(val);
            val.Component = this.gridControl2;
            string str = "历史数据";
            PageHeaderFooter pageHeaderFooter = val.PageHeaderFooter as PageHeaderFooter;
            pageHeaderFooter.Header.Content.Clear();
            pageHeaderFooter.Header.Content.AddRange(new string[] { "", str, "" });
            pageHeaderFooter.Header.Font = new Font("宋体", 14f, FontStyle.Bold);
            pageHeaderFooter.Header.LineAlignment = BrickAlignment.Center;
            val.CreateDocument();
            ps.PreviewFormEx.Show();
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Title = "导出Excel",
                Filter = "Excel文件(*.xls)|*.xls"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                new XlsExportOptions();
                this.gridControl2.ExportToXls(dialog.FileName);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("确定清空操作日志吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                if (((DataTable) this.gridControl2.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("无可清除的数据");
                }
                else
                {
                    new DataAccess().TransCommand("truncate table HisData");
                    MessageBox.Show("清除成功");
                    this.BindData();
                }
            }
        }

        private void BindData()
        {
            string sql = "select * from HisData";
            DataTable list = new DataAccess().GetList(sql);
            this.gridControl2.DataSource = list;
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}

