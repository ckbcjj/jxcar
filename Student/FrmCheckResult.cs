using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmCheckResult : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataRow _dr;

        private Dictionary<int, string> AnswerList;


        public FrmCheckResult(Dictionary<int, string> answerlist)
        {
            this.InitializeComponent();
            this.AnswerList = answerlist;
            this._dr = this.da.GetList("select * from checkinfo where testerno='" + LoginInfo.StudyNO + "' order by begintime desc").Rows[0];
        }

        private void FrmCheckResult_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.panelControl1.Controls)
            {
                if (control is TextEdit)
                {
                    control.Enabled = false;
                }
            }
            this.textEdit1.Text = this._dr["TesterName"].ToString();
            this.textEdit2.Text = this._dr["Score"].ToString();
            TimeSpan timeSpan = DateTime.Parse(this._dr["EndTime"].ToString()) - DateTime.Parse(this._dr["BeginTime"].ToString());
            this.textEdit3.Text = (timeSpan.Hours * 60 + timeSpan.Minutes).ToString();
            this.textEdit4.Text = this._dr["TestTimes"].ToString();
            this.BindData();
        }

        private void BindData()
        {
            DataTable dataTable = new DataTable();
            DataColumn[] columns = new DataColumn[]
			{
				new DataColumn("Id"),
				new DataColumn("Question1"),
				new DataColumn("Question2"),
				new DataColumn("Answer")
			};
            dataTable.Columns.AddRange(columns);
            foreach (KeyValuePair<int, string> current in ClientSystemInfo.dic)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["id"] = current.Key;
                dataRow["Question1"] = this.GetItemName(current.Key);
                dataRow["Question2"] = current.Value;
                dataRow["Answer"] = ((!this.AnswerList.Keys.Contains(current.Key)) ? "未答题" : this.AnswerList[current.Key]);
                dataTable.Rows.Add(dataRow);
            }
            this.gridControl2.DataSource = dataTable;
        }

        public string GetItemName(int id)
        {
            string result = string.Empty;
            DataTable list = this.da.GetList(string.Concat(new object[]
			{
				"select Name from faultpoint where ModuleId=",
				ClientSystemInfo.ModuleId,
				" and id=",
				id
			}));
            if (list != null && list.Rows.Count != 0)
            {
                result = list.Rows[0][0].ToString();
            }
            return result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
    }
}
