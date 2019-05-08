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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Student
{
    partial class FrmHisOscillogram
    {
        private IContainer components;

        private PanelControl panelControl2;

        private ChartControl chartControl1;

        private GroupControl groupControl2;

        private BarManager barManager1;

        private ChartAppearanceBar chartAppearanceBar1;

        private SaveAsTemplateChartItem saveAsTemplateChartItem1;

        private LoadTemplateChartItem loadTemplateChartItem1;

        private PrintChartItem printChartItem1;

        private PrintPreviewChartItem printPreviewChartItem1;

        private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown7;

        private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;

        private CommandBarGalleryDropDown commandBarGalleryDropDown8;

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

        private RunWizardChartItem runWizardChartItem1;

        private ChartBarController chartBarController1;

        private LabelControl labelControl5;

        private ColorEdit colorEdit1;

        private CheckEdit checkEdit1;

    
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
            SuperToolTip superToolTip5 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem5 = new ToolTipTitleItem();
            ToolTipItem toolTipItem5 = new ToolTipItem();
            SkinPaddingEdges skinPaddingEdges = new SkinPaddingEdges();
            SkinPaddingEdges skinPaddingEdges2 = new SkinPaddingEdges();
            SuperToolTip superToolTip6 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem6 = new ToolTipTitleItem();
            ToolTipItem toolTipItem6 = new ToolTipItem();
            SuperToolTip superToolTip7 = new SuperToolTip();
            ToolTipTitleItem toolTipTitleItem7 = new ToolTipTitleItem();
            ToolTipItem toolTipItem7 = new ToolTipItem();
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
            this.panelControl2 = new PanelControl();
            this.chartControl1 = new ChartControl();
            this.groupControl2 = new GroupControl();
            this.labelControl5 = new LabelControl();
            this.colorEdit1 = new ColorEdit();
            this.barManager1 = new BarManager(this.components);
            this.chartAppearanceBar1 = new ChartAppearanceBar();
            this.loadTemplateChartItem1 = new LoadTemplateChartItem();
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
            this.runWizardChartItem1 = new RunWizardChartItem();
            this.checkEdit1 = new CheckEdit();
            this.chartBarController1 = new ChartBarController();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.chartControl1).BeginInit();
            ((ISupportInitialize)swiftPlotDiagram).BeginInit();
            ((ISupportInitialize)series).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView).BeginInit();
            ((ISupportInitialize)series2).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView2).BeginInit();
            ((ISupportInitialize)swiftPlotSeriesView3).BeginInit();
            ((ISupportInitialize)this.groupControl2).BeginInit();
            this.groupControl2.SuspendLayout();
            ((ISupportInitialize)this.colorEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.barManager1).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown7).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown8).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown1).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown2).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown3).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown4).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown5).BeginInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown6).BeginInit();
            ((ISupportInitialize)this.checkEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.chartBarController1).BeginInit();
            base.SuspendLayout();
            this.panelControl2.Controls.Add(this.chartControl1);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(887, 427);
            this.panelControl2.TabIndex = 1;
            swiftPlotDiagram.AxisX.GridLines.Color = Color.LightGray;
            swiftPlotDiagram.AxisX.GridLines.MinorColor = Color.LightGray;
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
            series.CrosshairEnabled = DefaultBoolean.True;
            series.CrosshairHighlightPoints = DefaultBoolean.True;
            series.CrosshairLabelPattern = "{A:yyyy/MM/dd HH:mm:ss fff}";
            series.CrosshairLabelVisibility = DefaultBoolean.True;
            series.LegendText = "实时波形";
            series.Name = "实时波形";
            series.View = swiftPlotSeriesView;
            series2.ArgumentScaleType = ScaleType.DateTime;
            series2.CrosshairEnabled = DefaultBoolean.True;
            series2.CrosshairHighlightPoints = DefaultBoolean.True;
            series2.CrosshairLabelPattern = "{A:yyyy/MM/dd HH:mm:ss fff}";
            series2.CrosshairLabelVisibility = DefaultBoolean.True;
            series2.LegendText = "标准波形";
            series2.Name = "标准波形";
            series2.View = swiftPlotSeriesView2;
            this.chartControl1.SeriesSerializable = new Series[]
			{
				series,
				series2
			};
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView3;
            this.chartControl1.Size = new Size(883, 423);
            this.chartControl1.TabIndex = 0;
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.colorEdit1);
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Dock = DockStyle.Bottom;
            this.groupControl2.Location = new Point(0, 458);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(887, 56);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "参数设定";
            this.labelControl5.Location = new Point(102, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(60, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "网格颜色：";
            this.colorEdit1.EditValue = Color.Empty;
            this.colorEdit1.Location = new Point(168, 24);
            this.colorEdit1.MenuManager = this.barManager1;
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.colorEdit1.Size = new Size(61, 20);
            this.colorEdit1.TabIndex = 18;
            this.colorEdit1.EditValueChanged += new EventHandler(this.colorEdit1_EditValueChanged);
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[]
			{
				this.chartAppearanceBar1
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
				this.runWizardChartItem1,
				this.saveAsTemplateChartItem1,
				this.loadTemplateChartItem1,
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
            this.barManager1.MaxItemId = 26;
            this.chartAppearanceBar1.Control = this.chartControl1;
            this.chartAppearanceBar1.DockCol = 0;
            this.chartAppearanceBar1.DockRow = 0;
            this.chartAppearanceBar1.DockStyle = BarDockStyle.Top;
            this.chartAppearanceBar1.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.loadTemplateChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.saveAsTemplateChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printPreviewChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printChartItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changePaletteGalleryBaseItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changeAppearanceGalleryBaseBarManagerItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.createExportBaseItem1, BarItemPaintStyle.CaptionGlyph)
			});
            this.chartAppearanceBar1.OptionsBar.DrawDragBorder = false;
            this.chartAppearanceBar1.OptionsBar.UseWholeRow = true;
            this.loadTemplateChartItem1.Caption = "导入波形";
            this.loadTemplateChartItem1.Id = 1;
            this.loadTemplateChartItem1.Name = "loadTemplateChartItem1";
            toolTipTitleItem.Text = "导入波形";
            toolTipItem.LeftIndent = 6;
            toolTipItem.Text = "将本地XML格式波形数据文件导入生成波形";
            superToolTip.Items.Add(toolTipTitleItem);
            superToolTip.Items.Add(toolTipItem);
            this.loadTemplateChartItem1.SuperTip = superToolTip;
            this.saveAsTemplateChartItem1.Caption = "保存";
            this.saveAsTemplateChartItem1.Id = 0;
            this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
            toolTipTitleItem2.Text = "保存";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "以XML格式保存当前波形的数据";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.saveAsTemplateChartItem1.SuperTip = superToolTip2;
            this.printPreviewChartItem1.Caption = "预览";
            this.printPreviewChartItem1.Id = 3;
            this.printPreviewChartItem1.Name = "printPreviewChartItem1";
            toolTipTitleItem3.Text = "预览";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "打印前预览和编辑波形";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.printPreviewChartItem1.SuperTip = superToolTip3;
            this.printChartItem1.Caption = "打印";
            this.printChartItem1.Id = 2;
            this.printChartItem1.Name = "printChartItem1";
            toolTipTitleItem4.Text = "打印";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "选择打印机或其它打印设备打印当前波形";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.printChartItem1.SuperTip = superToolTip4;
            this.changePaletteGalleryBaseItem1.Caption = "线条颜色";
            this.changePaletteGalleryBaseItem1.DropDownControl = this.commandBarGalleryDropDown7;
            this.changePaletteGalleryBaseItem1.Id = 4;
            this.changePaletteGalleryBaseItem1.Name = "changePaletteGalleryBaseItem1";
            toolTipTitleItem5.Text = "线条颜色";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "改变当前图表的线条样式";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.changePaletteGalleryBaseItem1.SuperTip = superToolTip5;
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
            this.changeAppearanceGalleryBaseBarManagerItem1.Id = 5;
            this.changeAppearanceGalleryBaseBarManagerItem1.Name = "changeAppearanceGalleryBaseBarManagerItem1";
            toolTipTitleItem6.Text = "画板";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "包含通过选择调色板来改变其外观的一系列样式的图表";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.changeAppearanceGalleryBaseBarManagerItem1.SuperTip = superToolTip6;
            this.commandBarGalleryDropDown8.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown8.Gallery.ColumnCount = 7;
            this.commandBarGalleryDropDown8.Gallery.ImageSize = new Size(80, 50);
            this.commandBarGalleryDropDown8.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown8.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown8.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown8.Manager = this.barManager1;
            this.commandBarGalleryDropDown8.Name = "commandBarGalleryDropDown8";
            this.createExportBaseItem1.Caption = "导出  ";
            this.createExportBaseItem1.Id = 6;
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
            toolTipTitleItem7.Text = "导出";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "可将当前波形导出为指定格式的的文件并保存";
            superToolTip7.Items.Add(toolTipTitleItem7);
            superToolTip7.Items.Add(toolTipItem7);
            this.createExportBaseItem1.SuperTip = superToolTip7;
            this.exportToPDFChartItem1.Id = 7;
            this.exportToPDFChartItem1.Name = "exportToPDFChartItem1";
            this.exportToHTMLChartItem1.Id = 8;
            this.exportToHTMLChartItem1.Name = "exportToHTMLChartItem1";
            this.exportToMHTChartItem1.Id = 9;
            this.exportToMHTChartItem1.Name = "exportToMHTChartItem1";
            this.exportToXLSChartItem1.Id = 10;
            this.exportToXLSChartItem1.Name = "exportToXLSChartItem1";
            this.exportToXLSXChartItem1.Id = 11;
            this.exportToXLSXChartItem1.Name = "exportToXLSXChartItem1";
            this.exportToRTFChartItem1.Id = 12;
            this.exportToRTFChartItem1.Name = "exportToRTFChartItem1";
            this.createExportToImageBaseItem1.Id = 13;
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
            this.exportToBMPChartItem1.Id = 14;
            this.exportToBMPChartItem1.Name = "exportToBMPChartItem1";
            this.exportToGIFChartItem1.Id = 15;
            this.exportToGIFChartItem1.Name = "exportToGIFChartItem1";
            this.exportToJPEGChartItem1.Id = 16;
            this.exportToJPEGChartItem1.Name = "exportToJPEGChartItem1";
            this.exportToPNGChartItem1.Id = 17;
            this.exportToPNGChartItem1.Name = "exportToPNGChartItem1";
            this.exportToTIFFChartItem1.Id = 18;
            this.exportToTIFFChartItem1.Name = "exportToTIFFChartItem1";
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(887, 31);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 514);
            this.barDockControlBottom.Size = new Size(887, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 31);
            this.barDockControlLeft.Size = new Size(0, 483);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(887, 31);
            this.barDockControlRight.Size = new Size(0, 483);
            this.createBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown1;
            this.createBarBaseItem1.Id = 19;
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
            this.createLineBaseItem1.Id = 20;
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
            this.createPieBaseItem1.Id = 21;
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
            this.createRotatedBarBaseItem1.Id = 22;
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
            this.createAreaBaseItem1.Id = 23;
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
            this.createOtherSeriesTypesBaseItem1.Id = 24;
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
            this.runWizardChartItem1.Id = 25;
            this.runWizardChartItem1.Name = "runWizardChartItem1";
            this.checkEdit1.Location = new Point(6, 25);
            this.checkEdit1.MenuManager = this.barManager1;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "网格线";
            this.checkEdit1.Size = new Size(75, 19);
            this.checkEdit1.TabIndex = 17;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            this.chartBarController1.BarItems.Add(this.createBarBaseItem1);
            this.chartBarController1.BarItems.Add(this.createLineBaseItem1);
            this.chartBarController1.BarItems.Add(this.createPieBaseItem1);
            this.chartBarController1.BarItems.Add(this.createRotatedBarBaseItem1);
            this.chartBarController1.BarItems.Add(this.createAreaBaseItem1);
            this.chartBarController1.BarItems.Add(this.createOtherSeriesTypesBaseItem1);
            this.chartBarController1.BarItems.Add(this.changePaletteGalleryBaseItem1);
            this.chartBarController1.BarItems.Add(this.changeAppearanceGalleryBaseBarManagerItem1);
            this.chartBarController1.BarItems.Add(this.runWizardChartItem1);
            this.chartBarController1.BarItems.Add(this.saveAsTemplateChartItem1);
            this.chartBarController1.BarItems.Add(this.loadTemplateChartItem1);
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
            base.ClientSize = new Size(887, 514);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.groupControl2);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmHisOscillogram";
            this.Text = "历史波形";
            base.Load += new EventHandler(this.FrmHisOscillogram_Load);
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((ISupportInitialize)swiftPlotDiagram).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView).EndInit();
            ((ISupportInitialize)series).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView2).EndInit();
            ((ISupportInitialize)series2).EndInit();
            ((ISupportInitialize)swiftPlotSeriesView3).EndInit();
            ((ISupportInitialize)this.chartControl1).EndInit();
            ((ISupportInitialize)this.groupControl2).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((ISupportInitialize)this.colorEdit1.Properties).EndInit();
            ((ISupportInitialize)this.barManager1).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown7).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown8).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown1).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown2).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown3).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown4).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown5).EndInit();
            ((ISupportInitialize)this.commandBarGalleryDropDown6).EndInit();
            ((ISupportInitialize)this.checkEdit1.Properties).EndInit();
            ((ISupportInitialize)this.chartBarController1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
