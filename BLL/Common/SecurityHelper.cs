using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;


namespace BLL.Common
{

    public class SecurityHelper
    {
        public string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[pToDecrypt.Length / 2];
            for (int i = 0; i < (pToDecrypt.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte) num2;
            }
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            try
            {
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.Default.GetString(stream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Encrypt(string pToEncrypt, string sKey)
        {
            string str;
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            provider.Key = Encoding.ASCII.GetBytes(sKey);
            provider.IV = Encoding.ASCII.GetBytes(sKey);
            try
            {
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }
                builder.ToString();
                str = builder.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }

        [DllImport("kernel32")]
        public static extern bool GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        public string ReadFile(string Header, string Key, string strPath)
        {
            StringBuilder lpReturnedString = new StringBuilder(0xff);
            GetPrivateProfileString(Header, Key, "", lpReturnedString, 0xff, strPath);
            string str = lpReturnedString.ToString();
            if (string.IsNullOrEmpty(str) || (!(Key == "PassWord") && !(Header == "UserInfo")))
            {
                return str;
            }
            return this.Decrypt(str, "iloveyou");
        }

        public void WriteFile(string Header, string Key, string Value, string srPath)
        {
            if ((Key != null) && (Value != null))
            {
                new StringBuilder(0xff);
                if ((Key == "PassWord") || (Header == "UserInfo"))
                {
                    string lpString = this.Encrypt(Value, "iloveyou");
                    WritePrivateProfileString(Header, Key, lpString, srPath);
                }
                else
                {
                    WritePrivateProfileString(Header, Key, Value, srPath);
                }
            }
        }

        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
    }
}

