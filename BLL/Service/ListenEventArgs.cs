namespace BLL.Service
{
    using BLL.Core;
    using System;

    public class ListenEventArgs : EventArgs
    {
        public SocketInfoType _eventType;
        public object value;

        public ListenEventArgs(SocketInfoType type, object value)
        {
            this.value = value;
            this._eventType = type;
        }
    }
}

