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


    public class FrmCheckResult : XtraForm
    {
        private DataRow _dr;
        private Dictionary<int, string> AnswerList;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridControl gridControl2;
        private GridView gridView2;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private PanelControl panelControl1;
        private SimpleButton simpleButton1;
        private TextEdit textEdit1;
        private TextEdit textEdit2;
        private TextEdit textEdit3;
        private TextEdit textEdit4;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmCheckResult));
            this.panelControl1 = new PanelControl();
            this.textEdit4 = new TextEdit();
            this.textEdit3 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.textEdit1 = new TextEdit();
            this.labelControl4 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.simpleButton1 = new SimpleButton();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.gridColumn4 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.textEdit4.Properties.BeginInit();
            this.textEdit3.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.textEdit1.Properties.BeginInit();
            this.gridControl2.BeginInit();
            this.gridView2.BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.textEdit4);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x28d, 0x29);
            this.panelControl1.TabIndex = 0;
            this.textEdit4.Location = new Point(0x1d4, 11);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new Size(0x49, 20);
            this.textEdit4.TabIndex = 8;
            this.textEdit3.Location = new Point(320, 11);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new Size(0x4e, 20);
            this.textEdit3.TabIndex = 7;
            this.textEdit2.Location = new Point(0xb5, 11);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(0x3e, 20);
            this.textEdit2.TabIndex = 6;
            this.textEdit1.Location = new Point(0x2b, 11);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(0x4d, 20);
            this.textEdit1.TabIndex = 5;
            this.labelControl4.Location = new Point(0x19b, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new Size(60, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "答题次数：";
            this.labelControl3.Location = new Point(0x108, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(60, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "考核用时：";
            this.simpleButton1.Image = (Image) manager.GetObject("simpleButton1.Image");
            this.simpleButton1.Location = new Point(0x223, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x63, 0x21);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "导出成绩";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.labelControl2.Location = new Point(0x7e, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "考核成绩：";
            this.labelControl1.Location = new Point(9, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "考生：";
            this.gridControl2.Dock = DockStyle.Fill;
            this.gridControl2.Location = new Point(0, 0x29);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(0x28d, 430);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new BaseView[] { this.gridView2 });
            this.gridView2.Columns.AddRange(new GridColumn[] { this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
            this.gridView2.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "考核详情";
            this.gridColumn4.Caption = "故障点编号";
            this.gridColumn4.FieldName = "Id";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn5.Caption = "故障点名称";
            this.gridColumn5.FieldName = "Question1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn6.Caption = "设置的故障指令";
            this.gridColumn6.FieldName = "Question2";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn7.Caption = "学生作答的指令";
            this.gridColumn7.FieldName = "Answer";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28d, 0x1d7);
            base.Controls.Add(this.gridControl2);
            base.Controls.Add(this.panelControl1);
            base.Name = "FrmCheckResult";
            this.Text = "考核结果";
            base.Load += new EventHandler(this.FrmCheckResult_Load);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.textEdit4.Properties.EndInit();
            this.textEdit3.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.textEdit1.Properties.EndInit();
            this.gridControl2.EndInit();
            this.gridView2.EndInit();
            base.ResumeLayout(false);
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

