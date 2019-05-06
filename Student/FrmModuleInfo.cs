using BLL.Common;
using BLL.Core;
using BLL.Service;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student
{
    public class FrmModuleInfo : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DataTable dt2;

        private StringBuilder sb;

        private IContainer components;

        private GridControl gridControl1;

        private GridView gridView1;

        private GridColumn gridColumn2;

        private GridColumn gridColumn3;

        private GridColumn gridColumn4;

        private GridColumn gridColumn5;

        private GridColumn gridColumn1;

        private BarManager barManager1;

        private Bar bar2;

        private BarLargeButtonItem barLargeButtonItem1;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlLeft;

        private BarDockControl barDockControlRight;

        private GridColumn gridColumn6;

        public FrmModuleInfo()
        {
            this.InitializeComponent();
        }

        private void FrmFault_Load(object sender, EventArgs e)
        {
            ClientListenManager.ListenEvent += new ListenDelegate(this.ListenManager_ListenEvent);
            this.BindData1();
        }

        private string GetPatternStr(int ModuleId, int FaultPointId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DataTable list = this.da.GetList(string.Concat(new object[]
			{
				"select PatternList,NormalIsBreak from FaultPoint where Id=",
				FaultPointId,
				" and ModuleId=",
				ModuleId
			}));
            if (list != null && list.Rows.Count != 0)
            {
                string text = list.Rows[0][0].ToString();
                if (!string.IsNullOrEmpty(text))
                {
                    string[] array = text.Split(new char[]
					{
						','
					});
                    this.dt2 = this.da.GetList("select * from FaultPattern");
                    string[] array2 = array;
                    for (int i = 0; i < array2.Length; i++)
                    {
                        string s = array2[i];
                        string text2 = this.dt2.Select(" OrderId=" + int.Parse(s)).First<DataRow>()["OrderName"].ToString();
                        if (!string.IsNullOrEmpty(text2))
                        {
                            stringBuilder.Append(text2 + ",");
                        }
                    }
                    stringBuilder = stringBuilder.Remove(stringBuilder.ToString().LastIndexOf(','), 1);
                }
            }
            return stringBuilder.ToString();
        }

        public void BindData1()
        {
            this.sb = new StringBuilder();
            string sql = "select *,'' as Pattern,'' as PointState,'' as IsNormal from FaultPoint  where ModuleId=" + ClientSystemInfo.ModuleId;
            this.dt = this.da.GetList(sql);
            foreach (DataRow dataRow in this.dt.Rows)
            {
                dataRow["Pattern"] = this.GetPatternStr(int.Parse(dataRow["ModuleId"].ToString()), int.Parse(dataRow["Id"].ToString()));
                this.sb.Append(string.Format("{0},", dataRow["Id"].ToString()));
            }
            this.gridControl1.DataSource = this.dt;
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool flag = false;
            if (ClientSystemInfo.ModuleId == 0)
            {
                MessageBox.Show("服务器已断开,请稍候再试");
                return;
            }
            if (ClientSystemInfo.SysPattern == 1 || CheckInfo.PcCheckState)
            {
                MessageBox.Show("当前为实训考核模式,不能查询故障点状态");
                return;
            }
            try
            {
                string text = this.sb.ToString();
                string arg = text.Remove(text.LastIndexOf(','), 1);
                SocketInfo sI = new SocketInfo
                {
                    Msg = string.Format("{0}:{1}", ClientSystemInfo.ModuleId, arg),
                    Type = SocketInfoType.ReadPointState
                };
                flag = TcpClient.SendMessage(sI);
            }
            finally
            {
                string text2 = flag ? "命令发送成功" : "命令发送失败";
                MessageBox.Show(text2);
            }
        }

        private void ListenManager_ListenEvent(object sender, ListenEventArgs e)
        {
            try
            {
                if (e._eventType == SocketInfoType.ReadPointState)
                {
                    List<int> list = (List<int>)e.value;
                    if (list != null)
                    {
                        int count = list.Count;
                        int count2 = this.dt.Rows.Count;
                        int num = (count >= count2) ? count2 : count;
                        string text = "读取故障失败";
                        for (int i = 0; i < num; i++)
                        {
                            bool flag = this.dt.Rows[i]["NormalIsBreak"].ToString() == "True";
                            if (list[i] == 0)
                            {
                                this.dt.Rows[i]["PointState"] = text;
                            }
                            else
                            {
                                text = this.dt2.Select("OrderId=" + list[i])[0]["OrderName"].ToString();
                                this.dt.Rows[i]["PointState"] = text;
                                if ((text == "断路" && flag) || (text == "通路" && !flag))
                                {
                                    this.dt.Rows[i]["IsNormal"] = "正常";
                                }
                                else
                                {
                                    this.dt.Rows[i]["IsNormal"] = "有故障";
                                }
                            }
                        }
                        if (count2 > num)
                        {
                            for (int j = num; j < count2; j++)
                            {
                                this.dt.Rows[j]["PointState"] = text;
                            }
                        }
                        base.Invoke(new MethodInvoker(delegate
                        {
                            this.gridControl1.RefreshDataSource();
                        }));
                    }
                }
            }
            catch
            {
                MessageBox.Show("界面数据更新出错");
            }
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmModuleInfo));
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn1 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            ((ISupportInitialize)this.barManager1).BeginInit();
            base.SuspendLayout();
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(0, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new Size(679, 374);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView1
			});
            this.gridView1.Columns.AddRange(new GridColumn[]
			{
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4,
				this.gridColumn1,
				this.gridColumn5,
				this.gridColumn6
			});
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 99;
            this.gridColumn3.Caption = "故障点";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 186;
            this.gridColumn4.Caption = "可设指令";
            this.gridColumn4.FieldName = "Pattern";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 186;
            this.gridColumn1.Caption = "当前状态";
            this.gridColumn1.FieldName = "PointState";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 86;
            this.gridColumn5.Caption = "备注说明";
            this.gridColumn5.FieldName = "PointMemo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 190;
            this.gridColumn6.Caption = "是否正常";
            this.gridColumn6.FieldName = "IsNormal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
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
				this.barLargeButtonItem1
			});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[]
			{
				new LinkPersistInfo(this.barLargeButtonItem1)
			});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem1.Caption = "读取故障";
            this.barLargeButtonItem1.Glyph = (Image)componentResourceManager.GetObject("barLargeButtonItem1.Glyph");
            this.barLargeButtonItem1.Id = 0;
            this.barLargeButtonItem1.LargeGlyph = (Image)componentResourceManager.GetObject("barLargeButtonItem1.LargeGlyph");
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(679, 60);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 434);
            this.barDockControlBottom.Size = new Size(679, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 60);
            this.barDockControlLeft.Size = new Size(0, 374);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(679, 60);
            this.barDockControlRight.Size = new Size(0, 374);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(679, 434);
            base.Controls.Add(this.gridControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "FrmModuleInfo";
            this.Text = "模块信息";
            base.Load += new EventHandler(this.FrmFault_Load);
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            ((ISupportInitialize)this.barManager1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
