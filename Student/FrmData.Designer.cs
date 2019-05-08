using BLL.Service;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    partial class FrmData 
    {
        private IContainer components;

        private BarManager barManager1;

        private Bar bar2;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private PanelControl panelControl2;

        private GridControl gridControl2;

        private GridView gridView2;

        private GridColumn gridColumn5;

        private GridColumn gridColumn6;

        private GridColumn gridColumn7;

        private GridColumn gridColumn8;

        private GridColumn gridColumn9;

        private GridColumn gridColumn10;

        private GridColumn gridColumn11;

        private GridColumn gridColumn12;

        private BarLargeButtonItem barLargeButtonItem1;

        private BarLargeButtonItem barLargeButtonItem2;

        private GridColumn gridColumn1;

   
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmData));
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
            ((ISupportInitialize)this.barManager1).BeginInit();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.gridControl2).BeginInit();
            ((ISupportInitialize)this.gridView2).BeginInit();
            base.SuspendLayout();
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[]
			{
				this.bar2
			});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[]
			{
				this.barLargeButtonItem1,
				this.barLargeButtonItem2
			});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.barLargeButtonItem1),
				new LinkPersistInfo(this.barLargeButtonItem2)
			});
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "预览";
            this.barLargeButtonItem1.Glyph = (Image)componentResourceManager.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 6;
            this.barLargeButtonItem1.LargeGlyph = (Image)componentResourceManager.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "导出";
            this.barLargeButtonItem2.Glyph = (Image)componentResourceManager.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 7;
            this.barLargeButtonItem2.LargeGlyph = (Image)componentResourceManager.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(719, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 476);
            this.barDockControlBottom.Size = new Size(719, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 416);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(719, 60);
            this.barDockControlRight.Size = new Size(0, 416);
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 60);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(719, 416);
            this.panelControl2.TabIndex = 6;
            this.gridControl2.Dock = DockStyle.Fill;
            this.gridControl2.Location = new Point(2, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(715, 412);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView2
			});
            this.gridView2.Columns.AddRange(new GridColumn[]
			{
				this.gridColumn9,
				this.gridColumn10,
				this.gridColumn11,
				this.gridColumn12,
				this.gridColumn1
			});
            this.gridView2.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.GroupSummary.AddRange(new GridSummaryItem[]
			{
				new GridGroupSummaryItem(SummaryItemType.None, "DataTypeId", null, ""),
				new GridGroupSummaryItem(SummaryItemType.None, "DataTypeName", null, "")
			});
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
            this.gridColumn10.Caption = "对象名";
            this.gridColumn10.FieldName = "DataTypeName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn11.Caption = "测量值";
            this.gridColumn11.FieldName = "Value";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn12.Caption = "测量时间";
            this.gridColumn12.DisplayFormat.FormatString = "yyyy/MM/dd  HH:mm:ss";
            this.gridColumn12.DisplayFormat.FormatType = FormatType.DateTime;
            this.gridColumn12.FieldName = "Time";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(719, 476);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmData";
            this.Text = "历史数据";
            base.Load += new EventHandler(this.FrmData_Load);
            ((ISupportInitialize)this.barManager1).EndInit();
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((ISupportInitialize)this.gridControl2).EndInit();
            ((ISupportInitialize)this.gridView2).EndInit();
            base.ResumeLayout(false);
        }
    }
}
