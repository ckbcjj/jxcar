using BLL.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace BLL.Service
{

    public class ServerListenManager
    {
        public event SocketDelegate CheckEvent;

        public void ReciveSocket(ClientInfo clientInfo, SocketInfo socketInfo)
        {
            List<ClientInfo> clientList = new List<ClientInfo>();
            switch (socketInfo.Type)
            {
                case SocketInfoType.SysModule:
                {
                    clientList.Clear();
                    clientList.Add(clientInfo);
                    string msg = string.Format("{0}:{1}", ServerSystemInfo.ModuleId, ServerSystemInfo.SysPattern);
                    SysManager.SentToClient(clientList, "Server", SocketInfoType.SysModule, msg);
                    return;
                }
                case SocketInfoType.SysPattern:
                case SocketInfoType.CheckItem:
                    break;

                case SocketInfoType.BeginCheck:
                {
                    CheckInfo item = (CheckInfo) socketInfo.Msg;
                    lock (CacheInvoke.CheckPool)
                    {
                        CacheInvoke.CheckPool.Add(item);
                    }
                    if (this.CheckEvent == null)
                    {
                        break;
                    }
                    this.CheckEvent(null, new SocketEventArgs(SocketInfoType.BeginCheck, clientInfo.UserName));
                    return;
                }
                case SocketInfoType.EndCheck:
                {
                    CheckInfo info2 = (CheckInfo) socketInfo.Msg;
                    lock (CacheInvoke.CheckPool)
                    {
                        CacheInvoke.CheckPool.Add(info2);
                    }
                    if (this.CheckEvent != null)
                    {
                        this.CheckEvent(null, new SocketEventArgs(SocketInfoType.EndCheck, clientInfo.UserName));
                    }
                    break;
                }
                case SocketInfoType.ReadPointState:
                {
                    MapLocation location = new MapLocation();
                    clientList.Clear();
                    clientList.Add(clientInfo);
                    try
                    {
                        string[] strArray = socketInfo.Msg.ToString().Split(new char[] { ':' });
                        if (int.Parse(strArray[0]) != ServerSystemInfo.ModuleId)
                        {
                            string str2 = "模块已变更,无法读取";
                            SysManager.SentToClient(clientList, "Server", SocketInfoType.ReadPointState, str2);
                        }
                        else
                        {
                            StringBuilder builder = new StringBuilder();
                            foreach (string str3 in strArray[1].Split(new char[] { ',' }))
                            {
                                int num2;
                                int faultPointState = SysManager.GetFaultPointState(int.Parse(str3));
                                if (faultPointState == 90)
                                {
                                    num2 = 0;
                                }
                                else
                                {
                                    num2 = location.CoderToData(faultPointState);
                                }
                                builder.Append(string.Format("{0},", num2));
                            }
                            string str4 = builder.ToString();
                            builder = builder.Remove(str4.LastIndexOf(','), 1);
                            SysManager.SentToClient(clientList, "Server", SocketInfoType.ReadPointState, builder);
                            SysManager._comm.closePort();
                        }
                    }
                    catch
                    {
                        SysManager.SentToClient(clientList, "Server", SocketInfoType.ReadPointState, "0,0,0,0");
                    }
                    break;
                }
                default:
                    return;
            }
        }
    }
}

