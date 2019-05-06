using BLL.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace BLL.Service
{

    public class SendMessage
    {
        public List<ClientInfo> ClientList { get; set; }

        public SocketInfo socketInfo { get; set; }
    }
}

