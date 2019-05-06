using BLL.Common;
using BLL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace BLL.Service
{
    public class TcpService
    {
        private ServerListenManager Listen = new ServerListenManager();

        public static List<ClientInfo> clientPool = new List<ClientInfo>();

        public static List<SendMessage> SendMsgPool = new List<SendMessage>();

        public void Run(int port)
        {
            new Thread(new ThreadStart(delegate
            {
                try
                {
                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    server.Bind(new IPEndPoint(IPAddress.Any, port));
                    server.Listen(50);
                    server.BeginAccept(new AsyncCallback(this.Accept), server);
                }
                catch
                {
                    MessageBox.Show("端口被占用或无该端口的访问权限");
                }
            }))
            {
                Name = "PcListen",
                IsBackground = true
            }.Start();
            this.Broadcast();
        }

        private void Broadcast()
        {
            new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    if (TcpService.SendMsgPool.Count != 0)
                    {
                        SendMessage SM;
                        lock (TcpService.SendMsgPool)
                        {
                            SM = TcpService.SendMsgPool[0];
                        }
                        if (SM != null && SM.ClientList != null)
                        {
                            for (int i = 0; i < SM.ClientList.Count; i++)
                            {
                                if (SM.ClientList[i] != null)
                                {
                                    ClientInfo CI = SM.ClientList[i];
                                    try
                                    {
                                        byte[] bt = Serialize.ObjectTobyte(SM.socketInfo);
                                        if (bt != null)
                                        {
                                            CI.socket.Send(bt, bt.Length, SocketFlags.None);
                                        }
                                    }
                                    catch (SocketException)
                                    {
                                        lock (TcpService.clientPool)
                                        {
                                            if (!CI.socket.Connected && TcpService.clientPool.Contains(CI))
                                            {
                                                TcpService.clientPool.Remove(CI);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        lock (TcpService.SendMsgPool)
                        {
                            TcpService.SendMsgPool.RemoveAt(0);
                            continue;
                        }
                    }
                    Thread.Sleep(500);
                }
            }))
            {
                Name = "PcSend",
                IsBackground = true
            }.Start();
        }

        private void Accept(IAsyncResult result)
        {
            Socket server = result.AsyncState as Socket;
            Socket client = server.EndAccept(result);
            try
            {
                server.BeginAccept(new AsyncCallback(this.Accept), server);
                byte[] buffer = new byte[4096];
                ClientInfo info = new ClientInfo();
                info.socket = client;
                info.buffer = buffer;
                lock (TcpService.clientPool)
                {
                    if (!TcpService.clientPool.Contains(info))
                    {
                        TcpService.clientPool.Add(info);
                    }
                }
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.Recieve), client);
            }
            catch
            {
            }
        }

        private void Recieve(IAsyncResult result)
        {
            Socket client = result.AsyncState as Socket;
            if (TcpService.clientPool.Count != 0)
            {
                ClientInfo CI = (from t in TcpService.clientPool
                                 where t.socket == client
                                 select t).FirstOrDefault<ClientInfo>();
                if (CI != null)
                {
                    try
                    {
                        client.EndReceive(result);
                        byte[] buffer = CI.buffer;
                        client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.Recieve), client);
                        object obj = Serialize.ByteToObject(buffer);
                        if (obj != null)
                        {
                            SocketInfo socketMsg = (SocketInfo)obj;
                            if (CI.UserName == null)
                            {
                                lock (TcpService.clientPool)
                                {
                                    (from t in TcpService.clientPool
                                     where t.socket == client
                                     select t).FirstOrDefault<ClientInfo>().UserName = socketMsg.Name;
                                }
                            }
                            this.Listen.ReciveSocket(CI, socketMsg);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
