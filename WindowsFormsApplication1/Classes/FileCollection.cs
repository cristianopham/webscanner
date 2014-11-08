using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulScanner.PluginProcessing
{
    class FileCollection
    {
        public List<string> FileList = new List<string>();

        public FileCollection(string dirPath, string ext)
        {
            string[] paths = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);

            string[] allowExts = ext.Split(',');

            foreach (string path in paths)
            {
                FileInfo info = new FileInfo(path);
                string ttt = info.Extension.ToLower();

                if (Array.Exists(allowExts, element => element == info.Extension.ToLower().Trim(new Char[] { '.' })))
                {
                    FileList.Add(path);
                }
            }

            allowExts = ext.Split(',');
        }
    }
}
