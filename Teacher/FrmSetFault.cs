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

    public partial class FrmSetFault : XtraForm
    {

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

