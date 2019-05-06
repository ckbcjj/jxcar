using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BLL.Common
{

    public class Serialize
    {
        public static object ByteToObject(byte[] buffer)
        {
            MemoryStream memStream = null;
            object obj3;
            try
            {
                memStream = new MemoryStream(buffer);
                object obj2 = DeserilaizeBinary(memStream);
                memStream.Close();
                obj3 = obj2;
            }
            catch
            {
                obj3 = null;
            }
            finally
            {
                memStream.Close();
            }
            return obj3;
        }

        public static object DeserilaizeBinary(MemoryStream memStream)
        {
            memStream.Position = 0L;
            object obj2 = new BinaryFormatter().Deserialize(memStream);
            memStream.Close();
            return obj2;
        }

        public static byte[] ObjectTobyte(object obj)
        {
            MemoryStream stream = null;
            byte[] buffer;
            try
            {
                stream = SerilaizeBinary(obj);
                buffer = stream.ToArray();
            }
            catch
            {
                buffer = null;
            }
            finally
            {
                stream.Close();
            }
            return buffer;
        }

        public static MemoryStream SerilaizeBinary(object obj)
        {
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, obj);
            return serializationStream;
        }
    }
}

