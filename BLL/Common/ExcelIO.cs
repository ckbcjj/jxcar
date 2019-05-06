using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace BLL.Common
{
    public class ExcelIO
    {
        private string _ReturnMessage;
        private int _ReturnStatus;

        public bool ExportExcel(string reportName, System.Data.DataTable dt, string saveFileName)
        {
            Microsoft.Office.Interop.Excel.Range range;
            if (dt == null)
            {
                this._ReturnStatus = -1;
                this._ReturnMessage = "数据集为空！";
                return false;
            }
            bool flag = false;
            Application o = (Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            if (o == null)
            {
                this._ReturnStatus = -1;
                this._ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
                return false;
            }
            Workbooks workbooks = o.Workbooks;
            Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet worksheet = (Worksheet) workbook.Worksheets[1];
            worksheet.Cells.Font.Size = 10;
            long count = dt.Rows.Count;
            long num2 = 0L;
            worksheet.Cells[1, 1] = reportName;
            ((Microsoft.Office.Interop.Excel.Range) worksheet.Cells[1, 1]).Font.Size = 12;
            ((Microsoft.Office.Interop.Excel.Range) worksheet.Cells[1, 1]).Font.Bold = true;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[2, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range) worksheet.Cells[2, i + 1];
                range.Interior.ColorIndex = 15;
                range.Font.Bold = true;
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    worksheet.Cells[j + 3, k + 1] = dt.Rows[j][k].ToString();
                }
                num2 += 1L;
                float single1 = ((float) (100L * num2)) / ((float) count);
            }
            range = (Microsoft.Office.Interop.Excel.Range) worksheet.get_Range((dynamic) worksheet.Cells[2, 1], (dynamic) worksheet.Cells[dt.Rows.Count + 2, dt.Columns.Count]);
            range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);
            if (dt.Rows.Count > 0)
            {
                range.Borders[XlBordersIndex.xlInsideHorizontal].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlInsideHorizontal].Weight = XlBorderWeight.xlThin;
            }
            if (dt.Columns.Count > 1)
            {
                range.Borders[XlBordersIndex.xlInsideVertical].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                range.Borders[XlBordersIndex.xlInsideVertical].Weight = XlBorderWeight.xlThin;
            }
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                    flag = true;
                }
                catch (Exception exception)
                {
                    flag = false;
                    this._ReturnStatus = -1;
                    this._ReturnMessage = "导出文件时出错,文件可能正被打开！\n" + exception.Message;
                }
            }
            else
            {
                flag = false;
            }
            if (range != null)
            {
                Marshal.ReleaseComObject(range);
                range = null;
            }
            if (worksheet != null)
            {
                Marshal.ReleaseComObject(worksheet);
                worksheet = null;
            }
            if (workbook != null)
            {
                Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            if (workbooks != null)
            {
                Marshal.ReleaseComObject(workbooks);
                workbooks = null;
            }
            o.Application.Workbooks.Close();
            o.Quit();
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
            GC.Collect();
            return flag;
        }

        public System.Data.DataTable ImportExcel(string fileName)
        {
            Workbook workbook;
            Application o = (Application) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            if (o == null)
            {
                this._ReturnStatus = -1;
                this._ReturnMessage = "无法创建Excel对象，可能您的计算机未安装Excel";
                return null;
            }
            try
            {
                workbook = o.Workbooks.Open(fileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, 1, 0);
            }
            catch
            {
                this._ReturnStatus = -1;
                this._ReturnMessage = "Excel文件处于打开状态，请保存关闭";
                return null;
            }
            int count = workbook.Worksheets.Count;
            string[] strArray = new string[count];
            new ArrayList();
            for (int i = 1; i <= count; i++)
            {
                strArray[i - 1] = ((Worksheet) workbook.Worksheets[i]).Name;
            }
            workbook.Close(null, null, null);
            o.Quit();
            if (workbook != null)
            {
                Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
            if (o != null)
            {
                Marshal.ReleaseComObject(o);
                o = null;
            }
            GC.Collect();
            DataSet dataSet = new DataSet();
            System.Data.DataTable table = new System.Data.DataTable();
            using (OleDbConnection connection = new OleDbConnection(" Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + fileName + ";Extended Properties=Excel 8.0"))
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [" + strArray[0] + "$] ", connection);
                adapter.Fill(dataSet, strArray[0]);
                adapter.Dispose();
                table = dataSet.Tables[0];
                connection.Close();
                connection.Dispose();
            }
            return table;
        }

        public string ReturnMessage
        {
            get
            {
                return this._ReturnMessage;
            }
        }

        public int ReturnStatus
        {
            get
            {
                return this._ReturnStatus;
            }
        }
    }
}

