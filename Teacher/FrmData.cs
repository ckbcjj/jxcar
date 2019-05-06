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


    public class FrmData : XtraForm
    {
        private Bar bar2;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarLargeButtonItem barLargeButtonItem1;
        private BarLargeButtonItem barLargeButtonItem2;
        private BarLargeButtonItem barLargeButtonItem3;
        private BarManager barManager1;
        private IContainer components;
        private GridColumn gridColumn1;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn8;
        private GridColumn gridColumn9;
        private GridControl gridControl2;
        private GridView gridView2;
        private PanelControl panelControl2;

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmData_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmData));
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.barLargeButtonItem2 = new BarLargeButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.panelControl2 = new PanelControl();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.gridColumn9 = new GridColumn();
            this.gridColumn10 = new GridColumn();
            this.gridColumn11 = new GridColumn();
            this.gridColumn12 = new GridColumn();
            this.gridColumn1 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.gridColumn8 = new GridColumn();
            this.barLargeButtonItem3 = new BarLargeButtonItem();
            this.barManager1.BeginInit();
            this.panelControl2.BeginInit();
            this.panelControl2.SuspendLayout();
            this.gridControl2.BeginInit();
            this.gridView2.BeginInit();
            base.SuspendLayout();
            this.barManager1.Bars.AddRange(new Bar[] { this.bar2 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.barLargeButtonItem1, this.barLargeButtonItem2, this.barLargeButtonItem3 });
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barLargeButtonItem3), new LinkPersistInfo(this.barLargeButtonItem1, true), new LinkPersistInfo(this.barLargeButtonItem2) });
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "预览";
            this.barLargeButtonItem1.Glyph = (Image) manager.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 6;
            this.barLargeButtonItem1.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "导出";
            this.barLargeButtonItem2.Glyph = (Image) manager.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 7;
            this.barLargeButtonItem2.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(0x2cf, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x1dc);
            this.barDockControlBottom.Size = new Size(0x2cf, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 0x1a0);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x2cf, 60);
            this.barDockControlRight.Size = new Size(0, 0x1a0);
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 60);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(0x2cf, 0x1a0);
            this.panelControl2.TabIndex = 6;
            this.gridControl2.Dock = DockStyle.Fill;
            this.gridControl2.Location = new Point(2, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(0x2cb, 0x19c);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new BaseView[] { this.gridView2 });
            this.gridView2.Columns.AddRange(new GridColumn[] { this.gridColumn9, this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn1 });
            this.gridView2.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem(SummaryItemType.None, "DataTypeId", null, ""), new GridGroupSummaryItem(SummaryItemType.None, "DataTypeName", null, "") });
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "历史数据";
            this.gridColumn9.Caption = "对象编号";
            this.gridColumn9.FieldName = "DataTypeId";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 100;
            this.gridColumn10.Caption = "对象名";
            this.gridColumn10.FieldName = "DataTypeName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 0xa1;
            this.gridColumn11.Caption = "测量值";
            this.gridColumn11.FieldName = "Value";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 0xa1;
            this.gridColumn12.Caption = "测量时间";
            this.gridColumn12.DisplayFormat.FormatString = "yyyy/MM/dd  HH:mm:ss";
            this.gridColumn12.DisplayFormat.FormatType = FormatType.DateTime;
            this.gridColumn12.FieldName = "Time";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 0xaf;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            this.gridColumn5.Caption = "编号";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn6.Caption = "测量对象";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn7.Caption = "测量参数";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn8.Caption = "测量值";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.barLargeButtonItem3.Caption = "清除历史数据";
            this.barLargeButtonItem3.Glyph = (Image) manager.GetObject("barLargeButtonItem3.Glyph");
            this.barLargeButtonItem3.Id = 9;
            this.barLargeButtonItem3.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem3.LargeGlyph");
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2cf, 0x1dc);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmData";
            this.Text = "历史数据";
            base.Load += new EventHandler(this.FrmData_Load);
            this.barManager1.EndInit();
            this.panelControl2.EndInit();
            this.panelControl2.ResumeLayout(false);
            this.gridControl2.EndInit();
            this.gridView2.EndInit();
            base.ResumeLayout(false);
        }
    }
}

