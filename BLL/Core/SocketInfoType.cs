using System;


namespace BLL.Core
{

    [Serializable]
    public enum SocketInfoType
    {
        SysModule,
        SysPattern,
        CheckItem,
        BeginCheck,
        EndCheck,
        RealTimeDataAsk,
        RealTimeData,
        SchematicMap,
        ReadPointState,
        None,
        OpenSoftWare
    }
}

