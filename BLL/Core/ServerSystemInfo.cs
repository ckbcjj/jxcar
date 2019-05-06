using BLL.Service;
using System;
using System.Collections.Generic;

namespace BLL.Core
{
    public static class ServerSystemInfo
    {
        public static string strPath = Environment.CurrentDirectory + "\\Sysconfig.ini";

        public static string SoftModuleName = "无";

        public static int SoftModuleId = -1;

        public static string ModuleName = "未连接";

        public static Dictionary<int, string> dic;

        public static double ScorePoint = 1.0;

        public static int Counts = 1;

        public static int PcTimeCount = 60;

        public static string Memo;

        public static event SocketDelegate ValueChangeEvent;

        public static int ModuleId
        {
            get;
            private set;
        }

        public static int ModuleIdBuff
        {
            set
            {
                if (value != ServerSystemInfo.ModuleId)
                {
                    ServerSystemInfo.OnEventHappen(SocketInfoType.SysModule, value);
                }
                ServerSystemInfo.ModuleId = value;
            }
        }

        public static int SysPattern
        {
            get;
            private set;
        }

        public static int SysPatternBuff
        {
            set
            {
                if (value != ServerSystemInfo.SysPattern)
                {
                    ServerSystemInfo.OnEventHappen(SocketInfoType.SysPattern, value);
                }
                ServerSystemInfo.SysPattern = value;
            }
        }

        public static List<SerialComConfig> SerialComInfoList
        {
            get;
            set;
        }

        private static void OnEventHappen(SocketInfoType type, int value)
        {
            if (ServerSystemInfo.ValueChangeEvent != null)
            {
                ServerSystemInfo.ValueChangeEvent(null, new SocketEventArgs(type, value));
            }
        }
    }
}
