using System;
using System.Net.Sockets;
using System.Text;


namespace BLL.Service
{

    public class StateObject
    {
        public byte[] buffer = new byte[0x400];
        public const int BUFFER_SIZE = 0x400;
        public StringBuilder sb = new StringBuilder();
        public Socket workSocket;
    }
}

