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
    public class FrmCheck : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataTable dt;

        private DateTime _time;

        private DateTime endtime;

        private StringBuilder CheckSb = new StringBuilder();

        private int count;

        private TimeSpan time;

        private double Score;

        private IContainer components;

        private GridControl gridControl1;

        private GridView gridView1;

        private GridColumn gridColumn5;

        private GridColumn gridColumn1;

        private GridColumn gridColumn2;

        private GridColumn gridColumn3;

        private RepositoryItemComboBox repositoryItemComboBox1;

        private RepositoryItemComboBox repositoryItemComboBox2;

        private PanelControl panelControl1;

        private PanelControl panelControl3;

        private PanelControl panelControl2;

        private SimpleButton simpleButton1;

        private GridColumn gridColumn4;

        private RepositoryItemButtonEdit repositoryItemButtonEdit1;

        private Timer timer1;

        private LabelControl labelControl1;

        private GridColumn gridColumn6;

        private PanelControl panelControl5;

        private PanelControl panelControl4;

        private LabelControl labelControl3;

        private LabelControl labelControl2;

        private SimpleButton simpleButton2;

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
            SerializableAppearanceObject serializableAppearanceObject = new SerializableAppearanceObject();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn5 = new GridColumn();
            this.gridColumn1 = new GridColumn();
            this.gridColumn2 = new GridColumn();
            this.gridColumn3 = new GridColumn();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.gridColumn4 = new GridColumn();
            this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
            this.gridColumn6 = new GridColumn();
            this.repositoryItemComboBox2 = new RepositoryItemComboBox();
            this.panelControl1 = new PanelControl();
            this.panelControl3 = new PanelControl();
            this.panelControl5 = new PanelControl();
            this.panelControl4 = new PanelControl();
            this.simpleButton2 = new SimpleButton();
            this.labelControl3 = new LabelControl();
            this.simpleButton1 = new SimpleButton();
            this.panelControl2 = new PanelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.timer1 = new Timer(this.components);
            ((ISupportInitialize)this.gridControl1).BeginInit();
            ((ISupportInitialize)this.gridView1).BeginInit();
            ((ISupportInitialize)this.repositoryItemComboBox1).BeginInit();
            ((ISupportInitialize)this.repositoryItemButtonEdit1).BeginInit();
            ((ISupportInitialize)this.repositoryItemComboBox2).BeginInit();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.panelControl3).BeginInit();
            this.panelControl3.SuspendLayout();
            ((ISupportInitialize)this.panelControl5).BeginInit();
            this.panelControl5.SuspendLayout();
            ((ISupportInitialize)this.panelControl4).BeginInit();
            this.panelControl4.SuspendLayout();
            ((ISupportInitialize)this.panelControl2).BeginInit();
            this.panelControl2.SuspendLayout();
            base.SuspendLayout();
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[]
			{
				this.repositoryItemComboBox1,
				this.repositoryItemComboBox2,
				this.repositoryItemButtonEdit1
			});
            this.gridControl1.Size = new Size(711, 496);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[]
			{
				this.gridView1
			});
            this.gridView1.Columns.AddRange(new GridColumn[]
			{
				this.gridColumn5,
				this.gridColumn1,
				this.gridColumn2,
				this.gridColumn3,
				this.gridColumn4,
				this.gridColumn6
			});
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridColumn5.Caption = "选择";
            this.gridColumn5.FieldName = "Checked";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 55;
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 58;
            this.gridColumn2.Caption = "故障点";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 277;
            this.gridColumn3.Caption = "故障指令";
            this.gridColumn3.ColumnEdit = this.repositoryItemComboBox1;
            this.gridColumn3.FieldName = "FaultPattern";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 110;
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Combo)
			});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.gridColumn4.Caption = "确定";
            this.gridColumn4.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn4.FieldName = "Sure";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 91;
            this.repositoryItemButtonEdit1.AutoHeight = false;
            serializableAppearanceObject.BackColor = Color.FromArgb(128, 255, 128);
            serializableAppearanceObject.Options.UseBackColor = true;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[]
			{
				new EditorButton(ButtonPredefines.Glyph, "", -1, true, true, false, ImageLocation.MiddleCenter, null, new KeyShortcut(Keys.None), serializableAppearanceObject, "", null, null, true)
			});
            this.repositoryItemButtonEdit1.ButtonsStyle = BorderStyles.Style3D;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            this.gridColumn6.Caption = "答题结果";
            this.gridColumn6.FieldName = "Result";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 98;
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(723, 559);
            this.panelControl1.TabIndex = 1;
            this.panelControl3.Controls.Add(this.panelControl5);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = DockStyle.Fill;
            this.panelControl3.Location = new Point(2, 24);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new Size(719, 533);
            this.panelControl3.TabIndex = 2;
            this.panelControl5.Controls.Add(this.gridControl1);
            this.panelControl5.Dock = DockStyle.Fill;
            this.panelControl5.Location = new Point(2, 2);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new Size(715, 500);
            this.panelControl5.TabIndex = 4;
            this.panelControl4.Controls.Add(this.simpleButton2);
            this.panelControl4.Controls.Add(this.labelControl3);
            this.panelControl4.Controls.Add(this.simpleButton1);
            this.panelControl4.Dock = DockStyle.Bottom;
            this.panelControl4.Location = new Point(2, 502);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new Size(715, 29);
            this.panelControl4.TabIndex = 3;
            this.simpleButton2.Dock = DockStyle.Right;
            this.simpleButton2.Enabled = false;
            this.simpleButton2.Location = new Point(582, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new Size(72, 25);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "考核结果";
            this.simpleButton2.Click += new EventHandler(this.simpleButton2_Click);
            this.labelControl3.Appearance.Font = new Font("Tahoma", 10f);
            this.labelControl3.Dock = DockStyle.Left;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new Point(2, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(42, 17);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "提示：";
            this.simpleButton1.Dock = DockStyle.Right;
            this.simpleButton1.Location = new Point(654, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(59, 25);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "提交";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = DockStyle.Top;
            this.panelControl2.Location = new Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new Size(719, 22);
            this.panelControl2.TabIndex = 1;
            this.labelControl2.Dock = DockStyle.Left;
            this.labelControl2.Location = new Point(2, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(36, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "次数：";
            this.labelControl1.Dock = DockStyle.Right;
            this.labelControl1.Location = new Point(693, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(24, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "时间";
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            base.AutoScrollMinSize = new Size(100, 0);
            base.ClientSize = new Size(723, 559);
            base.Controls.Add(this.panelControl1);
            base.Name = "FrmCheck";
            this.Text = "考核答题";
            base.Load += new EventHandler(this.FrmCheck_Load);
            ((ISupportInitialize)this.gridControl1).EndInit();
            ((ISupportInitialize)this.gridView1).EndInit();
            ((ISupportInitialize)this.repositoryItemComboBox1).EndInit();
            ((ISupportInitialize)this.repositoryItemButtonEdit1).EndInit();
            ((ISupportInitialize)this.repositoryItemComboBox2).EndInit();
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl3).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl5).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((ISupportInitialize)this.panelControl4).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((ISupportInitialize)this.panelControl2).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
