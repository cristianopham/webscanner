using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Xml.Linq;

namespace VulScanner.PluginProcessing
{
    class Cppcheck
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
            XDocument xml = XDocument.Parse(resultString);
            foreach (XElement e in xml.Descendants("error"))
            {
                VulDetails vul = new VulDetails();
                vul.PluginName = "CppCheck";
                vul.FileName = e.Attribute("file").Value.ToString();
                vul.LineNumber = Convert.ToInt32(e.Attribute("line").Value.ToString()).ToString();
                vul.Category = e.Attribute("id").Value.ToString();
                vul.CategoryLink = "";
                vul.IsSourceCode = "true";
                vul.Severity = convertSeverity(e.Attribute("severity").Value.ToString()).ToString();
                vul.Reliability = "";             
                vul.Description = e.Attribute("msg").Value.ToString();
                string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                vul.Source = fileContents[Convert.ToInt32(e.Attribute("line").Value.ToString()) - 1];

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
                case "error":
                    return 1;
                case "warning":
                    return 5;
                case "notice":
                    return 5;
                default:
                    return 5;
            }
        }

    }
}
