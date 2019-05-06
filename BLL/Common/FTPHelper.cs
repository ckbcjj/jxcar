using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


namespace BLL.Common
{

    public class FTPHelper
    {
        private string ftpPassword;
        private string ftpRemotePath;
        private string ftpServerIP;
        private string ftpURI;
        private string ftpUserID;

        public FTPHelper(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        {
            this.ftpServerIP = FtpServerIP;
            this.ftpRemotePath = FtpRemotePath;
            this.ftpUserID = FtpUserID;
            this.ftpPassword = FtpPassword;
            this.ftpURI = "ftp://" + this.ftpServerIP + "/" + this.ftpRemotePath + "/";
        }

        public void Delete(string fileName)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + fileName));
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                request.Method = "DELE";
                request.KeepAlive = false;
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                long contentLength = response.ContentLength;
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Download(string filePath, string fileName)
        {
            try
            {
                FileStream stream = new FileStream(filePath + @"\" + fileName, FileMode.Create);
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + fileName));
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                request.Method = "RETR";
                request.UseBinary = true;
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                long contentLength = response.ContentLength;
                int count = 0x800;
                byte[] buffer = new byte[count];
                for (int i = responseStream.Read(buffer, 0, count); i > 0; i = responseStream.Read(buffer, 0, count))
                {
                    stream.Write(buffer, 0, i);
                }
                responseStream.Close();
                stream.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public bool FileExist(string RemoteFileName)
        {
            foreach (string str in this.GetFileList("*.*"))
            {
                if (str.Trim() == RemoteFileName.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        private string[] GetAllList(string url)
        {
            List<string> list = new List<string>();
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(url));
            request.Credentials = new NetworkCredential(this.ftpPassword, this.ftpPassword);
            request.Method = "NLST";
            request.UseBinary = true;
            request.UsePassive = true;
            try
            {
                using (FtpWebResponse response = (FtpWebResponse) request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string str;
                        while ((str = reader.ReadLine()) != null)
                        {
                            list.Add(str);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list.ToArray();
        }

        public string[] GetFileList(string url)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(url));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(this.ftpPassword, this.ftpPassword);
                request.Method = "LIST";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                for (string str = reader.ReadLine(); str != null; str = reader.ReadLine())
                {
                    if (str.IndexOf("<DIR>") == -1)
                    {
                        builder.Append(Regex.Match(str, @"[\S]+ [\S]+", RegexOptions.IgnoreCase).Value.Split(new char[] { ' ' })[1]);
                        builder.Append("\n");
                    }
                }
                builder.Remove(builder.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return builder.ToString().Split(new char[] { '\n' });
        }

        public string[] GetFilesDetailList()
        {
            string[] strArray;
            try
            {
                StringBuilder builder = new StringBuilder();
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI));
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                request.Method = "LIST";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string str = reader.ReadLine();
                str = reader.ReadLine();
                for (str = reader.ReadLine(); str != null; str = reader.ReadLine())
                {
                    builder.Append(str);
                    builder.Append("\n");
                }
                builder.Remove(builder.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                strArray = builder.ToString().Split(new char[] { '\n' });
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return strArray;
        }

        public long GetFileSize(string filename)
        {
            long contentLength = 0L;
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + filename));
                request.Method = "SIZE";
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                contentLength = response.ContentLength;
                responseStream.Close();
                response.Close();
            }
            catch (Exception)
            {
            }
            return contentLength;
        }

        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                this.ftpRemotePath = DirectoryName;
            }
            else
            {
                this.ftpRemotePath = this.ftpRemotePath + DirectoryName + "/";
            }
            this.ftpURI = "ftp://" + this.ftpServerIP + "/" + this.ftpRemotePath + "/";
        }

        public void MakeDir(string dirName)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + dirName));
                request.Method = "MKD";
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                response.GetResponseStream().Close();
                response.Close();
            }
            catch (Exception)
            {
            }
        }

        public void MovieFile(string currentFilename, string newDirectory)
        {
            this.ReName(currentFilename, newDirectory);
        }

        public void ReName(string currentFilename, string newFilename)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + currentFilename));
                request.Method = "RENAME";
                request.RenameTo = newFilename;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                response.GetResponseStream().Close();
                response.Close();
            }
            catch (Exception)
            {
            }
        }

        public void Upload(string filename)
        {
            FileInfo info = new FileInfo(filename);
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri(this.ftpURI + info.Name));
            request.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
            request.Method = "STOR";
            request.KeepAlive = false;
            request.UseBinary = true;
            request.ContentLength = info.Length;
            int count = 0x800;
            byte[] buffer = new byte[count];
            FileStream stream = info.OpenRead();
            try
            {
                Stream requestStream = request.GetRequestStream();
                for (int i = stream.Read(buffer, 0, count); i != 0; i = stream.Read(buffer, 0, count))
                {
                    requestStream.Write(buffer, 0, i);
                }
                requestStream.Close();
                stream.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

