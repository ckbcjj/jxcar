using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;


namespace BLL.Service
{

    public class ClientInfo
    {
        public byte[] buffer;

        public Socket socket { get; set; }

        public string UserName { get; set; }
    }
}

