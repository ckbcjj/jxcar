using System;
using System.Data;
using System.Data.Common;


namespace BLL.Common
{

    public class Trans : IDisposable
    {
        private System.Data.Common.DbConnection conn;
        private DBHelper db;
        private DbTransaction dbTrans;

        public Trans()
        {
            this.db = new DBHelper();
            this.conn = this.db.CreateConnection();
            this.conn.Open();
            this.dbTrans = this.conn.BeginTransaction();
        }

        public Trans(string connectionString)
        {
            this.db = new DBHelper();
            this.conn = this.db.CreateConnection(connectionString);
            this.conn.Open();
            this.dbTrans = this.conn.BeginTransaction();
        }

        public void Colse()
        {
            if (this.conn.State == ConnectionState.Open)
            {
                this.conn.Close();
            }
        }

        public void Commit()
        {
            this.dbTrans.Commit();
            this.Colse();
        }

        public void Dispose()
        {
            this.Colse();
        }

        public void RollBack()
        {
            this.dbTrans.Rollback();
            this.Colse();
        }

        public System.Data.Common.DbConnection DbConnection
        {
            get
            {
                return this.conn;
            }
        }

        public DbTransaction DbTrans
        {
            get
            {
                return this.dbTrans;
            }
        }
    }
}

