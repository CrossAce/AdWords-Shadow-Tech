using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShadowAdwords
{
    public class ConfigBuilder
    {
        public static bool Build(string path)
        {
            try
            {
                using (var streamWriter = new StreamWriter(path + @"\config.xml", false))
                {
                    streamWriter.WriteLine("<xml>");
                    streamWriter.WriteLine("<directoryForDwedReports></directoryForDwedReports>");
                    streamWriter.WriteLine("<emailFromName></emailFromName>");
                    streamWriter.WriteLine("<emailFromPassword></emailFromPassword>");
                    streamWriter.WriteLine("<emailToListPHL></emailToListPHL>");
                    streamWriter.WriteLine("<emailToListAcc></emailToListAcc>");
                    streamWriter.WriteLine("</xml>");
                }
                return true;
            }
            catch
            {
                return false;
            }
          
            
        }
    }
}
