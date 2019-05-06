using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;


namespace BLL.Service
{

    public class Communication
    {
        public SerialPort _serialPort;
        private int baudRate;
        private bool flag;
        private string protName;

        public event MyDataRecivedDelegate DataRecived;

        public Communication()
        {
            this._serialPort = new SerialPort();
        }

        public Communication(string comPortName)
        {
            this._serialPort = new SerialPort(comPortName);
            this._serialPort.BaudRate = 0x2580;
            this._serialPort.Parity = Parity.None;
            this._serialPort.DataBits = 8;
            this._serialPort.StopBits = StopBits.One;
            this._serialPort.Handshake = Handshake.None;
            this._serialPort.RtsEnable = true;
            this._serialPort.ReadTimeout = 0x7d0;
            this.setSerialPort();
        }

        public Communication(string comPortName, int baudRate)
        {
            this._serialPort = new SerialPort(comPortName, baudRate);
            this._serialPort.Parity = Parity.None;
            this._serialPort.DataBits = 8;
            this._serialPort.StopBits = StopBits.One;
            this._serialPort.Handshake = Handshake.None;
            this._serialPort.RtsEnable = true;
            this._serialPort.ReadTimeout = 0x7d0;
            this.setSerialPort();
        }

        public Communication(string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            this._serialPort = new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);
            this._serialPort.RtsEnable = true;
            this._serialPort.ReadTimeout = 0xbb8;
            this.setSerialPort();
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.flag)
                {
                    byte[] buffer = new byte[this._serialPort.BytesToRead];
                    this._serialPort.Read(buffer, 0, buffer.Length);
                    if ((buffer.Length != 0) && (this.DataRecived != null))
                    {
                        this.DataRecived(sender, e, buffer);
                    }
                }
            }
            catch
            {
                if (!this._serialPort.IsOpen)
                {
                    this._serialPort.Open();
                }
            }
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string str = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    str = str + bytes[i].ToString("X2");
                }
            }
            return str;
        }

        public static string ByteToString(byte[] InBytes)
        {
            string str = "";
            foreach (byte num in InBytes)
            {
                str = str + string.Format("{0:X2} ", num);
            }
            return str;
        }

        public void closePort()
        {
            lock (SysManager.SetLock)
            {
                if (this._serialPort.IsOpen)
                {
                    try
                    {
                        this._serialPort.Close();
                    }
                    catch
                    {
                        MessageBox.Show(string.Format("关闭串口{0}失败", this._serialPort.PortName));
                    }
                }
            }
        }

        ~Communication()
        {
            if (this._serialPort.IsOpen)
            {
                this._serialPort.Close();
            }
        }

        public byte[] GetSendPag(byte FrameType, byte FaultPointId, byte CommandType, byte Order)
        {
            byte[] buffer = new byte[12];
            buffer[0] = 250;
            buffer[1] = 1;
            buffer[2] = FrameType;
            buffer[3] = FaultPointId;
            buffer[4] = 0;
            buffer[5] = 1;
            buffer[6] = CommandType;
            buffer[7] = Order;
            buffer[8] = 0;
            buffer[9] = FaultPointId;
            buffer[10] = this.GetSum(buffer);
            buffer[11] = 251;
            return buffer;
        }

        public byte[] GetSendPag(byte FrameType, byte FaultPointId, byte CommandType, byte Order, int iFaultNo)
        {
            byte[] buffer = new byte[12];
            buffer[0] = 250;
            buffer[1] = (byte)iFaultNo;
            buffer[2] = FrameType;
            buffer[3] = FaultPointId;
            buffer[4] = 0;
            buffer[5] = 1;
            buffer[6] = CommandType;
            buffer[7] = Order;
            buffer[8] = 0;
            buffer[9] = FaultPointId;
            buffer[10] = this.GetSum(buffer);
            buffer[11] = 0xfb;
            return buffer;
        }

        public byte[] GetSendPag2(byte FrameType, byte ModuleId)
        {
            byte[] buffer = new byte[6];
            buffer[0] = 250;
            buffer[1] = ModuleId;
            buffer[2] = FrameType;
            buffer[3] = 3;
            buffer[4] = this.GetSum(buffer);
            buffer[5] = 0xfb;
            return buffer;
        }

        public string[] getSerials()
        {
            return SerialPort.GetPortNames();
        }

        private byte GetSum(byte[] bt)
        {
            byte num = 0;
            for (int i = 0; i < (bt.Length - 3); i++)
            {
                num = (byte) (num + bt[i + 1]);
            }
            return num;
        }

        public bool openPort()
        {
            if (this._serialPort.IsOpen)
            {
                return true;
            }
            try
            {
                this._serialPort.Open();
                return true;
            }
            catch
            {
                MessageBox.Show(string.Format("串口{0}打开失败", this._serialPort.PortName));
                return false;
            }
        }

        public int SendCommand(byte[] SendData, ref byte[] ReceiveData, int Overtime)
        {
            if (this._serialPort.IsOpen)
            {
                try
                {
                    this._serialPort.DiscardInBuffer();
                    this._serialPort.Write(SendData, 0, SendData.Length);
                    int num = 0;
                    int num2 = 0;
                    Thread.Sleep(10);
                    while (num++ < Overtime)
                    {
                        if (this._serialPort.BytesToRead >= ReceiveData.Length)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }
                    if (this._serialPort.BytesToRead >= ReceiveData.Length)
                    {
                        num2 = this._serialPort.Read(ReceiveData, 0, ReceiveData.Length);
                    }
                    else
                    {
                        num2 = this._serialPort.Read(ReceiveData, 0, this._serialPort.BytesToRead);
                    }
                    return num2;
                }
                catch
                {
                    MessageBox.Show("串口通信过程中不允许关闭串口");
                    return 0;
                }
            }
            return -1;
        }

        public int SendCommand2(byte[] SendData, ref byte[] ReceiveData, int Overtime)
        {
            if (this._serialPort.IsOpen)
            {
                if (ReceiveData.Length == 0x24)
                {
                    ReceiveData = new byte[] { 
                        0x37, 0x45, 0x39, 0x20, 0x30, 0x33, 0x20, 0x34, 0x31, 0x20, 0x30, 0x35, 0x20, 0x36, 0x45, 0x20, 
                        13, 0x37, 0x45, 0x38, 0x20, 0x30, 0x33, 0x20, 0x34, 0x31, 0x20, 0x30, 0x35, 0x20, 0x36, 0x45, 
                        0x20, 13, 0, 0
                     };
                    Thread.Sleep(10);
                    ReceiveData[0x22] = 13;
                    ReceiveData[0x23] = 0x3e;
                }
                else
                {
                    ReceiveData = new byte[] { 
                        0x37, 0x45, 0x38, 0x20, 0x30, 0x34, 0x20, 0x34, 0x31, 0x20, 0x30, 0x43, 0x20, 0x30, 0x39, 0x20, 
                        0x36, 0x30, 0x20, 13, 0, 0
                     };
                    Thread.Sleep(10);
                    ReceiveData[20] = 13;
                    ReceiveData[0x15] = 0x3e;
                }
            }
            return 1;
        }

        public void SendData(string data)
        {
            try
            {
                if (!this._serialPort.IsOpen)
                {
                    this._serialPort.Open();
                }
                this._serialPort.Write(data);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                if (this._serialPort.IsOpen)
                {
                    this._serialPort.Close();
                }
            }
        }

        public void SendData(byte[] data, int offset, int count)
        {
            try
            {
                if (this._serialPort.IsOpen)
                {
                    this._serialPort.DiscardInBuffer();
                    this._serialPort.Write(data, offset, count);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string[] serialsIsConnected()
        {
            List<string> list = new List<string>();
            string[] strArray2 = this.getSerials();
            for (int i = 0; i < strArray2.Length; i++)
            {
                string text1 = strArray2[i];
            }
            return list.ToArray();
        }

        private void setSerialPort()
        {
            if (this._serialPort != null)
            {
                this._serialPort.ReceivedBytesThreshold = 1;
            }
        }

        public void setSerialPort(string comPortName, int baudRate, int dataBits, int stopBits)
        {
            if (this._serialPort.IsOpen)
            {
                this._serialPort.Close();
            }
            this._serialPort.PortName = comPortName;
            this._serialPort.BaudRate = baudRate;
            this._serialPort.Parity = Parity.None;
            this._serialPort.DataBits = dataBits;
            this._serialPort.StopBits = (StopBits) stopBits;
            this._serialPort.Handshake = Handshake.None;
            this._serialPort.RtsEnable = false;
            this._serialPort.ReadTimeout = 0xbb8;
            this._serialPort.NewLine = "/r/n";
            this.setSerialPort();
        }

        public static byte[] StringToByte(string InString)
        {
            string[] strArray = InString.Split(" ".ToCharArray());
            byte[] buffer = new byte[strArray.Length];
            for (int i = 0; i <= (strArray.Length - 1); i++)
            {
                buffer[i] = byte.Parse(strArray[i], NumberStyles.HexNumber);
            }
            return buffer;
        }

        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString = hexString + " ";
            }
            byte[] buffer = new byte[hexString.Length / 2];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }

        public int BaudRate
        {
            get
            {
                return this._serialPort.BaudRate;
            }
            set
            {
                this._serialPort.BaudRate = value;
                this.baudRate = value;
            }
        }

        public string PortName
        {
            get
            {
                return this._serialPort.PortName;
            }
            set
            {
                this._serialPort.PortName = value;
                this.protName = value;
            }
        }

        public delegate void MyDataRecivedDelegate(object sender, SerialDataReceivedEventArgs e, byte[] buff);
    }
}

