using BLL.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace BLL.Service
{

    public class SysManager
    {
        public static Communication _comm;
        public Action<byte[]> ActData;
        public Communication comm;
        private string ErrorData1 = string.Empty;
        private string ErrorData2 = string.Empty;
        private static object LoadSerialComInfoLock = new object();
        public static int ModuleId;
        private Random random = new Random();
        public static object SetLock = new object();

        public SysManager(string com, int port)
        {
            this.comm = new Communication(com, port);
            this.comm.openPort();
        }

        private double CalculateNextValue(double value, int typeid)
        {
            double num = 1.0;
            double num2 = 0.0;
            if (typeid == 1)
            {
                num = 20.0;
                num2 = 10.0;
            }
            else
            {
                num = 100.0;
                num2 = -150.0;
            }
            return (value + ((this.random.NextDouble() * num) - num2));
        }

        public bool ConnectModule(int moduleId)
        {
            bool flag = false;
            byte[] sendData = this.comm.GetSendPag2(1, (byte) moduleId);
            byte[] receiveData = new byte[7];
            try
            {
                if (this.comm.openPort() && (this.comm.SendCommand(sendData, ref receiveData, 200) > 0))
                {
                    if (this.ActData != null)
                    {
                        this.ActData(receiveData);
                    }
                    if ((((receiveData[0] == 250) && (receiveData[5] == 0xfb)) && (receiveData[2] == 170)) || (((receiveData[1] == 250) && (receiveData[6] == 0xfb)) && (receiveData[3] == 170)))
                    {
                        return true;
                    }
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }

        public bool ConnectOBD()
        {
            bool flag = false;
            if (!this.comm.openPort())
            {
                return flag;
            }
            try
            {
                byte[] data = new byte[] { 0x41, 0x54, 0x57, 0x53, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(12);
                data = new byte[] { 0x41, 0x54, 90, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(800);
                data = new byte[] { 0x41, 0x54, 0x45, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(8);
                data = new byte[] { 0x41, 0x54, 0x4c, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(8);
                data = new byte[] { 0x41, 0x54, 0x48, 0x31, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(8);
                data = new byte[] { 0x41, 0x54, 0x49, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x1a);
                data = new byte[] { 0x41, 0x54, 0x49, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(10);
                data = new byte[] { 0x41, 0x54, 0x40, 0x31, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(14);
                data = new byte[] { 0x41, 0x54, 0x40, 50, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x17);
                data = new byte[] { 0x41, 0x54, 0x52, 0x56, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(20);
                data = new byte[] { 0x41, 0x54, 0x53, 80, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x17);
                data = new byte[] { 0x30, 0x31, 0x30, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x872);
                data = new byte[] { 0x41, 0x54, 0x44, 80, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x11);
                data = new byte[] { 0x30, 0x31, 0x30, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0xe8);
                data = new byte[] { 0x41, 0x54, 0x44, 80, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x18);
                data = new byte[] { 0x41, 0x54, 0x44, 80, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x7d0);
                data = new byte[] { 0x30, 0x31, 0x30, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(220);
                data = new byte[] { 0x30, 0x31, 50, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x51);
                data = new byte[] { 0x30, 0x31, 0x34, 0x30, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x191);
                data = new byte[] { 0x30, 0x31, 0x31, 0x43, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x54);
                data = new byte[] { 0x30, 0x31, 0x30, 0x31, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x59);
                data = new byte[] { 0x30, 0x31, 0x30, 0x43, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x57);
                data = new byte[] { 0x30, 0x31, 0x30, 0x33, 13 };
                this.comm.SendData(data, 0, data.Length);
                Thread.Sleep(0x51);
                data = new byte[] { 0x30, 0x31, 0x31, 0x33, 13 };
                this.comm.SendData(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteFaultPoint(int PointId)
        {
            bool flag = false;
            byte[] sendData = _comm.GetSendPag(1, (byte) PointId, 5, 0);
            byte[] receiveData = new byte[12];
            return ((((_comm.openPort() && (_comm.SendCommand(sendData, ref receiveData, 200) > 0)) && ((receiveData[0] == 250) && (receiveData[11] == 0xfb))) && (receiveData[7] == 0x5b)) || flag);
        }

        public bool DisConnectModule(int moduleId)
        {
            bool flag = false;
            byte[] sendData = this.comm.GetSendPag2(3, (byte) moduleId);
            byte[] receiveData = new byte[7];
            try
            {
                if (this.comm.openPort() && (this.comm.SendCommand(sendData, ref receiveData, 200) > 0))
                {
                    if (this.ActData != null)
                    {
                        this.ActData(receiveData);
                    }
                    if ((((receiveData[0] == 250) && (receiveData[5] == 0xfb)) && (receiveData[2] == 170)) || (((receiveData[1] == 250) && (receiveData[6] == 0xfb)) && (receiveData[3] == 170)))
                    {
                        return true;
                    }
                }
                return flag;
            }
            catch
            {
                return false;
            }
        }

        public RTData GetAllRTData()
        {
            RTData msg = null;
            string vaule = this.GetVaule(1);
            string str2 = this.GetVaule(2);
            msg = new RTData {
                FDJLQYWD = vaule,
                FDJZS = str2,
                time = DateTime.Now
            };
            if (msg != null)
            {
                SentToClient(TcpService.clientPool, "Server", SocketInfoType.RealTimeData, msg);
                lock (CacheInvoke.newdata)
                {
                    CacheInvoke.newdata = msg;
                }
                lock (CacheInvoke._queue)
                {
                    CacheInvoke._queue.Add(msg);
                }
            }
            return msg;
        }

        public static int GetFaultCatelog()
        {
            switch (ModuleId)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return 1;

                case 5:
                    return 2;

                case 6:
                    return 3;

                case 7:
                case 8:
                    return 4;

                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    return 5;
            }
            return 1;
        }

        public static int GetFaultPointState(int PointId)
        {
            lock (CacheInvoke.FaultDic)
            {
                if (CacheInvoke.FaultDic.ContainsKey(PointId))
                {
                    return CacheInvoke.FaultDic[PointId];
                }
            }
            LoadSerialComInfo();
            byte[] sendData = _comm.GetSendPag(2, (byte) PointId, 2, 0x11);
            byte[] receiveData = new byte[12];
            int num2 = 0;
            lock (SetLock)
            {
                if (_comm.openPort())
                {
                    num2 = _comm.SendCommand(sendData, ref receiveData, 200);
                }
            }
            if (((num2 > 0) && (receiveData[0] == 250)) && (receiveData[11] == 0xfb))
            {
                int orderCode = receiveData[7];
                UpCacheState(PointId, orderCode);
                return orderCode;
            }
            return 90;
        }

        private string GetVaule(int typeid)
        {
            byte[] buffer;
            byte[] buffer2;
            string str = string.Empty;
            switch (typeid)
            {
                case 1:
                    try
                    {
                        buffer = new byte[] { 0x30, 0x31, 0x30, 0x35, 13 };
                        buffer2 = new byte[0x24];
                        if (!this.comm.openPort())
                        {
                            return str;
                        }
                        if (this.comm.SendCommand(buffer, ref buffer2, 400) > 0)
                        {
                            long num = int.Parse(Encoding.Default.GetString(buffer2).TrimEnd(new char[0]).Split(new char[] { ' ', '\r' })[4], NumberStyles.HexNumber) - 40;
                            str = string.Format("{0}℃", num);
                            this.ErrorData1 = str;
                            return str;
                        }
                        if (this.ErrorData1 != null)
                        {
                            str = this.ErrorData1;
                        }
                    }
                    catch
                    {
                        if (this.ErrorData1 != null)
                        {
                            str = this.ErrorData1;
                        }
                    }
                    return str;

                case 2:
                    try
                    {
                        buffer = new byte[] { 0x30, 0x31, 0x30, 0x43, 13 };
                        buffer2 = new byte[0x16];
                        if (!this.comm.openPort())
                        {
                            return str;
                        }
                        if (this.comm.SendCommand(buffer, ref buffer2, 400) > 0)
                        {
                            string[] strArray2 = Encoding.Default.GetString(buffer2).TrimEnd(new char[0]).Split(new char[] { ' ', '\r' });
                            long num2 = int.Parse(string.Format("{0}{1}", strArray2[4], strArray2[5]), NumberStyles.HexNumber) / 4;
                            str = string.Format("{0}rpm", num2);
                            this.ErrorData2 = str;
                            return str;
                        }
                        if (this.ErrorData2 != null)
                        {
                            str = this.ErrorData2;
                        }
                    }
                    catch
                    {
                        if (this.ErrorData2 != null)
                        {
                            str = this.ErrorData2;
                        }
                    }
                    return str;
            }
            return str;
        }

        private static void LoadSerialComInfo()
        {
            lock (LoadSerialComInfoLock)
            {
                if (((_comm == null) && (ServerSystemInfo.SerialComInfoList != null)) && (ServerSystemInfo.SerialComInfoList.Count != 0))
                {
                    SerialComConfig config = (from t in ServerSystemInfo.SerialComInfoList
                        where t.SerialComType == 3
                        select t).FirstOrDefault<SerialComConfig>();
                    if (config != null)
                    {
                        _comm = new Communication(config.SerialComInfo.Key, config.SerialComInfo.Value);
                    }
                }
            }
        }

        public static bool ResetFaultPoint()
        {
            LoadSerialComInfo();
            bool flag = false;
            byte[] sendData = _comm.GetSendPag(1, 0, 3, 0);
            byte[] receiveData = new byte[12];
            int num = 0;
            lock (SetLock)
            {
                if (_comm.openPort())
                {
                    num = _comm.SendCommand(sendData, ref receiveData, 200);
                }
            }
            if (((num > 0) && (receiveData[0] == 250)) && ((receiveData[11] == 0xfb) && (receiveData[7] == 0x5b)))
            {
                UpCacheState(0, 0);
                flag = true;
            }
            return flag;
        }

        public static void SentToClient(List<ClientInfo> clientList, string TeacherNO, SocketInfoType type, object msg)
        {
            SocketInfo info = new SocketInfo {
                Name = TeacherNO,
                Type = type,
                Msg = msg,
                Time = DateTime.Now
            };
            SendMessage item = new SendMessage {
                ClientList = clientList,
                socketInfo = info
            };
            lock (TcpService.SendMsgPool)
            {
                TcpService.SendMsgPool.Add(item);
            }
        }

        public static bool SetFaultPoint(int PointId, int OrderCode)
        {
            LoadSerialComInfo();
            byte[] sendData = _comm.GetSendPag(1, (byte) PointId, 1, (byte) OrderCode);
            byte[] receiveData = new byte[12];
            int num = 0;
            lock (SetLock)
            {
                if (_comm.openPort())
                {
                    num = _comm.SendCommand(sendData, ref receiveData, 200);
                }
            }
            if (((num > 0) && (receiveData[0] == 250)) && (receiveData[11] == 0xfb))
            {
                UpCacheState(PointId, OrderCode);
                return true;
            }
            return false;
        }

        private static void UpCacheState(int PointId = 0, int OrderCode = 0)
        {
            lock (CacheInvoke.FaultDic)
            {
                if (PointId == 0)
                {
                    CacheInvoke.FaultDic.ToList<KeyValuePair<int, int>>().ForEach(t => CacheInvoke.FaultDic[t.Key] = 0x11);
                }
                else if (CacheInvoke.FaultDic.ContainsKey(PointId))
                {
                    CacheInvoke.FaultDic[PointId] = OrderCode;
                }
                else
                {
                    CacheInvoke.FaultDic.Add(PointId, OrderCode);
                }
            }
        }
    }
}

