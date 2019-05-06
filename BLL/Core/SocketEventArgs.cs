namespace BLL.Core
{
    using System;

    public class SocketEventArgs : EventArgs
    {
        public SocketInfoType _eventType;
        public object _value;

        public SocketEventArgs(SocketInfoType type, object value)
        {
            this._value = value;
            this._eventType = type;
        }
    }
}

