using BLL.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace BLL.Service
{

    public static class PaidComm
    {
        private static Dictionary<Socket, ClientInfo> clientPool = new Dictionary<Socket, ClientInfo>();

        public static  event Action<int> BackModel;

        public static  event Action<int> ChangeModle;

        public static  event Action<Socket, byte[], int> ChangeModles;

        public static  event Action<int> ChangePattern;

        public static  event Action<Dictionary<Socket, ClientInfo>> clientListHand;

        public static  event Action ConnetctModel;

        public static  event Action<Socket, byte[], int> ConnetctModels;

        public static  event Action DefaultConfig;

        public static  event Action<int> GetClientCount;

        public static  event Action<int, int, int, int> SetCheckEvent;

        public static  event Action<int, int, int> SetFault;

        public static  event System.Action<Socket, byte[], int, int, int> SetFaults;

        private static void Accept(IAsyncResult ar)
        {
            Socket asyncState = (Socket) ar.AsyncState;
            Socket socket2 = asyncState.EndAccept(ar);
            try
            {
                asyncState.BeginAccept(new AsyncCallback(PaidComm.Accept), asyncState);
                StateObject state = new StateObject {
                    workSocket = socket2
                };
                socket2.BeginReceive(state.buffer, 0, state.buffer.Length, SocketFlags.None, new AsyncCallback(PaidComm.Recieve), state);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error :\r\n\t" + exception.ToString());
            }
        }

        private static byte[] GetMsg(byte[] socketBt)
        {
            byte[] buffer = null;
            if ((socketBt[0] == 250) && (socketBt[4] == 0xfb))
            {
                if ((socketBt[1] == 0) && (socketBt[2] == 0))
                {
                    CheckInfo.PaidCheckState = true;
                    return buffer;
                }
                if ((socketBt[1] == 0) && (socketBt[2] == 1))
                {
                    CheckInfo.PaidCheckState = false;
                    return buffer;
                }
                buffer = PaidResult(socketBt);
                if (socketBt[1] != 3)
                {
                    return buffer;
                }
                try
                {
                    DataAccess access = new DataAccess();
                    string str = string.Empty;
                    string msg = string.Empty;
                    DataTable list = access.GetList("select OrderName from FaultPattern where OrderId=" + socketBt[3]);
                    if ((list != null) && (list.Rows.Count != 0))
                    {
                        str = list.Rows[0][0].ToString();
                    }
                    if (buffer[3] == 0)
                    {
                        msg = string.Format("成功设置故障[{2}]:模块为[{0}],故障点为[{1}]", ServerSystemInfo.ModuleName, socketBt[2], str);
                    }
                    else
                    {
                        msg = string.Format("设置故障[{2}]失败:模块为[{0}],故障点为[{1}]", ServerSystemInfo.ModuleName, socketBt[2], str);
                    }
                    access.WriteLog("平板用户", msg);
                }
                catch
                {
                }
            }
            return buffer;
        }

        public static byte[] PaidResult(byte[] socketBt)
        {
            byte[] buffer = new byte[5];
            MapLocation location = new MapLocation();
            buffer[0] = 250;
            buffer[4] = 0xfb;
            switch (socketBt[1])
            {
                case 1:
                    buffer[1] = 1;
                    buffer[2] = (byte) ServerSystemInfo.ModuleId;
                    buffer[3] = 0;
                    break;

                case 2:
                {
                    buffer[1] = 2;
                    buffer[2] = socketBt[2];
                    int faultPointState = SysManager.GetFaultPointState(socketBt[2]);
                    buffer[3] = (byte) location.CoderToData(faultPointState);
                    break;
                }
                case 3:
                    buffer[1] = 3;
                    buffer[2] = socketBt[2];
                    buffer[3] = SysManager.SetFaultPoint(socketBt[2], location.DataToCoder(socketBt[3])) ? ((byte) 0) : ((byte) 1);
                    break;

                case 4:
                    buffer[1] = 4;
                    buffer[2] = 0;
                    buffer[3] = SysManager.ResetFaultPoint() ? ((byte) 0) : ((byte) 1);
                    break;

                case 5:
                    buffer[1] = 4;
                    buffer[2] = 0;
                    buffer[3] = SysManager.DeleteFaultPoint(socketBt[3]) ? ((byte) 0) : ((byte) 1);
                    break;
            }
            SysManager._comm.closePort();
            return buffer;
        }

        private static void Recieve(IAsyncResult result)
        {
            StateObject asyncState = result.AsyncState as StateObject;
            Socket workSocket = asyncState.workSocket;
            try
            {
                if (workSocket.Poll(10, SelectMode.SelectRead))
                {
                    workSocket.Disconnect(true);
                }
                else
                {
                    workSocket.EndReceive(result);
                    byte[] source = asyncState.buffer;
                    source.ToList<byte>();
                    if (source[1] == 1)
                    {
                        if (source[4] == 1)
                        {
                            if (ChangeModle != null)
                            {
                                SendBack(workSocket, source, 0);
                                ChangeModle(source[3]);
                            }
                            else
                            {
                                SendBack(workSocket, source, 1);
                            }
                        }
                        else if (source[4] == 2)
                        {
                            if (ConnetctModels != null)
                            {
                                ConnetctModels(workSocket, source, source[3]);
                            }
                            else
                            {
                                SendBack(workSocket, source, 0);
                            }
                        }
                        else if (source[4] == 3)
                        {
                            if (BackModel != null)
                            {
                                SendBack(workSocket, source, 0);
                                BackModel(source[3]);
                            }
                            else
                            {
                                SendBack(workSocket, source, 1);
                            }
                        }
                    }
                    else if (source[1] == 2)
                    {
                        if (DefaultConfig != null)
                        {
                            DefaultConfig();
                            if (SetFaults != null)
                            {
                                SetFaults(workSocket, source, source[4], source[5], source[6]);
                            }
                            else
                            {
                                SendBack(workSocket, source, 1);
                            }
                        }
                        else
                        {
                            SendBack(workSocket, source, 1);
                        }
                    }
                    else if (source[1] == 3)
                    {
                        if (DefaultConfig != null)
                        {
                            DefaultConfig();
                            if (source[4] == 1)
                            {
                                if (SetCheckEvent != null)
                                {
                                    SendBack(workSocket, source, 0);
                                    SetCheckEvent(source[4], 0, 0, 0);
                                }
                                else
                                {
                                    SendBack(workSocket, source, 0);
                                }
                            }
                            else if (SetCheckEvent != null)
                            {
                                SendBack(workSocket, source, 0);
                                SetCheckEvent(source[4], source[5], source[6], source[7]);
                            }
                            else
                            {
                                SendBack(workSocket, source, 1);
                            }
                        }
                        else
                        {
                            DefaultConfig();
                        }
                    }
                    else if (source[1] == 4)
                    {
                        if (ChangePattern != null)
                        {
                            SendBack(workSocket, source, 0);
                            ChangePattern(source[3]);
                        }
                        else
                        {
                            SendBack(workSocket, source, 1);
                        }
                    }
                    workSocket.BeginReceive(asyncState.buffer, 0, asyncState.buffer.Length, SocketFlags.None, new AsyncCallback(PaidComm.Recieve), asyncState);
                }
            }
            catch (Exception)
            {
                if (!workSocket.Connected)
                {
                    workSocket.Disconnect(true);
                }
            }
        }

        public static void Run(int port)
        {
            new Thread(new ThreadStart(delegate {
                Socket state = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    state.Bind(new IPEndPoint(IPAddress.Any, port));
                    state.Listen(1);
                    state.BeginAccept(new AsyncCallback(PaidComm.Accept), state);
                }
                catch
                {
                    MessageBox.Show("端口被占用或无该端口的访问权限");
                }
            })) { IsBackground = true }.Start();
        }

        public static void SendBack(Socket client, byte[] buffer, int iRes = 0)
        {
            int num = 0;
            if (buffer[1] == 2)
            {
                num = 8;
            }
            else
            {
                num = 7;
            }
            byte[] buffer2 = new byte[num];
            buffer2[0] = 0xfb;
            buffer2[1] = buffer[1];
            buffer2[2] = buffer[2];
            buffer2[3] = buffer[3];
            buffer2[4] = buffer[4];
            if (buffer[1] == 1)
            {
                buffer2[5] = (byte) iRes;
                buffer2[6] = 250;
            }
            else if (buffer[1] == 2)
            {
                buffer2[5] = buffer[5];
                buffer2[6] = (byte) iRes;
                buffer2[7] = 250;
            }
            else if (buffer[1] == 3)
            {
                buffer2[5] = (byte) iRes;
                buffer2[6] = 250;
            }
            else if (buffer[1] == 4)
            {
                buffer2[3] = (byte) iRes;
                buffer2[4] = 0;
                buffer2[5] = 0;
                buffer2[6] = 250;
            }
            if (client.Connected)
            {
                client.Send(buffer2);
            }
        }
    }
}

