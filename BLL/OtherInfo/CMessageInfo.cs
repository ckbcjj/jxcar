using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace BLL.OtherInfo
{

    public class CMessageInfo
    {
        private static Timer timerShow;

        public static void ShowMessage(string strMessage, string strTitle, int iTimers = 1)
        {
            timerShow = new Timer();
            timerShow.Interval = iTimers * 0x3e8;
            timerShow.Start();
            timerShow.Tick += new EventHandler(CMessageInfo.Showtimer_Tick);
            MessageBox.Show(strMessage, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        private static void Showtimer_Tick(object sender, EventArgs e)
        {
            timerShow.Stop();
            SendKeys.SendWait("Y");
        }
    }
}

