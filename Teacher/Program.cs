using BLL.Common;
using BLL.Core;
using BLL.Service;
using DevExpress.Data;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Teacher;

namespace LYcar
{


    internal static class Program
    {
        private static void InitServerIp()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            hostEntry.AddressList[0].ToString();
            string str = hostEntry.AddressList[1].ToString();
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    str = address.ToString();
                    break;
                }
            }
            DataAccess access = new DataAccess();
            string sql = "update serverinfo set ip='" + str + "' where id=1";
            access.SqlCommand(sql);
        }

        public static void InsertDatabase()
        {
            List<RTData> datalist = new List<RTData>();
            DataAccess da = new DataAccess();
            new Thread(new ThreadStart( delegate {
                while (true)
                {
                    if (CacheInvoke._queue.Count > 300)
                    {
                        lock (CacheInvoke._queue)
                        {
                            datalist.AddRange(CacheInvoke._queue);
                            CacheInvoke._queue.Clear();
                        }
                        if (datalist != null)
                        {
                            for (int j = 0; j < datalist.Count; j++)
                            {
                                if ((j == 0) || ((j % 2) == 0))
                                {
                                    RTData data = datalist[j];
                                    string str2 = "insert into HisData values(0,1,'发动机冷却液温度','" + data.FDJLQYWD + "','" + data.time.ToString("yyyy/MM/dd HH:mm:ss") + "');";
                                    string sql = str2 + "insert into HisData values(0,2,'发动机转速','" + data.FDJZS + "','" + data.time.ToString("yyyy/MM/dd HH:mm:ss") + "');";
                                    da.TransCommand(sql);
                                }
                            }
                            datalist.Clear();
                        }
                    }
                    Thread.Sleep(0x7d0);
                }
            })) { Name = "RTDataListen", IsBackground = true }.Start();
        }

        [STAThread]
        private static void Main()
        {
            bool createdNew = false;
            Mutex mutex = new Mutex(true, "OnlyOneServer", out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("程序已运行,不能同时运行多个");
            }
            else
            {
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                CurrencyDataController.DisableThreadingProblemsDetection = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ValidateConnect();
                InitServerIp();
                SocketListen();
                InsertDatabase();
                Application.Run(new Login());
                GC.KeepAlive(mutex);
            }
        }

        public static void SocketListen()
        {
            DataAccess access = new DataAccess();
            TcpService service = new TcpService();
            DataTable list = access.GetList("select * from serverinfo where id=1");
            if ((list != null) && (list.Rows.Count != 0))
            {
                int port = int.Parse(list.Rows[0]["port1"].ToString());
                int num2 = int.Parse(list.Rows[0]["port2"].ToString());
                service.Run(port);
                PaidComm.Run(num2);
            }
            else
            {
                service.Run(0x1f90);
                PaidComm.Run(0x1f91);
            }
        }

        private static void ValidateConnect()
        {
            SecurityHelper helper = new SecurityHelper();
            string strPath = ServerSystemInfo.strPath;
            string str2 = helper.ReadFile("Sql Server", "Server", strPath);
            string str3 = helper.ReadFile("Sql Server", "DataBase", strPath);
            string str4 = helper.ReadFile("Sql Server", "UserName", strPath);
            string str5 = string.Empty;
            SqlConnection connection = null;
            try
            {
                str5 = helper.ReadFile("Sql Server", "PassWord", strPath);
                connection = new SqlConnection("server='" + str2 + "';database='" + str3 + "';uid='" + str4 + "';pwd='" + str5 + "';");
                connection.Open();
            }
            catch
            {
                MessageBox.Show("数据库连接失败,请修改数据库连接配置");
                Environment.Exit(0);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }
    }
}

