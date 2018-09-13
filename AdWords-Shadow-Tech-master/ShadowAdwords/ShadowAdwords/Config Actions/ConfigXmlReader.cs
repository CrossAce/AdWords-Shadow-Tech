using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ShadowAdwords
{
    public static class ConfigXmlReader
    {
        public static ConfigData BuildConfigData(string xmlFilePath)
        {
            
            if (!File.Exists(xmlFilePath))
            {
                throw new FileNotFoundException(); 
            }
            else
            {
                ConfigData result = new ConfigData();
                AuthToken token = new AuthToken();

                string phlEmailList = ""; // gets the unseperated string 
                string accEmailList = ""; // --//--

                Stream stream = new FileStream(xmlFilePath, FileMode.Open);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Async = true;

                bool isDirectory = false;
                bool isUsername = false;
                bool isPassword = false;
                bool isPHLEmailList = false;
                bool isAccEmailList = false;


                using (XmlReader reader = XmlReader.Create(stream,settings))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name == "directoryForDwedReports") isDirectory = true;
                                else if (reader.Name == "emailFromName") isUsername = true;
                                else if (reader.Name == "emailFromPassword") isPassword = true;
                                else if (reader.Name == "emailToListPHL") isPHLEmailList = true;
                                else if (reader.Name == "emailToListAcc") isAccEmailList = true;
                                break;
                            case XmlNodeType.Text:
                                if (isDirectory)
                                    result.DownloadPath = reader.Value;
                                else if (isUsername)
                                    token.Username = reader.Value;
                                else if (isPassword)
                                {
                                    token.Password = reader.Value;
                                    result.authToken = token;
                                }
                                else if (isPHLEmailList) phlEmailList = reader.Value;
                                else if (isAccEmailList) accEmailList = reader.Value;

                                break;

                            case XmlNodeType.EndElement:
                                if (reader.Name == "directoryForDwedReports") isDirectory = false;
                                else if (reader.Name == "emailFromName") isUsername = false;
                                else if (reader.Name == "emailFromPassword") isPassword = false;
                                else if (reader.Name == "emailToListPHL") isPHLEmailList = false;
                                else if (reader.Name == "emailToListAcc") isAccEmailList = false;
                                break;
                          
                        }
                        
                    } // end while
                } // end using

                result.adWordsPHLTeamEmails = phlEmailList.Split(',');
                result.accountantEmails = accEmailList.Split(',');
                stream.Close();
                return result;

            }
            
        }
    }
}
