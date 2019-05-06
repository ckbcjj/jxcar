using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Teacher;

namespace Teacher
{
    public class FrmCheckScore : XtraForm
    {
        private IContainer components;

        private BarManager barManager1;

        private Bar bar2;

        private Bar bar3;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private PanelControl panelControl2;

        private GridControl gridControl2;

        private GridView gridView2;

        private PanelControl panelControl1;

        private GridControl gridControl1;

        private GridView gridView1;

        private GridColumn gridColumn1;

        private GridColumn gridColumn2;

        private GridColumn gridColumn3;

        private GridColumn gridColumn4;

        private GridColumn gridColumn5;

        private GridColumn gridColumn6;

        private GridColumn gridColumn7;

        private GridColumn gridColumn8;

        private GridColumn gridColumn9;

        private GridColumn gridColumn10;

        private GridColumn gridColumn11;

        private GridColumn gridColumn12;

        private RepositoryItemButtonEdit repositoryItemButtonEdit1;

        private PanelControl panelControl4;

        private PanelControl panelControl3;

        private GridColumn gridColumn14;

        private GridColumn gridColumn15;

        private GridColumn gridColumn16;

        private SimpleButton simpleButton2;

        private SimpleButton simpleButton1;

        private TextEdit textEdit1;

        private LabelControl labelControl2;

        private ComboBoxEdit comboBoxEdit1;

        private LabelControl labelControl1;

        private GridColumn gridColumn17;

        private GridColumn gridColumn19;

        private Timer timer1;

        private BarLargeButtonItem barLargeButtonItem1;

        private BarLargeButtonItem barLargeButtonItem2;

