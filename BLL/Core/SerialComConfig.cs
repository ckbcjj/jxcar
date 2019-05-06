using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;


namespace BLL.Core
{

    public class SerialComConfig
    {
        public readonly int SerialComType;

        public event SerialComConfigDelegate SerialComConfigChange;

        public SerialComConfig(int type, KeyValuePair<string, int> serialcominfo)
        {
            this.SerialComType = type;
            this.SerialComInfo = serialcominfo;
        }

        public void OnEvent(int type, object value)
        {
            if (this.SerialComConfigChange != null)
            {
                this.SerialComConfigChange(type, value);
            }
        }

        public KeyValuePair<string, int> NewSerialComInfo
        {
            set
            {
                KeyValuePair<string, int> pair = value;
                if (pair.Key != this.SerialComInfo.Key)
                {
                    this.OnEvent(this.SerialComType, pair);
                    this.SerialComInfo = pair;
                }
                else if ((pair.Key == this.SerialComInfo.Key) && (pair.Value != this.SerialComInfo.Value))
                {
                    this.OnEvent(this.SerialComType * -1, pair);
                    this.SerialComInfo = pair;
                }
            }
        }

        public KeyValuePair<string, int> SerialComInfo { get; private set; }
    }
}

