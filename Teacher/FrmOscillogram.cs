using BLL.Core;
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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Teacher
{

    public class FrmOscillogram : XtraForm
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
        private ChartPrintExportBar chartPrintExportBar1;
        private ChartTemplatesBar chartTemplatesBar1;
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
        private int currenttypeid;
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
        private LabelControl labelControl6;
        private PanelControl panelControl1;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PrintChartItem printChartItem1;
        private PrintPreviewChartItem printPreviewChartItem1;
        private Random random = new Random();
        private SaveAsTemplateChartItem saveAsTemplateChartItem1;
        private int selecttypeid = 1;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private SpinEdit spinEdit3;
        private Timer timer1;
        private TreeList treeList1;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private double value1;
        private double value2;

        public FrmOscillogram()
        {
            this.InitializeComponent();
        }

        private void AddPoints(Series series, SeriesPoint[] pointsToUpdate)
        {
            if (series.View is SwiftPlotSeriesViewBase)
            {
                series.Points.AddRange(pointsToUpdate);
            }
        }

        private void BindData()
        {
            this.treeList1.Nodes.Clear();
            this.treeList1.Nodes.Add(new object[] { 1, "发动机冷却液温度", 1 });
            this.treeList1.Nodes.Add(new object[] { 2, "发动机转速", 2 });
        }

        private double CalculateNextValue(double value)
        {
            return (value + ((this.random.NextDouble() * 10.0) - 5.0));
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
            {
                this.diagram.AxisX.GridLines.Color = this.colorEdit1.Color;
                this.diagram.AxisX.GridLines.MinorColor = this.colorEdit1.Color;
                this.diagram.AxisX.GridLines.Visible = true;
                this.diagram.AxisX.GridLines.MinorVisible = true;
                this.diagram.AxisY.GridLines.MinorColor = this.colorEdit1.Color;
                this.diagram.AxisY.GridLines.Color = this.colorEdit1.Color;
                this.diagram.AxisY.GridLines.MinorVisible = true;
            }
            else
            {
                this.diagram.AxisX.GridLines.Color = Color.White;
                this.diagram.AxisX.GridLines.Visible = false;
                this.diagram.AxisX.GridLines.MinorVisible = false;
                this.diagram.AxisY.GridLines.MinorVisible = false;
            }
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            this.diagram.AxisX.GridLines.Color = (sender as ColorEdit).Color;
            this.diagram.AxisX.GridLines.MinorColor = (sender as ColorEdit).Color;
            this.diagram.AxisY.GridLines.MinorColor = this.colorEdit1.Color;
            this.diagram.AxisY.GridLines.Color = this.colorEdit1.Color;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmOscillogram_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.checkEdit1.Checked = false;
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
            this.Series1.Points.Add(new SeriesPoint(DateTime.Now));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmOscillogram));
            SwiftPlotDiagram diagram = new SwiftPlotDiagram();
            Series series = new Series();
            SwiftPlotSeriesView view = new SwiftPlotSeriesView();
            Series series2 = new Series();
            SwiftPlotSeriesView view2 = new SwiftPlotSeriesView();
            SwiftPlotSeriesView view3 = new SwiftPlotSeriesView();
            SuperToolTip tip = new SuperToolTip();
            ToolTipTitleItem item = new ToolTipTitleItem();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipTitleItem item3 = new ToolTipTitleItem();
            ToolTipItem item4 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipTitleItem item5 = new ToolTipTitleItem();
            ToolTipItem item6 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipTitleItem item7 = new ToolTipTitleItem();
            ToolTipItem item8 = new ToolTipItem();
            SkinPaddingEdges edges = new SkinPaddingEdges();
            SkinPaddingEdges edges2 = new SkinPaddingEdges();
            SuperToolTip tip5 = new SuperToolTip();
            ToolTipTitleItem item9 = new ToolTipTitleItem();
            ToolTipItem item10 = new ToolTipItem();
            SuperToolTip tip6 = new SuperToolTip();
            ToolTipTitleItem item11 = new ToolTipTitleItem();
            ToolTipItem item12 = new ToolTipItem();
            ChartControlCommandGalleryItemGroup2DColumn column = new ChartControlCommandGalleryItemGroup2DColumn();
            CreateBarChartItem item13 = new CreateBarChartItem();
            CreateFullStackedBarChartItem item14 = new CreateFullStackedBarChartItem();
            CreateSideBySideFullStackedBarChartItem item15 = new CreateSideBySideFullStackedBarChartItem();
            CreateSideBySideStackedBarChartItem item16 = new CreateSideBySideStackedBarChartItem();
            CreateStackedBarChartItem item17 = new CreateStackedBarChartItem();
            ChartControlCommandGalleryItemGroup3DColumn column2 = new ChartControlCommandGalleryItemGroup3DColumn();
            CreateBar3DChartItem item18 = new CreateBar3DChartItem();
            CreateFullStackedBar3DChartItem item19 = new CreateFullStackedBar3DChartItem();
            CreateManhattanBarChartItem item20 = new CreateManhattanBarChartItem();
            CreateSideBySideFullStackedBar3DChartItem item21 = new CreateSideBySideFullStackedBar3DChartItem();
            CreateSideBySideStackedBar3DChartItem item22 = new CreateSideBySideStackedBar3DChartItem();
            CreateStackedBar3DChartItem item23 = new CreateStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupCylinderColumn column3 = new ChartControlCommandGalleryItemGroupCylinderColumn();
            CreateCylinderBar3DChartItem item24 = new CreateCylinderBar3DChartItem();
            CreateCylinderFullStackedBar3DChartItem item25 = new CreateCylinderFullStackedBar3DChartItem();
            CreateCylinderManhattanBarChartItem item26 = new CreateCylinderManhattanBarChartItem();
            CreateCylinderSideBySideFullStackedBar3DChartItem item27 = new CreateCylinderSideBySideFullStackedBar3DChartItem();
            CreateCylinderSideBySideStackedBar3DChartItem item28 = new CreateCylinderSideBySideStackedBar3DChartItem();
            CreateCylinderStackedBar3DChartItem item29 = new CreateCylinderStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupConeColumn column4 = new ChartControlCommandGalleryItemGroupConeColumn();
            CreateConeBar3DChartItem item30 = new CreateConeBar3DChartItem();
            CreateConeFullStackedBar3DChartItem item31 = new CreateConeFullStackedBar3DChartItem();
            CreateConeManhattanBarChartItem item32 = new CreateConeManhattanBarChartItem();
            CreateConeSideBySideFullStackedBar3DChartItem item33 = new CreateConeSideBySideFullStackedBar3DChartItem();
            CreateConeSideBySideStackedBar3DChartItem item34 = new CreateConeSideBySideStackedBar3DChartItem();
            CreateConeStackedBar3DChartItem item35 = new CreateConeStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroupPyramidColumn column5 = new ChartControlCommandGalleryItemGroupPyramidColumn();
            CreatePyramidBar3DChartItem item36 = new CreatePyramidBar3DChartItem();
            CreatePyramidFullStackedBar3DChartItem item37 = new CreatePyramidFullStackedBar3DChartItem();
            CreatePyramidManhattanBarChartItem item38 = new CreatePyramidManhattanBarChartItem();
            CreatePyramidSideBySideFullStackedBar3DChartItem item39 = new CreatePyramidSideBySideFullStackedBar3DChartItem();
            CreatePyramidSideBySideStackedBar3DChartItem item40 = new CreatePyramidSideBySideStackedBar3DChartItem();
            CreatePyramidStackedBar3DChartItem item41 = new CreatePyramidStackedBar3DChartItem();
            ChartControlCommandGalleryItemGroup2DLine line = new ChartControlCommandGalleryItemGroup2DLine();
            CreateLineChartItem item42 = new CreateLineChartItem();
            CreateFullStackedLineChartItem item43 = new CreateFullStackedLineChartItem();
            CreateScatterLineChartItem item44 = new CreateScatterLineChartItem();
            CreateSplineChartItem item45 = new CreateSplineChartItem();
            CreateStackedLineChartItem item46 = new CreateStackedLineChartItem();
            CreateStepLineChartItem item47 = new CreateStepLineChartItem();
            ChartControlCommandGalleryItemGroup3DLine line2 = new ChartControlCommandGalleryItemGroup3DLine();
            CreateLine3DChartItem item48 = new CreateLine3DChartItem();
            CreateFullStackedLine3DChartItem item49 = new CreateFullStackedLine3DChartItem();
            CreateSpline3DChartItem item50 = new CreateSpline3DChartItem();
            CreateStackedLine3DChartItem item51 = new CreateStackedLine3DChartItem();
            CreateStepLine3DChartItem item52 = new CreateStepLine3DChartItem();
            ChartControlCommandGalleryItemGroup2DPie pie = new ChartControlCommandGalleryItemGroup2DPie();
            CreatePieChartItem item53 = new CreatePieChartItem();
            CreateDoughnutChartItem item54 = new CreateDoughnutChartItem();
            ChartControlCommandGalleryItemGroup3DPie pie2 = new ChartControlCommandGalleryItemGroup3DPie();
            CreatePie3DChartItem item55 = new CreatePie3DChartItem();
            CreateDoughnut3DChartItem item56 = new CreateDoughnut3DChartItem();
            ChartControlCommandGalleryItemGroup2DBar bar = new ChartControlCommandGalleryItemGroup2DBar();
            CreateRotatedBarChartItem item57 = new CreateRotatedBarChartItem();
            CreateRotatedFullStackedBarChartItem item58 = new CreateRotatedFullStackedBarChartItem();
            CreateRotatedSideBySideFullStackedBarChartItem item59 = new CreateRotatedSideBySideFullStackedBarChartItem();
            CreateRotatedSideBySideStackedBarChartItem item60 = new CreateRotatedSideBySideStackedBarChartItem();
            CreateRotatedStackedBarChartItem item61 = new CreateRotatedStackedBarChartItem();
            ChartControlCommandGalleryItemGroup2DArea area = new ChartControlCommandGalleryItemGroup2DArea();
            CreateAreaChartItem item62 = new CreateAreaChartItem();
            CreateFullStackedAreaChartItem item63 = new CreateFullStackedAreaChartItem();
            CreateFullStackedSplineAreaChartItem item64 = new CreateFullStackedSplineAreaChartItem();
            CreateSplineAreaChartItem item65 = new CreateSplineAreaChartItem();
            CreateStackedAreaChartItem item66 = new CreateStackedAreaChartItem();
            CreateStackedSplineAreaChartItem item67 = new CreateStackedSplineAreaChartItem();
            CreateStepAreaChartItem item68 = new CreateStepAreaChartItem();
            ChartControlCommandGalleryItemGroup3DArea area2 = new ChartControlCommandGalleryItemGroup3DArea();
            CreateArea3DChartItem item69 = new CreateArea3DChartItem();
            CreateFullStackedArea3DChartItem item70 = new CreateFullStackedArea3DChartItem();
            CreateFullStackedSplineArea3DChartItem item71 = new CreateFullStackedSplineArea3DChartItem();
            CreateSplineArea3DChartItem item72 = new CreateSplineArea3DChartItem();
            CreateStackedArea3DChartItem item73 = new CreateStackedArea3DChartItem();
            CreateStackedSplineArea3DChartItem item74 = new CreateStackedSplineArea3DChartItem();
            CreateStepArea3DChartItem item75 = new CreateStepArea3DChartItem();
            ChartControlCommandGalleryItemGroupPoint point = new ChartControlCommandGalleryItemGroupPoint();
            CreatePointChartItem item76 = new CreatePointChartItem();
            CreateBubbleChartItem item77 = new CreateBubbleChartItem();
            ChartControlCommandGalleryItemGroupFunnel funnel = new ChartControlCommandGalleryItemGroupFunnel();
            CreateFunnelChartItem item78 = new CreateFunnelChartItem();
            CreateFunnel3DChartItem item79 = new CreateFunnel3DChartItem();
            ChartControlCommandGalleryItemGroupFinancial financial = new ChartControlCommandGalleryItemGroupFinancial();
            CreateStockChartItem item80 = new CreateStockChartItem();
            CreateCandleStickChartItem item81 = new CreateCandleStickChartItem();
            ChartControlCommandGalleryItemGroupRadar radar = new ChartControlCommandGalleryItemGroupRadar();
            CreateRadarPointChartItem item82 = new CreateRadarPointChartItem();
            CreateRadarLineChartItem item83 = new CreateRadarLineChartItem();
            CreateRadarAreaChartItem item84 = new CreateRadarAreaChartItem();
            ChartControlCommandGalleryItemGroupPolar polar = new ChartControlCommandGalleryItemGroupPolar();
            CreatePolarPointChartItem item85 = new CreatePolarPointChartItem();
            CreatePolarLineChartItem item86 = new CreatePolarLineChartItem();
            CreatePolarAreaChartItem item87 = new CreatePolarAreaChartItem();
            ChartControlCommandGalleryItemGroupRange range = new ChartControlCommandGalleryItemGroupRange();
            CreateRangeBarChartItem item88 = new CreateRangeBarChartItem();
            CreateSideBySideRangeBarChartItem item89 = new CreateSideBySideRangeBarChartItem();
            CreateRangeAreaChartItem item90 = new CreateRangeAreaChartItem();
            CreateRangeArea3DChartItem item91 = new CreateRangeArea3DChartItem();
            ChartControlCommandGalleryItemGroupGantt gantt = new ChartControlCommandGalleryItemGroupGantt();
            CreateGanttChartItem item92 = new CreateGanttChartItem();
            CreateSideBySideGanttChartItem item93 = new CreateSideBySideGanttChartItem();
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
            this.timer1 = new Timer(this.components);
            this.chartBarController1 = new ChartBarController();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.treeList1.BeginInit();
            this.panelControl5.BeginInit();
            this.panelControl5.SuspendLayout();
            this.panelControl3.BeginInit();
            this.panelControl3.SuspendLayout();
            this.groupControl2.BeginInit();
            this.groupControl2.SuspendLayout();
            this.colorEdit1.Properties.BeginInit();
            this.barManager1.BeginInit();
            this.chartControl1.BeginInit();
            ((ISupportInitialize) diagram).BeginInit();
            ((ISupportInitialize) series).BeginInit();
            ((ISupportInitialize) view).BeginInit();
            ((ISupportInitialize) series2).BeginInit();
            ((ISupportInitialize) view2).BeginInit();
            ((ISupportInitialize) view3).BeginInit();
            this.commandBarGalleryDropDown7.BeginInit();
            this.commandBarGalleryDropDown8.BeginInit();
            this.commandBarGalleryDropDown1.BeginInit();
            this.commandBarGalleryDropDown2.BeginInit();
            this.commandBarGalleryDropDown3.BeginInit();
            this.commandBarGalleryDropDown4.BeginInit();
            this.commandBarGalleryDropDown5.BeginInit();
            this.commandBarGalleryDropDown6.BeginInit();
            this.checkEdit1.Properties.BeginInit();
            this.spinEdit3.Properties.BeginInit();
            this.panelControl4.BeginInit();
            this.panelControl4.SuspendLayout();
            ((ISupportInitialize) this.chartBarController1).BeginInit();
            base.SuspendLayout();
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Controls.Add(this.panelControl5);
            this.panelControl1.Dock = DockStyle.Left;
            this.panelControl1.Location = new Point(0, 0x1f);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0xae, 0x214);
            this.panelControl1.TabIndex = 0;
            this.treeList1.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3 });
            this.treeList1.Dock = DockStyle.Fill;
            this.treeList1.Location = new Point(2, 0x4f);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.Size = new Size(170, 0x1c3);
            this.treeList1.TabIndex = 1;
            this.treeList1.AfterFocusNode += new NodeEventHandler(this.treeList1_AfterFocusNode);
            this.treeListColumn1.Caption = "编号";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 0x22;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0x22;
            this.treeListColumn2.Caption = "测量对象";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 0x77;
            this.treeListColumn3.Caption = "测量对象类型";
            this.treeListColumn3.FieldName = "TypeId";
            this.treeListColumn3.Name = "treeListColumn3";
            this.panelControl5.Controls.Add(this.simpleButton2);
            this.panelControl5.Controls.Add(this.simpleButton1);
            this.panelControl5.Dock = DockStyle.Top;
            this.panelControl5.Location = new Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(170, 0x4d);
            this.panelControl5.TabIndex = 0;
            this.simpleButton2.Image = (Image) manager.GetObject("simpleButton2.Image");
            this.simpleButton2.Location = new Point(0x17, 0x2a);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(0x59, 30);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "停止监测\r\n";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image) manager.GetObject("simpleButton1.Image");
            this.simpleButton1.Location = new Point(0x17, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(0x59, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "开始监测";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.panelControl3.Controls.Add(this.groupControl2);
            this.panelControl3.Dock = DockStyle.Bottom;
            this.panelControl3.Location = new Point(0xae, 0x1ed);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(750, 70);
            this.panelControl3.TabIndex = 2;
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.colorEdit1);
            this.groupControl2.Controls.Add(this.checkEdit1);
            this.groupControl2.Controls.Add(this.spinEdit3);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Dock = DockStyle.Fill;
            this.groupControl2.Location = new Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(0x2ea, 0x42);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "参数设定";
            this.labelControl5.Location = new Point(0x65, 0x23);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x24, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "颜色：";
            this.colorEdit1.EditValue = Color.Empty;
            this.colorEdit1.Location = new Point(0x8f, 0x21);
            this.colorEdit1.MenuManager = this.barManager1;
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEdit1.Size = new Size(0x3d, 20);
            this.colorEdit1.TabIndex = 13;
            this.colorEdit1.EditValueChanged += new EventHandler(this.colorEdit1_EditValueChanged);
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[] { this.chartAppearanceBar1, this.chartTemplatesBar1, this.chartPrintExportBar1 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { 
                this.createBarBaseItem1, this.createLineBaseItem1, this.createPieBaseItem1, this.createRotatedBarBaseItem1, this.createAreaBaseItem1, this.createOtherSeriesTypesBaseItem1, this.changePaletteGalleryBaseItem1, this.changeAppearanceGalleryBaseBarManagerItem1, this.saveAsTemplateChartItem1, this.printPreviewChartItem1, this.printChartItem1, this.createExportBaseItem1, this.exportToPDFChartItem1, this.exportToHTMLChartItem1, this.exportToMHTChartItem1, this.exportToXLSChartItem1, 
                this.exportToXLSXChartItem1, this.exportToRTFChartItem1, this.exportToBMPChartItem1, this.exportToGIFChartItem1, this.exportToJPEGChartItem1, this.exportToPNGChartItem1, this.exportToTIFFChartItem1, this.createExportToImageBaseItem1
             });
            this.barManager1.MaxItemId = 0x1b;
            this.chartAppearanceBar1.BarName = "";
            this.chartAppearanceBar1.Control = this.chartControl1;
            this.chartAppearanceBar1.DockCol = 2;
            this.chartAppearanceBar1.DockRow = 0;
            this.chartAppearanceBar1.DockStyle = BarDockStyle.Top;
            this.chartAppearanceBar1.OptionsBar.DrawBorder = false;
            this.chartAppearanceBar1.OptionsBar.DrawDragBorder = false;
            this.chartAppearanceBar1.Text = "";
            diagram.AxisX.GridLines.Color = Color.LightGray;
            diagram.AxisX.GridLines.MinorColor = Color.LightGray;
            diagram.AxisX.MinorCount = 1;
            diagram.AxisX.VisibleInPanesSerializable = "-1";
            diagram.AxisY.GridLines.Color = Color.White;
            diagram.AxisY.GridLines.MinorColor = Color.DarkGray;
            diagram.AxisY.Interlaced = true;
            diagram.AxisY.VisibleInPanesSerializable = "-1";
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisXZooming = true;
            diagram.EnableAxisYScrolling = true;
            diagram.EnableAxisYZooming = true;
            this.chartControl1.Diagram = diagram;
            this.chartControl1.Dock = DockStyle.Fill;
            this.chartControl1.Location = new Point(2, 2);
            this.chartControl1.Name = "chartControl1";
            series.ArgumentScaleType = ScaleType.DateTime;
            series.LabelsVisibility = DefaultBoolean.True;
            series.LegendText = "实时波形";
            series.Name = "实时波形";
            series.View = view;
            series2.ArgumentScaleType = ScaleType.DateTime;
            series2.LabelsVisibility = DefaultBoolean.True;
            series2.LegendText = "标准波形";
            series2.Name = "标准波形";
            series2.View = view2;
            this.chartControl1.SeriesSerializable = new Series[] { series, series2 };
            this.chartControl1.SeriesTemplate.View = view3;
            this.chartControl1.Size = new Size(0x2ea, 0x1ca);
            this.chartControl1.TabIndex = 0;
            this.chartTemplatesBar1.Control = this.chartControl1;
            this.chartTemplatesBar1.DockCol = 0;
            this.chartTemplatesBar1.DockRow = 0;
            this.chartTemplatesBar1.DockStyle = BarDockStyle.Top;
            this.chartTemplatesBar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.saveAsTemplateChartItem1, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printPreviewChartItem1, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.printChartItem1, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changePaletteGalleryBaseItem1, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.changeAppearanceGalleryBaseBarManagerItem1, BarItemPaintStyle.CaptionGlyph), new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.createExportBaseItem1, BarItemPaintStyle.CaptionGlyph) });
            this.chartTemplatesBar1.OptionsBar.DrawBorder = false;
            this.chartTemplatesBar1.OptionsBar.DrawDragBorder = false;
            this.saveAsTemplateChartItem1.Caption = "保存";
            this.saveAsTemplateChartItem1.Id = 9;
            this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
            item.Text = "保存";
            item2.LeftIndent = 6;
            item2.Text = "以XML格式保存当前波形的数据";
            tip.Items.Add(item);
            tip.Items.Add(item2);
            this.saveAsTemplateChartItem1.SuperTip = tip;
            this.printPreviewChartItem1.Caption = "预览";
            this.printPreviewChartItem1.Id = 11;
            this.printPreviewChartItem1.Name = "printPreviewChartItem1";
            item3.Text = "预览";
            item4.LeftIndent = 6;
            item4.Text = "打印前预览和编辑波形";
            tip2.Items.Add(item3);
            tip2.Items.Add(item4);
            this.printPreviewChartItem1.SuperTip = tip2;
            this.printChartItem1.Caption = "打印";
            this.printChartItem1.Id = 12;
            this.printChartItem1.Name = "printChartItem1";
            item5.Text = "打印";
            item6.LeftIndent = 6;
            item6.Text = "选择打印机或其它打印设备打印当前波形";
            tip3.Items.Add(item5);
            tip3.Items.Add(item6);
            this.printChartItem1.SuperTip = tip3;
            this.changePaletteGalleryBaseItem1.Caption = "线条颜色";
            this.changePaletteGalleryBaseItem1.DropDownControl = this.commandBarGalleryDropDown7;
            this.changePaletteGalleryBaseItem1.Id = 6;
            this.changePaletteGalleryBaseItem1.Name = "changePaletteGalleryBaseItem1";
            this.changePaletteGalleryBaseItem1.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            item7.Text = "线条颜色";
            item8.LeftIndent = 6;
            item8.Text = "改变当前图表的线条样式";
            tip4.Items.Add(item7);
            tip4.Items.Add(item8);
            this.changePaletteGalleryBaseItem1.SuperTip = tip4;
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
            edges.Bottom = -3;
            edges.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemImagePadding = edges;
            edges2.Bottom = -3;
            edges2.Top = -3;
            this.commandBarGalleryDropDown7.Gallery.ItemTextPadding = edges2;
            this.commandBarGalleryDropDown7.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown7.Gallery.ShowGroupCaption = false;
            this.commandBarGalleryDropDown7.Gallery.ShowItemText = true;
            this.commandBarGalleryDropDown7.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown7.Manager = this.barManager1;
            this.commandBarGalleryDropDown7.Name = "commandBarGalleryDropDown7";
            this.changeAppearanceGalleryBaseBarManagerItem1.Caption = "画板";
            this.changeAppearanceGalleryBaseBarManagerItem1.DropDownControl = this.commandBarGalleryDropDown8;
            this.changeAppearanceGalleryBaseBarManagerItem1.GlyphDisabled = (Image) manager.GetObject("changeAppearanceGalleryBaseBarManagerItem1.GlyphDisabled");
            this.changeAppearanceGalleryBaseBarManagerItem1.Id = 7;
            this.changeAppearanceGalleryBaseBarManagerItem1.Name = "changeAppearanceGalleryBaseBarManagerItem1";
            item9.Text = "画板";
            item10.LeftIndent = 6;
            item10.Text = "包含通过选择调色板来改变其外观的一系列样式的图表";
            tip5.Items.Add(item9);
            tip5.Items.Add(item10);
            this.changeAppearanceGalleryBaseBarManagerItem1.SuperTip = tip5;
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
            this.createExportBaseItem1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.exportToPDFChartItem1), new LinkPersistInfo(this.exportToHTMLChartItem1), new LinkPersistInfo(this.exportToMHTChartItem1), new LinkPersistInfo(this.exportToXLSChartItem1), new LinkPersistInfo(this.exportToXLSXChartItem1), new LinkPersistInfo(this.exportToRTFChartItem1), new LinkPersistInfo(this.createExportToImageBaseItem1) });
            this.createExportBaseItem1.MenuDrawMode = MenuDrawMode.SmallImagesText;
            this.createExportBaseItem1.Name = "createExportBaseItem1";
            item11.Text = "导出 ";
            item12.LeftIndent = 6;
            item12.Text = "可将当前波形导出为指定格式的的文件并保存";
            tip6.Items.Add(item11);
            tip6.Items.Add(item12);
            this.createExportBaseItem1.SuperTip = tip6;
            this.exportToPDFChartItem1.Id = 14;
            this.exportToPDFChartItem1.Name = "exportToPDFChartItem1";
            this.exportToHTMLChartItem1.Id = 15;
            this.exportToHTMLChartItem1.Name = "exportToHTMLChartItem1";
            this.exportToMHTChartItem1.Id = 0x10;
            this.exportToMHTChartItem1.Name = "exportToMHTChartItem1";
            this.exportToXLSChartItem1.Id = 0x11;
            this.exportToXLSChartItem1.Name = "exportToXLSChartItem1";
            this.exportToXLSXChartItem1.Id = 0x12;
            this.exportToXLSXChartItem1.Name = "exportToXLSXChartItem1";
            this.exportToRTFChartItem1.Id = 0x13;
            this.exportToRTFChartItem1.Name = "exportToRTFChartItem1";
            this.createExportToImageBaseItem1.Id = 20;
            this.createExportToImageBaseItem1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.exportToBMPChartItem1), new LinkPersistInfo(this.exportToGIFChartItem1), new LinkPersistInfo(this.exportToJPEGChartItem1), new LinkPersistInfo(this.exportToPNGChartItem1), new LinkPersistInfo(this.exportToTIFFChartItem1) });
            this.createExportToImageBaseItem1.MenuDrawMode = MenuDrawMode.SmallImagesText;
            this.createExportToImageBaseItem1.Name = "createExportToImageBaseItem1";
            this.exportToBMPChartItem1.Id = 0x15;
            this.exportToBMPChartItem1.Name = "exportToBMPChartItem1";
            this.exportToGIFChartItem1.Id = 0x16;
            this.exportToGIFChartItem1.Name = "exportToGIFChartItem1";
            this.exportToJPEGChartItem1.Id = 0x17;
            this.exportToJPEGChartItem1.Name = "exportToJPEGChartItem1";
            this.exportToPNGChartItem1.Id = 0x18;
            this.exportToPNGChartItem1.Name = "exportToPNGChartItem1";
            this.exportToTIFFChartItem1.Id = 0x19;
            this.exportToTIFFChartItem1.Name = "exportToTIFFChartItem1";
            this.chartPrintExportBar1.BarName = "";
            this.chartPrintExportBar1.Control = this.chartControl1;
            this.chartPrintExportBar1.DockCol = 1;
            this.chartPrintExportBar1.DockRow = 0;
            this.chartPrintExportBar1.DockStyle = BarDockStyle.Top;
            this.chartPrintExportBar1.Offset = 0x47;
            this.chartPrintExportBar1.OptionsBar.DrawBorder = false;
            this.chartPrintExportBar1.OptionsBar.DrawDragBorder = false;
            this.chartPrintExportBar1.Text = "";
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(0x39c, 0x1f);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x233);
            this.barDockControlBottom.Size = new Size(0x39c, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 0x1f);
            this.barDockControlLeft.Size = new Size(0, 0x214);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x39c, 0x1f);
            this.barDockControlRight.Size = new Size(0, 0x214);
            this.createBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown1;
            this.createBarBaseItem1.Id = 0;
            this.createBarBaseItem1.Name = "createBarBaseItem1";
            this.commandBarGalleryDropDown1.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown1.Gallery.ColumnCount = 4;
            column.Items.AddRange(new GalleryItem[] { item13, item14, item15, item16, item17 });
            column2.Items.AddRange(new GalleryItem[] { item18, item19, item20, item21, item22, item23 });
            column3.Items.AddRange(new GalleryItem[] { item24, item25, item26, item27, item28, item29 });
            column4.Items.AddRange(new GalleryItem[] { item30, item31, item32, item33, item34, item35 });
            column5.Items.AddRange(new GalleryItem[] { item36, item37, item38, item39, item40, item41 });
            this.commandBarGalleryDropDown1.Gallery.Groups.AddRange(new GalleryItemGroup[] { column, column2, column3, column4, column5 });
            this.commandBarGalleryDropDown1.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown1.Gallery.RowCount = 10;
            this.commandBarGalleryDropDown1.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown1.Manager = this.barManager1;
            this.commandBarGalleryDropDown1.Name = "commandBarGalleryDropDown1";
            this.createLineBaseItem1.DropDownControl = this.commandBarGalleryDropDown2;
            this.createLineBaseItem1.Id = 1;
            this.createLineBaseItem1.Name = "createLineBaseItem1";
            this.commandBarGalleryDropDown2.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown2.Gallery.ColumnCount = 3;
            line.Items.AddRange(new GalleryItem[] { item42, item43, item44, item45, item46, item47 });
            line2.Items.AddRange(new GalleryItem[] { item48, item49, item50, item51, item52 });
            this.commandBarGalleryDropDown2.Gallery.Groups.AddRange(new GalleryItemGroup[] { line, line2 });
            this.commandBarGalleryDropDown2.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown2.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown2.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown2.Manager = this.barManager1;
            this.commandBarGalleryDropDown2.Name = "commandBarGalleryDropDown2";
            this.createPieBaseItem1.DropDownControl = this.commandBarGalleryDropDown3;
            this.createPieBaseItem1.Id = 2;
            this.createPieBaseItem1.Name = "createPieBaseItem1";
            this.commandBarGalleryDropDown3.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown3.Gallery.ColumnCount = 2;
            pie.Items.AddRange(new GalleryItem[] { item53, item54 });
            pie2.Items.AddRange(new GalleryItem[] { item55, item56 });
            this.commandBarGalleryDropDown3.Gallery.Groups.AddRange(new GalleryItemGroup[] { pie, pie2 });
            this.commandBarGalleryDropDown3.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown3.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown3.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown3.Manager = this.barManager1;
            this.commandBarGalleryDropDown3.Name = "commandBarGalleryDropDown3";
            this.createRotatedBarBaseItem1.DropDownControl = this.commandBarGalleryDropDown4;
            this.createRotatedBarBaseItem1.Id = 3;
            this.createRotatedBarBaseItem1.Name = "createRotatedBarBaseItem1";
            this.commandBarGalleryDropDown4.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown4.Gallery.ColumnCount = 3;
            bar.Items.AddRange(new GalleryItem[] { item57, item58, item59, item60, item61 });
            this.commandBarGalleryDropDown4.Gallery.Groups.AddRange(new GalleryItemGroup[] { bar });
            this.commandBarGalleryDropDown4.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown4.Gallery.RowCount = 2;
            this.commandBarGalleryDropDown4.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown4.Manager = this.barManager1;
            this.commandBarGalleryDropDown4.Name = "commandBarGalleryDropDown4";
            this.createAreaBaseItem1.DropDownControl = this.commandBarGalleryDropDown5;
            this.createAreaBaseItem1.Id = 4;
            this.createAreaBaseItem1.Name = "createAreaBaseItem1";
            this.commandBarGalleryDropDown5.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown5.Gallery.ColumnCount = 4;
            area.Items.AddRange(new GalleryItem[] { item62, item63, item64, item65, item66, item67, item68 });
            area2.Items.AddRange(new GalleryItem[] { item69, item70, item71, item72, item73, item74, item75 });
            this.commandBarGalleryDropDown5.Gallery.Groups.AddRange(new GalleryItemGroup[] { area, area2 });
            this.commandBarGalleryDropDown5.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown5.Gallery.RowCount = 4;
            this.commandBarGalleryDropDown5.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown5.Manager = this.barManager1;
            this.commandBarGalleryDropDown5.Name = "commandBarGalleryDropDown5";
            this.createOtherSeriesTypesBaseItem1.DropDownControl = this.commandBarGalleryDropDown6;
            this.createOtherSeriesTypesBaseItem1.Id = 5;
            this.createOtherSeriesTypesBaseItem1.Name = "createOtherSeriesTypesBaseItem1";
            this.commandBarGalleryDropDown6.Gallery.AllowFilter = false;
            this.commandBarGalleryDropDown6.Gallery.ColumnCount = 4;
            point.Items.AddRange(new GalleryItem[] { item76, item77 });
            funnel.Items.AddRange(new GalleryItem[] { item78, item79 });
            financial.Items.AddRange(new GalleryItem[] { item80, item81 });
            radar.Items.AddRange(new GalleryItem[] { item82, item83, item84 });
            polar.Items.AddRange(new GalleryItem[] { item85, item86, item87 });
            range.Items.AddRange(new GalleryItem[] { item88, item89, item90, item91 });
            gantt.Items.AddRange(new GalleryItem[] { item92, item93 });
            this.commandBarGalleryDropDown6.Gallery.Groups.AddRange(new GalleryItemGroup[] { point, funnel, financial, radar, polar, range, gantt });
            this.commandBarGalleryDropDown6.Gallery.ImageSize = new Size(0x20, 0x20);
            this.commandBarGalleryDropDown6.Gallery.RowCount = 7;
            this.commandBarGalleryDropDown6.Gallery.ShowScrollBar = ShowScrollBar.Auto;
            this.commandBarGalleryDropDown6.Manager = this.barManager1;
            this.commandBarGalleryDropDown6.Name = "commandBarGalleryDropDown6";
            this.checkEdit1.Location = new Point(5, 0x20);
            this.checkEdit1.MenuManager = this.barManager1;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "网格线";
            this.checkEdit1.Size = new Size(0x4b, 0x13);
            this.checkEdit1.TabIndex = 12;
            this.checkEdit1.CheckedChanged += new EventHandler(this.checkEdit1_CheckedChanged);
            int[] bits = new int[4];
            bits[0] = 10;
            this.spinEdit3.EditValue = new decimal(bits);
            this.spinEdit3.Location = new Point(0x143, 0x20);
            this.spinEdit3.Name = "spinEdit3";
            this.spinEdit3.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            bits = new int[4];
            bits[0] = 0x13;
            this.spinEdit3.Properties.MaxValue = new decimal(bits);
            bits = new int[4];
            bits[0] = 1;
            this.spinEdit3.Properties.MinValue = new decimal(bits);
            this.spinEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.spinEdit3.Size = new Size(0x41, 20);
            this.spinEdit3.TabIndex = 11;
            this.labelControl6.Location = new Point(0xf9, 0x23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new Size(60, 14);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "移动速度：";
            this.panelControl4.Controls.Add(this.chartControl1);
            this.panelControl4.Dock = DockStyle.Fill;
            this.panelControl4.Location = new Point(0xae, 0x1f);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(750, 0x1ce);
            this.panelControl4.TabIndex = 3;
            this.timer1.Interval = 0x3e8;
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
            base.ClientSize = new Size(0x39c, 0x233);
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
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.treeList1.EndInit();
            this.panelControl5.EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl3.EndInit();
            this.panelControl3.ResumeLayout(false);
            this.groupControl2.EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.colorEdit1.Properties.EndInit();
            this.barManager1.EndInit();
            ((ISupportInitialize) diagram).EndInit();
            ((ISupportInitialize) view).EndInit();
            ((ISupportInitialize) series).EndInit();
            ((ISupportInitialize) view2).EndInit();
            ((ISupportInitialize) series2).EndInit();
            ((ISupportInitialize) view3).EndInit();
            this.chartControl1.EndInit();
            this.commandBarGalleryDropDown7.EndInit();
            this.commandBarGalleryDropDown8.EndInit();
            this.commandBarGalleryDropDown1.EndInit();
            this.commandBarGalleryDropDown2.EndInit();
            this.commandBarGalleryDropDown3.EndInit();
            this.commandBarGalleryDropDown4.EndInit();
            this.commandBarGalleryDropDown5.EndInit();
            this.commandBarGalleryDropDown6.EndInit();
            this.checkEdit1.Properties.EndInit();
            this.spinEdit3.Properties.EndInit();
            this.panelControl4.EndInit();
            this.panelControl4.ResumeLayout(false);
            ((ISupportInitialize) this.chartBarController1).EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled)
            {
                MessageBox.Show("监测正在进行");
            }
            else if (this.selecttypeid == 0)
            {
                MessageBox.Show("请选择要监控的对象");
            }
            else
            {
                this.currenttypeid = this.selecttypeid;
                switch (this.currenttypeid)
                {
                    case 1:
                        this.Series1.Name = "实时温度";
                        this.Series2.Name = "标准温度";
                        break;

                    case 2:
                        this.Series1.Name = "实时转速";
                        this.Series2.Name = "标准转速";
                        break;
                }
                this.timer1.Enabled = true;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((this.Series1 != null) && (this.Series2 != null))
            {
                DateTime now = DateTime.Now;
                int num = 500;
                int num2 = 2;
                SeriesPoint[] pointsToUpdate = new SeriesPoint[num2];
                SeriesPoint[] pointArray2 = new SeriesPoint[num2];
                for (int i = 0; i < num2; i++)
                {
                    pointsToUpdate[i] = new SeriesPoint(now, new double[] { this.value1 });
                    pointArray2[i] = new SeriesPoint(now, new double[] { this.value2 });
                    now = now.AddMilliseconds((double) num);
                    this.UpdateValues();
                }
                DateTime minValue = now.AddSeconds((double) -this.TimeInterval);
                int count = 0;
                foreach (SeriesPoint point in this.Series1.Points)
                {
                    if (point.DateTimeArgument < minValue)
                    {
                        count++;
                    }
                }
                if (count < this.Series1.Points.Count)
                {
                    count--;
                }
                this.AddPoints(this.Series1, pointsToUpdate);
                this.AddPoints(this.Series2, pointArray2);
                if (count > 0)
                {
                    this.Series1.Points.RemoveRange(0, count);
                    this.Series2.Points.RemoveRange(0, count);
                }
                if ((this.diagram != null) && ((this.diagram.AxisX.DateTimeScaleOptions.MeasureUnit == DateTimeMeasureUnit.Second) || (this.diagram.AxisX.DateTimeScaleOptions.ScaleMode == ScaleMode.Continuous)))
                {
                    this.diagram.AxisX.WholeRange.SetMinMaxValues(minValue, now);
                }
            }
        }

        private void treeList1_AfterFocusNode(object sender, NodeEventArgs e)
        {
            if (!this.timer1.Enabled)
            {
                this.currenttypeid = (int) e.Node.GetValue("TypeId");
            }
            this.selecttypeid = (int) e.Node.GetValue("TypeId");
        }

        private void UpdateValues()
        {
            RTData newdata = null;
            lock (CacheInvoke.newdata)
            {
                newdata = CacheInvoke.newdata;
            }
            if (newdata == null)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                string fDJLQYWD = string.Empty;
                switch (this.currenttypeid)
                {
                    case 1:
                        this.value2 = 70.0;
                        if (newdata == null)
                        {
                            this.value1 = 0.0;
                            return;
                        }
                        fDJLQYWD = newdata.FDJLQYWD;
                        if (string.IsNullOrEmpty(fDJLQYWD))
                        {
                            break;
                        }
                        this.value1 = Convert.ToDouble(fDJLQYWD.Remove(fDJLQYWD.IndexOf('℃')));
                        return;

                    case 2:
                        this.value2 = 800.0;
                        if (newdata == null)
                        {
                            this.value1 = 0.0;
                            break;
                        }
                        fDJLQYWD = newdata.FDJZS;
                        if (string.IsNullOrEmpty(fDJLQYWD))
                        {
                            break;
                        }
                        this.value1 = Convert.ToDouble(fDJLQYWD.Remove(fDJLQYWD.IndexOf('r')));
                        return;

                    default:
                        return;
                }
            }
        }

        private SwiftPlotDiagram diagram
        {
            get
            {
                return (this.chartControl1.Diagram as SwiftPlotDiagram);
            }
        }

        private Series Series1
        {
            get
            {
                if (this.chartControl1.Series.Count <= 0)
                {
                    return null;
                }
                return this.chartControl1.Series[0];
            }
        }

        private Series Series2
        {
            get
            {
                if (this.chartControl1.Series.Count <= 1)
                {
                    return null;
                }
                return this.chartControl1.Series[1];
            }
        }

        private int TimeInterval
        {
            get
            {
                return (20 - Convert.ToInt32(this.spinEdit3.EditValue));
            }
        }
    }
}

