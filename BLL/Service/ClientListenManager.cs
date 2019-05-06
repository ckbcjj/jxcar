namespace BLL.Service
{
    using BLL.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ClientListenManager
    {
        public static RTData NewData = new RTData();

        public static  event ListenDelegate ListenEvent;

        public void GetCheckItem(string UserNO, SendCheckItem value, DateTime time)
        {
            ClientSystemInfo.TeaCherNO = UserNO;
            ClientSystemInfo.dic = value.ItemList;
            ClientSystemInfo.ScorePoint = value.ScorePoint;
            ClientSystemInfo.Counts = value.Counts;
            ClientSystemInfo.TimeCount = value.Time;
            ClientSystemInfo.Memo = value.Memo;
            if (!ClientSystemInfo.readyToExit && (ListenEvent != null))
            {
                ListenEvent(null, new ListenEventArgs(SocketInfoType.CheckItem, null));
            }
        }

        public void GetRTData(object value)
        {
            RTData data = value as RTData;
            if ((data != null) && (ListenEvent != null))
            {
                lock (NewData)
                {
                    NewData = data;
                }
                if (!ClientSystemInfo.readyToExit && (ListenEvent != null))
                {
                    ListenEvent(null, new ListenEventArgs(SocketInfoType.RealTimeData, data));
                }
            }
        }

        public void ReadPointState(object msg)
        {
            List<int> list = new List<int>();
            string[] strArray = msg.ToString().Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                int item = int.Parse(strArray[i]);
                list.Add(item);
            }
            if (!ClientSystemInfo.readyToExit && (ListenEvent != null))
            {
                ListenEvent(null, new ListenEventArgs(SocketInfoType.ReadPointState, list));
            }
        }
    }
}

