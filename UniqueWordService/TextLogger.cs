using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueWordService
{
    public static class TextLogger
    {
        private static object lockObject = new object();
        public static void WriteEventLog(string filePath,Exception ex)
        {
            lock (lockObject)
            {
                try
                {

                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog.txt", true))
                    {
                        sw.WriteLine("File path: "+filePath+";Exception source:"+ex.Source.ToString().Trim() + ":" + ex.Message.ToString().Trim() + ";Base Message:" + ex.GetBaseException().Message.ToString().Trim());
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception exex)
                {
                    exex.Data.Add("BaseException", ex);
                    //  throw exex;
                }
            }
        }
    }
}
