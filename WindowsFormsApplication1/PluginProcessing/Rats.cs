using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace VulScanner.PluginProcessing
{
    class Rats
    {
        public static void Run(string cmd, string pathOfFile, Result result)
        {
            cmd = cmd.Replace("%%fileName%%", pathOfFile);

            ExecuteCmd exe = new ExecuteCmd();
            exe.ExecuteCommandSync(cmd);

            ExecuteParsing(exe.ResultOfScanning, pathOfFile, result);

        }

        private static void ExecuteParsing(string originalResult, string pathOfFile, Result result)
        {
            string resultString = originalResult;
            XDocument xml = XDocument.Parse(originalResult);
            foreach (XElement e in xml.Descendants("vulnerability")) {              

                VulDetails vul = new VulDetails();
                vul.PluginName = "Rats";
                vul.FileName = e.Descendants("name").First().Value.ToString();
                vul.LineNumber = Convert.ToInt32(e.Descendants("line").First().Value.ToString()).ToString();
                vul.Category = e.Descendants("type").First().Value.ToString();
                vul.CategoryLink = "#";
                vul.IsSourceCode = "true";
                vul.Severity = convertSeverity(e.Descendants("severity").First().Value.ToString()).ToString();
                vul.Reliability = "";        
                vul.Description = e.Descendants("message").First().Value.ToString();
                string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                vul.Source = fileContents[Convert.ToInt32(e.Descendants("line").First().Value.ToString()) - 1];

                //default for whitebox
                vul.Param = "";
                vul.Url = "";

                result.Vuls.VulList.Add(vul);

            }
        }

        private static int convertSeverity(string seve)
        {
            switch (seve)
            {
                case "High":
                    return 1;
                case "Medium":
                    return 3;
                case "Low":
                    return 5;
                default:
                    return 5;
            }
        }
    }
}
