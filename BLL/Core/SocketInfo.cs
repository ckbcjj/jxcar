using System;
using System.Runtime.CompilerServices;


namespace BLL.Core
{

    [Serializable]
    public class SocketInfo
    {
        public object Msg { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public SocketInfoType Type { get; set; }
    }
}

