namespace Teacher
{
    using BLL.Core;
    using BLL.OtherInfo;
    using BLL.Service;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
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
    using System.Net.Sockets;
    using System.Windows.Forms;

    public class FrmSetFault : XtraForm
    {
        private Bar bar2;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarLargeButtonItem barLargeButtonItem1;
        private BarLargeButtonItem barLargeButtonItem10;
        private BarLargeButtonItem barLargeButtonItem11;
        private BarLargeButtonItem barLargeButtonItem2;
        private BarLargeButtonItem barLargeButtonItem4;
        private BarLargeButtonItem barLargeButtonItem6;
        private BarLargeButtonItem barLargeButtonItem7;
        private BarLargeButtonItem barLargeButtonItem8;
        private BarLargeButtonItem barLargeButtonItem9;
        private BarManager barManager1;
        private BarStaticItem barStaticItem1;
        private BarStaticItem barStaticItem2;
        private BarStaticItem barStaticItem3;
        private byte[] buffer;
        private Button button1;
        private Socket client;
        private IContainer components;
        private DataAccess da = new DataAccess();
        private DataTable dt;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridControl gridControl1;
        private GridView gridView1;
        private PopupMenu popupMenu1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private const string str1 = "清除故障失败";
        private const string str2 = "读取状态失败";
        private const string str3 = "设置故障失败";
        private const string StrTxt = "对不起,您要操作的模块和接入的模块不一致。请接入该系统模块后再尝试";
        private const string StrTxt2 = "学生机考核进行中，不能操作";
        private const string StrTxt3 = "平板用户考核进行中，不能操作";
        private DataTable table;
        private TextBox textBox1;

        public FrmSetFault()
        {
            this.InitializeComponent();
            this.table = this.da.GetList("select * from faultpattern");
        }

        private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
            {
                row[0] = "True";
            }
        }

