using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace BLL.Core
{

    [Serializable]
    public class SendCheckItem
    {
        public int Counts { get; set; }

        public Dictionary<int, string> ItemList { get; set; }

        public string Memo { get; set; }

        public double ScorePoint { get; set; }

        public int Time { get; set; }
    }
}

