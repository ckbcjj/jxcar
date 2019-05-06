using System;
using System.Collections.Generic;

namespace BLL.Core
{
    public class ClientSystemInfo
    {
        public static bool readyToExit = false;

        private static object moduleLock = new object();

        private static object patternLock = new object();

        public static string strPath = Environment.CurrentDirectory + "\\SysConfig.ini";

        public static int ModuleId = 0;

        public static int SysPattern = 0;

        public static string TeaCherNO;

        public static Dictionary<int, string> dic;

        public static double ScorePoint = 1.0;

        public static int Counts = 1;

        public static int TimeCount = 60;

        public static string Memo;

        public static event SocketDelegate ValueChangeEvent;

        public static int ModuleIdBuff
        {
            set
            {
                lock (ClientSystemInfo.moduleLock)
                {
                    if (value != ClientSystemInfo.ModuleId)
                    {
                        ClientSystemInfo.OnEventHappen(SocketInfoType.SysModule, value);
                    }
                    ClientSystemInfo.ModuleId = value;
                }
            }
        }

        public static int SysPatternBuff
        {
            set
            {
                lock (ClientSystemInfo.patternLock)
                {
                    if (value != ClientSystemInfo.SysPattern)
                    {
                        ClientSystemInfo.OnEventHappen(SocketInfoType.SysPattern, value);
                    }
                    ClientSystemInfo.SysPattern = value;
                }
            }
        }

        public static List<SerialComConfig> SerialComInfoList
        {
            get;
            set;
        }

        private static void OnEventHappen(SocketInfoType type, int value)
        {
            if (ClientSystemInfo.ValueChangeEvent != null)
            {
                ClientSystemInfo.ValueChangeEvent(null, new SocketEventArgs(type, value));
            }
        }
    }
}
