using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DBCreate
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

        public string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < (pToDecrypt.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte) num2;
            }
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            try
            {
                stream2.FlushFinalBlock();
                return Encoding.Default.GetString(stream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            builder.ToString();
            return builder.ToString();
        }

        public int ExecuteSQLFile(string sqlFileName, string dbname, out string Msg)
        {
            Msg = string.Empty;
            int num = 0;
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                FileStream stream = new FileStream(sqlFileName, FileMode.Open);
                StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    string str = "Create database " + dbname;
                    command.CommandText = str;
                    num = command.ExecuteNonQuery();
                    string str2 = "";
                    StringBuilder builder = new StringBuilder();
                    int num2 = 0;
                    while ((str2 = reader.ReadLine()) != null)
                    {
                        num2++;
                        if (str2.Trim().ToUpper() != "GO")
                        {
                            if (num2 == 1)
                            {
                                str2 = "Use " + dbname;
                            }
                            builder.AppendLine(str2);
                        }
                        else
                        {
                            command.CommandText = builder.ToString();
                            num = command.ExecuteNonQuery();
                            builder.Remove(0, builder.Length);
                        }
                    }
                    reader.Close();
                    stream.Close();
                }
                catch (Exception exception)
                {
                    Msg = exception.Message;
                    reader.Close();
                    stream.Close();
                    num = 0;
                }
            }
            return num;
        }

        [DllImport("kernel32")]
        public static extern bool GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        public bool RestoreDataBase(string databasename, string databasefile, out string Msg)
        {
            Msg = string.Empty;
            string cmdText = "RESTORE DATABASE " + databasename + " from DISK = '" + databasefile + "'";
            SqlConnection connection = new SqlConnection(this.connectString);
            SqlCommand command = new SqlCommand(cmdText, connection) {
                CommandType = CommandType.Text
            };
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                Msg = exception.Message;
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }

        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
    }
}

