using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShadowAdwords
{
    public class ErrorLogWriter
    {
        private string exeFilePath;

        public ErrorLogWriter(string ExeFilePath)
        {
            this.exeFilePath = ExeFilePath; 
        }

        public void LogError(string errorMessage)
        {
            try
            {
                string delimiter = Environment.NewLine + "---------------------------" + Environment.NewLine;
                using (var writer = new StreamWriter(exeFilePath + @"\errorLog.file", true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyy.MM.dd:hh.mm.ss") + delimiter);
                    writer.WriteLine(errorMessage + delimiter);
                }
            }
            // unforseen circumstances
            catch { }
          
        }


    } 

}
