using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;

namespace VulScanner.PluginProcessing
{
    class Wapiti
    {
        public static void Run(string cmd, Result result)
        {
            //Format of temp file: NameOfPluginReport.xml - (Ex: WapitiReport.xml)
            string tempFile = Directory.GetCurrentDirectory() + "\\Temp\\xml\\WapitiReport.xml";

            cmd = cmd.Replace("%%url%%", Form1.UrlTarget).Replace("%%tempFile%%", tempFile);
            
            //Excecute command
            ExecuteCmd exe = new ExecuteCmd();
            exe.ExecuteCommandSync(cmd);

            //Convert XML File (result of scanning) to ResultObject.
            Convert2ResultObject(tempFile, result);
        }

        private static void Convert2ResultObject(string pathOfXml, Result result)
        {
            var xDoc = XDocument.Load(new StreamReader(pathOfXml));
            dynamic root = new ExpandoObject();
            XmlToDynamic.Parse(root, xDoc.Elements().First());

            try
            {
                // default root.report.vulnerabilities.vulnerability.Count = 9
                for (int i = 0; i < root.report.vulnerabilities.vulnerability.Count; i++)
                {
                    //case <entries/>: there is no entry
                    if (root.report.vulnerabilities.vulnerability[i].entries.ToString() == "")
                    {
                        //Console.WriteLine(i + " " + root.report.vulnerabilities.vulnerability[i].name);
                        continue;
                    }

                    //case <entries><entry>...</entry></entries>: there is only 1 entry
                    else if (root.report.vulnerabilities.vulnerability[i].entries.entry.ToString() == "System.Dynamic.ExpandoObject")
                    {
                        VulDetails vul = new VulDetails();
                        vul.PluginName = "Wapiti";
                        vul.Category = root.report.vulnerabilities.vulnerability[i].name;
                        vul.Description = root.report.vulnerabilities.vulnerability[i].description;
                        vul.CategoryLink = root.report.vulnerabilities.vulnerability[i].references.reference[0].url;
                        vul.Url = root.report.vulnerabilities.vulnerability[i].entries.entry.curl_command;
                        vul.Param = root.report.vulnerabilities.vulnerability[i].entries.entry.parameter;
                        vul.Severity = root.report.vulnerabilities.vulnerability[i].entries.entry.level;  //not sure !!!
                        vul.Reliability = "";    //there is no info                           

                        //default for blackbox
                        vul.FileName = "";
                        vul.IsSourceCode = "false";
                        vul.LineNumber = "-1";    //format: -1 is have no linenumber
                        vul.Source = "";

                        result.Vuls.VulList.Add(vul);
                    }
                    //case <entries><entry>...</entry><entry>...</entry>...<entry>...</entry></entries>: there is more than 1 entry (>=2)
                    else if (root.report.vulnerabilities.vulnerability[i].entries.entry.ToString() == "System.Collections.Generic.List`1[System.Object]")
                    {
                        for (int j = 0; j < root.report.vulnerabilities.vulnerability[i].entries.entry.Count; j++)
                        {
                            VulDetails vul = new VulDetails();
                            vul.PluginName = "Wapiti";
                            vul.Category = root.report.vulnerabilities.vulnerability[i].name;
                            vul.Description = root.report.vulnerabilities.vulnerability[i].description;
                            vul.CategoryLink = root.report.vulnerabilities.vulnerability[i].references.reference[0].url;
                            vul.Url = root.report.vulnerabilities.vulnerability[i].entries.entry[j].curl_command;
                            vul.Param = root.report.vulnerabilities.vulnerability[i].entries.entry[j].parameter;
                            vul.Severity = root.report.vulnerabilities.vulnerability[i].entries.entry[j].level;  //not sure !!!
                            vul.Reliability = "";    //there is no info                           

                            //default for blackbox
                            vul.FileName = "";  
                            vul.IsSourceCode = "false";
                            vul.LineNumber = "-1";    //format: -1 is have no linenumber
                            vul.Source = "";

                            result.Vuls.VulList.Add(vul);
                        }
                    }                  
                }
            }

            catch (Exception objException)
            {
                Console.WriteLine("Cannot create list of vulnerabilities for Wapiti");
                MessageBox.Show("Cannot create list of vulnerabilities for Wapiti", "Error");
            }
            
        }
    }
}
