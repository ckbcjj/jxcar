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

namespace Teacher
{
    public partial class FrmOperateLog : XtraForm
    {

        public FrmOperateLog()
        {
            this.InitializeComponent();
        }

        private void FrmOperateLog_Load(object sender, EventArgs e)
        {
            this.BindData(null);
        }

        public void BindData(string strConditon)
        {
            string sql = "select RecordId,OperaterName,Message,CONVERT(datetime,Time,120) as Time from OperateLog";
            if (strConditon != null)
            {
                sql += strConditon;
            }
            DataTable dt = this.da.GetList(sql);
            this.gridControl1.DataSource = dt;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DateTime BeginTime = this.dateEdit1.DateTime;
            DateTime EndTime = this.dateEdit2.DateTime;
            string UserName = this.textEdit1.Text.Trim();
            StringBuilder sb = new StringBuilder(" where 1=1");
            if (!string.IsNullOrWhiteSpace(BeginTime.ToString()))
            {
                sb.Append(" and time>'" + BeginTime.ToString() + "'");
            }
            if (!string.IsNullOrWhiteSpace(EndTime.ToString()))
            {
                sb.Append(" and time<'" + EndTime.ToString() + "'");
            }
            if (!string.IsNullOrWhiteSpace(UserName.ToString()))
            {
                sb.Append(" and OperaterName like '%" + UserName + "%'");
            }
            string strcondition = sb.ToString();
            this.BindData(strcondition);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空操作日志吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }
            if (((DataTable)this.gridControl1.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("无可清除的数据");
                return;
            }
            this.da.TransCommand("truncate table operatelog");
            MessageBox.Show("清除成功");
            this.BindData(null);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.textEdit1.Text = "";
            this.BindData(null);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.BindData(null);
        }
    }
}
