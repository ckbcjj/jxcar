using System;
using System.Data;
using System.Data.SqlClient;


namespace ConfigDB
{

    public class DbManager
    {
        private string connectString;

        public DbManager(string connStr)
        {
            this.connectString = connStr;
        }

        public bool ConnectTest()
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection(this.connectString);
            try
            {
                connection.Open();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return flag;
        }
    }
}

