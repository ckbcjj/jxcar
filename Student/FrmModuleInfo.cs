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
    public partial class FrmModuleInfo : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DataTable dt2;

        private StringBuilder sb;

  
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
    }
}
