using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BLL.Core;
using DevExpress.Data;

namespace Teacher
{


    public class FrmManager : XtraForm
    {
        private Bar bar2;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarLargeButtonItem barLargeButtonItem4;
        private BarLargeButtonItem barLargeButtonItem5;
        private BarLargeButtonItem barLargeButtonItem6;
        private BarManager barManager1;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private DataTable dt;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridControl gridControl1;
        private GridView gridView1;

        public FrmManager()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else
            {
                FrmEditManager manager = new FrmEditManager(this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]));
                if (manager.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要注销的项");
            }
            else if (MessageBox.Show("确定注销该用户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (int.Parse(dataRow["RoleId"].ToString()) == 0)
                {
                    MessageBox.Show("管理员用户不可注销");
                }
                else
                {
                    string sql = "delete UserInfo where StudyNO='" + dataRow["StudyNO"].ToString() + "'";
                    if (this.da.SqlCommand(sql))
                    {
                        string msg = string.Format("注销用户[{0}]成功", dataRow["UserName"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show(msg);
                        this.BindData();
                    }
                }
            }
        }

        private void barLargeButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            string sql = "select StudyNO,StudyName,UserName,PassWord,RoleId,RoleName,mail,(case Userable when 0 then '待审核...' else '正常使用' end) as Userable from UserInfo where RoleId<>2";
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmManager_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmManager));
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn1 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem4 = new BarLargeButtonItem();
            this.barLargeButtonItem5 = new BarLargeButtonItem();
            this.barLargeButtonItem6 = new BarLargeButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.barManager1.BeginInit();
            base.SuspendLayout();
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x295, 0x13c);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn1, this.gridColumn4, this.gridColumn2, this.gridColumn3, this.gridColumn5 });
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new GridSummaryItem[] { new GridGroupSummaryItem(SummaryItemType.None, "RoleId", null, "") });
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn1.Caption = "身份";
            this.gridColumn1.FieldName = "RoleName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x5d;
            this.gridColumn4.Caption = "姓名";
            this.gridColumn4.FieldName = "StudyName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 0x74;
            this.gridColumn2.Caption = "用户名";
            this.gridColumn2.FieldName = "UserName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 0x8d;
            this.gridColumn3.Caption = "登录密码";
            this.gridColumn3.FieldName = "PassWord";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 0x8d;
            this.gridColumn5.Caption = "审核状态";
            this.gridColumn5.FieldName = "Userable";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 0x98;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[] { this.bar2 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.barLargeButtonItem4, this.barLargeButtonItem5, this.barLargeButtonItem6 });
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barLargeButtonItem4), new LinkPersistInfo(this.barLargeButtonItem5), new LinkPersistInfo(this.barLargeButtonItem6) });
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem4.Caption = "编辑用户信息";
            this.barLargeButtonItem4.Glyph = (Image) manager.GetObject("barLargeButtonItem4.Glyph");
            this.barLargeButtonItem4.Id = 5;
            this.barLargeButtonItem4.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem4.LargeGlyph");
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barLargeButtonItem4.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            this.barLargeButtonItem5.Caption = "注销用户";
            this.barLargeButtonItem5.Glyph = (Image) manager.GetObject("barLargeButtonItem5.Glyph");
            this.barLargeButtonItem5.Id = 6;
            this.barLargeButtonItem5.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem5.LargeGlyph");
            this.barLargeButtonItem5.Name = "barLargeButtonItem5";
            this.barLargeButtonItem5.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem5_ItemClick);
            this.barLargeButtonItem6.Caption = "刷新";
            this.barLargeButtonItem6.Glyph = (Image) manager.GetObject("barLargeButtonItem6.Glyph");
            this.barLargeButtonItem6.Id = 7;
            this.barLargeButtonItem6.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem6.LargeGlyph");
            this.barLargeButtonItem6.Name = "barLargeButtonItem6";
            this.barLargeButtonItem6.Visibility = BarItemVisibility.Never;
            this.barLargeButtonItem6.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem6_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(0x295, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x178);
            this.barDockControlBottom.Size = new Size(0x295, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 0x13c);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x295, 60);
            this.barDockControlRight.Size = new Size(0, 0x13c);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x295, 0x178);
            base.Controls.Add(this.gridControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmManager";
            this.Text = "特殊用户";
            base.Load += new EventHandler(this.FrmManager_Load);
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.barManager1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