        private BarLargeButtonItem barLargeButtonItem3;

        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DataTable dt2;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCheckScore));
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.barLargeButtonItem2 = new BarLargeButtonItem();
            this.barLargeButtonItem3 = new BarLargeButtonItem();
            this.bar3 = new Bar();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn14 = new GridColumn();
            this.gridColumn15 = new GridColumn();
            this.gridColumn16 = new GridColumn();
            this.gridColumn17 = new GridColumn();
            this.gridColumn19 = new GridColumn();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.panelControl1 = new PanelControl();
            this.panelControl4 = new PanelControl();
            this.panelControl3 = new PanelControl();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.textEdit1 = new TextEdit();
            this.labelControl2 = new LabelControl();
            this.comboBoxEdit1 = new ComboBoxEdit();
            this.labelControl1 = new LabelControl();
            this.panelControl2 = new PanelControl();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.gridColumn9 = new GridColumn();
            this.gridColumn10 = new GridColumn();
            this.gridColumn11 = new GridColumn();
            this.gridColumn12 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.gridColumn8 = new GridColumn();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize)this.barManager1).BeginInit();
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            ((ISupportInitialize)this.repositoryItemButtonEdit1).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.panelControl4).BeginInit();
            this.panelControl4.SuspendLayout();
            ((ISupportInitialize)this.panelControl3).BeginInit();
            this.panelControl3.SuspendLayout();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            ((ISupportInitialize)this.gridControl2).BeginInit();
            ((ISupportInitialize)this.gridView2).BeginInit();
            base.SuspendLayout();
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[]
			{
				this.bar2,
				this.bar3
			});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[]
			{
				this.barLargeButtonItem1,
				this.barLargeButtonItem2,
				this.barLargeButtonItem3
			});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.FloatLocation = new Point(422, 153);
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.barLargeButtonItem1),
				new LinkPersistInfo(this.barLargeButtonItem2),
				new LinkPersistInfo(this.barLargeButtonItem3)
			});
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "预览";
            this.barLargeButtonItem1.Glyph = (Image)resources.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 8;
            this.barLargeButtonItem1.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "导出";
            this.barLargeButtonItem2.Glyph = (Image)resources.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 9;
            this.barLargeButtonItem2.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barLargeButtonItem3.Caption = "考核详情";
            this.barLargeButtonItem3.Glyph = (Image)resources.GetObject("barLargeButtonItem3.Glyph");
            this.barLargeButtonItem3.Id = 10;
            this.barLargeButtonItem3.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem3.LargeGlyph");
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(801, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 442);
            this.barDockControlBottom.Size = new Size(801, 23);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 382);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(801, 60);
            this.barDockControlRight.Size = new Size(0, 382);
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[]
			{
				this.repositoryItemButtonEdit1
			});
            this.gridControl1.Size = new Size(793, 337);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView1
			});
            this.gridView1.Columns.AddRange(new GridColumn[]
			{
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4,
				this.gridColumn14,
				this.gridColumn15,
				this.gridColumn16,
				this.gridColumn17,
				this.gridColumn19
			});
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "此次考核成绩";
            this.gridView1.RowClick += new RowClickEventHandler(this.gridView1_RowClick);
            this.gridColumn1.Caption = "学号";
            this.gridColumn1.FieldName = "StudyNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 59;
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "StudyName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 90;
            this.gridColumn3.Caption = "性别";
            this.gridColumn3.FieldName = "IsMan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 43;
            this.gridColumn4.Caption = "用户名";
            this.gridColumn4.FieldName = "UserName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 81;
            this.gridColumn14.Caption = "考核成绩";
            this.gridColumn14.FieldName = "score";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 103;
            this.gridColumn15.Caption = "答题次数";
            this.gridColumn15.FieldName = "testtimes";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 103;
            this.gridColumn16.Caption = "答题用时";
            this.gridColumn16.FieldName = "usetime";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            this.gridColumn16.Width = 115;
            this.gridColumn17.Caption = "答题时间";
            this.gridColumn17.FieldName = "begintime";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 7;
            this.gridColumn19.Caption = "考核状态";
            this.gridColumn19.FieldName = "CheckState";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 8;
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton()
			});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(801, 382);
            this.panelControl1.TabIndex = 5;
            this.panelControl4.Controls.Add(this.gridControl1);
            this.panelControl4.Dock = DockStyle.Fill;
            this.panelControl4.Location = new Point(2, 39);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(797, 341);
            this.panelControl4.TabIndex = 6;
            this.panelControl3.Controls.Add(this.simpleButton2);
            this.panelControl3.Controls.Add(this.simpleButton1);
            this.panelControl3.Controls.Add(this.textEdit1);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.comboBoxEdit1);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Dock = DockStyle.Top;
            this.panelControl3.Location = new Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(797, 37);
            this.panelControl3.TabIndex = 5;
            this.simpleButton2.Image = (Image)resources.GetObject("simpleButton2.Image");
            this.simpleButton2.Location = new Point(329, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(98, 30);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "全部显示";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image)resources.GetObject("simpleButton1.Image");
            this.simpleButton1.Location = new Point(246, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(77, 30);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "查找";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new Point(139, 5);
            this.textEdit1.MenuManager = this.barManager1;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(82, 20);
            this.textEdit1.TabIndex = 3;
            this.labelControl2.Location = new Point(105, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(28, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "查找:";
            this.comboBoxEdit1.EditValue = "学号";
            this.comboBoxEdit1.Location = new Point(24, 4);
            this.comboBoxEdit1.MenuManager = this.barManager1;
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[]
			{
				"学号",
				"姓名",
				"用户名"
			});
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new Size(75, 20);
            this.comboBoxEdit1.TabIndex = 1;
            this.labelControl1.Location = new Point(6, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(12, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "按";
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Dock = DockStyle.Bottom;
            this.panelControl2.Location = new Point(0, 243);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(801, 199);
            this.panelControl2.TabIndex = 6;
            this.gridControl2.Dock = DockStyle.Fill;
            this.gridControl2.Location = new Point(2, 2);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new Size(797, 195);
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
				this.gridColumn12
			});
            this.gridView2.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowViewCaption = true;
            this.gridView2.ViewCaption = "历史考试成绩";
            this.gridColumn9.Caption = "学号";
            this.gridColumn9.FieldName = "TesterNO";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn10.Caption = "姓名";
            this.gridColumn10.FieldName = "TesterName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn11.Caption = "考核成绩";
            this.gridColumn11.FieldName = "score";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn12.Caption = "考核时间";
            this.gridColumn12.FieldName = "begintime";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
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
            this.timer1.Interval = 3000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(801, 465);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmCheckScore";
            this.Text = "考核成绩查询";
            base.Load += new EventHandler(this.FrmCheckScore_Load);
            ((ISupportInitialize)this.barManager1).EndInit();
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            ((ISupportInitialize)this.repositoryItemButtonEdit1).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl4).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl3).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((ISupportInitialize)this.gridControl2).EndInit();
            ((ISupportInitialize)this.gridView2).EndInit();
            base.ResumeLayout(false);
        }

        public FrmCheckScore()
        {
            this.InitializeComponent();
        }

        private void FrmCheckScore_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.timer1.Start();
        }

        public void BindData()
        {
            string sql = "select StudyNO, StudyName,(case IsMan when 0 then '女' else '男' end) as IsMan,UserName,'' as AnswerList,'' as score, '' as testtimes,'' as usetime,'' as begintime,'未开始考核' as CheckState from UserInfo  where RoleId=2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataMember = "dt";
            this.gridControl1.DataSource = this.dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow[] drs;
            switch (this.comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    drs = this.dt.Select(" studyno like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
                case 1:
                    drs = this.dt.Select(" StudyName like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
                default:
                    drs = this.dt.Select(" username like '%" + this.textEdit1.Text.Trim() + "%'");
                    break;
            }
            this.dt2 = this.dt.Clone();
            DataRow[] array = drs;
            for (int i = 0; i < array.Length; i++)
            {
                DataRow item = array[i];
                this.dt2.Rows.Add(item.ItemArray);
            }
            this.gridControl1.DataSource = null;
            this.gridControl1.DataMember = "dt2";
            this.gridControl1.DataSource = this.dt2;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "";
            this.gridControl1.DataSource = null;
            this.gridControl1.DataMember = "dt";
            this.gridControl1.DataSource = this.dt;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataRow dr = this.gridView1.GetDataRow(e.RowHandle);
                if (dr != null && dr["StudyNO"] != null)
                {
                    string testerno = dr["StudyNO"].ToString();
                    string sql = "select TesterNO,TesterName,score,begintime from checkinfo where testerno='" + testerno + "'";
                    DataTable dt = this.da.GetList(sql);
                    this.gridControl2.DataSource = dt;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CacheInvoke.CheckPool != null && CacheInvoke.CheckPool.Count != 0)
            {
                IEnumerator enumerator = this.dt.Rows.GetEnumerator();
                try
                {
                    DataRow item;
                    while (enumerator.MoveNext())
                    {
                        item = (DataRow)enumerator.Current;
                        List<CheckInfo> CIlist = (from t in CacheInvoke.CheckPool
                                                  where t.UserName == item["UserName"].ToString()
                                                  select t).ToList<CheckInfo>();
                        if (CIlist.Count != 0)
                        {
                            CheckInfo CI = CIlist.FirstOrDefault<CheckInfo>();
                            item["AnswerList"] = CI.AnswerList;
                            item["score"] = CI.Score;
                            item["testtimes"] = CI.Times;
                            item["usetime"] = CI.UseTime;
                            item["begintime"] = CI.BeginTime;
                            item["CheckState"] = ((CI.State == 0) ? "未开始考核" : ((CI.State == 1) ? "正在答题" : "答题结束"));
                            if (this.dt2 != null)
                            {
                                foreach (DataRow dr in from DataRow t in this.dt2.Rows
                                                       where t["StudyNO"].ToString() == item["StudyNO"].ToString()
                                                       select t)
                                {
                                    dr["score"] = CI.Score;
                                    dr["testtimes"] = CI.Times;
                                    dr["usetime"] = CI.UseTime;
                                    dr["begintime"] = CI.BeginTime;
                                    dr["CheckState"] = ((CI.State == 0) ? "未开始考核" : ((CI.State == 1) ? "正在答题" : "答题结束"));
                                }
                            }
                            lock (CacheInvoke.CheckPool)
                            {
                                CacheInvoke.CheckPool.Remove(CI);
                            }
                        }
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintingSystem print = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(print);
            print.Links.Add(link);
            link.Component = this.gridControl1;
            string _PrintHeader = "学生成绩";
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            phf.Header.Content.AddRange(new string[]
			{
				"",
				_PrintHeader,
				""
			});
            phf.Header.Font = new Font("宋体", 14f, FontStyle.Bold);
            phf.Header.LineAlignment = BrickAlignment.Center;
            link.CreateDocument();
            print.PreviewFormEx.Show();
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                new XlsExportOptions();
                this.gridControl1.ExportToXls(fileDialog.FileName);
                XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要查看的学员");
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            if (dr["CheckState"].ToString() == "未开始考核" || dr["CheckState"].ToString() == "正在答题")
            {
                MessageBox.Show(string.Format("该生{0},无法查看详情", dr["CheckState"].ToString()));
                return;
            }
            if (dr != null)
            {
                new FrmCheckResult(dr)
                {
                    StartPosition = FormStartPosition.CenterParent
                }.ShowDialog(this);
            }
        }
    }
}
