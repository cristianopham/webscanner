using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Dynamic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VulScanner.PluginProcessing
{
    class ClickJacking
    {
        public static void Run(string cmd, Result result)
        {
            //Format of temp file: NameOfPluginReport.xml - (Ex: WapitiReport.xml)
            string tempFile = Directory.GetCurrentDirectory() + "\\Temp\\xml\\ClickJackingReport.xml";

            cmd = cmd.Replace("%%url%%", Form1.UrlTarget).Replace("%%tempFile%%", tempFile);
            //Console.WriteLine(cmd);
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
            StreamReader streamReader = new StreamReader(pathOfXml);
            string cjResult = streamReader.ReadToEnd();
            streamReader.Close();

            //string[] results = cjResult.Split(new string[] { "|||||" }, StringSplitOptions.None);

            //testing
            string[] results = new string[] { "Sunday", "Monday" };
            

            if (results.Count() > 1)
            {
                try
                {

                    VulDetails vul = new VulDetails();
                    vul.PluginName = "ClickJacking";
                    vul.Category = "ClickJacking";
                    vul.Description = results[1];
                    vul.CategoryLink = "";
                    vul.Url = results[0];
                    vul.Param = "";
                    vul.Severity = "";  //not sure !!!
                    vul.Reliability = "";    //there is no info                           

                    //default for blackbox
                    vul.FileName = "";
                    vul.IsSourceCode = "false";
                    vul.LineNumber = "-1";    //format: -1 is have no linenumber
                    vul.Source = "";

                    result.Vuls.VulList.Add(vul);

                }

                catch (Exception objException)
                {
                    Console.WriteLine("Cannot create list of vulnerabilities for ClickJacking");
                    MessageBox.Show("Cannot create list of vulnerabilities for ClickJacking", "Error");
                }
            }

        }
    }
}
