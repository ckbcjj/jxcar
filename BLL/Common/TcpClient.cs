namespace BLL.Common
{
    using BLL.Core;
    using BLL.Service;
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Net;
    using System.Net.Sockets;

    public class TcpClient
    {
        public static bool asyncTag = false;
        private static byte[] buf = new byte[0x1000];
        public static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static string ip = GetAddress(ref Port);
        private static ClientListenManager listen = new ClientListenManager();
        private static int Port = 0x1f90;

        public static bool Connect()
        {
            try
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), Port));
                client.BeginReceive(buf, 0, buf.Length, SocketFlags.None, new AsyncCallback(BLL.Common.TcpClient.Recieve), client);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ConnectServer(IAsyncResult ar)
        {
            Socket asyncState = ar.AsyncState as Socket;
            try
            {
                asyncState.EndConnect(ar);
                asyncTag = true;
                client.BeginReceive(buf, 0, buf.Length, SocketFlags.None, new AsyncCallback(BLL.Common.TcpClient.Recieve), client);
            }
            catch
            {
                asyncTag = false;
            }
        }

        public static string GetAddress(ref int port)
        {
            string str = GetIpv4()[0];
            DataTable list = new DataAccess().GetList("select ip, port1 from serverinfo where id=1");
            if ((list != null) && (list.Rows.Count != 0))
            {
                port = int.Parse(list.Rows[0][1].ToString());
                str = list.Rows[0][0].ToString().Trim();
            }
            return str;
        }

        public static string[] GetIpv4()
        {
            StringCollection strings = new StringCollection();
            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    strings.Add(address.ToString());
                }
            }
            string[] array = new string[strings.Count];
            strings.CopyTo(array, 0);
            return array;
        }

        private static void Recieve(IAsyncResult result)
        {
            if (!ClientSystemInfo.readyToExit)
            {
                try
                {
                    Socket asyncState = result.AsyncState as Socket;
                    asyncState.EndReceive(result);
                    SocketInfo info = (SocketInfo) Serialize.ByteToObject(buf);
                    asyncState.BeginReceive(buf, 0, buf.Length, SocketFlags.None, new AsyncCallback(BLL.Common.TcpClient.Recieve), asyncState);
                    if (info != null)
                    {
                        switch (info.Type)
                        {
                            case SocketInfoType.SysModule:
                            {
                                string[] strArray = info.Msg.ToString().Split(new char[] { ':' });
                                ClientSystemInfo.ModuleIdBuff = int.Parse(strArray[0]);
                                ClientSystemInfo.SysPatternBuff = int.Parse(strArray[1]);
                                return;
                            }
                            case SocketInfoType.SysPattern:
                            case SocketInfoType.SchematicMap:
                                return;

                            case SocketInfoType.CheckItem:
                                listen.GetCheckItem(info.Name, (SendCheckItem) info.Msg, info.Time);
                                return;

                            case SocketInfoType.RealTimeData:
                                listen.GetRTData(info.Msg);
                                return;

                            case SocketInfoType.ReadPointState:
                                listen.ReadPointState(info.Msg);
                                return;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public static bool SendMessage(SocketInfo SI)
        {
            byte[] buffer = Serialize.ObjectTobyte(SI);
            try
            {
                buffer = Serialize.ObjectTobyte(SI);
                if (buffer != null)
                {
                    client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, null);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static void SynConnect()
        {
            try
            {
                client.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), Port), new AsyncCallback(BLL.Common.TcpClient.ConnectServer), client);
            }
            catch
            {
            }
        }
    }
}

