using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VulScanner.PluginProcessing
{
    class Pixy
    {
        public static void Run(string cmd, string pathOfFile, Result result)
        {
                           
            cmd = cmd.Replace("%%fileName%%", pathOfFile);

            //Excecute command
            ExecuteCmd exe = new ExecuteCmd();
            exe.ExecuteCommandSync(cmd);
                
            ExecuteParsing(exe.ResultOfScanning, pathOfFile, result);
            
        }

        private static void ExecuteParsing(string originalResult, string pathOfFile, Result result)
        {
            string resultString = originalResult;
            string[] lines = resultString.Split('\n');

            string rule = "";
            string categoryLink = "#";
            foreach (string line in lines)
            {
                if (Regex.IsMatch(line, @"^XSS Analysis BEGIN\r$"))
                {
                    rule = "Cross-Site Scripting";
                    categoryLink = "http://www.owasp.org/index.php/Cross_Site_Scripting";
                    continue;
                }
                else if (Regex.IsMatch(line, @"^SQL Analysis BEGIN\r$"))
                {
                    rule = "SQL Injection";
                    categoryLink = "http://www.owasp.org/index.php/SQL_Injection";
                    continue;
                }
                else if (Regex.IsMatch(line, @"^File Analysis BEGIN\r$"))
                {
                    rule = "File-Related Vulnerability";
                    categoryLink = "#";
                    continue;
                }
                else if (rule == "")
                {
                    continue;
                }

                if (Regex.IsMatch(line, @"^\-\d*(.*?):(\d+)\r$"))
                {
                    MatchCollection mc = Regex.Matches(line, @"^\-\d*(.*?):(\d+)\r$");
                    foreach (Match match in mc) // It iterates 1 times
                    {
                        string vFileName = match.Groups[1].ToString().Trim();
                        int vLine = Convert.ToInt32(match.Groups[2].ToString());

                        VulDetails vul = new VulDetails();
                        vul.PluginName = "Pixy";
                        vul.FileName = vFileName;
                        vul.LineNumber = vLine.ToString();
                        vul.Category = rule;
                        vul.CategoryLink = categoryLink;
                        vul.IsSourceCode = "true";
                        vul.Severity = "5";
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
                //result.PluginID = "1";
                //result.PluginName = "Pixy";
                //result.Site = "";   //default for whitebox  
            }
        }
    }
}
