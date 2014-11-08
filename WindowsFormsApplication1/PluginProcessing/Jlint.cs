using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VulScanner.PluginProcessing
{
    class Jlint
    {
        public static void Run(string cmd, string pathOfFile, Result result)
        {
            cmd = cmd.Replace("%%fileName%%", pathOfFile);
            //Console.WriteLine(cmd);
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
                string[] matchs = line.Split(':');
                int l = matchs.Length;
                if (l >= 3) {
                    int vLine = 1;  
            
                    VulDetails vul = new VulDetails();
                    vul.PluginName = "Jlint";
                    vul.FileName = matchs[l-3];
                    vul.LineNumber = Convert.ToInt32(matchs[l-2]).ToString();
                    vul.Category = "";
                    vul.CategoryLink = "#";
                    vul.IsSourceCode = "true";
                    vul.Severity = "5";
                    vul.Reliability = "";                
                    vul.Description = matchs[l-1];
                    //vul.Description = "";
                    string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                    vul.Source = fileContents[Convert.ToInt32(matchs[l - 2]) - 1];

                    //default for whitebox
                    vul.Param = "";
                    vul.Url = "";

                    result.Vuls.VulList.Add(vul);

               }
            }
        }
    }
}
