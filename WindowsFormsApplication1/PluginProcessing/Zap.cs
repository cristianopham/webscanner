using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;


namespace VulScanner.PluginProcessing
{
    class Zap
    {
        public static void Run(string cmd, Result result)
        {
            //Format of temp file: NameOfPluginReport.xml - (Ex: ZapReport.xml)
            string tempFile = Directory.GetCurrentDirectory() + "\\Temp\\xml\\ZapReport.xml";
           
            cmd = cmd.Replace("%%url%%", Form1.UrlTarget).Replace("%%tempFile%%", tempFile);                       

            //Excecute command
            ExecuteCmd exe = new ExecuteCmd();
            exe.ExecuteCommandSync(cmd);

            //Convert XML File (result of scanning) to ResultObject.
            Convert2ResultObject(tempFile, result);
            
            //MessageBox.Show(exe.ResultOfScanning);
        }

        private static void Convert2ResultObject(string pathOfXml, Result result)
        {
            //Result result = new Result();

            var xDoc = XDocument.Load(new StreamReader(pathOfXml));
            dynamic root = new ExpandoObject();
            XmlToDynamic.Parse(root, xDoc.Elements().First());
          
            try
            {
                if (root.OWASPZAPReport.site.alerts.ToString() == "")
                {
                    //do nothing
                }

                else if (root.OWASPZAPReport.site.alerts.alertitem.ToString() == "System.Dynamic.ExpandoObject")
                {
                    VulDetails vul = new VulDetails();
                    vul.PluginName = "Zap";
                    vul.Category = root.OWASPZAPReport.site.alerts.alertitem.alert;
                    vul.Severity = root.OWASPZAPReport.site.alerts.alertitem.riskcode;
                    vul.Reliability = root.OWASPZAPReport.site.alerts.alertitem.reliability;
                    vul.Url = root.OWASPZAPReport.site.alerts.alertitem.uri;
                    vul.Param = root.OWASPZAPReport.site.alerts.alertitem.param;
                    vul.Description = "";   //there is no info
                    vul.CategoryLink = "";  //root.OWASPZAPReport.site.alerts.alertitem[i].reference.p - CANNOT ACCESS!!!

                    //default for blackbox
                    vul.FileName = "";
                    vul.IsSourceCode = "false";
                    vul.LineNumber = "-1";    //format: -1 is have no linenumber
                    vul.Source = "";

                    result.Vuls.VulList.Add(vul);
                }
                else if (root.OWASPZAPReport.site.alerts.alertitem.ToString() == "System.Collections.Generic.List`1[System.Object]")
                {
                    for (int i = 0; i < root.OWASPZAPReport.site.alerts.alertitem.Count; i++)
                    {
                        VulDetails vul = new VulDetails();
                        vul.PluginName = "Zap";
                        vul.Category = root.OWASPZAPReport.site.alerts.alertitem[i].alert;
                        vul.Severity = root.OWASPZAPReport.site.alerts.alertitem[i].riskcode;
                        vul.Reliability = root.OWASPZAPReport.site.alerts.alertitem[i].reliability;
                        vul.Url = root.OWASPZAPReport.site.alerts.alertitem[i].uri;
                        vul.Param = root.OWASPZAPReport.site.alerts.alertitem[i].param;
                        vul.Description = "";   //there is no info
                        vul.CategoryLink = "";  //root.OWASPZAPReport.site.alerts.alertitem[i].reference.p - CANNOT ACCESS!!!

                        //default for blackbox
                        vul.FileName = "";
                        vul.IsSourceCode = "false";
                        vul.LineNumber = "-1";    //format: -1 is have no linenumber
                        vul.Source = "";

                        result.Vuls.VulList.Add(vul);
                    }
                }
            }

            catch (Exception objException)
            {
                Console.WriteLine("Cannot create list of vulnerabilities for Zap !");
                MessageBox.Show("Cannot create list of vulnerabilities for Zap !", "Error");
            }
        }
    }
}
