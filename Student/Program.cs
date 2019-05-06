using BLL.Common;
using BLL.Core;
using DevExpress.Data;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student
{


    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            CurrencyDataController.DisableThreadingProblemsDetection=true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ValidateConnect();
            Application.Run((Form) new Login());
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

