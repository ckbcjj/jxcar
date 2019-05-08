namespace Teacher
{
    using BLL.Common;
    using BLL.Core;
    using BLL.Service;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO.Ports;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class FrmSetting : XtraForm
    {

        public FrmSetting(bool state)
        {
            this.InitializeComponent();
            this._isRTDataRun = state;
            this.Test = this.GetTable();
        }

        public IPStatus CheckNet(string ip)
        {
            string[] strArray = ip.Split(new char[] { '.' });
            byte[] buffer = new byte[] { byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2]), byte.Parse(strArray[3]) };
            IPAddress address = new IPAddress(buffer);
            Ping ping = new Ping();
            return ping.Send(address).Status;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            this.labelControl3.Text = (ServerSystemInfo.SysPattern == 0) ? "自由训练模式" : "实训考核模式";
            this.textEdit1.Text = this.GetIpv4().FirstOrDefault<string>();
            this.textEdit1.Enabled = false;
            if ((this.Test != null) && (this.Test.Rows.Count != 0))
            {
                this.textEdit2.Text = this.Test.Rows[0]["Port1"].ToString();
                this.textEdit5.Text = this.Test.Rows[0]["Port2"].ToString();
            }
            string[] comList = this.GetComList();
            this.comboBoxEdit1.SelectedIndex = ServerSystemInfo.SysPattern;
            this.comboBoxEdit2.Properties.Items.AddRange(comList);
            this.comboBoxEdit5.Properties.Items.AddRange(comList);
            this.comboBoxEdit7.Properties.Items.AddRange(comList);
            SerialComConfig config = null;
            SerialComConfig config2 = null;
            SerialComConfig config3 = null;
            if ((ServerSystemInfo.SerialComInfoList != null) && (ServerSystemInfo.SerialComInfoList.Count != 0))
            {
                config = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 1
                    select t).FirstOrDefault<SerialComConfig>();
                config2 = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 2
                    select t).FirstOrDefault<SerialComConfig>();
                config3 = (from t in ServerSystemInfo.SerialComInfoList
                    where t.SerialComType == 3
                    select t).FirstOrDefault<SerialComConfig>();
            }
            if (config != null)
            {
                this.comboBoxEdit2.SelectedIndex = this.comboBoxEdit2.Properties.Items.IndexOf(config.SerialComInfo.Key);
                this.comboBoxEdit3.SelectedIndex = this.comboBoxEdit3.Properties.Items.IndexOf(config.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit2.SelectedItem = "COM1";
                this.comboBoxEdit3.SelectedItem = "19200";
            }
            if (config2 != null)
            {
                this.comboBoxEdit5.SelectedIndex = this.comboBoxEdit5.Properties.Items.IndexOf(config2.SerialComInfo.Key);
                this.comboBoxEdit4.SelectedIndex = this.comboBoxEdit4.Properties.Items.IndexOf(config2.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit5.SelectedItem = "COM1";
                this.comboBoxEdit4.SelectedItem = "19200";
            }
            if (config3 != null)
            {
                this.comboBoxEdit7.SelectedIndex = this.comboBoxEdit7.Properties.Items.IndexOf(config3.SerialComInfo.Key);
                this.comboBoxEdit6.SelectedIndex = this.comboBoxEdit6.Properties.Items.IndexOf(config3.SerialComInfo.Value.ToString());
            }
            else
            {
                this.comboBoxEdit7.SelectedItem = "COM1";
                this.comboBoxEdit6.SelectedItem = "19200";
            }
        }

        public string[] GetComList()
        {
            return SerialPort.GetPortNames();
        }

        public string[] GetIpv4()
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

        private DataTable GetTable()
        {
            this.da = new DataAccess();
            return this.da.GetList("select * from serverinfo where id=1");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.comboBoxEdit2.SelectedItem.ToString();
                int num = int.Parse(this.comboBoxEdit3.SelectedItem.ToString().Trim());
                string str2 = this.comboBoxEdit5.SelectedItem.ToString();
                int num2 = int.Parse(this.comboBoxEdit4.SelectedItem.ToString().Trim());
                string str3 = this.comboBoxEdit7.SelectedItem.ToString();
                int num3 = int.Parse(this.comboBoxEdit6.SelectedItem.ToString().Trim());
                if (((str == str2) || (str2 == str3)) || (str == str3))
                {
                    MessageBox.Show("请选择正确的串口");
                }
                else
                {
                    if (this._isRTDataRun)
                    {
                        SerialComConfig config = (from t in ServerSystemInfo.SerialComInfoList
                            where t.SerialComType == 3
                            select t).FirstOrDefault<SerialComConfig>();
                        if ((config != null) && ((config.SerialComInfo.Key != str3) || (config.SerialComInfo.Value != num3)))
                        {
                            MessageBox.Show("实时数据正在获取中,不能更改相应的串口通信配置");
                            return;
                        }
                    }
                    if (CheckInfo.PcCheckState && (this.comboBoxEdit1.SelectedIndex == 1))
                    {
                        MessageBox.Show("考核过程中不能切换为自由训练模式");
                    }
                    else
                    {
                        string str4 = this.textEdit1.Text.Trim();
                        string str5 = this.textEdit3.Text.Trim();
                        int num4 = Convert.ToInt32(this.textEdit2.Text.Trim());
                        int num5 = Convert.ToInt32(this.textEdit5.Text.Trim());
                        ServerSystemInfo.SysPatternBuff = this.comboBoxEdit1.SelectedIndex;
                        string sql = null;
                        if ((this.Test != null) && (this.Test.Rows.Count != 0))
                        {
                            sql = string.Concat(new object[] { "update serverinfo set ip='", str4, "',port1=", num4, ",port2=", num5 });
                            if (!string.IsNullOrWhiteSpace(str5))
                            {
                                sql = sql + ",shareaddress='" + str5 + "'";
                            }
                            sql = sql + " where id=1";
                        }
                        else
                        {
                            sql = string.Concat(new object[] { "insert into serverinfo values('", str4, "',", num4, ",", num5, "," });
                            if (!string.IsNullOrWhiteSpace(str5))
                            {
                                sql = sql + "'" + str5 + "',";
                            }
                            else
                            {
                                sql = sql + "null,";
                            }
                            sql = sql + "null)";
                        }
                        if (this.da.SqlCommand(sql))
                        {
                            SecurityHelper helper = new SecurityHelper();
                            string strPath = ServerSystemInfo.strPath;
                            helper.WriteFile("切换板", "SerialCom", str, strPath);
                            helper.WriteFile("切换板", "BaudRate", num.ToString(), strPath);
                            helper.WriteFile("设故板", "SerialCom", str2, strPath);
                            helper.WriteFile("设故板", "BaudRate", num2.ToString(), strPath);
                            helper.WriteFile("实时数据", "SerialCom", str3, strPath);
                            helper.WriteFile("实时数据", "BaudRate", num3.ToString(), strPath);
                            if ((ServerSystemInfo.SerialComInfoList != null) && (ServerSystemInfo.SerialComInfoList.Count != 0))
                            {
                                KeyValuePair<string, int> pair = new KeyValuePair<string, int>(str, num);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 1
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair;
                                KeyValuePair<string, int> pair2 = new KeyValuePair<string, int>(str2, num2);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 2
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair2;
                                KeyValuePair<string, int> pair3 = new KeyValuePair<string, int>(str3, num3);
                                (from t in ServerSystemInfo.SerialComInfoList
                                    where t.SerialComType == 3
                                    select t).FirstOrDefault<SerialComConfig>().NewSerialComInfo = pair3;
                            }
                            MessageBox.Show("信息保存成功！");
                            if ((this.textEdit2.Text.Trim() != this.Test.Rows[0]["Port1"].ToString()) || (this.textEdit5.Text.Trim() != this.Test.Rows[0]["Port2"].ToString()))
                            {
                                MessageBox.Show("通信端口已更改,需重启服务器才能生效");
                            }
                            base.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("请输入合法参数");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string input = this.textEdit4.Text.Trim();
            if (!Regex.IsMatch(input, @"^(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.)(([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))\.){2}([1-9]|([1-9]\d)|(1\d\d)|(2([0-4]\d|5[0-5])))$"))
            {
                MessageBox.Show("请输入合法的ip地址");
            }
            else
            {
                switch (this.CheckNet(input))
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

                    case IPStatus.TimedOut:
                        this.labelControl10.Text = "请求超时";
                        return;

                    case IPStatus.Success:
                        this.labelControl10.Text = "连接成功";
                        return;
                }
                this.labelControl10.Text = "连接失败";
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

