using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace Teacher
{


    public partial class FrmCheckResult : XtraForm
    {
        private DataRow _dr;
        private Dictionary<int, string> AnswerList;

        public FrmCheckResult(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
            this.AnswerList = this.GetAnswerList();
        }

        private void BindData()
        {
            DataTable table = new DataTable();
            DataColumn[] columns = new DataColumn[] { new DataColumn("Id"), new DataColumn("Question1"), new DataColumn("Question2"), new DataColumn("Answer") };
            table.Columns.AddRange(columns);
            foreach (KeyValuePair<int, string> pair in ServerSystemInfo.dic)
            {
                DataRow row = table.NewRow();
                row["id"] = pair.Key;
                row["Question1"] = this.GetItemName(pair.Key);
                row["Question2"] = pair.Value;
                row["Answer"] = !this.AnswerList.Keys.Contains<int>(pair.Key) ? "未答题" : this.AnswerList[pair.Key];
                table.Rows.Add(row);
            }
            this.gridControl2.DataSource = table;
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
            this.textEdit1.Text = this._dr["StudyName"].ToString();
            this.textEdit2.Text = this._dr["score"].ToString();
            this.textEdit3.Text = this._dr["usetime"].ToString();
            this.textEdit4.Text = this._dr["testtimes"].ToString();
            this.BindData();
        }

        private Dictionary<int, string> GetAnswerList()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            string[] strArray = this._dr["AnswerList"].ToString().Split(new char[] { ';' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!string.IsNullOrEmpty(strArray[i]))
                {
                    int num2 = int.Parse(strArray[i].Split(new char[] { ',' })[0]);
                    string str = strArray[i].Split(new char[] { ',' })[1];
                    if (!dictionary.Keys.Contains<int>(num2))
                    {
                        dictionary.Add(num2, str);
                    }
                    else
                    {
                        dictionary[num2] = str;
                    }
                }
            }
            return dictionary;
        }

        public string GetItemName(int id)
        {
            string str = string.Empty;
            DataTable list = this.da.GetList(string.Concat(new object[] { "select Name from faultpoint where ModuleId=", ServerSystemInfo.ModuleId, " and id=", id }));
            if ((list != null) && (list.Rows.Count != 0))
            {
                str = list.Rows[0][0].ToString();
            }
            return str;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
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
    }
}

