using BLL.Common;
using BLL.Core;
using BLL.Service;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmCheck : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DateTime _time;

        private DateTime endtime;

        private StringBuilder CheckSb = new StringBuilder();

        private int count;

        private TimeSpan time;

        private double Score;

 

        public FrmCheck(DateTime time)
        {
            this.InitializeComponent();
            this._time = time;
        }

        private void FrmCheck_Load(object sender, EventArgs e)
        {
            this.BindData();
            this.LoadState();
            Task task = new Task(delegate
            {
                CheckInfo msg = new CheckInfo
                {
                    BeginTime = this._time,
                    UserName = LoginInfo.UserName,
                    State = 1
                };
                SocketInfo sI = new SocketInfo
                {
                    Type = SocketInfoType.BeginCheck,
                    Name = LoginInfo.UserName,
                    Time = DateTime.Now,
                    Msg = msg
                };
                int num = 3;
                do
                {
                    num--;
                }
                while (!TcpClient.SendMessage(sI) && num > 0);
                if (num == 0)
                {
                    MessageBox.Show("与服务器断开连接,加载答题失败");
                }
            });
            task.Start();
        }

        public void BindData()
        {
            string sql = "select convert(bit,0) as Checked ,*,'选择指令' as FaultPattern,'' as Result from FaultPoint  where ModuleId=" + ClientSystemInfo.ModuleId;
            this.dt = this.da.GetList(sql);
            this.gridControl1.DataSource = this.dt;
            ArrayList faultPattern = this.GetFaultPattern();
            if (faultPattern.Count != 0)
            {
                this.repositoryItemComboBox1.Items.AddRange(faultPattern);
            }
        }

        private ArrayList GetFaultPattern()
        {
            ArrayList arrayList = new ArrayList();
            DataTable list = this.da.GetList("select OrderName from FaultPattern");
            if (list != null)
            {
                foreach (DataRow dataRow in list.Rows)
                {
                    string value = dataRow["OrderName"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        arrayList.Add(value);
                    }
                }
            }
            return arrayList;
        }

        private void LoadState()
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes((double)ClientSystemInfo.TimeCount) - (DateTime.Now - this._time);
            this.labelControl1.Text = string.Format("离答题结束剩{0}时{1}分{2}秒", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            this.labelControl2.Text = string.Format("每题分值{0}分，共{1}次答题机会,剩余{2}次机会", ClientSystemInfo.ScorePoint, ClientSystemInfo.Counts, ClientSystemInfo.Counts - this.count);
            this.labelControl3.Text = string.Format("提示：{0}", string.IsNullOrEmpty(ClientSystemInfo.Memo) ? "无答题提示" : ClientSystemInfo.Memo);
            this.timer1.Start();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int focusedRowHandle = this.gridView1.FocusedRowHandle;
            DataRow dataRow = this.gridView1.GetDataRow(focusedRowHandle);
            if (string.Compare(dataRow["Checked"].ToString(), "True", false) != 0)
            {
                MessageBox.Show("请选择");
                return;
            }
            if (dataRow["FaultPattern"].ToString() == "选择指令")
            {
                MessageBox.Show("请选择故障指令");
                return;
            }
            if (string.Compare(dataRow["Result"].ToString(), "正确", false) == 0)
            {
                MessageBox.Show("已回答正确，不能重复作答");
                return;
            }
            int Id = int.Parse(dataRow["Id"].ToString());
            string Pattenrn = dataRow["FaultPattern"].ToString();
            int dataSourceRowIndex = this.gridView1.GetDataSourceRowIndex(focusedRowHandle);
            if (ClientSystemInfo.dic != null)
            {
                if ((from t in ClientSystemInfo.dic
                     where t.Key == Id && t.Value == Pattenrn
                     select t).Count<KeyValuePair<int, string>>() != 0)
                {
                    MessageBox.Show("正确！故障排除");
                    this.dt.Rows[dataSourceRowIndex]["Result"] = "正确";
                    this.Score += ClientSystemInfo.ScorePoint;
                }
                else
                {
                    MessageBox.Show("不正确！请再检查");
                    this.dt.Rows[dataSourceRowIndex]["Result"] = "错误";
                }
                this.count++;
                this.CheckSb.Append(string.Format("{0},{1};", Id, Pattenrn));
                if (this.count >= ClientSystemInfo.Counts)
                {
                    foreach (EditorButton editorButton in this.repositoryItemButtonEdit1.Buttons)
                    {
                        editorButton.Enabled = false;
                        editorButton.Appearance.BackColor = Color.Gray;
                    }
                    MessageBox.Show("答题次数用完，停止答题。请交卷！");
                    return;
                }
                this.gridControl1.RefreshDataSource();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.time = TimeSpan.FromMinutes((double)ClientSystemInfo.TimeCount) - (DateTime.Now - this._time);
            this.labelControl1.Text = string.Format("离答题结束剩{0}时{1}分{2}秒", this.time.Hours, this.time.Minutes, this.time.Seconds);
            this.labelControl2.Text = string.Format("每题分值{0}分,共{1}次答题机会,剩余{2}次机会", ClientSystemInfo.ScorePoint, ClientSystemInfo.Counts, ClientSystemInfo.Counts - this.count);
            if (this.time.TotalSeconds < 0.0)
            {
                this.timer1.Stop();
                foreach (EditorButton editorButton in this.repositoryItemButtonEdit1.Buttons)
                {
                    editorButton.Enabled = false;
                    editorButton.Appearance.BackColor = Color.Gray;
                }
                MessageBox.Show("答题时间已结束，停止答题。请交卷！");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.count <= ClientSystemInfo.Counts && this.time.TotalSeconds > 0.0 && MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            this.endtime = DateTime.Now;
            if (!this.InsertData())
            {
                MessageBox.Show("信息提交失败");
                return;
            }
            this.simpleButton2.Enabled = true;
            this.simpleButton1.Enabled = false;
            Task task = new Task(delegate
            {
                CheckInfo msg = new CheckInfo
                {
                    BeginTime = this._time,
                    Times = this.count,
                    UseTime = (this.endtime - this._time).Hours * 60 + (this.endtime - this._time).Minutes,
                    AnswerList = this.CheckSb.ToString(),
                    UserName = LoginInfo.UserName,
                    State = 2,
                    Score = this.Score
                };
                SocketInfo sI = new SocketInfo
                {
                    Type = SocketInfoType.EndCheck,
                    Name = LoginInfo.UserName,
                    Time = DateTime.Now,
                    Msg = msg
                };
                int num = 3;
                do
                {
                    num--;
                }
                while (!TcpClient.SendMessage(sI) && num > 0);
                if (num == 0)
                {
                    MessageBox.Show("与服务器断开连接,提交答题失败");
                    return;
                }
                MessageBox.Show("答题提交成功");
            });
            task.Start();
            foreach (EditorButton editorButton in this.repositoryItemButtonEdit1.Buttons)
            {
                editorButton.Enabled = false;
                editorButton.Appearance.BackColor = Color.Gray;
            }
        }

        private bool InsertData()
        {
            bool result = false;
            DataTable list = this.da.GetList("select StudyName from UserInfo where studyno='" + ClientSystemInfo.TeaCherNO + "'");
            if (list != null && list.Rows.Count != 0)
            {
                string text = list.Rows[0][0].ToString();
                string sql = string.Concat(new object[]
				{
					"insert into checkinfo values('",
					LoginInfo.StudyNO,
					"','",
					LoginInfo.StudyName,
					"','",
					this._time.ToString("yyyy/MM/dd HH:mm:ss"),
					"','",
					this.endtime.ToString("yyyy/MM/dd HH:mm:ss"),
					"',",
					this.count,
					",",
					this.Score,
					",'",
					ClientSystemInfo.TeaCherNO,
					"','",
					text,
					"',@memo)"
				});
                string value = string.IsNullOrEmpty(ClientSystemInfo.Memo) ? "" : ClientSystemInfo.Memo;
                SqlParameter[] parramlist = new SqlParameter[]
				{
					new SqlParameter("@memo", value)
				};
                if (this.da.SqlParramCommand(sql, parramlist))
                {
                    result = true;
                }
            }
            return result;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            string[] array = this.CheckSb.ToString().Split(new char[]
			{
				';'
			});
            for (int i = 0; i < array.Length; i++)
            {
                if (!string.IsNullOrEmpty(array[i]))
                {
                    int num = int.Parse(array[i].Split(new char[]
					{
						','
					})[0]);
                    string value = array[i].Split(new char[]
					{
						','
					})[1];
                    if (!dictionary.Keys.Contains(num))
                    {
                        dictionary.Add(num, value);
                    }
                    else
                    {
                        dictionary[num] = value;
                    }
                }
            }
            new FrmCheckResult(dictionary)
            {
                StartPosition = FormStartPosition.CenterParent
            }.ShowDialog(this);
        }
    }
}
