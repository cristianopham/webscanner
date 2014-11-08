using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VulScanner.PluginProcessing
{
    class Yasca
    {

        public static void Run(string cmd, string pathOfFile, Result result)
        {
            string tempFile = Directory.GetCurrentDirectory() + "\\Temp\\csv\\YascaReport.csv";        
            //string tempFile = Directory.GetCurrentDirectory() + "\\Temp\\csv\\YascaReport_";
                                                   
            cmd = cmd.Replace("%%tempFile%%", tempFile).Replace("%%fileName%%", pathOfFile);

            ExecuteCmd exe = new ExecuteCmd();
            exe.ExecuteCommandSync(cmd);
                         
            Convert2ResultObject(DeserializeCSV2Object(tempFile), pathOfFile, result);
            
            
        }

        
        private static YascaDataRecord[] DeserializeCSV2Object(string pathOfCsvFile)
        {
            List<YascaDataRecord> myList = new List<YascaDataRecord>();
            YascaDataRecord tempObj;
            using (var sr = new StreamReader(pathOfCsvFile))
            {
                var reader = new CsvReader(sr);

                //CSVReader will now read the whole file into an enumerable
                IEnumerable<YascaDataRecord> records = reader.GetRecords<YascaDataRecord>();

                int count = 0;
                foreach (YascaDataRecord row in records)
                {
                    tempObj = new YascaDataRecord();
                    tempObj = row;
                    myList.Add(tempObj);
                    count++;
                }

                YascaDataRecord[] YascaObjs = new YascaDataRecord[count];
                int i = 0;
                foreach (YascaDataRecord obj in myList)
                {
                    YascaObjs[i] = obj;
                    i++;
                }

                //Deserialized CSV file to an array of objects successfully !
                //Parse ket qua sang format result và createXML;

                return YascaObjs;
            }
        }

        private static void Convert2ResultObject(YascaDataRecord[] yascaObjs, string pathOfFile, Result result)
        {
            int length = yascaObjs.Length;

            for (int i = 0; i < length; i++)
            {
                VulDetails vul = new VulDetails();
                vul.PluginName = "Yasca";
                vul.FileName = pathOfFile;
                vul.LineNumber = Convert.ToInt32(yascaObjs[i].Location.Remove(0, 1)).ToString();
                vul.Category = yascaObjs[i].Category;
                vul.CategoryLink = "";
                vul.IsSourceCode = "true";
                vul.Severity = Convert2Severity(yascaObjs[i].Severity).ToString();
                vul.Reliability = "";   //there is no info
                vul.Description = "";   //there is no info
                string[] fileContents = System.IO.File.ReadAllLines(pathOfFile);
                vul.Source = fileContents[Convert.ToInt32(yascaObjs[i].Location.Remove(0, 1)) - 1];

                //default for whitebox
                vul.Param = "";
                vul.Url = "";

                result.Vuls.VulList.Add(vul);
            }
        }

        private static int Convert2Severity(string svrStr)
        {
            switch (svrStr)
            {
                case "Critical":
                    return 1;
                case "High":
                    return 2;
                case "Warning":
                    return 3;
                case "Informational":
                    return 4;
                default:
                    return 5;
            }
        }
    }

    class YascaDataRecord
    {
        public string No { set; get; }
        public string Category { set; get; }
        public string PluginName { set; get; }
        public string Severity { set; get; }
        public string Location { set; get; }
        public string FullLocation { set; get; }
        public string Message { set; get; }

    }
}
