using BLL.Common;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace BLL.Service
{

    public class DataAccess
    {
        private DBHelper helper = new DBHelper();

        public DataTable GetList(string sql)
        {
            if (sql == null)
            {
                return null;
            }
            return this.helper.ExecuteDataTable(this.helper.GetSqlStringCommond(sql));
        }

        public bool SqlCommand(string sql)
        {
            if (sql == null)
            {
                return false;
            }
            return (this.helper.ExecuteNonQuery(this.helper.GetSqlStringCommond(sql)) != 0);
        }

        public bool SqlParramCommand(string sql, SqlParameter[] parramlist)
        {
            try
            {
                DbCommand sqlStringCommond = this.helper.GetSqlStringCommond(sql);
                this.helper.AddParameterCollection(sqlStringCommond, parramlist);
                return (this.helper.ExecuteNonQuery(sqlStringCommond) != 0);
            }
            catch
            {
                return false;
            }
        }

        public int TransCommand(string sql)
        {
            int num = 0;
            Trans t = new Trans();
            num = this.helper.ExecuteNonQuery(this.helper.GetSqlStringCommond(sql), t);
            if (num != 0)
            {
                t.Commit();
                return num;
            }
            t.RollBack();
            return num;
        }

        public void WriteLog(string Operater, string Msg)
        {
            string sql = "insert into Operatelog values('" + Operater + "','" + Msg + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "')";
            this.SqlCommand(sql);
        }
    }
}

