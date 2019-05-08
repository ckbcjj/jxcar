using BLL.Common;
using BLL.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Student
{
    public partial class FrmSetting : XtraForm
    {
  
        public FrmSetting()
        {
            this.InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            string[] comList = this.GetComList();
            this.comboBoxEdit2.Properties.Items.AddRange(comList);
            this.comboBoxEdit4.Properties.Items.AddRange(comList);
            SerialComConfig serialComConfig = null;
            SerialComConfig serialComConfig2 = null;
            if (ClientSystemInfo.SerialComInfoList != null && ClientSystemInfo.SerialComInfoList.Count != 0)
            {
                serialComConfig = (from t in ClientSystemInfo.SerialComInfoList
                                   where t.SerialComType == 1
                                   select t).FirstOrDefault<SerialComConfig>();
                serialComConfig2 = (from t in ClientSystemInfo.SerialComInfoList
                                    where t.SerialComType == 2
                                    select t).FirstOrDefault<SerialComConfig>();
            }
            if (serialComConfig != null)
            {
                this.comboBoxEdit2.SelectedIndex = this.comboBoxEdit2.Properties.Items.IndexOf(serialComConfig.SerialComInfo.Key);
                this.comboBoxEdit1.SelectedIndex = this.comboBoxEdit1.Properties.Items.IndexOf(serialComConfig.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit2.SelectedItem = "COM1";
                this.comboBoxEdit1.SelectedItem = "19200";
            }
            if (serialComConfig2 != null)
            {
                this.comboBoxEdit4.SelectedIndex = this.comboBoxEdit4.Properties.Items.IndexOf(serialComConfig2.SerialComInfo.Key);
                this.comboBoxEdit3.SelectedIndex = this.comboBoxEdit3.Properties.Items.IndexOf(serialComConfig2.SerialComInfo.Value.ToString());
                return;
            }
            this.comboBoxEdit4.SelectedItem = "COM1";
            this.comboBoxEdit3.SelectedItem = "19200";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string text = this.textEdit4.Text.Trim();
            if (!Regex.IsMatch(text, "^(([1-9]|([1-9]\\d)|(1\\d\\d)|(2([0-4]\\d|5[0-5])))\\.)(([1-9]|([1-9]\\d)|(1\\d\\d)|(2([0-4]\\d|5[0-5])))\\.){2}([1-9]|([1-9]\\d)|(1\\d\\d)|(2([0-4]\\d|5[0-5])))$"))
            {
                MessageBox.Show("请输入合法的ip地址");
                return;
            }
            IPStatus iPStatus = this.CheckNet(text);
            IPStatus iPStatus2 = iPStatus;
            if (iPStatus2 == IPStatus.Success)
            {
                this.labelControl10.Text = "连接成功";
                return;
            }
            switch (iPStatus2)
            {
                case IPStatus.DestinationNetworkUnreachable:
                    this.labelControl10.Text = "无法访问目标计算机的网络";
                    return;
                case IPStatus.DestinationHostUnreachable:
                    this.labelControl10.Text = "无法访问目标主机";
                    return;
                case IPStatus.DestinationProtocolUnreachable:
                    this.labelControl10.Text = "目标管理员已禁止访问主机";
                    return;
                default:
                    if (iPStatus2 != IPStatus.TimedOut)
                    {
                        this.labelControl10.Text = "连接失败";
                        return;
                    }
                    this.labelControl10.Text = "请求超时";
                    return;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.Compare(this.comboBoxEdit2.Text, this.comboBoxEdit4.Text) == 0)
            {
                MessageBox.Show("请选择正确的串口");
                return;
            }
            try
            {
                SecurityHelper securityHelper = new SecurityHelper();
                string strPath = ClientSystemInfo.strPath;
                string text = this.comboBoxEdit2.SelectedItem.ToString();
                int value = int.Parse(this.comboBoxEdit1.SelectedItem.ToString().Trim());
                securityHelper.WriteFile("检测板", "SerialCom", text, strPath);
                securityHelper.WriteFile("检测板", "BaudRate", value.ToString(), strPath);
                if (ClientSystemInfo.SerialComInfoList != null && ClientSystemInfo.SerialComInfoList.Count != 0)
                {
                    KeyValuePair<string, int> newSerialComInfo = new KeyValuePair<string, int>(text, value);
                    (from t in ClientSystemInfo.SerialComInfoList
                     where t.SerialComType == 1
                     select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = newSerialComInfo;
                }
            }
            catch
            {
                MessageBox.Show("保存失败");
            }
            base.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        public string[] GetIpv4()
        {
            StringCollection stringCollection = new StringCollection();
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress[] array = hostAddresses;
            for (int i = 0; i < array.Length; i++)
            {
                IPAddress iPAddress = array[i];
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    stringCollection.Add(iPAddress.ToString());
                }
            }
            string[] array2 = new string[stringCollection.Count];
            stringCollection.CopyTo(array2, 0);
            return array2;
        }

        public string[] GetComList()
        {
            return SerialPort.GetPortNames();
        }

        public IPStatus CheckNet(string ip)
        {
            string[] array = ip.Split(new char[]
			{
				'.'
			});
            byte[] address = new byte[]
			{
				byte.Parse(array[0]),
				byte.Parse(array[1]),
				byte.Parse(array[2]),
				byte.Parse(array[3])
			};
            IPAddress address2 = new IPAddress(address);
            Ping ping = new Ping();
            return ping.Send(address2).Status;
        }
    }
}
