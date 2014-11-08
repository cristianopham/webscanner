using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace VulScanner.PluginProcessing
{
    class Findbugs
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
            
            foreach (XElement e in xml.Descendants("BugInstance"))
            {
                VulDetails vul = new VulDetails();
                
                vul.PluginName = "FindBugs";
                vul.FileName = xml.Descendants("Project").First().Element("Jar").Value.ToString();
                vul.LineNumber = Convert.ToInt32(e.Descendants("SourceLine").First().Attribute("start").Value.ToString()).ToString();
                vul.Category = e.Attribute("category").Value.ToString();
                vul.CategoryLink = "";
                vul.IsSourceCode = "true";
                vul.Severity = Convert.ToInt32(e.Attribute("priority").Value.ToString()).ToString();
                vul.Reliability = "";               
                vul.Description = e.Descendants("LongMessage").First().Value.ToString();
                string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                vul.Source = fileContents[Convert.ToInt32(e.Descendants("SourceLine").First().Attribute("start").Value.ToString()) - 1];

                //default for whitebox
                vul.Param = "";
                vul.Url = "";

                result.Vuls.VulList.Add(vul);

            }
        }
    }
}
