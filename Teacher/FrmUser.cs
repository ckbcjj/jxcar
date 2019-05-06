using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Teacher;

namespace Teacher
{
    public class FrmUser : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DataTable dt2;

        private IContainer components;

        private BarManager barManager1;

        private Bar bar2;

        private BarLargeButtonItem barLargeButtonItem1;

        private BarLargeButtonItem barLargeButtonItem2;

        private BarLargeButtonItem barLargeButtonItem3;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private PanelControl panelControl2;

        private GridControl gridControl1;

        private GridView gridView1;

        private GridColumn gridColumn1;

        private GridColumn gridColumn2;

        private GridColumn gridColumn3;

        private GridColumn gridColumn4;

        private GridColumn gridColumn5;

        private GridColumn gridColumn6;

        private GridColumn gridColumn7;

        private PanelControl panelControl1;

        private SimpleButton simpleButton1;

        private TextEdit textEdit2;

        private LabelControl labelControl2;

        private TextEdit textEdit1;

        private LabelControl labelControl1;

        private Timer timer1;

        private BarLargeButtonItem barLargeButtonItem4;

        private SimpleButton simpleButton2;

        public FrmUser()
        {
            this.InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.timer1.Start();
        }

        public void BindData()
        {
            string sql = "select StudyNO,StudyName,(case IsMan when 0 then '女' else '男' end) as IsMan,UserName,PassWord,Mail,'离线'as IsOnline from UserInfo where RoleId=2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEditUser feu = new FrmEditUser(null);
            if (feu.ShowDialog(this) == DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            if (dr != null)
            {
                FrmEditUser fem = new FrmEditUser(dr);
                if (fem.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要删除的项");
                return;
            }
            if (MessageBox.Show("确定删除该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }
            DataRow dr = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
            string sql = "delete userinfo where StudyNO='" + dr["studyno"].ToString() + "'";
            bool Result = this.da.SqlCommand(sql);
            if (Result)
            {
                string msg = string.Format("删除用户[{0}]成功", dr["UserName"].ToString());
                this.da.WriteLog(LoginInfo.UserName, msg);
                MessageBox.Show(msg);
                this.BindData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            string no = this.textEdit1.Text.ToString().Trim();
            string name = this.textEdit2.Text.ToString().Trim();
            if (string.IsNullOrEmpty(no))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    sql.Append("  studyname like '%" + name + "%'");
                }
            }
            else if (!string.IsNullOrEmpty(name))
            {
                sql.Append(string.Concat(new string[]
				{
					"  studyno like '%",
					no,
					"%' and studyname like '%",
					name,
					"%'"
				}));
            }
            else
            {
                sql.Append("  studyno like '%" + no + "%'");
            }
            DataRow[] drs = this.dt.Select(sql.ToString());
            this.dt2 = this.dt.Clone();
            DataRow[] array = drs;
            for (int i = 0; i < array.Length; i++)
            {
                DataRow item = array[i];
                this.dt2.Rows.Add(item.ItemArray);
            }
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = this.dt2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TcpService.clientPool.Count != 0)
            {
                IEnumerator enumerator = this.dt.Rows.GetEnumerator();
                try
                {
                    DataRow item;
                    while (enumerator.MoveNext())
                    {
                        item = (DataRow)enumerator.Current;
                        if ((from t in TcpService.clientPool
                             where t.UserName == item["UserName"].ToString()
                             select t).Count<ClientInfo>() != 0)
                        {
                            item["IsOnline"] = "上线";
                            if (this.dt2 == null)
                            {
                                continue;
                            }
                            using (IEnumerator<DataRow> enumerator2 = (from DataRow t in this.dt2.Rows
                                                                       where t["StudyNO"].ToString() == item["StudyNO"].ToString()
                                                                       select t).GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    DataRow dr = enumerator2.Current;
                                    dr["IsOnline"] = "上线";
                                }
                                continue;
                            }
                        }
                        item["IsOnline"] = "离线";
                    }
                    goto IL_1C8;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            foreach (DataRow item3 in this.dt.Rows)
            {
                item3["IsOnline"] = "离线";
            }
            if (this.dt2 != null)
            {
                foreach (DataRow item2 in this.dt2.Rows)
                {
                    item2["IsOnline"] = "离线";
                }
            }
        IL_1C8:
            this.gridControl1.RefreshDataSource();
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "";
            this.textEdit2.Text = "";
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = this.dt;
        }

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUser));
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.barLargeButtonItem2 = new BarLargeButtonItem();
            this.barLargeButtonItem3 = new BarLargeButtonItem();
            this.barLargeButtonItem4 = new BarLargeButtonItem();
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
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.gridColumn7 = new GridColumn();
            this.panelControl1 = new PanelControl();
            this.simpleButton2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            this.textEdit2 = new TextEdit();
            this.labelControl2 = new LabelControl();
            this.textEdit1 = new TextEdit();
            this.labelControl1 = new LabelControl();
            this.panelControl2 = new PanelControl();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize)this.barManager1).BeginInit();
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.textEdit2.Properties).BeginInit();
            ((ISupportInitialize)this.textEdit1.Properties).BeginInit();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.barManager1.AllowMoveBarOnToolbar = false;
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
				this.barLargeButtonItem2,
				this.barLargeButtonItem3,
				this.barLargeButtonItem4
			});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem1, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem2, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem3, BarItemPaintStyle.CaptionGlyph),
				new LinkPersistInfo(BarLinkUserDefines.PaintStyle, this.barLargeButtonItem4, BarItemPaintStyle.CaptionGlyph)
			});
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "增加";
            this.barLargeButtonItem1.Glyph = (Image)resources.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 2;
            this.barLargeButtonItem1.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "修改";
            this.barLargeButtonItem2.Glyph = (Image)resources.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 3;
            this.barLargeButtonItem2.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barLargeButtonItem3.Caption = "删除";
            this.barLargeButtonItem3.Glyph = (Image)resources.GetObject("barLargeButtonItem3.Glyph");
            this.barLargeButtonItem3.Id = 4;
            this.barLargeButtonItem3.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem3.LargeGlyph");
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            this.barLargeButtonItem4.Caption = "刷新";
            this.barLargeButtonItem4.Glyph = (Image)resources.GetObject("barLargeButtonItem4.Glyph");
            this.barLargeButtonItem4.Id = 7;
            this.barLargeButtonItem4.LargeGlyph = (Image)resources.GetObject("barLargeButtonItem4.LargeGlyph");
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barLargeButtonItem4.Visibility = BarItemVisibility.Never;
            this.barLargeButtonItem4.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(716, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 457);
            this.barDockControlBottom.Size = new Size(716, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 397);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(716, 60);
            this.barDockControlRight.Size = new Size(0, 397);
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(712, 359);
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
				this.gridColumn5,
				this.gridColumn6,
				this.gridColumn7
			});
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoPopulateColumns = false;
            this.gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "StudyNO";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.FieldName = "StudyName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn3.Caption = "性别";
            this.gridColumn3.FieldName = "IsMan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn4.Caption = "用户名";
            this.gridColumn4.FieldName = "UserName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn5.Caption = "密码";
            this.gridColumn5.FieldName = "PassWord";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn6.Caption = "邮箱";
            this.gridColumn6.FieldName = "Mail";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn7.Caption = "当前在线状态";
            this.gridColumn7.FieldName = "IsOnline";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.textEdit2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = DockStyle.Top;
            this.panelControl1.Location = new Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(716, 34);
            this.panelControl1.TabIndex = 5;
            this.simpleButton2.Image = (Image)resources.GetObject("simpleButton2.Image");
            this.simpleButton2.Location = new Point(529, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(98, 30);
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "全部显示";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.simpleButton1.Image = (Image)resources.GetObject("simpleButton1.Image");
            this.simpleButton1.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButton1.Location = new Point(433, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(76, 34);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "查找";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.textEdit2.Location = new Point(308, 7);
            this.textEdit2.MenuManager = this.barManager1;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new Size(100, 20);
            this.textEdit2.TabIndex = 3;
            this.labelControl2.Location = new Point(225, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(72, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "按姓名查找：";
            this.textEdit1.Location = new Point(92, 6);
            this.textEdit1.MenuManager = this.barManager1;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new Size(100, 20);
            this.textEdit1.TabIndex = 1;
            this.labelControl1.Location = new Point(13, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "按编号查找：";
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = DockStyle.Fill;
            this.panelControl2.Location = new Point(0, 94);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(716, 363);
            this.panelControl2.TabIndex = 6;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(716, 457);
            base.Controls.Add(this.panelControl2);
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmUser";
            this.Text = "普通用户信息表";
            base.Load += new EventHandler(this.FrmUser_Load);
            ((ISupportInitialize)this.barManager1).EndInit();
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((ISupportInitialize)this.textEdit2.Properties).EndInit();
            ((ISupportInitialize)this.textEdit1.Properties).EndInit();
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}
