using System;
using System.Collections.Generic;


namespace BLL.Core
{

    public static class CacheInvoke
    {
        public static List<RTData> _queue = new List<RTData>();
        public static List<CheckInfo> CheckPool = new List<CheckInfo>();
        public static Dictionary<int, int> FaultDic = new Dictionary<int, int>();
        public static RTData newdata = new RTData();
    }
}

