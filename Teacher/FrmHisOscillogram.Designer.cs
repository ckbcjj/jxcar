using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Commands;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Teacher
{


    partial class FrmHisOscillogram
    {
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;
        private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;
        private ChartAppearanceBar chartAppearanceBar1;
        private ChartBarController chartBarController1;
        private ChartControl chartControl1;
        private CheckEdit checkEdit1;
        private ColorEdit colorEdit1;
        private CommandBarGalleryDropDown commandBarGalleryDropDown1;
        private CommandBarGalleryDropDown commandBarGalleryDropDown2;
        private CommandBarGalleryDropDown commandBarGalleryDropDown3;
        private CommandBarGalleryDropDown commandBarGalleryDropDown4;
        private CommandBarGalleryDropDown commandBarGalleryDropDown5;
        private CommandBarGalleryDropDown commandBarGalleryDropDown6;
        private CommandBarGalleryDropDown commandBarGalleryDropDown7;
        private CommandBarGalleryDropDown commandBarGalleryDropDown8;
        private IContainer components;
        private CreateAreaBaseItem createAreaBaseItem1;
        private CreateBarBaseItem createBarBaseItem1;
        private CreateExportBaseItem createExportBaseItem1;
        private CreateExportToImageBaseItem createExportToImageBaseItem1;
        private CreateLineBaseItem createLineBaseItem1;
        private CreateOtherSeriesTypesBaseItem createOtherSeriesTypesBaseItem1;
        private CreatePieBaseItem createPieBaseItem1;
        private CreateRotatedBarBaseItem createRotatedBarBaseItem1;
        private ExportToBMPChartItem exportToBMPChartItem1;
        private ExportToGIFChartItem exportToGIFChartItem1;
        private ExportToHTMLChartItem exportToHTMLChartItem1;
        private ExportToJPEGChartItem exportToJPEGChartItem1;
        private ExportToMHTChartItem exportToMHTChartItem1;
        private ExportToPDFChartItem exportToPDFChartItem1;
        private ExportToPNGChartItem exportToPNGChartItem1;
        private ExportToRTFChartItem exportToRTFChartItem1;
        private ExportToTIFFChartItem exportToTIFFChartItem1;
        private ExportToXLSChartItem exportToXLSChartItem1;
        private ExportToXLSXChartItem exportToXLSXChartItem1;
        private GroupControl groupControl2;
        private LabelControl labelControl5;
        private LoadTemplateChartItem loadTemplateChartItem1;
        private PanelControl panelControl2;
        private PrintChartItem printChartItem1;
        private PrintPreviewChartItem printPreviewChartItem1;
        private RunWizardChartItem runWizardChartItem1;
        private SaveAsTemplateChartItem saveAsTemplateChartItem1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView3 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges1 = new DevExpress.Skins.SkinPaddingEdges();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges2 = new DevExpress.Skins.SkinPaddingEdges();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn chartControlCommandGalleryItemGroup2DColumn1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn();
            DevExpress.XtraCharts.UI.CreateBarChartItem createBarChartItem1 = new DevExpress.XtraCharts.UI.CreateBarChartItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHisOscillogram));
            DevExpress.XtraCharts.UI.CreateFullStackedBarChartItem createFullStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBarChartItem createSideBySideFullStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideStackedBarChartItem createSideBySideStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateStackedBarChartItem createStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedBarChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DColumn chartControlCommandGalleryItemGroup3DColumn1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DColumn();
            DevExpress.XtraCharts.UI.CreateBar3DChartItem createBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedBar3DChartItem createFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateManhattanBarChartItem createManhattanBarChartItem1 = new DevExpress.XtraCharts.UI.CreateManhattanBarChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBar3DChartItem createSideBySideFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideStackedBar3DChartItem createSideBySideStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateStackedBar3DChartItem createStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupCylinderColumn chartControlCommandGalleryItemGroupCylinderColumn1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupCylinderColumn();
            DevExpress.XtraCharts.UI.CreateCylinderBar3DChartItem createCylinderBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateCylinderFullStackedBar3DChartItem createCylinderFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateCylinderManhattanBarChartItem createCylinderManhattanBarChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderManhattanBarChartItem();
            DevExpress.XtraCharts.UI.CreateCylinderSideBySideFullStackedBar3DChartItem createCylinderSideBySideFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderSideBySideFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateCylinderSideBySideStackedBar3DChartItem createCylinderSideBySideStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderSideBySideStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateCylinderStackedBar3DChartItem createCylinderStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateCylinderStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupConeColumn chartControlCommandGalleryItemGroupConeColumn1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupConeColumn();
            DevExpress.XtraCharts.UI.CreateConeBar3DChartItem createConeBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateConeBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateConeFullStackedBar3DChartItem createConeFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateConeFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateConeManhattanBarChartItem createConeManhattanBarChartItem1 = new DevExpress.XtraCharts.UI.CreateConeManhattanBarChartItem();
            DevExpress.XtraCharts.UI.CreateConeSideBySideFullStackedBar3DChartItem createConeSideBySideFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateConeSideBySideFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateConeSideBySideStackedBar3DChartItem createConeSideBySideStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateConeSideBySideStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreateConeStackedBar3DChartItem createConeStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreateConeStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPyramidColumn chartControlCommandGalleryItemGroupPyramidColumn1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPyramidColumn();
            DevExpress.XtraCharts.UI.CreatePyramidBar3DChartItem createPyramidBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidBar3DChartItem();
            DevExpress.XtraCharts.UI.CreatePyramidFullStackedBar3DChartItem createPyramidFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreatePyramidManhattanBarChartItem createPyramidManhattanBarChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidManhattanBarChartItem();
            DevExpress.XtraCharts.UI.CreatePyramidSideBySideFullStackedBar3DChartItem createPyramidSideBySideFullStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidSideBySideFullStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreatePyramidSideBySideStackedBar3DChartItem createPyramidSideBySideStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidSideBySideStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.CreatePyramidStackedBar3DChartItem createPyramidStackedBar3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePyramidStackedBar3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DLine chartControlCommandGalleryItemGroup2DLine1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DLine();
            DevExpress.XtraCharts.UI.CreateLineChartItem createLineChartItem1 = new DevExpress.XtraCharts.UI.CreateLineChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedLineChartItem createFullStackedLineChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedLineChartItem();
            DevExpress.XtraCharts.UI.CreateScatterLineChartItem createScatterLineChartItem1 = new DevExpress.XtraCharts.UI.CreateScatterLineChartItem();
            DevExpress.XtraCharts.UI.CreateSplineChartItem createSplineChartItem1 = new DevExpress.XtraCharts.UI.CreateSplineChartItem();
            DevExpress.XtraCharts.UI.CreateStackedLineChartItem createStackedLineChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedLineChartItem();
            DevExpress.XtraCharts.UI.CreateStepLineChartItem createStepLineChartItem1 = new DevExpress.XtraCharts.UI.CreateStepLineChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DLine chartControlCommandGalleryItemGroup3DLine1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DLine();
            DevExpress.XtraCharts.UI.CreateLine3DChartItem createLine3DChartItem1 = new DevExpress.XtraCharts.UI.CreateLine3DChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedLine3DChartItem createFullStackedLine3DChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedLine3DChartItem();
            DevExpress.XtraCharts.UI.CreateSpline3DChartItem createSpline3DChartItem1 = new DevExpress.XtraCharts.UI.CreateSpline3DChartItem();
            DevExpress.XtraCharts.UI.CreateStackedLine3DChartItem createStackedLine3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedLine3DChartItem();
            DevExpress.XtraCharts.UI.CreateStepLine3DChartItem createStepLine3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStepLine3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie chartControlCommandGalleryItemGroup2DPie1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie();
            DevExpress.XtraCharts.UI.CreatePieChartItem createPieChartItem1 = new DevExpress.XtraCharts.UI.CreatePieChartItem();
            DevExpress.XtraCharts.UI.CreateDoughnutChartItem createDoughnutChartItem1 = new DevExpress.XtraCharts.UI.CreateDoughnutChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie chartControlCommandGalleryItemGroup3DPie1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie();
            DevExpress.XtraCharts.UI.CreatePie3DChartItem createPie3DChartItem1 = new DevExpress.XtraCharts.UI.CreatePie3DChartItem();
            DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem createDoughnut3DChartItem1 = new DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar chartControlCommandGalleryItemGroup2DBar1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar();
            DevExpress.XtraCharts.UI.CreateRotatedBarChartItem createRotatedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRotatedBarChartItem();
            DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem createRotatedFullStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem createRotatedSideBySideFullStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem createRotatedSideBySideStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem();
            DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem createRotatedStackedBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DArea chartControlCommandGalleryItemGroup2DArea1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DArea();
            DevExpress.XtraCharts.UI.CreateAreaChartItem createAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateAreaChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedAreaChartItem createFullStackedAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedAreaChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedSplineAreaChartItem createFullStackedSplineAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedSplineAreaChartItem();
            DevExpress.XtraCharts.UI.CreateSplineAreaChartItem createSplineAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateSplineAreaChartItem();
            DevExpress.XtraCharts.UI.CreateStackedAreaChartItem createStackedAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedAreaChartItem();
            DevExpress.XtraCharts.UI.CreateStackedSplineAreaChartItem createStackedSplineAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedSplineAreaChartItem();
            DevExpress.XtraCharts.UI.CreateStepAreaChartItem createStepAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateStepAreaChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DArea chartControlCommandGalleryItemGroup3DArea1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DArea();
            DevExpress.XtraCharts.UI.CreateArea3DChartItem createArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedArea3DChartItem createFullStackedArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateFullStackedSplineArea3DChartItem createFullStackedSplineArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateFullStackedSplineArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateSplineArea3DChartItem createSplineArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateSplineArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateStackedArea3DChartItem createStackedArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateStackedSplineArea3DChartItem createStackedSplineArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStackedSplineArea3DChartItem();
            DevExpress.XtraCharts.UI.CreateStepArea3DChartItem createStepArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateStepArea3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPoint chartControlCommandGalleryItemGroupPoint1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPoint();
            DevExpress.XtraCharts.UI.CreatePointChartItem createPointChartItem1 = new DevExpress.XtraCharts.UI.CreatePointChartItem();
            DevExpress.XtraCharts.UI.CreateBubbleChartItem createBubbleChartItem1 = new DevExpress.XtraCharts.UI.CreateBubbleChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFunnel chartControlCommandGalleryItemGroupFunnel1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFunnel();
            DevExpress.XtraCharts.UI.CreateFunnelChartItem createFunnelChartItem1 = new DevExpress.XtraCharts.UI.CreateFunnelChartItem();
            DevExpress.XtraCharts.UI.CreateFunnel3DChartItem createFunnel3DChartItem1 = new DevExpress.XtraCharts.UI.CreateFunnel3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFinancial chartControlCommandGalleryItemGroupFinancial1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFinancial();
            DevExpress.XtraCharts.UI.CreateStockChartItem createStockChartItem1 = new DevExpress.XtraCharts.UI.CreateStockChartItem();
            DevExpress.XtraCharts.UI.CreateCandleStickChartItem createCandleStickChartItem1 = new DevExpress.XtraCharts.UI.CreateCandleStickChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRadar chartControlCommandGalleryItemGroupRadar1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRadar();
            DevExpress.XtraCharts.UI.CreateRadarPointChartItem createRadarPointChartItem1 = new DevExpress.XtraCharts.UI.CreateRadarPointChartItem();
            DevExpress.XtraCharts.UI.CreateRadarLineChartItem createRadarLineChartItem1 = new DevExpress.XtraCharts.UI.CreateRadarLineChartItem();
            DevExpress.XtraCharts.UI.CreateRadarAreaChartItem createRadarAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateRadarAreaChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPolar chartControlCommandGalleryItemGroupPolar1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPolar();
            DevExpress.XtraCharts.UI.CreatePolarPointChartItem createPolarPointChartItem1 = new DevExpress.XtraCharts.UI.CreatePolarPointChartItem();
            DevExpress.XtraCharts.UI.CreatePolarLineChartItem createPolarLineChartItem1 = new DevExpress.XtraCharts.UI.CreatePolarLineChartItem();
            DevExpress.XtraCharts.UI.CreatePolarAreaChartItem createPolarAreaChartItem1 = new DevExpress.XtraCharts.UI.CreatePolarAreaChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRange chartControlCommandGalleryItemGroupRange1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRange();
            DevExpress.XtraCharts.UI.CreateRangeBarChartItem createRangeBarChartItem1 = new DevExpress.XtraCharts.UI.CreateRangeBarChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideRangeBarChartItem createSideBySideRangeBarChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideRangeBarChartItem();
            DevExpress.XtraCharts.UI.CreateRangeAreaChartItem createRangeAreaChartItem1 = new DevExpress.XtraCharts.UI.CreateRangeAreaChartItem();
            DevExpress.XtraCharts.UI.CreateRangeArea3DChartItem createRangeArea3DChartItem1 = new DevExpress.XtraCharts.UI.CreateRangeArea3DChartItem();
            DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupGantt chartControlCommandGalleryItemGroupGantt1 = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupGantt();
            DevExpress.XtraCharts.UI.CreateGanttChartItem createGanttChartItem1 = new DevExpress.XtraCharts.UI.CreateGanttChartItem();
            DevExpress.XtraCharts.UI.CreateSideBySideGanttChartItem createSideBySideGanttChartItem1 = new DevExpress.XtraCharts.UI.CreateSideBySideGanttChartItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.colorEdit1 = new DevExpress.XtraEditors.ColorEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.chartAppearanceBar1 = new DevExpress.XtraCharts.UI.ChartAppearanceBar();
            this.loadTemplateChartItem1 = new DevExpress.XtraCharts.UI.LoadTemplateChartItem();
            this.saveAsTemplateChartItem1 = new DevExpress.XtraCharts.UI.SaveAsTemplateChartItem();
            this.printPreviewChartItem1 = new DevExpress.XtraCharts.UI.PrintPreviewChartItem();
            this.printChartItem1 = new DevExpress.XtraCharts.UI.PrintChartItem();
            this.changePaletteGalleryBaseItem1 = new DevExpress.XtraCharts.UI.ChangePaletteGalleryBaseItem();
            this.commandBarGalleryDropDown7 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.changeAppearanceGalleryBaseBarManagerItem1 = new DevExpress.XtraCharts.UI.ChangeAppearanceGalleryBaseBarManagerItem();
            this.commandBarGalleryDropDown8 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createExportBaseItem1 = new DevExpress.XtraCharts.UI.CreateExportBaseItem();
            this.exportToPDFChartItem1 = new DevExpress.XtraCharts.UI.ExportToPDFChartItem();
            this.exportToHTMLChartItem1 = new DevExpress.XtraCharts.UI.ExportToHTMLChartItem();
            this.exportToMHTChartItem1 = new DevExpress.XtraCharts.UI.ExportToMHTChartItem();
            this.exportToXLSChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSChartItem();
            this.exportToXLSXChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSXChartItem();
            this.exportToRTFChartItem1 = new DevExpress.XtraCharts.UI.ExportToRTFChartItem();
            this.createExportToImageBaseItem1 = new DevExpress.XtraCharts.UI.CreateExportToImageBaseItem();
            this.exportToBMPChartItem1 = new DevExpress.XtraCharts.UI.ExportToBMPChartItem();
            this.exportToGIFChartItem1 = new DevExpress.XtraCharts.UI.ExportToGIFChartItem();
            this.exportToJPEGChartItem1 = new DevExpress.XtraCharts.UI.ExportToJPEGChartItem();
            this.exportToPNGChartItem1 = new DevExpress.XtraCharts.UI.ExportToPNGChartItem();
            this.exportToTIFFChartItem1 = new DevExpress.XtraCharts.UI.ExportToTIFFChartItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.createBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateBarBaseItem();
            this.commandBarGalleryDropDown1 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createLineBaseItem1 = new DevExpress.XtraCharts.UI.CreateLineBaseItem();
            this.commandBarGalleryDropDown2 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createPieBaseItem1 = new DevExpress.XtraCharts.UI.CreatePieBaseItem();
            this.commandBarGalleryDropDown3 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createRotatedBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateRotatedBarBaseItem();
            this.commandBarGalleryDropDown4 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createAreaBaseItem1 = new DevExpress.XtraCharts.UI.CreateAreaBaseItem();
            this.commandBarGalleryDropDown5 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.createOtherSeriesTypesBaseItem1 = new DevExpress.XtraCharts.UI.CreateOtherSeriesTypesBaseItem();
            this.commandBarGalleryDropDown6 = new DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(this.components);
            this.runWizardChartItem1 = new DevExpress.XtraCharts.UI.RunWizardChartItem();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.chartBarController1 = new DevExpress.XtraCharts.UI.ChartBarController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chartControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(887, 427);
            this.panelControl2.TabIndex = 1;
            // 
            // chartControl1
            // 
            swiftPlotDiagram1.AxisX.GridLines.Color = System.Drawing.Color.LightGray;
            swiftPlotDiagram1.AxisX.GridLines.MinorColor = System.Drawing.Color.LightGray;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.GridLines.Color = System.Drawing.Color.White;
            swiftPlotDiagram1.AxisY.GridLines.MinorColor = System.Drawing.Color.LightGray;
            swiftPlotDiagram1.AxisY.Interlaced = true;
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.EnableAxisXScrolling = true;
            swiftPlotDiagram1.EnableAxisXZooming = true;
            swiftPlotDiagram1.EnableAxisYScrolling = true;
            swiftPlotDiagram1.EnableAxisYZooming = true;
            this.chartControl1.Diagram = swiftPlotDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(2, 2);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairHighlightPoints = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairLabelPattern = "{A:yyyy/MM/dd HH:mm:ss fff}";
            series1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "实时波形";
            series1.View = swiftPlotSeriesView1;
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series2.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series2.CrosshairHighlightPoints = DevExpress.Utils.DefaultBoolean.True;
            series2.CrosshairLabelPattern = "{A:yyyy/MM/dd HH:mm:ss fff}";
            series2.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "标准波形";
            series2.View = swiftPlotSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.SeriesTemplate.View = swiftPlotSeriesView3;
            this.chartControl1.Size = new System.Drawing.Size(883, 423);
            this.chartControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.colorEdit1);
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 458);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(887, 56);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "参数设定";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(102, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "网格颜色：";
            // 
            // colorEdit1
            // 
            this.colorEdit1.EditValue = System.Drawing.Color.Empty;
            this.colorEdit1.Location = new System.Drawing.Point(168, 24);
            this.colorEdit1.MenuManager = this.barManager1;
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit1.Size = new System.Drawing.Size(61, 20);
            this.colorEdit1.TabIndex = 18;
            this.colorEdit1.EditValueChanged += new System.EventHandler(this.colorEdit1_EditValueChanged);
            // 
            // barManager1
            // 
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.chartAppearanceBar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
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
            this.createExportToImageBaseItem1});
            this.barManager1.MaxItemId = 26;
            // 
            // chartAppearanceBar1
            // 
            this.chartAppearanceBar1.Control = this.chartControl1;
            this.chartAppearanceBar1.DockCol = 0;
            this.chartAppearanceBar1.DockRow = 0;
            this.chartAppearanceBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.chartAppearanceBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.loadTemplateChartItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.saveAsTemplateChartItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.printPreviewChartItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.printChartItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.changePaletteGalleryBaseItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.changeAppearanceGalleryBaseBarManagerItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.createExportBaseItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.chartAppearanceBar1.OptionsBar.DrawDragBorder = false;
            this.chartAppearanceBar1.OptionsBar.UseWholeRow = true;
            // 
            // loadTemplateChartItem1
            // 
            this.loadTemplateChartItem1.Caption = "导入波形";
            this.loadTemplateChartItem1.Id = 1;
            this.loadTemplateChartItem1.Name = "loadTemplateChartItem1";
            toolTipTitleItem1.Text = "导入波形";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "将本地XML格式波形数据文件导入生成波形";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.loadTemplateChartItem1.SuperTip = superToolTip1;
            // 
            // saveAsTemplateChartItem1
            // 
            this.saveAsTemplateChartItem1.Caption = "保存";
            this.saveAsTemplateChartItem1.Id = 0;
            this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
            toolTipTitleItem2.Text = "保存";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "以XML格式保存当前波形的数据";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.saveAsTemplateChartItem1.SuperTip = superToolTip2;
            // 
            // printPreviewChartItem1
            // 
            this.printPreviewChartItem1.Caption = "预览";
            this.printPreviewChartItem1.Id = 3;
            this.printPreviewChartItem1.Name = "printPreviewChartItem1";
            toolTipTitleItem3.Text = "预览";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "打印前预览和编辑波形";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.printPreviewChartItem1.SuperTip = superToolTip3;
            // 
            // printChartItem1
            // 
            this.printChartItem1.Caption = "打印";
            this.printChartItem1.Id = 2;
            this.printChartItem1.Name = "printChartItem1";
            toolTipTitleItem4.Text = "打印";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "选择打印机或其它打印设备打印当前波形";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.printChartItem1.SuperTip = superToolTip4;
            // 
            // changePaletteGalleryBaseItem1
            // 
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
            // 
            // commandBarGalleryDropDown7
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown7.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseFont = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseTextOptions = true;
            this.commandBarGalleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.commandBarGalleryDropDown7.Gallery.ColumnCount = 1;
            this.commandBarGalleryDropDown7.Gallery.ImageSize = new System.Drawing.Size(160, 10);
            this.commandBarGalleryDropDown7.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleLeft;
            this.commandBarGalleryDropDown7.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Right;
            skinPaddingEdges1.Bottom = -3;
            skinPaddingEdges1.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemImagePadding = skinPaddingEdges1;
            skinPaddingEdges2.Bottom = -3;
            skinPaddingEdges2.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemTextPadding = skinPaddingEdges2;
            this.commandBarGalleryDropDown7.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown7.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown7.Gallery.ShowItemText = true;
            this.commandBarGalleryDropDown7.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown7.Manager = this.barManager1;
            this.commandBarGalleryDropDown7.Name = "commandBarGalleryDropDown7";
            // 
            // changeAppearanceGalleryBaseBarManagerItem1
            // 
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
            // 
            // commandBarGalleryDropDown8
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown8.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown8.Gallery.ColumnCount = 7;
            this.commandBarGalleryDropDown8.Gallery.ImageSize = new System.Drawing.Size(80, 50);
            this.commandBarGalleryDropDown8.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown8.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown8.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown8.Manager = this.barManager1;
            this.commandBarGalleryDropDown8.Name = "commandBarGalleryDropDown8";
            // 
            // createExportBaseItem1
            // 
            this.createExportBaseItem1.Caption = "导出  ";
            this.createExportBaseItem1.Id = 6;
            this.createExportBaseItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToPDFChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToHTMLChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToMHTChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToXLSChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToXLSXChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToRTFChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.createExportToImageBaseItem1)});
            this.createExportBaseItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText;
            this.createExportBaseItem1.Name = "createExportBaseItem1";
            toolTipTitleItem7.Text = "导出";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "可将当前波形导出为指定格式的的文件并保存";
            superToolTip7.Items.Add(toolTipTitleItem7);
            superToolTip7.Items.Add(toolTipItem7);
            this.createExportBaseItem1.SuperTip = superToolTip7;
            // 
            // exportToPDFChartItem1
            // 
            this.exportToPDFChartItem1.Id = 7;
            this.exportToPDFChartItem1.Name = "exportToPDFChartItem1";
            // 
            // exportToHTMLChartItem1
            // 
            this.exportToHTMLChartItem1.Id = 8;
            this.exportToHTMLChartItem1.Name = "exportToHTMLChartItem1";
            // 
            // exportToMHTChartItem1
            // 
            this.exportToMHTChartItem1.Id = 9;
            this.exportToMHTChartItem1.Name = "exportToMHTChartItem1";
            // 
            // exportToXLSChartItem1
            // 
            this.exportToXLSChartItem1.Id = 10;
            this.exportToXLSChartItem1.Name = "exportToXLSChartItem1";
            // 
            // exportToXLSXChartItem1
            // 
            this.exportToXLSXChartItem1.Id = 11;
            this.exportToXLSXChartItem1.Name = "exportToXLSXChartItem1";
            // 
            // exportToRTFChartItem1
            // 
            this.exportToRTFChartItem1.Id = 12;
            this.exportToRTFChartItem1.Name = "exportToRTFChartItem1";
            // 
            // createExportToImageBaseItem1
            // 
            this.createExportToImageBaseItem1.Id = 13;
            this.createExportToImageBaseItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToBMPChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToGIFChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToJPEGChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToPNGChartItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportToTIFFChartItem1)});
            this.createExportToImageBaseItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText;
            this.createExportToImageBaseItem1.Name = "createExportToImageBaseItem1";
            // 
            // exportToBMPChartItem1
            // 
            this.exportToBMPChartItem1.Id = 14;
            this.exportToBMPChartItem1.Name = "exportToBMPChartItem1";
            // 
            // exportToGIFChartItem1
            // 
            this.exportToGIFChartItem1.Id = 15;
            this.exportToGIFChartItem1.Name = "exportToGIFChartItem1";
            // 
            // exportToJPEGChartItem1
            // 
            this.exportToJPEGChartItem1.Id = 16;
            this.exportToJPEGChartItem1.Name = "exportToJPEGChartItem1";
            // 
            // exportToPNGChartItem1
            // 
            this.exportToPNGChartItem1.Id = 17;
            this.exportToPNGChartItem1.Name = "exportToPNGChartItem1";
            // 
            // exportToTIFFChartItem1
            // 
            this.exportToTIFFChartItem1.Id = 18;
            this.exportToTIFFChartItem1.Name = "exportToTIFFChartItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(887, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 514);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(887, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 483);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(887, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 483);
            // 
            // createBarBaseItem1
            // 
            this.createBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown1;
            this.createBarBaseItem1.Id = 19;
            this.createBarBaseItem1.Name = "createBarBaseItem1";
            // 
            // commandBarGalleryDropDown1
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown1.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown1.Gallery.ColumnCount = 4;
            createBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            createFullStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            createSideBySideFullStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            createSideBySideStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            createStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            chartControlCommandGalleryItemGroup2DColumn1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createBarChartItem1,
            createFullStackedBarChartItem1,
            createSideBySideFullStackedBarChartItem1,
            createSideBySideStackedBarChartItem1,
            createStackedBarChartItem1});
            createBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            createFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            createManhattanBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            createSideBySideFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image8")));
            createSideBySideStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image9")));
            createStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image10")));
            chartControlCommandGalleryItemGroup3DColumn1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createBar3DChartItem1,
            createFullStackedBar3DChartItem1,
            createManhattanBarChartItem1,
            createSideBySideFullStackedBar3DChartItem1,
            createSideBySideStackedBar3DChartItem1,
            createStackedBar3DChartItem1});
            createCylinderBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image11")));
            createCylinderFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image12")));
            createCylinderManhattanBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image13")));
            createCylinderSideBySideFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image14")));
            createCylinderSideBySideStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image15")));
            createCylinderStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image16")));
            chartControlCommandGalleryItemGroupCylinderColumn1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createCylinderBar3DChartItem1,
            createCylinderFullStackedBar3DChartItem1,
            createCylinderManhattanBarChartItem1,
            createCylinderSideBySideFullStackedBar3DChartItem1,
            createCylinderSideBySideStackedBar3DChartItem1,
            createCylinderStackedBar3DChartItem1});
            createConeBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image17")));
            createConeFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image18")));
            createConeManhattanBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image19")));
            createConeSideBySideFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image20")));
            createConeSideBySideStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image21")));
            createConeStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image22")));
            chartControlCommandGalleryItemGroupConeColumn1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createConeBar3DChartItem1,
            createConeFullStackedBar3DChartItem1,
            createConeManhattanBarChartItem1,
            createConeSideBySideFullStackedBar3DChartItem1,
            createConeSideBySideStackedBar3DChartItem1,
            createConeStackedBar3DChartItem1});
            createPyramidBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image23")));
            createPyramidFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image24")));
            createPyramidManhattanBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image25")));
            createPyramidSideBySideFullStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image26")));
            createPyramidSideBySideStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image27")));
            createPyramidStackedBar3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image28")));
            chartControlCommandGalleryItemGroupPyramidColumn1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createPyramidBar3DChartItem1,
            createPyramidFullStackedBar3DChartItem1,
            createPyramidManhattanBarChartItem1,
            createPyramidSideBySideFullStackedBar3DChartItem1,
            createPyramidSideBySideStackedBar3DChartItem1,
            createPyramidStackedBar3DChartItem1});
            this.commandBarGalleryDropDown1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroup2DColumn1,
            chartControlCommandGalleryItemGroup3DColumn1,
            chartControlCommandGalleryItemGroupCylinderColumn1,
            chartControlCommandGalleryItemGroupConeColumn1,
            chartControlCommandGalleryItemGroupPyramidColumn1});
            this.commandBarGalleryDropDown1.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown1.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown1.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown1.Manager = this.barManager1;
            this.commandBarGalleryDropDown1.Name = "commandBarGalleryDropDown1";
            // 
            // createLineBaseItem1
            // 
            this.createLineBaseItem1.DropDownControl = this.commandBarGalleryDropDown2;
            this.createLineBaseItem1.Id = 20;
            this.createLineBaseItem1.Name = "createLineBaseItem1";
            // 
            // commandBarGalleryDropDown2
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown2.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown2.Gallery.ColumnCount = 3;
            createLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image29")));
            createFullStackedLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image30")));
            createScatterLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image31")));
            createSplineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image32")));
            createStackedLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image33")));
            createStepLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image34")));
            chartControlCommandGalleryItemGroup2DLine1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createLineChartItem1,
            createFullStackedLineChartItem1,
            createScatterLineChartItem1,
            createSplineChartItem1,
            createStackedLineChartItem1,
            createStepLineChartItem1});
            createLine3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image35")));
            createFullStackedLine3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image36")));
            createSpline3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image37")));
            createStackedLine3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image38")));
            createStepLine3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image39")));
            chartControlCommandGalleryItemGroup3DLine1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createLine3DChartItem1,
            createFullStackedLine3DChartItem1,
            createSpline3DChartItem1,
            createStackedLine3DChartItem1,
            createStepLine3DChartItem1});
            this.commandBarGalleryDropDown2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroup2DLine1,
            chartControlCommandGalleryItemGroup3DLine1});
            this.commandBarGalleryDropDown2.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown2.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown2.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown2.Manager = this.barManager1;
            this.commandBarGalleryDropDown2.Name = "commandBarGalleryDropDown2";
            // 
            // createPieBaseItem1
            // 
            this.createPieBaseItem1.DropDownControl = this.commandBarGalleryDropDown3;
            this.createPieBaseItem1.Id = 21;
            this.createPieBaseItem1.Name = "createPieBaseItem1";
            // 
            // commandBarGalleryDropDown3
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown3.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown3.Gallery.ColumnCount = 3;
            createPieChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image40")));
            createDoughnutChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image41")));
            chartControlCommandGalleryItemGroup2DPie1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createPieChartItem1,
            createDoughnutChartItem1});
            createPie3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image42")));
            createDoughnut3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image43")));
            chartControlCommandGalleryItemGroup3DPie1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createPie3DChartItem1,
            createDoughnut3DChartItem1});
            this.commandBarGalleryDropDown3.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroup2DPie1,
            chartControlCommandGalleryItemGroup3DPie1});
            this.commandBarGalleryDropDown3.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown3.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown3.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown3.Manager = this.barManager1;
            this.commandBarGalleryDropDown3.Name = "commandBarGalleryDropDown3";
            // 
            // createRotatedBarBaseItem1
            // 
            this.createRotatedBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown4;
            this.createRotatedBarBaseItem1.Id = 22;
            this.createRotatedBarBaseItem1.Name = "createRotatedBarBaseItem1";
            // 
            // commandBarGalleryDropDown4
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown4.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown4.Gallery.ColumnCount = 3;
            createRotatedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image44")));
            createRotatedFullStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image45")));
            createRotatedSideBySideFullStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image46")));
            createRotatedSideBySideStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image47")));
            createRotatedStackedBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image48")));
            chartControlCommandGalleryItemGroup2DBar1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createRotatedBarChartItem1,
            createRotatedFullStackedBarChartItem1,
            createRotatedSideBySideFullStackedBarChartItem1,
            createRotatedSideBySideStackedBarChartItem1,
            createRotatedStackedBarChartItem1});
            this.commandBarGalleryDropDown4.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroup2DBar1});
            this.commandBarGalleryDropDown4.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown4.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown4.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown4.Manager = this.barManager1;
            this.commandBarGalleryDropDown4.Name = "commandBarGalleryDropDown4";
            // 
            // createAreaBaseItem1
            // 
            this.createAreaBaseItem1.DropDownControl = this.commandBarGalleryDropDown5;
            this.createAreaBaseItem1.Id = 23;
            this.createAreaBaseItem1.Name = "createAreaBaseItem1";
            // 
            // commandBarGalleryDropDown5
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown5.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown5.Gallery.ColumnCount = 4;
            createAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image49")));
            createFullStackedAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image50")));
            createFullStackedSplineAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image51")));
            createSplineAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image52")));
            createStackedAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image53")));
            createStackedSplineAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image54")));
            createStepAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image55")));
            chartControlCommandGalleryItemGroup2DArea1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createAreaChartItem1,
            createFullStackedAreaChartItem1,
            createFullStackedSplineAreaChartItem1,
            createSplineAreaChartItem1,
            createStackedAreaChartItem1,
            createStackedSplineAreaChartItem1,
            createStepAreaChartItem1});
            createArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image56")));
            createFullStackedArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image57")));
            createFullStackedSplineArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image58")));
            createSplineArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image59")));
            createStackedArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image60")));
            createStackedSplineArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image61")));
            createStepArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image62")));
            chartControlCommandGalleryItemGroup3DArea1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createArea3DChartItem1,
            createFullStackedArea3DChartItem1,
            createFullStackedSplineArea3DChartItem1,
            createSplineArea3DChartItem1,
            createStackedArea3DChartItem1,
            createStackedSplineArea3DChartItem1,
            createStepArea3DChartItem1});
            this.commandBarGalleryDropDown5.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroup2DArea1,
            chartControlCommandGalleryItemGroup3DArea1});
            this.commandBarGalleryDropDown5.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown5.Gallery.RowCount = 5;
            this.commandBarGalleryDropDown5.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown5.Manager = this.barManager1;
            this.commandBarGalleryDropDown5.Name = "commandBarGalleryDropDown5";
            // 
            // createOtherSeriesTypesBaseItem1
            // 
            this.createOtherSeriesTypesBaseItem1.DropDownControl = this.commandBarGalleryDropDown6;
            this.createOtherSeriesTypesBaseItem1.Id = 24;
            this.createOtherSeriesTypesBaseItem1.Name = "createOtherSeriesTypesBaseItem1";
            // 
            // commandBarGalleryDropDown6
            // 
            // 
            // 
            // 
            this.commandBarGalleryDropDown6.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown6.Gallery.ColumnCount = 4;
            createPointChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image63")));
            createBubbleChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image64")));
            chartControlCommandGalleryItemGroupPoint1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createPointChartItem1,
            createBubbleChartItem1});
            createFunnelChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image65")));
            createFunnel3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image66")));
            chartControlCommandGalleryItemGroupFunnel1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createFunnelChartItem1,
            createFunnel3DChartItem1});
            createStockChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image67")));
            createCandleStickChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image68")));
            chartControlCommandGalleryItemGroupFinancial1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createStockChartItem1,
            createCandleStickChartItem1});
            createRadarPointChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image69")));
            createRadarLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image70")));
            createRadarAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image71")));
            chartControlCommandGalleryItemGroupRadar1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createRadarPointChartItem1,
            createRadarLineChartItem1,
            createRadarAreaChartItem1});
            createPolarPointChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image72")));
            createPolarLineChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image73")));
            createPolarAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image74")));
            chartControlCommandGalleryItemGroupPolar1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createPolarPointChartItem1,
            createPolarLineChartItem1,
            createPolarAreaChartItem1});
            createRangeBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image75")));
            createSideBySideRangeBarChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image76")));
            createRangeAreaChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image77")));
            createRangeArea3DChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image78")));
            chartControlCommandGalleryItemGroupRange1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createRangeBarChartItem1,
            createSideBySideRangeBarChartItem1,
            createRangeAreaChartItem1,
            createRangeArea3DChartItem1});
            createGanttChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image79")));
            createSideBySideGanttChartItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image80")));
            chartControlCommandGalleryItemGroupGantt1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            createGanttChartItem1,
            createSideBySideGanttChartItem1});
            this.commandBarGalleryDropDown6.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            chartControlCommandGalleryItemGroupPoint1,
            chartControlCommandGalleryItemGroupFunnel1,
            chartControlCommandGalleryItemGroupFinancial1,
            chartControlCommandGalleryItemGroupRadar1,
            chartControlCommandGalleryItemGroupPolar1,
            chartControlCommandGalleryItemGroupRange1,
            chartControlCommandGalleryItemGroupGantt1});
            this.commandBarGalleryDropDown6.Gallery.ImageSize = new System.Drawing.Size(32, 32);
            this.commandBarGalleryDropDown6.Gallery.RowCount = 9;
            this.commandBarGalleryDropDown6.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
            this.commandBarGalleryDropDown6.Manager = this.barManager1;
            this.commandBarGalleryDropDown6.Name = "commandBarGalleryDropDown6";
            // 
            // runWizardChartItem1
            // 
            this.runWizardChartItem1.Id = 25;
            this.runWizardChartItem1.Name = "runWizardChartItem1";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(6, 25);
            this.checkEdit1.MenuManager = this.barManager1;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "网格线";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 17;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // chartBarController1
            // 
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
            // 
            // FrmHisOscillogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 514);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmHisOscillogram";
            this.Text = "历史波形";
            this.Load += new System.EventHandler(this.FrmHisOscillogram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandBarGalleryDropDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