        private void barLargeButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ServerSystemInfo.ModuleId != ServerSystemInfo.SoftModuleId) || (ServerSystemInfo.SysPattern != 1))
            {
                CMessageInfo.ShowMessage("请先连接当前要操作的系统模块并且将软件运行模式设置为实训考核模式", "考核发题", 2);
            }
            else if (CheckInfo.PcCheckState)
            {
                MessageBox.Show("学生机考核进行中，不能操作");
            }
            else
            {
                ServerSystemInfo.dic = new Dictionary<int, string>();
                foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
                {
                    if (row[0].ToString() == "True")
                    {
                        string str = row["PointState"].ToString();
                        string.Compare(row["NormalIsBreak"].ToString(), "False", true);
                        if ((string.IsNullOrEmpty(str) || (str == "清除故障失败")) || ((str == "读取状态失败") || (str == "设置故障失败")))
                        {
                            CMessageInfo.ShowMessage("请先设置故障，再发题", "考核发题", 1);
                            return;
                        }
                        ServerSystemInfo.dic.Add(int.Parse(row[1].ToString()), str);
                    }
                }
                int num = (ServerSystemInfo.Counts == 0) ? this.dt.Rows.Count : ServerSystemInfo.Counts;
                SendCheckItem msg = new SendCheckItem {
                    ItemList = ServerSystemInfo.dic,
                    ScorePoint = ServerSystemInfo.ScorePoint,
                    Counts = num,
                    Time = ServerSystemInfo.PcTimeCount,
                    Memo = ServerSystemInfo.Memo
                };
                SysManager.SentToClient(TcpService.clientPool, LoginInfo.StudyNO, SocketInfoType.CheckItem, msg);
                CheckInfo.PcCheckState = true;
                CheckInfo.PcCheckTime = DateTime.Now;
                CMessageInfo.ShowMessage("发题成功", "考核发题", 1);
            }
        }

        private void barLargeButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FrmCheckSetting(this.dt.Rows.Count).ShowDialog(this);
        }

        private void barLargeButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
            {
                if (row[0].ToString() == "True")
                {
                    row[0] = "False";
                }
                else
                {
                    row[0] = "True";
                }
            }
        }

        private void barLargeButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapLocation location = new MapLocation();
            if (ServerSystemInfo.ModuleId == ServerSystemInfo.SoftModuleId)
            {
                foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
                {
                    if (row[0].ToString() == "True")
                    {
                        bool flag = string.Compare(row["NormalIsBreak"].ToString(), "False", true) != 0;
                        int moduleId = ServerSystemInfo.ModuleId;
                        int faultPointState = SysManager.GetFaultPointState(int.Parse(row[1].ToString().Trim()));
                        if (faultPointState == 90)
                        {
                            row["PointState"] = "读取状态失败";
                        }
                        else
                        {
                            int num = location.CoderToData(faultPointState);
                            row["PointState"] = this.table.Select(" orderid=" + num).First<DataRow>()["ordername"].ToString();
                            if (((row["PointState"].ToString() == "通路") && !flag) || ((row["PointState"].ToString() == "断路") && flag))
                            {
                                row["IsNormal"] = "正常";
                            }
                            else
                            {
                                row["IsNormal"] = "有故障";
                            }
                        }
                        this.gridControl1.RefreshDataSource();
                    }
                }
            }
            else
            {
                MessageBox.Show("对不起,您要操作的模块和接入的模块不一致。请接入该系统模块后再尝试");
            }
        }

        private void barLargeButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            MapLocation location = new MapLocation();
            if (ServerSystemInfo.ModuleId == ServerSystemInfo.SoftModuleId)
            {
                if (CheckInfo.PcCheckState)
                {
                    CMessageInfo.ShowMessage("学生机考核进行中，不能操作", "故障设置", 2);
                }
                else if (CheckInfo.PaidCheckState)
                {
                    CMessageInfo.ShowMessage("平板用户考核进行中，不能操作", "故障设置", 2);
                }
                else
                {
                    foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
                    {
                        if (row[0].ToString() == "True")
                        {
                            bool flag = string.Compare(row["NormalIsBreak"].ToString(), "False", true) != 0;
                            int moduleId = ServerSystemInfo.ModuleId;
                            int pointId = int.Parse(row[1].ToString().Trim());
                            if (row["FaultPattern"].ToString() == "故障指令")
                            {
                                CMessageInfo.ShowMessage("请选择故障指令", "故障设置", 2);
                                return;
                            }
                            if (row["FaultPattern"].ToString() != row["PointState"].ToString())
                            {
                                int data = int.Parse(this.table.Select(" OrderName='" + row["FaultPattern"].ToString() + "'").First<DataRow>()["OrderId"].ToString());
                                int orderCode = location.DataToCoder(data);
                                if (SysManager.SetFaultPoint(pointId, orderCode))
                                {
                                    row["PointState"] = row["FaultPattern"].ToString().Trim();
                                    if (((row["PointState"].ToString() == "通路") && !flag) || ((row["PointState"].ToString() == "断路") && flag))
                                    {
                                        row["IsNormal"] = "正常";
                                    }
                                    else
                                    {
                                        row["IsNormal"] = "有故障";
                                    }
                                    if ((this.client != null) && (this.buffer != null))
                                    {
                                        this.buffer[3] = (byte) moduleId;
                                        this.buffer[4] = 1;
                                        this.buffer[5] = (byte) pointId;
                                        PaidComm.SendBack(this.client, this.buffer, 0);
                                    }
                                    this.da.WriteLog(LoginInfo.UserName, string.Format("成功设置故障[{2}]:模块为[{0}],故障点为[{1}]", ServerSystemInfo.ModuleName, row["name"].ToString(), row["FaultPattern"].ToString()));
                                }
                                else
                                {
                                    row["PointState"] = "设置故障失败";
                                    if ((this.client != null) && (this.buffer != null))
                                    {
                                        this.buffer[3] = (byte) moduleId;
                                        this.buffer[4] = 1;
                                        this.buffer[5] = (byte) pointId;
                                        PaidComm.SendBack(this.client, this.buffer, 1);
                                    }
                                    this.da.WriteLog(LoginInfo.UserName, string.Format("设置故障[{2}]失败:模块为[{0}],故障点为[{1}]", ServerSystemInfo.ModuleName, row["name"].ToString(), row["FaultPattern"].ToString()));
                                }
                            }
                            else
                            {
                                if ((this.client != null) && (this.buffer != null))
                                {
                                    this.buffer[3] = (byte) moduleId;
                                    this.buffer[4] = 1;
                                    this.buffer[5] = (byte) pointId;
                                    PaidComm.SendBack(this.client, this.buffer, 0);
                                }
                                this.da.WriteLog(LoginInfo.UserName, string.Format("成功设置故障[{2}]:模块为[{0}],故障点为[{1}]", ServerSystemInfo.ModuleName, row["name"].ToString(), row["FaultPattern"].ToString()));
                            }
                            this.gridControl1.RefreshDataSource();
                        }
                    }
                    if ((this.client != null) && (this.buffer != null))
                    {
                        PaidComm.SendBack(this.client, this.buffer, 0);
                    }
                }
            }
            else
            {
                if ((this.client != null) && (this.buffer != null))
                {
                    PaidComm.SendBack(this.client, this.buffer, 1);
                }
                CMessageInfo.ShowMessage("对不起,您要操作的模块和接入的模块不一致。请接入该系统模块后再尝试", "故障设置", 1);
            }
        }

        private void barLargeButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            int iFaultNo = 1;
            this.SetFaultEvent(0, 0, iFaultNo);
        }

        public void BindData()
        {
            string sql = "select convert(bit,0) as Checked ,*,'故障指令' as FaultPattern,'' as PointState,'' as IsNormal from FaultPoint  where ModuleId=" + ServerSystemInfo.SoftModuleId;
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.textBox1.Text);
            this.SelectItem(num, 0, this.GetFalutName(num));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmFaultPoint_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void FrmSetFault_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private string GetFalutName(int iFaultNo)
        {
            switch (iFaultNo)
            {
                case 1:
                    return "通路";

                case 2:
                    return "断路";

                case 3:
                    return "偶发";

                case 4:
                    return "虚接";
            }
            return "短路";
        }

        private void gridControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (this.dt != null)
            {
                int dataSourceRowIndex = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
                string fieldName = e.Column.FieldName;
                this.dt.Rows[dataSourceRowIndex][fieldName] = e.Value.ToString();
                this.gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == this.gridColumn4)
            {
                int dataSourceRowIndex = this.gridView1.GetDataSourceRowIndex(e.RowHandle);
                RepositoryItemComboBox box = new RepositoryItemComboBox {
                    TextEditStyle = TextEditStyles.DisableTextEditor
                };
                string[] strArray = this.dt.Rows[dataSourceRowIndex]["patternlist"].ToString().Split(new char[] { ',' });
                string.Compare(this.dt.Rows[dataSourceRowIndex]["NormalIsBreak"].ToString(), "False", true);
                foreach (string str in strArray)
                {
                    string item = this.table.Select(" orderid=" + int.Parse(str)).First<DataRow>()[1].ToString();
                    box.Items.Add(item);
                }
                e.RepositoryItem = box;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmSetFault));
            this.barManager1 = new BarManager(this.components);
            this.bar2 = new Bar();
            this.barLargeButtonItem6 = new BarLargeButtonItem();
            this.barLargeButtonItem7 = new BarLargeButtonItem();
            this.barLargeButtonItem8 = new BarLargeButtonItem();
            this.barLargeButtonItem9 = new BarLargeButtonItem();
            this.barLargeButtonItem10 = new BarLargeButtonItem();
            this.barLargeButtonItem11 = new BarLargeButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.barLargeButtonItem4 = new BarLargeButtonItem();
            this.barStaticItem1 = new BarStaticItem();
            this.barStaticItem2 = new BarStaticItem();
            this.barStaticItem3 = new BarStaticItem();
            this.barLargeButtonItem1 = new BarLargeButtonItem();
            this.barLargeButtonItem2 = new BarLargeButtonItem();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new RepositoryItemComboBox();
            this.repositoryItemComboBox3 = new RepositoryItemComboBox();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn7 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.gridColumn4 = new GridColumn();
            this.gridColumn5 = new GridColumn();
            this.gridColumn6 = new GridColumn();
            this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
            this.gridColumn1 = new GridColumn();
            this.popupMenu1 = new PopupMenu(this.components);
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.barManager1.BeginInit();
            this.repositoryItemComboBox1.BeginInit();
            this.repositoryItemComboBox2.BeginInit();
            this.repositoryItemComboBox3.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemCheckEdit1.BeginInit();
            this.popupMenu1.BeginInit();
            base.SuspendLayout();
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new Bar[] { this.bar2 });
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.barLargeButtonItem4, this.barStaticItem1, this.barLargeButtonItem6, this.barLargeButtonItem7, this.barLargeButtonItem8, this.barLargeButtonItem9, this.barLargeButtonItem10, this.barLargeButtonItem11, this.barStaticItem2, this.barStaticItem3, this.barLargeButtonItem1, this.barLargeButtonItem2 });
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 0x21;
            this.barManager1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox1, this.repositoryItemComboBox2, this.repositoryItemComboBox3 });
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barLargeButtonItem6, true), new LinkPersistInfo(this.barLargeButtonItem7), new LinkPersistInfo(this.barLargeButtonItem8), new LinkPersistInfo(this.barLargeButtonItem9), new LinkPersistInfo(this.barLargeButtonItem10, true), new LinkPersistInfo(this.barLargeButtonItem11) });
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.barLargeButtonItem6.Caption = "读取故障";
            this.barLargeButtonItem6.Glyph = (Image) manager.GetObject("barLargeButtonItem6.Glyph");
            this.barLargeButtonItem6.Id = 0x17;
            this.barLargeButtonItem6.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem6.LargeGlyph");
            this.barLargeButtonItem6.Name = "barLargeButtonItem6";
            this.barLargeButtonItem6.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem6_ItemClick);
            this.barLargeButtonItem7.Caption = "设置故障";
            this.barLargeButtonItem7.Glyph = (Image) manager.GetObject("barLargeButtonItem7.Glyph");
            this.barLargeButtonItem7.Id = 0x18;
            this.barLargeButtonItem7.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem7.LargeGlyph");
            this.barLargeButtonItem7.Name = "barLargeButtonItem7";
            this.barLargeButtonItem7.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem7_ItemClick);
            this.barLargeButtonItem8.Caption = "删除故障";
            this.barLargeButtonItem8.Glyph = (Image) manager.GetObject("barLargeButtonItem8.Glyph");
            this.barLargeButtonItem8.Id = 0x19;
            this.barLargeButtonItem8.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem8.LargeGlyph");
            this.barLargeButtonItem8.Name = "barLargeButtonItem8";
            this.barLargeButtonItem8.Visibility = BarItemVisibility.Never;
            this.barLargeButtonItem9.Caption = "清除故障";
            this.barLargeButtonItem9.Glyph = (Image) manager.GetObject("barLargeButtonItem9.Glyph");
            this.barLargeButtonItem9.Id = 0x1a;
            this.barLargeButtonItem9.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem9.LargeGlyph");
            this.barLargeButtonItem9.Name = "barLargeButtonItem9";
            this.barLargeButtonItem9.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem9_ItemClick);
            this.barLargeButtonItem10.Caption = "考核发题";
            this.barLargeButtonItem10.Glyph = (Image) manager.GetObject("barLargeButtonItem10.Glyph");
            this.barLargeButtonItem10.Id = 0x1b;
            this.barLargeButtonItem10.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem10.LargeGlyph");
            this.barLargeButtonItem10.Name = "barLargeButtonItem10";
            this.barLargeButtonItem10.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem10_ItemClick);
            this.barLargeButtonItem11.Caption = "发题参数设置";
            this.barLargeButtonItem11.Glyph = (Image) manager.GetObject("barLargeButtonItem11.Glyph");
            this.barLargeButtonItem11.Id = 0x1c;
            this.barLargeButtonItem11.LargeGlyph = (Image) manager.GetObject("barLargeButtonItem11.LargeGlyph");
            this.barLargeButtonItem11.Name = "barLargeButtonItem11";
            this.barLargeButtonItem11.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem11_ItemClick);
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Margin = new Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new Size(0x3d0, 0x47);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 0x284);
            this.barDockControlBottom.Margin = new Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new Size(0x3d0, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 0x47);
            this.barDockControlLeft.Margin = new Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new Size(0, 0x23d);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(0x3d0, 0x47);
            this.barDockControlRight.Margin = new Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new Size(0, 0x23d);
            this.barLargeButtonItem4.Caption = "设置故障";
            this.barLargeButtonItem4.Id = 3;
            this.barLargeButtonItem4.Name = "barLargeButtonItem4";
            this.barStaticItem1.Caption = "共有故障  ，需设置故障   ，";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = StringAlignment.Near;
            this.barStaticItem2.Caption = "全选";
            this.barStaticItem2.Id = 0x1d;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = StringAlignment.Near;
            this.barStaticItem3.Caption = "反选";
            this.barStaticItem3.Id = 30;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = StringAlignment.Near;
            this.barLargeButtonItem1.Caption = "全选";
            this.barLargeButtonItem1.Id = 0x1f;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            this.barLargeButtonItem2.Caption = "反选";
            this.barLargeButtonItem2.Id = 0x20;
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            this.barLargeButtonItem2.ItemClick += new ItemClickEventHandler(this.barLargeButtonItem2_ItemClick);
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox2.Items.AddRange(new object[] { "增加故障点", "修改故障点", "删除故障点" });
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new Padding(3, 4, 3, 4);
            this.gridControl1.Location = new Point(0, 0x47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new Padding(3, 4, 3, 4);
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemCheckEdit1 });
            this.gridControl1.Size = new Size(0x3d0, 0x23d);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridControl1.MouseUp += new MouseEventHandler(this.gridControl1_MouseUp);
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn7, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6 });
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomRowCellEdit += new CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.CellValueChanging += new CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridColumn7.Caption = "选择";
            this.gridColumn7.FieldName = "Checked";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "Id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 0x34;
            this.gridColumn3.Caption = "故障点";
            this.gridColumn3.FieldName = "Name";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 0x90;
            this.gridColumn4.Caption = "选择故障指令";
            this.gridColumn4.FieldName = "FaultPattern";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 320;
            this.gridColumn5.Caption = "故障状态";
            this.gridColumn5.FieldName = "PointState";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 0xa8;
            this.gridColumn6.Caption = "是否正常";
            this.gridColumn6.FieldName = "IsNormal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 0x98;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.gridColumn1.Caption = "选择";
            this.gridColumn1.DisplayFormat.FormatType = FormatType.Custom;
            this.gridColumn1.FieldName = "Checked";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 0x34;
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barLargeButtonItem1), new LinkPersistInfo(this.barLargeButtonItem2) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.button1.Location = new Point(0x24b, 0x20);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.Location = new Point(0x2ae, 0x1d);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 0x1a);
            this.textBox1.TabIndex = 10;
            this.textBox1.Visible = false;
            this.AllowMdiBar = true;
            base.AutoScaleDimensions = new SizeF(8f, 18f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3d0, 0x284);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.gridControl1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Margin = new Padding(3, 4, 3, 4);
            base.Name = "FrmSetFault";
            this.Text = "设故考核";
            base.FormClosed += new FormClosedEventHandler(this.FrmSetFault_FormClosed);
            base.Load += new EventHandler(this.FrmFaultPoint_Load);
            this.barManager1.EndInit();
            this.repositoryItemComboBox1.EndInit();
            this.repositoryItemComboBox2.EndInit();
            this.repositoryItemComboBox3.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemCheckEdit1.EndInit();
            this.popupMenu1.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void SelectItem(int num, int iFaultNo, string strFault)
        {
            if (num == 0)
            {
                base.Invoke(new MethodInvoker(this.barLargeButtonItem1.PerformClick));
                foreach (DataRow row in ((DataTable) this.gridControl1.DataSource).Rows)
                {
                    row["FaultPattern"] = strFault;
                }
            }
            else
            {
                foreach (DataRow row2 in ((DataTable) this.gridControl1.DataSource).Rows)
                {
                    if (int.Parse(row2["id"].ToString()) == iFaultNo)
                    {
                        row2[0] = true;
                        row2["FaultPattern"] = strFault;
                        break;
                    }
                }
            }
        }

        public void SetCheckEvent(int iFunc, int iTimes, int iMins, int iScores)
        {
            if (iFunc == 1)
            {
                this.barLargeButtonItem10.PerformClick();
            }
            else
            {
                ServerSystemInfo.Counts = iTimes;
                ServerSystemInfo.PcTimeCount = iMins;
                ServerSystemInfo.ScorePoint = iScores;
            }
        }

        public void SetFaultEvent(int iMo, int iSn, int iFaultNo)
        {
            if (iMo == 1)
            {
                this.SelectItem(1, iSn, this.GetFalutName(iFaultNo));
            }
            else if (iMo == 2)
            {
                iFaultNo = 1;
                this.SelectItem(2, iSn, this.GetFalutName(iFaultNo));
            }
            else
            {
                iFaultNo = 1;
                this.SelectItem(0, 0, this.GetFalutName(iFaultNo));
            }
            this.barLargeButtonItem7.PerformClick();
        }

        public void SetFaultEvents(Socket client, byte[] buffer, int iMo, int iSn, int iFaultNo)
        {
            this.client = client;
            this.buffer = buffer;
            if (iMo == 1)
            {
                this.SelectItem(1, iSn, this.GetFalutName(iFaultNo));
            }
            else if (iMo == 2)
            {
                iFaultNo = 1;
                this.SelectItem(2, iSn, this.GetFalutName(iFaultNo));
            }
            else
            {
                iFaultNo = 1;
                this.SelectItem(0, 0, this.GetFalutName(iFaultNo));
            }
            this.barLargeButtonItem7.PerformClick();
        }
    }
}

