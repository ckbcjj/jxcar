using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Commands;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    partial class FrmOscillogram
    {

        private IContainer components;

        private PanelControl panelControl1;

        private TreeList treeList1;

        private TreeListColumn treeListColumn1;

        private TreeListColumn treeListColumn2;

        private PanelControl panelControl5;

        private PanelControl panelControl3;

        private PanelControl panelControl4;

        private SimpleButton simpleButton2;

        private SimpleButton simpleButton1;

        private GroupControl groupControl2;

        private ChartControl chartControl1;

        private SpinEdit spinEdit3;

        private LabelControl labelControl6;

        private System.Windows.Forms.Timer timer1;

        private BarManager barManager1;

        private CreateBarBaseItem createBarBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown1;

        private CreateLineBaseItem createLineBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown2;

        private CreatePieBaseItem createPieBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown3;

        private CreateRotatedBarBaseItem createRotatedBarBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown4;

        private CreateAreaBaseItem createAreaBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown5;

        private CreateOtherSeriesTypesBaseItem createOtherSeriesTypesBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown6;

        private ChartAppearanceBar chartAppearanceBar1;

        private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown7;

        private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown8;

        private ChartTemplatesBar chartTemplatesBar1;

        private SaveAsTemplateChartItem saveAsTemplateChartItem1;

        private ChartPrintExportBar chartPrintExportBar1;

        private PrintPreviewChartItem printPreviewChartItem1;

        private PrintChartItem printChartItem1;

        private CreateExportBaseItem createExportBaseItem1;

        private ExportToPDFChartItem exportToPDFChartItem1;

        private ExportToHTMLChartItem exportToHTMLChartItem1;

        private ExportToMHTChartItem exportToMHTChartItem1;

        private ExportToXLSChartItem exportToXLSChartItem1;

        private ExportToXLSXChartItem exportToXLSXChartItem1;

        private ExportToRTFChartItem exportToRTFChartItem1;

        private CreateExportToImageBaseItem createExportToImageBaseItem1;

        private ExportToBMPChartItem exportToBMPChartItem1;

        private ExportToGIFChartItem exportToGIFChartItem1;

        private ExportToJPEGChartItem exportToJPEGChartItem1;

        private ExportToPNGChartItem exportToPNGChartItem1;

        private ExportToTIFFChartItem exportToTIFFChartItem1;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private ChartBarController chartBarController1;

        private CheckEdit checkEdit1;

        private LabelControl labelControl5;

        private ColorEdit colorEdit1;

        private TreeListColumn treeListColumn3;

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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmOscillogram));
            SwiftPlotDiagram swiftPlotDiagram = new SwiftPlotDiagram();
            Series series = new Series();
            SwiftPlotSeriesView swiftPlotSeriesView = new SwiftPlotSeriesView();
            Series series2 = new Series();
            SwiftPlotSeriesView swiftPlotSeriesView2 = new SwiftPlotSeriesView();
            SwiftPlotSeriesView swiftPlotSeriesView3 = new SwiftPlotSeriesView();
            SuperToolTip superToolTip = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem = new ToolTipTitleItem();
            ToolTipItem toolTipItem = new ToolTipItem();
            SuperToolTip superToolTip2 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem2 = new ToolTipTitleItem();
            ToolTipItem toolTipItem2 = new ToolTipItem();
            SuperToolTip superToolTip3 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem3 = new ToolTipTitleItem();
            ToolTipItem toolTipItem3 = new ToolTipItem();
            SuperToolTip superToolTip4 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem4 = new ToolTipTitleItem();
            ToolTipItem toolTipItem4 = new ToolTipItem();
            SkinPaddingEdges skinPaddingEdges = new SkinPaddingEdges();
            SkinPaddingEdges skinPaddingEdges2 = new SkinPaddingEdges();
            SuperToolTip superToolTip5 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem5 = new ToolTipTitleItem();
            ToolTipItem toolTipItem5 = new ToolTipItem();
            SuperToolTip superToolTip6 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem6 = new ToolTipTitleItem();
            ToolTipItem toolTipItem6 = new ToolTipItem();
            ChartControlCommandGalleryItemGroup2DColumn chartControlCommandGalleryItemGroup2DColumn = new ChartControlCommandGalleryItemGroup2DColumn();
            CreateBarChartItem createBarChartItem = new CreateBarChartItem();
            CreateFullStackedBarChartItem createFullStackedBarChartItem = new CreateFullStackedBarChartItem();
            CreateSideBySideFullStackedBarChartItem createSideBySideFullStackedBarChartItem = new CreateSideBySideFullStackedBarChartItem();
            CreateSideBySideStackedBarChartItem createSideBySideStackedBarChartItem = new CreateSideBySideStackedBarChartItem();
            CreateStackedBarChartItem createStackedBarChartItem = new CreateStackedBarChartItem();
            ChartControlCommandGalleryItemGroup3DColumn chartControlCommandGalleryItemGroup3DColumn = new ChartControlCommandGalleryItemGroup3DColumn();
            CreateBar3DChartItem createBar3DChartItem = new CreateBar3DChartItem();
            CreateFullStackedBar3DChartItem createFullStackedBar3DChartItem = new CreateFullStackedBar3DChartItem();
            CreateManhattanBarChartItem createManhattanBarChartItem = new CreateManhattanBarChartItem();
            CreateSideBySideFullStackedBar3DChartItem createSideBySideFullStackedBar3DChartItem = new CreateSideBySideFullStackedBar3DChartItem();
            CreateSideBySideStackedBar3DChartItem createSideBySideStackedBar3DChartItem = new CreateSideBySideStackedBar3DChartItem();
            CreateStackedBar3DChartItem createStackedBar3DChartItem = new CreateStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupCylinderColumn chartControlCommandGalleryItemGroupCylinderColumn = new ChartControlCommandGalleryItemGroupCylinderColumn();
            CreateCylinderBar3DChartItem createCylinderBar3DChartItem = new CreateCylinderBar3DChartItem();
            CreateCylinderFullStackedBar3DChartItem createCylinderFullStackedBar3DChartItem = new CreateCylinderFullStackedBar3DChartItem();
            CreateCylinderManhattanBarChartItem createCylinderManhattanBarChartItem = new CreateCylinderManhattanBarChartItem();
            CreateCylinderSideBySideFullStackedBar3DChartItem createCylinderSideBySideFullStackedBar3DChartItem = new CreateCylinderSideBySideFullStackedBar3DChartItem();
            CreateCylinderSideBySideStackedBar3DChartItem createCylinderSideBySideStackedBar3DChartItem = new CreateCylinderSideBySideStackedBar3DChartItem();
            CreateCylinderStackedBar3DChartItem createCylinderStackedBar3DChartItem = new CreateCylinderStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupConeColumn chartControlCommandGalleryItemGroupConeColumn = new ChartControlCommandGalleryItemGroupConeColumn();
            CreateConeBar3DChartItem createConeBar3DChartItem = new CreateConeBar3DChartItem();
            CreateConeFullStackedBar3DChartItem createConeFullStackedBar3DChartItem = new CreateConeFullStackedBar3DChartItem();
            CreateConeManhattanBarChartItem createConeManhattanBarChartItem = new CreateConeManhattanBarChartItem();
            CreateConeSideBySideFullStackedBar3DChartItem createConeSideBySideFullStackedBar3DChartItem = new CreateConeSideBySideFullStackedBar3DChartItem();
            CreateConeSideBySideStackedBar3DChartItem createConeSideBySideStackedBar3DChartItem = new CreateConeSideBySideStackedBar3DChartItem();
            CreateConeStackedBar3DChartItem createConeStackedBar3DChartItem = new CreateConeStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupPyramidColumn chartControlCommandGalleryItemGroupPyramidColumn = new ChartControlCommandGalleryItemGroupPyramidColumn();
            CreatePyramidBar3DChartItem createPyramidBar3DChartItem = new CreatePyramidBar3DChartItem();
            CreatePyramidFullStackedBar3DChartItem createPyramidFullStackedBar3DChartItem = new CreatePyramidFullStackedBar3DChartItem();
            CreatePyramidManhattanBarChartItem createPyramidManhattanBarChartItem = new CreatePyramidManhattanBarChartItem();
            CreatePyramidSideBySideFullStackedBar3DChartItem createPyramidSideBySideFullStackedBar3DChartItem = new CreatePyramidSideBySideFullStackedBar3DChartItem();
            CreatePyramidSideBySideStackedBar3DChartItem createPyramidSideBySideStackedBar3DChartItem = new CreatePyramidSideBySideStackedBar3DChartItem();
            CreatePyramidStackedBar3DChartItem createPyramidStackedBar3DChartItem = new CreatePyramidStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroup2DLine chartControlCommandGalleryItemGroup2DLine = new ChartControlCommandGalleryItemGroup2DLine();
            CreateLineChartItem createLineChartItem = new CreateLineChartItem();
            CreateFullStackedLineChartItem createFullStackedLineChartItem = new CreateFullStackedLineChartItem();
            CreateScatterLineChartItem createScatterLineChartItem = new CreateScatterLineChartItem();
            CreateSplineChartItem createSplineChartItem = new CreateSplineChartItem();
            CreateStackedLineChartItem createStackedLineChartItem = new CreateStackedLineChartItem();
            CreateStepLineChartItem createStepLineChartItem = new CreateStepLineChartItem();
            ChartControlCommandGalleryItemGroup3DLine chartControlCommandGalleryItemGroup3DLine = new ChartControlCommandGalleryItemGroup3DLine();
            CreateLine3DChartItem createLine3DChartItem = new CreateLine3DChartItem();
            CreateFullStackedLine3DChartItem createFullStackedLine3DChartItem = new CreateFullStackedLine3DChartItem();
            CreateSpline3DChartItem createSpline3DChartItem = new CreateSpline3DChartItem();
            CreateStackedLine3DChartItem createStackedLine3DChartItem = new CreateStackedLine3DChartItem();
            CreateStepLine3DChartItem createStepLine3DChartItem = new CreateStepLine3DChartItem();
            ChartControlCommandGalleryItemGroup2DPie chartControlCommandGalleryItemGroup2DPie = new ChartControlCommandGalleryItemGroup2DPie();
            CreatePieChartItem createPieChartItem = new CreatePieChartItem();
            CreateDoughnutChartItem createDoughnutChartItem = new CreateDoughnutChartItem();
            ChartControlCommandGalleryItemGroup3DPie chartControlCommandGalleryItemGroup3DPie = new ChartControlCommandGalleryItemGroup3DPie();
            CreatePie3DChartItem createPie3DChartItem = new CreatePie3DChartItem();
            CreateDoughnut3DChartItem createDoughnut3DChartItem = new CreateDoughnut3DChartItem();
            ChartControlCommandGalleryItemGroup2DBar chartControlCommandGalleryItemGroup2DBar = new ChartControlCommandGalleryItemGroup2DBar();
            CreateRotatedBarChartItem createRotatedBarChartItem = new CreateRotatedBarChartItem();
            CreateRotatedFullStackedBarChartItem createRotatedFullStackedBarChartItem = new CreateRotatedFullStackedBarChartItem();
            CreateRotatedSideBySideFullStackedBarChartItem createRotatedSideBySideFullStackedBarChartItem = new CreateRotatedSideBySideFullStackedBarChartItem();
            CreateRotatedSideBySideStackedBarChartItem createRotatedSideBySideStackedBarChartItem = new CreateRotatedSideBySideStackedBarChartItem();
            CreateRotatedStackedBarChartItem createRotatedStackedBarChartItem = new CreateRotatedStackedBarChartItem();
            ChartControlCommandGalleryItemGroup2DArea chartControlCommandGalleryItemGroup2DArea = new ChartControlCommandGalleryItemGroup2DArea();
            CreateAreaChartItem createAreaChartItem = new CreateAreaChartItem();
            CreateFullStackedAreaChartItem createFullStackedAreaChartItem = new CreateFullStackedAreaChartItem();
            CreateFullStackedSplineAreaChartItem createFullStackedSplineAreaChartItem = new CreateFullStackedSplineAreaChartItem();
            CreateSplineAreaChartItem createSplineAreaChartItem = new CreateSplineAreaChartItem();
            CreateStackedAreaChartItem createStackedAreaChartItem = new CreateStackedAreaChartItem();
            CreateStackedSplineAreaChartItem createStackedSplineAreaChartItem = new CreateStackedSplineAreaChartItem();
            CreateStepAreaChartItem createStepAreaChartItem = new CreateStepAreaChartItem();
            ChartControlCommandGalleryItemGroup3DArea chartControlCommandGalleryItemGroup3DArea = new ChartControlCommandGalleryItemGroup3DArea();
            CreateArea3DChartItem createArea3DChartItem = new CreateArea3DChartItem();
            CreateFullStackedArea3DChartItem createFullStackedArea3DChartItem = new CreateFullStackedArea3DChartItem();
            CreateFullStackedSplineArea3DChartItem createFullStackedSplineArea3DChartItem = new CreateFullStackedSplineArea3DChartItem();
            CreateSplineArea3DChartItem createSplineArea3DChartItem = new CreateSplineArea3DChartItem();
            CreateStackedArea3DChartItem createStackedArea3DChartItem = new CreateStackedArea3DChartItem();
            CreateStackedSplineArea3DChartItem createStackedSplineArea3DChartItem = new CreateStackedSplineArea3DChartItem();
            CreateStepArea3DChartItem createStepArea3DChartItem = new CreateStepArea3DChartItem();
            ChartControlCommandGalleryItemGroupPoint chartControlCommandGalleryItemGroupPoint = new ChartControlCommandGalleryItemGroupPoint();
            CreatePointChartItem createPointChartItem = new CreatePointChartItem();
            CreateBubbleChartItem createBubbleChartItem = new CreateBubbleChartItem();
            ChartControlCommandGalleryItemGroupFunnel chartControlCommandGalleryItemGroupFunnel = new ChartControlCommandGalleryItemGroupFunnel();
            CreateFunnelChartItem createFunnelChartItem = new CreateFunnelChartItem();
            CreateFunnel3DChartItem createFunnel3DChartItem = new CreateFunnel3DChartItem();
            ChartControlCommandGalleryItemGroupFinancial chartControlCommandGalleryItemGroupFinancial = new ChartControlCommandGalleryItemGroupFinancial();
            CreateStockChartItem createStockChartItem = new CreateStockChartItem();
            CreateCandleStickChartItem createCandleStickChartItem = new CreateCandleStickChartItem();
            ChartControlCommandGalleryItemGroupRadar chartControlCommandGalleryItemGroupRadar = new ChartControlCommandGalleryItemGroupRadar();
            CreateRadarPointChartItem createRadarPointChartItem = new CreateRadarPointChartItem();
            CreateRadarLineChartItem createRadarLineChartItem = new CreateRadarLineChartItem();
            CreateRadarAreaChartItem createRadarAreaChartItem = new CreateRadarAreaChartItem();
            ChartControlCommandGalleryItemGroupPolar chartControlCommandGalleryItemGroupPolar = new ChartControlCommandGalleryItemGroupPolar();
            CreatePolarPointChartItem createPolarPointChartItem = new CreatePolarPointChartItem();
            CreatePolarLineChartItem createPolarLineChartItem = new CreatePolarLineChartItem();
            CreatePolarAreaChartItem createPolarAreaChartItem = new CreatePolarAreaChartItem();
            ChartControlCommandGalleryItemGroupRange chartControlCommandGalleryItemGroupRange = new ChartControlCommandGalleryItemGroupRange();
            CreateRangeBarChartItem createRangeBarChartItem = new CreateRangeBarChartItem();
            CreateSideBySideRangeBarChartItem createSideBySideRangeBarChartItem = new CreateSideBySideRangeBarChartItem();
            CreateRangeAreaChartItem createRangeAreaChartItem = new CreateRangeAreaChartItem();
            CreateRangeArea3DChartItem createRangeArea3DChartItem = new CreateRangeArea3DChartItem();
            ChartControlCommandGalleryItemGroupGantt chartControlCommandGalleryItemGroupGantt = new ChartControlCommandGalleryItemGroupGantt();
            CreateGanttChartItem createGanttChartItem = new CreateGanttChartItem();
            CreateSideBySideGanttChartItem createSideBySideGanttChartItem = new CreateSideBySideGanttChartItem();
            this.panelControl1 = new PanelControl();
            this.treeList1 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.panelControl5 = new PanelControl();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.panelControl3 = new PanelControl();
            this.groupControl2 = new GroupControl();
            this.labelControl5 = new LabelControl();
            this.colorEdit1 = new ColorEdit();
            this.barManager1 = new BarManager(this.components);
            this.chartAppearanceBar1 = new ChartAppearanceBar();
            this.chartControl1 = new ChartControl();
            this.chartTemplatesBar1 = new ChartTemplatesBar();
            this.saveAsTemplateChartItem1 = new SaveAsTemplateChartItem();
            this.printPreviewChartItem1 = new PrintPreviewChartItem();
            this.printChartItem1 = new PrintChartItem();
            this.changePaletteGalleryBaseItem1 = new ChangePaletteGalleryBaseItem();
            this.commandBarGalleryDropDown7 = new CommandBarGalleryDropDown(this.components);
            this.changeAppearanceGalleryBaseBarManagerItem1 = new ChangeAppearanceGalleryBaseBarManagerItem();
            this.commandBarGalleryDropDown8 = new CommandBarGalleryDropDown(this.components);
            this.createExportBaseItem1 = new CreateExportBaseItem();
            this.exportToPDFChartItem1 = new ExportToPDFChartItem();
            this.exportToHTMLChartItem1 = new ExportToHTMLChartItem();
            this.exportToMHTChartItem1 = new ExportToMHTChartItem();
            this.exportToXLSChartItem1 = new ExportToXLSChartItem();
            this.exportToXLSXChartItem1 = new ExportToXLSXChartItem();
            this.exportToRTFChartItem1 = new ExportToRTFChartItem();
            this.createExportToImageBaseItem1 = new CreateExportToImageBaseItem();
            this.exportToBMPChartItem1 = new ExportToBMPChartItem();
            this.exportToGIFChartItem1 = new ExportToGIFChartItem();
            this.exportToJPEGChartItem1 = new ExportToJPEGChartItem();
            this.exportToPNGChartItem1 = new ExportToPNGChartItem();
            this.exportToTIFFChartItem1 = new ExportToTIFFChartItem();
            this.chartPrintExportBar1 = new ChartPrintExportBar();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.createBarBaseItem1 = new CreateBarBaseItem();
            this.commandBarGalleryDropDown1 = new CommandBarGalleryDropDown(this.components);
            this.createLineBaseItem1 = new CreateLineBaseItem();
            this.commandBarGalleryDropDown2 = new CommandBarGalleryDropDown(this.components);
            this.createPieBaseItem1 = new CreatePieBaseItem();
            this.commandBarGalleryDropDown3 = new CommandBarGalleryDropDown(this.components);
            this.createRotatedBarBaseItem1 = new CreateRotatedBarBaseItem();
            this.commandBarGalleryDropDown4 = new CommandBarGalleryDropDown(this.components);
            this.createAreaBaseItem1 = new CreateAreaBaseItem();
            this.commandBarGalleryDropDown5 = new CommandBarGalleryDropDown(this.components);
            this.createOtherSeriesTypesBaseItem1 = new CreateOtherSeriesTypesBaseItem();
            this.commandBarGalleryDropDown6 = new CommandBarGalleryDropDown(this.components);
            this.checkEdit1 = new CheckEdit();
            this.spinEdit3 = new SpinEdit();
            this.labelControl6 = new LabelControl();
            this.panelControl4 = new PanelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chartBarController1 = new ChartBarController();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.treeList1).BeginInit();
            ((ISupportInitialize)this.panelControl5).BeginInit();
            this.panelControl5.SuspendLayout();
            ((ISupportInitialize)this.panelControl3).BeginInit();
            this.panelControl3.SuspendLayout();
            ((ISupportInitialize)this.groupControl2).BeginInit();
            this.groupControl2.SuspendLayout();
            ((ISupportInitialize)this.colorEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.barManager1).BeginInit();
            ((ISupportInitialize)this.chartControl1).BeginInit();
            ((ISupportInitialize)swiftPlotDiagram).BeginInit();
            ((ISupportInitialize)series).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView).BeginInit();
            ((ISupportInitialize)series2).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView2).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView3).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown7).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown8).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown1).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown2).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown3).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown4).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown5).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown6).BeginInit();
            ((ISupportInitialize)this.checkEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.spinEdit3.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl4).BeginInit();
            this.panelControl4.SuspendLayout();
            ((ISupportInitialize)this.chartBarController1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Dock = DockStyle.Left;
            this.panelControl1.Location = new Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(146, 532);
            this.panelControl1.TabIndex = 0;
            this.treeList1.Columns.AddRange(new TreeListColumn[]
			{
				this.treeListColumn1,
				this.treeListColumn2,
				this.treeListColumn3
			});
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new Point(2, 79);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.Size = new Size(142, 451);
            this.treeList1.TabIndex = 1;
            this.treeList1.AfterFocusNode += new NodeEventHandler(this.treeList1_AfterFocusNode);
            this.treeListColumn1.Caption = "编号";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 32;
            this.treeListColumn2.Caption = "测量对象";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 92;
            this.treeListColumn3.Caption = "测量对象类型";
            this.treeListColumn3.FieldName = "TypeId";
            this.treeListColumn3.Name = "treeListColumn3";
            this.panelControl5.Controls.Add(this.simpleButton2);
            this.panelControl5.Controls.Add(this.simpleButton1);
            this.panelControl5.Dock = DockStyle.Top;
            this.panelControl5.Location = new Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(142, 77);
            this.panelControl5.TabIndex = 0;
            this.simpleButton2.Image = (Image)componentResourceManager.GetObject("simpleButton2.Image");
            this.simpleButton2.Location = new Point(23, 42);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(89, 30);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "停止监测\r\n";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image)componentResourceManager.GetObject("simpleButton1.Image");
            this.simpleButton1.Location = new Point(23, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(89, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "开始监测";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.panelControl3.Controls.Add(this.groupControl2);
            this.panelControl3.Dock = DockStyle.Bottom;
            this.panelControl3.Location = new Point(146, 493);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(778, 70);
            this.panelControl3.TabIndex = 2;
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.colorEdit1);
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Controls.Add(this.spinEdit3);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Dock = DockStyle.Fill;
            this.groupControl2.Location = new Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(774, 66);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "参数设定";
            this.labelControl5.Location = new Point(101, 35);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(36, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "颜色：";
            this.colorEdit1.EditValue = Color.Empty;
            this.colorEdit1.Location = new Point(143, 33);
            this.colorEdit1.MenuManager = this.barManager1;
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.colorEdit1.Size = new Size(61, 20);
            this.colorEdit1.TabIndex = 13;
            this.colorEdit1.EditValueChanged += new EventHandler(this.colorEdit1_EditValueChanged);
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[]
			{
				this.chartAppearanceBar1,
				this.chartTemplatesBar1,
				this.chartPrintExportBar1
			});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[]
			{
				this.createBarBaseItem1,
				this.createLineBaseItem1,
				this.createPieBaseItem1,
				this.createRotatedBarBaseItem1,
				this.createAreaBaseItem1,
				this.createOtherSeriesTypesBaseItem1,
				this.changePaletteGalleryBaseItem1,
				this.changeAppearanceGalleryBaseBarManagerItem1,
				this.saveAsTemplateChartItem1,
				this.printPreviewChartItem1,
				this.printChartItem1,
				this.createExportBaseItem1,
				this.exportToPDFChartItem1,
				this.exportToHTMLChartItem1,
				this.exportToMHTChartItem1,
				this.exportToXLSChartItem1,
				this.exportToXLSXChartItem1,
				this.exportToRTFChartItem1,
				this.exportToBMPChartItem1,
				this.exportToGIFChartItem1,
				this.exportToJPEGChartItem1,
				this.exportToPNGChartItem1,
				this.exportToTIFFChartItem1,
				this.createExportToImageBaseItem1
			});
            this.barManager1.MaxItemId = 27;
            this.chartAppearanceBar1.BarName = "";
            this.chartAppearanceBar1.Control = this.chartControl1;
            this.chartAppearanceBar1.DockCol = 2;
            this.chartAppearanceBar1.DockRow = 0;
            this.chartAppearanceBar1.DockStyle = BarDockStyle.Top;
            this.chartAppearanceBar1.OptionsBar.DrawBorder = false;
            this.chartAppearanceBar1.OptionsBar.DrawDragBorder = false;
            this.chartAppearanceBar1.Text = "";
            swiftPlotDiagram.AxisX.GridLines.Color = Color.LightGray;
            swiftPlotDiagram.AxisX.GridLines.MinorColor = Color.LightGray;
            swiftPlotDiagram.AxisX.MinorCount = 1;
            swiftPlotDiagram.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram.AxisY.GridLines.Color = Color.White;
            swiftPlotDiagram.AxisY.GridLines.MinorColor = Color.LightGray;
            swiftPlotDiagram.AxisY.Interlaced = true;
            swiftPlotDiagram.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram.EnableAxisXScrolling = true;
            swiftPlotDiagram.EnableAxisXZooming = true;
            swiftPlotDiagram.EnableAxisYScrolling = true;
            swiftPlotDiagram.EnableAxisYZooming = true;
            this.chartControl1.Diagram = swiftPlotDiagram;
            this.chartControl1.Dock = DockStyle.Fill;
            this.chartControl1.Location = new Point(2, 2);
            this.chartControl1.Name = "chartControl1";
            series.ArgumentScaleType = ScaleType.DateTime;
            series.LabelsVisibility = DefaultBoolean.True;
            series.LegendText = "实时波形";
            series.Name = "实时波形";
            series.View = swiftPlotSeriesView;
            series2.ArgumentScaleType = ScaleType.DateTime;
            series2.LegendText = "标准波形";
            series2.Name = "标准波形";
            series2.TopNOptions.ThresholdPercent = 1.0;
            series2.TopNOptions.ThresholdValue = 1.0;
            series2.View = swiftPlotSeriesView2;
            this.chartControl1.SeriesSerializable = new Series[]
			{
				series,
				series2
			};
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView3;
            this.chartControl1.Size = new Size(774, 458);
            this.chartControl1.TabIndex = 0;
            this.chartTemplatesBar1.Control = this.chartControl1;
            this.chartTemplatesBar1.DockCol = 0;
            this.chartTemplatesBar1.DockRow = 0;
            this.chartTemplatesBar1.DockStyle = BarDockStyle.Top;
            this.chartTemplatesBar1.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.saveAsTemplateChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printPreviewChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changePaletteGalleryBaseItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changeAppearanceGalleryBaseBarManagerItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.createExportBaseItem1, BarItemPaintStyle.CaptionGlyph)
			});
            this.chartTemplatesBar1.OptionsBar.DrawBorder = false;
            this.chartTemplatesBar1.OptionsBar.DrawDragBorder = false;
            this.saveAsTemplateChartItem1.Caption = "保存";
            this.saveAsTemplateChartItem1.Id = 9;
            this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
            toolTipTitleItem.Text = "保存";
            toolTipItem.LeftIndent = 6;
            toolTipItem.Text = "以XML格式保存当前波形的数据";
            superToolTip.Items.Add(toolTipTitleItem);
            superToolTip.Items.Add(toolTipItem);
            this.saveAsTemplateChartItem1.SuperTip = superToolTip;
            this.printPreviewChartItem1.Caption = "预览";
            this.printPreviewChartItem1.Id = 11;
            this.printPreviewChartItem1.Name = "printPreviewChartItem1";
            toolTipTitleItem2.Text = "预览";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "打印前预览和编辑波形";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.printPreviewChartItem1.SuperTip = superToolTip2;
            this.printChartItem1.Caption = "打印";
            this.printChartItem1.Id = 12;
            this.printChartItem1.Name = "printChartItem1";
            toolTipTitleItem3.Text = "打印";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "选择打印机或其它打印设备打印当前波形";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.printChartItem1.SuperTip = superToolTip3;
            this.changePaletteGalleryBaseItem1.Caption = "线条颜色";
            this.changePaletteGalleryBaseItem1.DropDownControl = this.commandBarGalleryDropDown7;
            this.changePaletteGalleryBaseItem1.Id = 6;
            this.changePaletteGalleryBaseItem1.Name = "changePaletteGalleryBaseItem1";
            this.changePaletteGalleryBaseItem1.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            toolTipTitleItem4.Text = "线条颜色";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "改变当前图表的线条样式";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.changePaletteGalleryBaseItem1.SuperTip = superToolTip4;
            this.commandBarGalleryDropDown7.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.TextOptions.HAlignment = HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.ColumnCount = 1;
            this.commandBarGalleryDropDown7.Gallery.ImageSize = new Size(160, 10);
            this.commandBarGalleryDropDown7.Gallery.ItemImageLayout = ImageLayoutMode.MiddleLeft;
            this.commandBarGalleryDropDown7.Gallery.ItemImageLocation = Locations.Right;
            skinPaddingEdges.Bottom = -3;
            skinPaddingEdges.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemImagePadding = skinPaddingEdges;
            skinPaddingEdges2.Bottom = -3;
            skinPaddingEdges2.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemTextPadding = skinPaddingEdges2;
            this.commandBarGalleryDropDown7.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown7.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown7.Gallery.ShowItemText = true;
            this.commandBarGalleryDropDown7.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown7.Manager = this.barManager1;
            this.commandBarGalleryDropDown7.Name = "commandBarGalleryDropDown7";
            this.changeAppearanceGalleryBaseBarManagerItem1.Caption = "画板";
            this.changeAppearanceGalleryBaseBarManagerItem1.DropDownControl = this.commandBarGalleryDropDown8;
            this.changeAppearanceGalleryBaseBarManagerItem1.GlyphDisabled = (Image)componentResourceManager.GetObject("changeAppearanceGalleryBaseBarManagerItem1.GlyphDisabled");
            this.changeAppearanceGalleryBaseBarManagerItem1.Id = 7;
            this.changeAppearanceGalleryBaseBarManagerItem1.Name = "changeAppearanceGalleryBaseBarManagerItem1";
            toolTipTitleItem5.Text = "画板";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "包含通过选择调色板来改变其外观的一系列样式的图表";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.changeAppearanceGalleryBaseBarManagerItem1.SuperTip = superToolTip5;
            this.commandBarGalleryDropDown8.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown8.Gallery.ColumnCount = 7;
            this.commandBarGalleryDropDown8.Gallery.ImageSize = new Size(80, 50);
            this.commandBarGalleryDropDown8.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown8.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown8.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown8.Manager = this.barManager1;
            this.commandBarGalleryDropDown8.Name = "commandBarGalleryDropDown8";
            this.createExportBaseItem1.Caption = "导出 ";
            this.createExportBaseItem1.Id = 13;
            this.createExportBaseItem1.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.exportToPDFChartItem1),
				new LinkPersistInfo(this.exportToHTMLChartItem1),
				new LinkPersistInfo(this.exportToMHTChartItem1),
				new LinkPersistInfo(this.exportToXLSChartItem1),
				new LinkPersistInfo(this.exportToXLSXChartItem1),
				new LinkPersistInfo(this.exportToRTFChartItem1),
				new LinkPersistInfo(this.createExportToImageBaseItem1)
			});
            this.createExportBaseItem1.MenuDrawMode = MenuDrawMode.SmallImagesText;
            this.createExportBaseItem1.Name = "createExportBaseItem1";
            toolTipTitleItem6.Text = "导出 ";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "可将当前波形导出为指定格式的的文件并保存";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.createExportBaseItem1.SuperTip = superToolTip6;
            this.exportToPDFChartItem1.Id = 14;
            this.exportToPDFChartItem1.Name = "exportToPDFChartItem1";
            this.exportToHTMLChartItem1.Id = 15;
            this.exportToHTMLChartItem1.Name = "exportToHTMLChartItem1";
            this.exportToMHTChartItem1.Id = 16;
            this.exportToMHTChartItem1.Name = "exportToMHTChartItem1";
            this.exportToXLSChartItem1.Id = 17;
            this.exportToXLSChartItem1.Name = "exportToXLSChartItem1";
            this.exportToXLSXChartItem1.Id = 18;
            this.exportToXLSXChartItem1.Name = "exportToXLSXChartItem1";
            this.exportToRTFChartItem1.Id = 19;
            this.exportToRTFChartItem1.Name = "exportToRTFChartItem1";
            this.createExportToImageBaseItem1.Id = 20;
            this.createExportToImageBaseItem1.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.exportToBMPChartItem1),
				new LinkPersistInfo(this.exportToGIFChartItem1),
				new LinkPersistInfo(this.exportToJPEGChartItem1),
				new LinkPersistInfo(this.exportToPNGChartItem1),
				new LinkPersistInfo(this.exportToTIFFChartItem1)
			});
            this.createExportToImageBaseItem1.MenuDrawMode = MenuDrawMode.SmallImagesText;
            this.createExportToImageBaseItem1.Name = "createExportToImageBaseItem1";
            this.exportToBMPChartItem1.Id = 21;
            this.exportToBMPChartItem1.Name = "exportToBMPChartItem1";
            this.exportToGIFChartItem1.Id = 22;
            this.exportToGIFChartItem1.Name = "exportToGIFChartItem1";
            this.exportToJPEGChartItem1.Id = 23;
            this.exportToJPEGChartItem1.Name = "exportToJPEGChartItem1";
            this.exportToPNGChartItem1.Id = 24;
            this.exportToPNGChartItem1.Name = "exportToPNGChartItem1";
            this.exportToTIFFChartItem1.Id = 25;
            this.exportToTIFFChartItem1.Name = "exportToTIFFChartItem1";
            this.chartPrintExportBar1.BarName = "";
            this.chartPrintExportBar1.Control = this.chartControl1;
            this.chartPrintExportBar1.DockCol = 1;
            this.chartPrintExportBar1.DockRow = 0;
            this.chartPrintExportBar1.DockStyle = BarDockStyle.Top;
            this.chartPrintExportBar1.Offset = 71;
            this.chartPrintExportBar1.OptionsBar.DrawBorder = false;
            this.chartPrintExportBar1.OptionsBar.DrawDragBorder = false;
            this.chartPrintExportBar1.Text = "";
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(924, 31);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 563);
            this.barDockControlBottom.Size = new Size(924, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 31);
            this.barDockControlLeft.Size = new Size(0, 532);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(924, 31);
            this.barDockControlRight.Size = new Size(0, 532);
            this.createBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown1;
            this.createBarBaseItem1.Id = 0;
            this.createBarBaseItem1.Name = "createBarBaseItem1";
            this.commandBarGalleryDropDown1.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown1.Gallery.ColumnCount = 4;
            chartControlCommandGalleryItemGroup2DColumn.Items.AddRange(new GalleryItem[]
			{
				createBarChartItem,
				createFullStackedBarChartItem,
				createSideBySideFullStackedBarChartItem,
				createSideBySideStackedBarChartItem,
				createStackedBarChartItem
			});
            chartControlCommandGalleryItemGroup3DColumn.Items.AddRange(new GalleryItem[]
			{
				createBar3DChartItem,
				createFullStackedBar3DChartItem,
				createManhattanBarChartItem,
				createSideBySideFullStackedBar3DChartItem,
				createSideBySideStackedBar3DChartItem,
				createStackedBar3DChartItem
			});
            chartControlCommandGalleryItemGroupCylinderColumn.Items.AddRange(new GalleryItem[]
			{
				createCylinderBar3DChartItem,
				createCylinderFullStackedBar3DChartItem,
				createCylinderManhattanBarChartItem,
				createCylinderSideBySideFullStackedBar3DChartItem,
				createCylinderSideBySideStackedBar3DChartItem,
				createCylinderStackedBar3DChartItem
			});
            chartControlCommandGalleryItemGroupConeColumn.Items.AddRange(new GalleryItem[]
			{
				createConeBar3DChartItem,
				createConeFullStackedBar3DChartItem,
				createConeManhattanBarChartItem,
				createConeSideBySideFullStackedBar3DChartItem,
				createConeSideBySideStackedBar3DChartItem,
				createConeStackedBar3DChartItem
			});
            chartControlCommandGalleryItemGroupPyramidColumn.Items.AddRange(new GalleryItem[]
			{
				createPyramidBar3DChartItem,
				createPyramidFullStackedBar3DChartItem,
				createPyramidManhattanBarChartItem,
				createPyramidSideBySideFullStackedBar3DChartItem,
				createPyramidSideBySideStackedBar3DChartItem,
				createPyramidStackedBar3DChartItem
			});
            this.commandBarGalleryDropDown1.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroup2DColumn,
				chartControlCommandGalleryItemGroup3DColumn,
				chartControlCommandGalleryItemGroupCylinderColumn,
				chartControlCommandGalleryItemGroupConeColumn,
				chartControlCommandGalleryItemGroupPyramidColumn
			});
            this.commandBarGalleryDropDown1.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown1.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown1.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown1.Manager = this.barManager1;
            this.commandBarGalleryDropDown1.Name = "commandBarGalleryDropDown1";
            this.createLineBaseItem1.DropDownControl = this.commandBarGalleryDropDown2;
            this.createLineBaseItem1.Id = 1;
            this.createLineBaseItem1.Name = "createLineBaseItem1";
            this.commandBarGalleryDropDown2.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown2.Gallery.ColumnCount = 3;
            chartControlCommandGalleryItemGroup2DLine.Items.AddRange(new GalleryItem[]
			{
				createLineChartItem,
				createFullStackedLineChartItem,
				createScatterLineChartItem,
				createSplineChartItem,
				createStackedLineChartItem,
				createStepLineChartItem
			});
            chartControlCommandGalleryItemGroup3DLine.Items.AddRange(new GalleryItem[]
			{
				createLine3DChartItem,
				createFullStackedLine3DChartItem,
				createSpline3DChartItem,
				createStackedLine3DChartItem,
				createStepLine3DChartItem
			});
            this.commandBarGalleryDropDown2.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroup2DLine,
				chartControlCommandGalleryItemGroup3DLine
			});
            this.commandBarGalleryDropDown2.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown2.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown2.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown2.Manager = this.barManager1;
            this.commandBarGalleryDropDown2.Name = "commandBarGalleryDropDown2";
            this.createPieBaseItem1.DropDownControl = this.commandBarGalleryDropDown3;
            this.createPieBaseItem1.Id = 2;
            this.createPieBaseItem1.Name = "createPieBaseItem1";
            this.commandBarGalleryDropDown3.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown3.Gallery.ColumnCount = 2;
            chartControlCommandGalleryItemGroup2DPie.Items.AddRange(new GalleryItem[]
			{
				createPieChartItem,
				createDoughnutChartItem
			});
            chartControlCommandGalleryItemGroup3DPie.Items.AddRange(new GalleryItem[]
			{
				createPie3DChartItem,
				createDoughnut3DChartItem
			});
            this.commandBarGalleryDropDown3.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroup2DPie,
				chartControlCommandGalleryItemGroup3DPie
			});
            this.commandBarGalleryDropDown3.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown3.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown3.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown3.Manager = this.barManager1;
            this.commandBarGalleryDropDown3.Name = "commandBarGalleryDropDown3";
            this.createRotatedBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown4;
            this.createRotatedBarBaseItem1.Id = 3;
            this.createRotatedBarBaseItem1.Name = "createRotatedBarBaseItem1";
            this.commandBarGalleryDropDown4.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown4.Gallery.ColumnCount = 3;
            chartControlCommandGalleryItemGroup2DBar.Items.AddRange(new GalleryItem[]
			{
				createRotatedBarChartItem,
				createRotatedFullStackedBarChartItem,
				createRotatedSideBySideFullStackedBarChartItem,
				createRotatedSideBySideStackedBarChartItem,
				createRotatedStackedBarChartItem
			});
            this.commandBarGalleryDropDown4.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroup2DBar
			});
            this.commandBarGalleryDropDown4.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown4.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown4.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown4.Manager = this.barManager1;
            this.commandBarGalleryDropDown4.Name = "commandBarGalleryDropDown4";
            this.createAreaBaseItem1.DropDownControl = this.commandBarGalleryDropDown5;
            this.createAreaBaseItem1.Id = 4;
            this.createAreaBaseItem1.Name = "createAreaBaseItem1";
            this.commandBarGalleryDropDown5.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown5.Gallery.ColumnCount = 4;
            chartControlCommandGalleryItemGroup2DArea.Items.AddRange(new GalleryItem[]
			{
				createAreaChartItem,
				createFullStackedAreaChartItem,
				createFullStackedSplineAreaChartItem,
				createSplineAreaChartItem,
				createStackedAreaChartItem,
				createStackedSplineAreaChartItem,
				createStepAreaChartItem
			});
            chartControlCommandGalleryItemGroup3DArea.Items.AddRange(new GalleryItem[]
			{
				createArea3DChartItem,
				createFullStackedArea3DChartItem,
				createFullStackedSplineArea3DChartItem,
				createSplineArea3DChartItem,
				createStackedArea3DChartItem,
				createStackedSplineArea3DChartItem,
				createStepArea3DChartItem
			});
            this.commandBarGalleryDropDown5.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroup2DArea,
				chartControlCommandGalleryItemGroup3DArea
			});
            this.commandBarGalleryDropDown5.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown5.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown5.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown5.Manager = this.barManager1;
            this.commandBarGalleryDropDown5.Name = "commandBarGalleryDropDown5";
            this.createOtherSeriesTypesBaseItem1.DropDownControl = this.commandBarGalleryDropDown6;
            this.createOtherSeriesTypesBaseItem1.Id = 5;
            this.createOtherSeriesTypesBaseItem1.Name = "createOtherSeriesTypesBaseItem1";
            this.commandBarGalleryDropDown6.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown6.Gallery.ColumnCount = 4;
            chartControlCommandGalleryItemGroupPoint.Items.AddRange(new GalleryItem[]
			{
				createPointChartItem,
				createBubbleChartItem
			});
            chartControlCommandGalleryItemGroupFunnel.Items.AddRange(new GalleryItem[]
			{
				createFunnelChartItem,
				createFunnel3DChartItem
			});
            chartControlCommandGalleryItemGroupFinancial.Items.AddRange(new GalleryItem[]
			{
				createStockChartItem,
				createCandleStickChartItem
			});
            chartControlCommandGalleryItemGroupRadar.Items.AddRange(new GalleryItem[]
			{
				createRadarPointChartItem,
				createRadarLineChartItem,
				createRadarAreaChartItem
			});
            chartControlCommandGalleryItemGroupPolar.Items.AddRange(new GalleryItem[]
			{
				createPolarPointChartItem,
				createPolarLineChartItem,
				createPolarAreaChartItem
			});
            chartControlCommandGalleryItemGroupRange.Items.AddRange(new GalleryItem[]
			{
				createRangeBarChartItem,
				createSideBySideRangeBarChartItem,
				createRangeAreaChartItem,
				createRangeArea3DChartItem
			});
            chartControlCommandGalleryItemGroupGantt.Items.AddRange(new GalleryItem[]
			{
				createGanttChartItem,
				createSideBySideGanttChartItem
			});
            this.commandBarGalleryDropDown6.Gallery.Groups.AddRange(new GalleryItemGroup[]
			{
				chartControlCommandGalleryItemGroupPoint,
				chartControlCommandGalleryItemGroupFunnel,
				chartControlCommandGalleryItemGroupFinancial,
				chartControlCommandGalleryItemGroupRadar,
				chartControlCommandGalleryItemGroupPolar,
				chartControlCommandGalleryItemGroupRange,
				chartControlCommandGalleryItemGroupGantt
			});
            this.commandBarGalleryDropDown6.Gallery.ImageSize = new Size(32, 32);
            this.commandBarGalleryDropDown6.Gallery.RowCount = 7;
            this.commandBarGalleryDropDown6.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown6.Manager = this.barManager1;
            this.commandBarGalleryDropDown6.Name = "commandBarGalleryDropDown6";
            this.checkEdit1.Location = new Point(5, 32);
            this.checkEdit1.MenuManager = this.barManager1;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "网格线";
            this.checkEdit1.Size = new Size(75, 19);
            this.checkEdit1.TabIndex = 12;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            BaseEdit arg_26E2_0 = this.spinEdit3;
            int[] array = new int[4];
            array[0] = 10;
            arg_26E2_0.EditValue = new decimal(array);
            this.spinEdit3.Location = new Point(323, 32);
            this.spinEdit3.Name = "spinEdit3";
            this.spinEdit3.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            RepositoryItemSpinEdit arg_2758_0 = this.spinEdit3.Properties;
            array = new int[4];
            array[0] = 19;
            arg_2758_0.MaxValue = new decimal(array);
            RepositoryItemSpinEdit arg_277C_0 = this.spinEdit3.Properties;
            array = new int[4];
            array[0] = 1;
            arg_277C_0.MinValue = new decimal(array);
            this.spinEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.spinEdit3.Size = new Size(65, 20);
            this.spinEdit3.TabIndex = 11;
            this.labelControl6.Location = new Point(249, 35);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(60, 14);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "移动速度：";
            this.panelControl4.Controls.Add(this.chartControl1);
            this.panelControl4.Dock = DockStyle.Fill;
            this.panelControl4.Location = new Point(146, 31);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(778, 462);
            this.panelControl4.TabIndex = 3;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.chartBarController1.BarItems.Add(this.createBarBaseItem1);
            this.chartBarController1.BarItems.Add(this.createLineBaseItem1);
            this.chartBarController1.BarItems.Add(this.createPieBaseItem1);
            this.chartBarController1.BarItems.Add(this.createRotatedBarBaseItem1);
            this.chartBarController1.BarItems.Add(this.createAreaBaseItem1);
            this.chartBarController1.BarItems.Add(this.createOtherSeriesTypesBaseItem1);
            this.chartBarController1.BarItems.Add(this.changePaletteGalleryBaseItem1);
            this.chartBarController1.BarItems.Add(this.changeAppearanceGalleryBaseBarManagerItem1);
            this.chartBarController1.BarItems.Add(this.saveAsTemplateChartItem1);
            this.chartBarController1.BarItems.Add(this.printPreviewChartItem1);
            this.chartBarController1.BarItems.Add(this.printChartItem1);
            this.chartBarController1.BarItems.Add(this.createExportBaseItem1);
            this.chartBarController1.BarItems.Add(this.exportToPDFChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToHTMLChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToMHTChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToXLSChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToXLSXChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToRTFChartItem1);
            this.chartBarController1.BarItems.Add(this.createExportToImageBaseItem1);
            this.chartBarController1.BarItems.Add(this.exportToBMPChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToGIFChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToJPEGChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToPNGChartItem1);
            this.chartBarController1.BarItems.Add(this.exportToTIFFChartItem1);
            this.chartBarController1.Control = this.chartControl1;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(924, 563);
            base.Controls.Add(this.panelControl4);
            base.Controls.Add(this.panelControl3);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmOscillogram";
            this.Text = "波形监控";
            base.Load += new EventHandler(this.FrmOscillogram_Load);
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((ISupportInitialize)this.treeList1).EndInit();
            ((ISupportInitialize)this.panelControl5).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl3).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((ISupportInitialize)this.groupControl2).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((ISupportInitialize)this.colorEdit1.Properties).EndInit();
            ((ISupportInitialize)this.barManager1).EndInit();
            ((ISupportInitialize)swiftPlotDiagram).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView).EndInit();
            ((ISupportInitialize)series).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView2).EndInit();
            ((ISupportInitialize)series2).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView3).EndInit();
            ((ISupportInitialize)this.chartControl1).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown7).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown8).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown1).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown2).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown3).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown4).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown5).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown6).EndInit();
            ((ISupportInitialize)this.checkEdit1.Properties).EndInit();
            ((ISupportInitialize)this.spinEdit3.Properties).EndInit();
            ((ISupportInitialize)this.panelControl4).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((ISupportInitialize)this.chartBarController1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
