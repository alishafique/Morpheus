using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace Seguro.Accounts
{
    public static class UploadUtils
    {
        //4 Mb default buffer size
        private const int DEFAULT_BUFFER_SIZE = 4 * 1024 * 1024;
        private const string DEFAULT_UPLOAD_PATH = "~/upload";
        public static int BufferSize
        {
            get
            {
                int bufferSize;
                if (Int32.TryParse(ConfigurationManager.AppSettings["uploadUtilsBufferSize"], out bufferSize))
                {
                    return bufferSize;
                }
                return DEFAULT_BUFFER_SIZE;
            }
        }
        public static string UploadPath
        {
            get
            {
                string path = DEFAULT_UPLOAD_PATH;
                if (ConfigurationManager.AppSettings["fileUploadPath"] != null)
                {
                    path = ConfigurationManager.AppSettings["fileUploadPath"];
                }
                if (path.StartsWith("~"))
                {
                    path = HttpContext.Current.Server.MapPath(path);
                }
                if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    path += Path.DirectorySeparatorChar;
                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException(path);
                return path;
            }
        }
        public static MemoryStream GetStreamFromCache(string key)
        {
            Dictionary<string, MemoryStream> uploadingFiles = HttpContext.Current.Cache["UploadingFiles"] as Dictionary<string, MemoryStream>;
            MemoryStream stream;
            if (uploadingFiles == null)
            {
                uploadingFiles = new Dictionary<string, MemoryStream>();
                HttpContext.Current.Cache["UploadingFiles"] = uploadingFiles;
            }
            if (!uploadingFiles.ContainsKey(key))
            {
                stream = new MemoryStream();
                uploadingFiles.Add(key, stream);
            }
            else
            {
                stream = uploadingFiles[key];
            }
            return stream;
        }
        public static void RemoveStreamFromCache(string key)
        {
            Dictionary<string, MemoryStream> uploadingFiles = HttpContext.Current.Cache["UploadingFiles"] as Dictionary<string, MemoryStream>;
            if (uploadingFiles != null && uploadingFiles.ContainsKey(key))
            {
                uploadingFiles.Remove(key);
            }
        }
        public static void AppendStreamToFile(string fileName, MemoryStream stream)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Append))
            {
                stream.WriteTo(fs);
            }
        }
    }
}