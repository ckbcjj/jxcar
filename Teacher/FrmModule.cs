using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace Teacher
{


    public class FrmModule : XtraForm
    {
        private string alertMsg = "系统已连接当前模块,请先断开连接再尝试";
        private Bar bar2;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarLargeButtonItem barLargeButtonItem1;
        private BarLargeButtonItem barLargeButtonItem2;
        private BarLargeButtonItem barLargeButtonItem3;
        private BarLargeButtonItem barLargeButtonItem4;
        private BarManager barManager1;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridControl gridControl1;
        private GridView gridView1;

        public FrmModule()
        {
            this.InitializeComponent();
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else
            {
                FrmModuleEdit edit = new FrmModuleEdit(null);
                if (edit.ShowDialog(this) == DialogResult.OK)
                {
                    this.BindData();
                }
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要编辑的项");
            }
            else
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    if (dataRow["id"].ToString() == ServerSystemInfo.ModuleId.ToString())
                    {
                        MessageBox.Show(this.alertMsg);
                    }
                    else
                    {
                        FrmModuleEdit edit = new FrmModuleEdit(dataRow);
                        if (edit.ShowDialog(this) == DialogResult.OK)
                        {
                            this.BindData();
                        }
                    }
                }
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (((LoginInfo.UserName != "SYSTEM") || (LoginInfo.Password != "GTA2015")) || (LoginInfo.RoleId != 0))
            {
                MessageBox.Show("您不是超级管理员,无权使用此项功能!");
            }
            else if (this.gridView1.GetSelectedRows().Length == 0)
            {
                MessageBox.Show("请选择要删除的项");
            }
            else if (MessageBox.Show("确定删除该模块吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
            {
                DataRow dataRow = this.gridView1.GetDataRow(this.gridView1.GetSelectedRows()[0]);
                if (dataRow != null)
                {
                    if (dataRow["id"].ToString() == ServerSystemInfo.ModuleId.ToString())
                    {
                        MessageBox.Show(this.alertMsg);
                    }
                    else if (this.da.SqlCommand("delete sysmodule where id=" + int.Parse(dataRow["id"].ToString())))
                    {
                        string msg = string.Format("系统模块[{0}]成功删除", dataRow["modulename"].ToString());
                        this.da.WriteLog(LoginInfo.UserName, msg);
                        MessageBox.Show("删除成功");
                        this.BindData();
                    }
                }
            }
        }

        private void barLargeButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            DataTable list = new DataTable();
            string sql = "select * from sysmodule";
            list = this.da.GetList(sql);
            this.gridControl1.DataSource = list;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmModule_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmModule));
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
            this.barManager1.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            base.SuspendLayout();
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[] { this.bar2 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.barLargeButtonItem1, this.barLargeButtonItem2, this.barLargeButtonItem3, this.barLargeButtonItem4 });
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barLargeButtonItem1), new LinkPersistInfo(this.barLargeButtonItem2), new LinkPersistInfo(this.barLargeButtonItem3), new LinkPersistInfo(this.barLargeButtonItem4, true) });
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "增加模块";
            this.barLargeButtonItem1.Glyph = (Image) manager.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 4;
            this.barLargeButtonItem1.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "编辑模块";
            this.barLargeButtonItem2.Glyph = (Image) manager.GetObject("barLargeButtonItem2.Glyph");
            this.barLargeButtonItem2.Id = 5;
            this.barLargeButtonItem2.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem2.LargeGlyph");
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.barLargeButtonItem3.Caption = "删除模块";
            this.barLargeButtonItem3.Glyph = (Image) manager.GetObject("barLargeButtonItem3.Glyph");
            this.barLargeButtonItem3.Id = 6;
            this.barLargeButtonItem3.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem3.LargeGlyph");
            this.barLargeButtonItem3.Name = "barLargeButtonItem3";
            this.barLargeButtonItem3.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            this.barLargeButtonItem4.Caption = "刷新";
            this.barLargeButtonItem4.Glyph = (Image) manager.GetObject("barLargeButtonItem4.Glyph");
            this.barLargeButtonItem4.Id = 7;
            this.barLargeButtonItem4.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem4.LargeGlyph");
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barLargeButtonItem4.Visibility = BarItemVisibility.Never;
            this.barLargeButtonItem4.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(0x250, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x192);
            this.barDockControlBottom.Size = new Size(0x250, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 0x156);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x250, 60);
            this.barDockControlRight.Size = new Size(0, 0x156);
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(0x250, 0x156);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x45;
            this.gridColumn2.Caption = "模块名";
            this.gridColumn2.FieldName = "ModuleName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 0x103;
            this.gridColumn3.Caption = "台架名";
            this.gridColumn3.FieldName = "CarClass";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 0xf6;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x250, 0x192);
            base.Controls.Add(this.gridControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmModule";
            this.Text = "系统模块";
            base.Load += new EventHandler(this.FrmModule_Load);
            this.barManager1.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            base.ResumeLayout(false);
        }
    }
}

