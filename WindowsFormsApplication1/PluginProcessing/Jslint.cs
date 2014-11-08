using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace VulScanner.PluginProcessing
{
    class Jslint
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
            string[] lines = resultString.Split('\n');
            
            foreach (string line in lines)
            {
                if (Regex.IsMatch(line, @"^(.*)\((\d+)\): (.*): (.*)\r$"))
                {
                    MatchCollection mc = Regex.Matches(line, @"^(.*)\((\d+)\): (.*): (.*)\r$");
                    foreach (Match match in mc)
                    {
                        
                        string vFileName = match.Groups[1].ToString().Trim();
                        int vLine = Convert.ToInt32(match.Groups[2].ToString());
                        int severity = Convert2Severity(match.Groups[3].ToString());
                        string message = new CultureInfo("en-US").TextInfo.ToTitleCase(match.Groups[4].ToString());

                        if (message == "Missing Semicolon")
                        {
                            vLine--;
                        }

                        VulDetails vul = new VulDetails();
                        vul.PluginName = "Jslint";
                        vul.FileName = vFileName;
                        vul.LineNumber = vLine.ToString();
                        vul.Category = "JavaScript Lint Finding";
                        vul.CategoryLink = "http://www.javascriptlint.com/";
                        vul.IsSourceCode = "false";
                        vul.Severity = severity.ToString();
                        vul.Reliability = "";   //there is no info
                        vul.Description = "";   //there is no info
                        string[] fileContents = System.IO.File.ReadAllLines(vFileName);
                        vul.Source = fileContents[vLine - 1];

                        //default for whitebox
                        vul.Param = "";
                        vul.Url = "";

                        result.Vuls.VulList.Add(vul);    
                        
                    }

                }
            }

            if (result == null) //case: there is no vulnerability
            {
                //result.PluginID = "3";
                //result.PluginName = "JSLint";
                //result.Site = "";   //default for whitebox   
            }           
        }

        private static int Convert2Severity(string svrStr)
        {
            if (svrStr == "")
            {
                return 5;   //Default severity
            }

            string str = svrStr.Replace("lint ", "");
            str = str.Trim().ToUpper();
            switch (str)
            {
                case "SYNTAXERROR":
                    return 1;
                case "WARNING":
                    return 3;                
                case "CAN'T OPEN FILE":
                    return 4;
                default:
                    return 5;
            }                              
        }
    }
}
