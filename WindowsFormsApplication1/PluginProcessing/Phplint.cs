using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VulScanner.PluginProcessing
{
    class Phplint
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

            string rule = "";
            string categoryLink = "#";

            result.PluginID = "2";

            string re = @"^(.+):(\d+): ([A-Z][A-Za-z]+): (.+)";
            foreach (string line in lines)
            {
                    Match match = Regex.Match(line, re);
                    if ( match.Success)
                    {
                        string vFileName = match.Groups[1].ToString().Trim();
                        int vLine = Convert.ToInt32(match.Groups[2].ToString());

                        VulDetails vul = new VulDetails();
                        vul.PluginName = "PHPLint";
                        vul.FileName = vFileName;
                        vul.LineNumber = vLine.ToString();
                        vul.Category = "";
                        vul.CategoryLink = "#";
                        vul.IsSourceCode = "true";
                        vul.Severity = convertSeverity(match.Groups[3].ToString()).ToString();
                        vul.Reliability = "";
                        vul.Description = match.Groups[4].ToString().Trim();
                        string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                        //vul.Source = fileContents[vLine - 1]; !!! chỗ này bị lỗi do truy xuất phần tử ngoài phạm vi của mảng (vLine) 

                        //default for whitebox
                        vul.Param = "";
                        vul.Url = "";

                        result.Vuls.VulList.Add(vul);
                }
            }
        }

        private static int convertSeverity(string str)
        {
            str = str.Replace("lint ", "");
            str = str.ToUpper();
            str = str.Trim();
            switch (str)
            {
                case "WARNING":
                    return 1;
                case "SYNTAXERROR":
                    return 3;
                case "CAN'T OPEN FILE":
                    return 5;
                default:
                    return 5;
            }
        }
    }
}
