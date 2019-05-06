using BLL.Core;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace BLL.Common
{
    public class DBHelper
    {
        private DbConnection connection;
        private static string dbConnectionString;
        private const string dbProviderName = "System.Data.SqlClient";

        public DBHelper()
        {
            if (string.IsNullOrEmpty(dbConnectionString))
            {
                dbConnectionString = GetConnectString();
            }
            this.connection = this.CreateConnection(dbConnectionString);
        }

        public DBHelper(string connectionString)
        {
            this.connection = this.CreateConnection(connectionString);
        }

        public void AddInParameter(DbCommand cmd, string parameterName, DbType dbType, object value)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.DbType = dbType;
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parameter);
        }

        public void AddOutParameter(DbCommand cmd, string parameterName, DbType dbType, int size)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.DbType = dbType;
            parameter.ParameterName = parameterName;
            parameter.Size = size;
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);
        }

        public void AddParameterCollection(DbCommand cmd, DbParameter[] dbParameterCollection)
        {
            foreach (DbParameter parameter in dbParameterCollection)
            {
                cmd.Parameters.Add(parameter);
            }
        }

        public void AddReturnParameter(DbCommand cmd, string parameterName, DbType dbType)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.DbType = dbType;
            parameter.ParameterName = parameterName;
            parameter.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(parameter);
        }

        public bool CopyDataTableToServer(DataTable dt)
        {
            if (dt == null)
            {
                return false;
            }
            SqlBulkCopy copy = new SqlBulkCopy(dbConnectionString);
            try
            {
                copy.WriteToServer(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DbConnection CreateConnection()
        {
            DbConnection connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            connection.ConnectionString = dbConnectionString;
            return connection;
        }

        public DbConnection CreateConnection(string connectionString)
        {
            DbConnection connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public DataSet ExecuteDataSet(DbCommand cmd)
        {
            DbDataAdapter adapter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        public DataSet ExecuteDataSet(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbDataAdapter adapter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        public DataTable ExecuteDataTable(DbCommand cmd)
        {
            DbDataAdapter adapter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public DataTable ExecuteDataTable(DbCommand cmd, Trans t)
        {
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbDataAdapter adapter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            cmd.Connection.Open();
            try
            {
                int num = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return num;
            }
            catch
            {
                return 0;
            }
        }

        public int ExecuteNonQuery(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            return cmd.ExecuteNonQuery();
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            cmd.Connection.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DbDataReader ExecuteReader(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            DbDataReader reader = cmd.ExecuteReader();
            new DataTable();
            return reader;
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            cmd.Connection.Open();
            object obj2 = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return obj2;
        }

        public object ExecuteScalar(DbCommand cmd, Trans t)
        {
            cmd.Connection.Close();
            cmd.Connection = t.DbConnection;
            cmd.Transaction = t.DbTrans;
            return cmd.ExecuteScalar();
        }

        private static string GetConnectString()
        {
            SecurityHelper helper = new SecurityHelper();
            string strPath = ServerSystemInfo.strPath;
            string str2 = helper.ReadFile("Sql Server", "Server", strPath);
            string str3 = helper.ReadFile("Sql Server", "DataBase", strPath);
            string str4 = helper.ReadFile("Sql Server", "UserName", strPath);
            string str5 = helper.ReadFile("Sql Server", "PassWord", strPath);
            return ("server='" + str2 + "';database='" + str3 + "';uid='" + str4 + "';pwd='" + str5 + "';");
        }

        public DbParameter GetParameter(DbCommand cmd, string parameterName)
        {
            return cmd.Parameters[parameterName];
        }

        public DbCommand GetSqlStringCommond(string sqlQuery)
        {
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = sqlQuery;
            command.CommandType = CommandType.Text;
            return command;
        }

        public DbCommand GetStoredProcCommond(string storedProcedure)
        {
            DbCommand command = this.connection.CreateCommand();
            command.CommandText = storedProcedure;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
    }
}

