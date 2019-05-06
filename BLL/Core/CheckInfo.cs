using System;

namespace BLL.Core
{
    [Serializable]
    public class CheckInfo
    {
        public static DateTime PcCheckTime
        {
            get;
            set;
        }

        public static bool PcCheckState
        {
            get;
            set;
        }

        public static bool PaidCheckState
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string AnswerList
        {
            get;
            set;
        }

        public double Score
        {
            get;
            set;
        }

        public int Times
        {
            get;
            set;
        }

        public int UseTime
        {
            get;
            set;
        }

        public DateTime BeginTime
        {
            get;
            set;
        }

        public int State
        {
            get;
            set;
        }
    }
}
