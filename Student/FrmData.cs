using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmData : XtraForm
    {
 

        public FrmData()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintingSystem printingSystem = new PrintingSystem();
            PrintableComponentLink printableComponentLink = new PrintableComponentLink(printingSystem);
            printingSystem.Links.Add(printableComponentLink);
            printableComponentLink.Component = this.gridControl2;
            string text = "历史数据";
            PageHeaderFooter pageHeaderFooter = printableComponentLink.PageHeaderFooter as PageHeaderFooter;
            pageHeaderFooter.Header.Content.Clear();
            pageHeaderFooter.Header.Content.AddRange(new string[]
			{
				"",
				text,
				""
			});
            pageHeaderFooter.Header.Font = new Font("宋体", 14f, FontStyle.Bold);
            pageHeaderFooter.Header.LineAlignment = BrickAlignment.Center;
            printableComponentLink.CreateDocument();
            printingSystem.PreviewFormEx.Show();
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                new XlsExportOptions();
                this.gridControl2.ExportToXls(saveFileDialog.FileName);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            string sql = "select * from HisData";
            DataAccess dataAccess = new DataAccess();
            DataTable list = dataAccess.GetList(sql);
            this.gridControl2.DataSource = list;
        }
    }
}
