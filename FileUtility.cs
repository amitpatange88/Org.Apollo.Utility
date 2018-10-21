using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Utility
{
    /// <summary>
    /// File Operations are handled here.
    /// </summary>
    public class HostFileUtility
    {
        private string _FileLocation = @"C:\ServiceLogs\HostLive\HostLive.txt";

        //Assigning objects here only immplies lazy loading in Singleton design pattern.
        private static readonly Lazy<HostFileUtility> instance = new Lazy<HostFileUtility>(() => new HostFileUtility());

        public static HostFileUtility Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public HostFileUtility()
        {
        }

        public bool WriteLog(string content)
        {
            bool IsDone = false;
            try
            {
                CreateFileIfNotExists();

                using (StreamWriter w = File.AppendText(_FileLocation))
                {
                    w.WriteLine(content);
                    IsDone = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return IsDone;
        }

        private void CreateFileIfNotExists()
        {
            bool IsExist = File.Exists(_FileLocation);
            if (!IsExist)
            {
                var file = File.Create(_FileLocation);
                file.Close();
            }
        }
    }
}
