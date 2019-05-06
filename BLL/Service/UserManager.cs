using BLL.Common;
using BLL.Core;
using System;
using System.Collections.Generic;
using System.Data;


namespace BLL.Service
{

    public class UserManager
    {
        private DBHelper helper = new DBHelper();
        public SecurityHelper sh = new SecurityHelper();

        public bool CheckNO(string StudyNO)
        {
            string sqlQuery = "select count(*) from UserInfo where studyno='" + StudyNO + "'";
            if (int.Parse(this.helper.ExecuteScalar(this.helper.GetSqlStringCommond(sqlQuery)).ToString()) == 0)
            {
                return false;
            }
            return true;
        }

        public bool CheckUser(string UserName)
        {
            string sqlQuery = "select count(*) from UserInfo where UserName='" + UserName + "'";
            if (int.Parse(this.helper.ExecuteScalar(this.helper.GetSqlStringCommond(sqlQuery)).ToString()) == 0)
            {
                return false;
            }
            return true;
        }

        public Dictionary<string, string> GetLoginerList(string strPath)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string sqlQuery = "select username from UserInfo";
            DataTable table = this.helper.ExecuteDataTable(this.helper.GetSqlStringCommond(sqlQuery));
            if ((table != null) && (table.Rows.Count != 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    string header = "UserInfo";
                    string str3 = this.sh.ReadFile(header, row[0].ToString(), strPath);
                    if (!string.IsNullOrEmpty(str3) && !dictionary.ContainsKey(row[0].ToString()))
                    {
                        dictionary.Add(row[0].ToString(), str3);
                    }
                }
            }
            return dictionary;
        }

        public bool Login(string UserName, string Password, int RoleId, bool IsRemember)
        {
            if ((UserName == null) || (Password == null))
            {
                return false;
            }
            string sqlQuery = string.Concat(new object[] { "select * from UserInfo where UserName='", UserName, "' and Password='", Password, "' and RoleId=", RoleId, " and Userable=1" });
            DataTable table = this.helper.ExecuteDataTable(this.helper.GetSqlStringCommond(sqlQuery));
            if ((table == null) || (table.Rows.Count == 0))
            {
                return false;
            }
            LoginInfo.RoleId = RoleId;
            LoginInfo.UserName = UserName;
            LoginInfo.Password = Password;
            LoginInfo.StudyNO = table.Rows[0]["studyno"].ToString();
            LoginInfo.StudyName = table.Rows[0]["studyname"].ToString();
            new DataAccess();
            if (IsRemember)
            {
                string strPath = ServerSystemInfo.strPath;
                string header = "UserInfo";
                this.sh.WriteFile(header, UserName, Password, strPath);
            }
            return true;
        }

        public bool Registry(string NO, string RealName, bool IsMan, string UserName, string pwd1, int role, string RoleName, string mail, bool Userable)
        {
            string sqlQuery = string.Concat(new object[] { 
                "insert into UserInfo values('", NO, "','", RealName, "','", IsMan, "','", UserName, "','", pwd1, "',", role, ",'", RoleName, "','", mail, 
                "','", Userable, "')"
             });
            if (this.helper.ExecuteNonQuery(this.helper.GetSqlStringCommond(sqlQuery)) == 1)
            {
                new DataAccess().WriteLog(UserName, "用户注册");
                return true;
            }
            return false;
        }

        public bool Registry(string NO, string RealName, bool IsMan, string UserName, string pwd1, string mail)
        {
            string sqlQuery = string.Concat(new object[] { "insert into UserInfo values('", NO, "','", RealName, "','", IsMan, "','", UserName, "','", pwd1, "',2,'学生','", mail, "','True')" });
            if (this.helper.ExecuteNonQuery(this.helper.GetSqlStringCommond(sqlQuery)) == 1)
            {
                new DataAccess().WriteLog(UserName, "用户注册");
                return true;
            }
            return false;
        }
    }
}

