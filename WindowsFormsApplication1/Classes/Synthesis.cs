using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Dynamic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VulScanner.PluginProcessing
{
    class Synthesis
    {
        private static string pathOfReport;
        public static string PathOfReport { get { return pathOfReport; } }

        public static string MergeAll(string path)
        {
            //List of xml files need to be merged
            FileCollection mergedFiles = new FileCollection(path, "xml");         

            Result result = new Result();

            for (int i = 0; i < mergedFiles.FileList.Count; i++)
            {
                var xDoc = XDocument.Load(new StreamReader(mergedFiles.FileList[i]));
                dynamic root = new ExpandoObject();
                XmlToDynamic.Parse(root, xDoc.Elements().First());
                
                //Case <vuls/>: there is no vul
                if (root.Result.vuls.ToString() == "")
                {
                    //Console.WriteLine(mergedFiles.FileList[i] + "has no vulnerability");
                    continue;
                }

                //Case <vuls><vul>...</vul></vuls>: there is only 1 vul
                else if (root.Result.vuls.vul.ToString() == "System.Dynamic.ExpandoObject")
                {
                    VulDetails vul = new VulDetails();
                    vul.PluginName = root.Result.vuls.vul.plugin_name;
                    vul.FileName = root.Result.vuls.vul.file_name;
                    vul.Severity = root.Result.vuls.vul.severity;
                    vul.Reliability = root.Result.vuls.vul.reliability;
                    vul.Url = root.Result.vuls.vul.url;
                    vul.Param = root.Result.vuls.vul.param;
                    vul.Category = GetAlias(root.Result.vuls.vul.category);
                    vul.CategoryLink = "file:///" + Directory.GetCurrentDirectory() + "\\ReportViewer\\vulsdb.xml#" + vul.Category;
                    vul.IsSourceCode = root.Result.vuls.vul.is_source_code;
                    vul.Source = root.Result.vuls.vul.source;
                    vul.LineNumber = root.Result.vuls.vul.line_number;
                    vul.Description = root.Result.vuls.vul.description;

                    result.Vuls.VulList.Add(vul);
                }

                //Case <vuls><vul>...</vul>...<vul>...</vul></vuls>: there is more than 1 vul (>=2)
                else if (root.Result.vuls.vul.ToString() == "System.Collections.Generic.List`1[System.Object]")
                {
                    for (int j = 0; j < root.Result.vuls.vul.Count; j++)
                    {
                        VulDetails vul = new VulDetails();
                        vul.PluginName = root.Result.vuls.vul[j].plugin_name;
                        vul.FileName = root.Result.vuls.vul[j].file_name;
                        vul.Severity = root.Result.vuls.vul[j].severity;
                        vul.Reliability = root.Result.vuls.vul[j].reliability;
                        vul.Url = root.Result.vuls.vul[j].url;
                        vul.Param = root.Result.vuls.vul[j].param;
                        vul.Category = GetAlias(root.Result.vuls.vul[j].category);
                        vul.CategoryLink = "file:///" + Directory.GetCurrentDirectory() + "\\ReportViewer\\vulsdb.xml#" + vul.Category;
                        vul.IsSourceCode = root.Result.vuls.vul[j].is_source_code;
                        vul.Source = root.Result.vuls.vul[j].source;
                        vul.LineNumber = root.Result.vuls.vul[j].line_number;
                        vul.Description = root.Result.vuls.vul[j].description;

                        result.Vuls.VulList.Add(vul);
                    }
                }
                
            }
            //Create the unique report
            string filename = DateTime.Now.ToString().Replace("/", "-").Replace(":", "_");           
            XMLReport xmlObj = new XMLReport();
            xmlObj.CreateXML(result, "\\SyntheticResult\\" + filename + ".xml");
            
            //Delete old reports (xml) from the previous scanning           
            FileCollection oldReport = new FileCollection(Directory.GetCurrentDirectory() + "\\ReportViewer", "xml");
            foreach(string old in oldReport.FileList)
            {
                File.Delete(old);
            }

            //Copy final report to viewer to show off
            string sourceFile = Directory.GetCurrentDirectory() + "\\SyntheticResult\\" + filename + ".xml";
            string destFile = Directory.GetCurrentDirectory() + "\\ReportViewer\\" + filename + ".xml";

            File.Copy(sourceFile, destFile, true);
            File.Copy(Directory.GetCurrentDirectory() + "\\VulsDB\\vulsdb.xml", 
                Directory.GetCurrentDirectory() + "\\ReportViewer\\vulsdb.xml", true);

            pathOfReport = destFile;
            return pathOfReport;
        }

        public static string GetAlias(string name)
        {
            Ini alias = new Ini(Directory.GetCurrentDirectory() + "\\VulsDB\\alias.ini");

            string[] aliasArr = alias.GetKeys("alias");

            for (int i = 0; i < aliasArr.Length; i++)
            {
                if (name == aliasArr[i])
                {
                    return alias.GetValue(aliasArr[i], "alias");
                }
            }

            return name;
        }

        public static void StartBrowser(string filename)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            //psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.FileName = "iexplore.exe";
            psi.Arguments = filename;
            Process p = System.Diagnostics.Process.Start(psi);
        }
    }
}
