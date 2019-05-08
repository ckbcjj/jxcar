using BLL.Core;
using BLL.Service;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Teacher
{
    public partial class FrmEditFault : XtraForm
    {
        private DataAccess da = new DataAccess();

        private DataRow _dr;

        private DataTable _dt;


        public FrmEditFault(DataRow dr)
        {
            this.InitializeComponent();
            this._dr = dr;
            this._dt = this.da.GetList("select * from FaultPattern");
        }

        private void FrmEditFault_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = this.PatternDic();
            if (dic.Count != 0)
            {
                string[] strlist = new string[dic.Values.Count];
                dic.Values.CopyTo(strlist, 0);
                this.checkedListBoxControl1.Items.AddRange(strlist);
            }
            if (this._dr != null)
            {
                string[] IdList = this._dr["Pattern"].ToString().Split(new char[]
				{
					','
				});
                this.textEdit1.Text = this._dr["Id"].ToString();
                this.textEdit2.Text = this._dr["Name"].ToString();
                this.memoEdit1.Text = ((this._dr["PointMemo"] == null) ? "" : this._dr["PointMemo"].ToString());
                this.checkEdit1.CheckState = ((this._dr["NormalIsBreak"].ToString() == "断路") ? CheckState.Checked : CheckState.Unchecked);
                this.labelControl5.Text = "故障点编辑";
                this.textEdit1.Enabled = false;
                IEnumerator enumerator = this.checkedListBoxControl1.Items.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        CheckedListBoxItem item = (CheckedListBoxItem)enumerator.Current;
                        if (IdList.Contains(item.Value.ToString()))
                        {
                            item.CheckState = CheckState.Checked;
                        }
                    }
                    return;
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
            string sql = "select max(id) from faultpoint where moduleid=" + ServerSystemInfo.SoftModuleId;
            DataTable dt = this.da.GetList(sql);
            if (dt != null && dt.Rows.Count != 0)
            {
                this.textEdit1.Text = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
            }
            this.textEdit1.Enabled = false;
            this.labelControl5.Text = "增加故障点";
        }

        private Dictionary<string, string> PatternDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (this._dt != null && this._dt.Rows.Count != 0)
            {
                foreach (DataRow item in this._dt.Rows)
                {
                    dic.Add(item["OrderId"].ToString(), item["OrderName"].ToString());
                }
            }
            return dic;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = this.PatternDic();
            StringBuilder sb = new StringBuilder();
            if (dic.Count != 0)
            {
                IEnumerator enumerator = this.checkedListBoxControl1.Items.GetEnumerator();
                try
                {
                    CheckedListBoxItem item;
                    while (enumerator.MoveNext())
                    {
                        item = (CheckedListBoxItem)enumerator.Current;
                        if (item.CheckState == CheckState.Checked)
                        {
                            sb.Append((from t in dic
                                       where t.Value.ToString() == item.Value.ToString()
                                       select t).First<KeyValuePair<string, string>>().Key);
                            sb.Append(",");
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
            }
            string patternlist = string.Empty;
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                string strsb = sb.ToString();
                patternlist = strsb.Remove(strsb.LastIndexOf(','));
            }
            string name = this.textEdit2.Text.ToString().Trim();
            string memo = this.memoEdit1.Text.ToString().Trim();
            bool normalisbreak = this.checkEdit1.CheckState == CheckState.Checked;
            int id = int.Parse(this.textEdit1.Text.ToString());
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("故障点名不能为空");
                return;
            }
            string sql;
            if (this._dr != null)
            {
                sql = string.Concat(new object[]
				{
					"update FaultPoint set name='",
					name,
					"',PatternList='",
					patternlist,
					"',NormalIsBreak='",
					normalisbreak,
					"',pointmemo='",
					memo,
					"' where id=",
					id,
					" and ModuleId=",
					ServerSystemInfo.SoftModuleId
				});
            }
            else
            {
                sql = string.Concat(new object[]
				{
					"insert into faultpoint values(",
					id,
					",'",
					name,
					"',",
					ServerSystemInfo.SoftModuleId,
					",'",
					patternlist,
					"','",
					normalisbreak,
					"','",
					memo,
					"')"
				});
            }
            if (this.da.SqlCommand(sql))
            {
                string msg = string.Empty;
                if (this._dr != null)
                {
                    msg = string.Format("修改编号为[{0}]的故障点信息成功", id);
                }
                else
                {
                    msg = string.Format("增加编号为[{0}]的故障点成功", id);
                }
                this.da.WriteLog(LoginInfo.UserName, msg);
                MessageBox.Show(msg);
                base.DialogResult = DialogResult.OK;
            }
        }
    }
}
