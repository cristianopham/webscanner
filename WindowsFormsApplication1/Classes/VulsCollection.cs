using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulScanner.PluginProcessing
{
    class VulsCollection
    {
        //List of black and white plugins
        public List<VulOption> VulsList = new List<VulOption>();

        public VulsCollection(string path)
        {
            CollectPlugins(path);
        }

        private string[] GetSubDirectories(string path)
        {

            string root = @path;

            // Get all subdirectories

            string[] subdirectoryEntries = Directory.GetDirectories(root);

            return subdirectoryEntries;
        }

        private void LoadSubDirs(string dir)
        {

            Console.WriteLine(dir);

            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }

        }

        private void CollectPlugins(string path)
        {
            Ini pluginConfig;
            string[] pluginBlackDirs = GetSubDirectories(path + "BlackBox");        //Plugins\BlackBox
            string[] pluginWhiteDirs = GetSubDirectories(path + "WhiteBox");        //Plugins\WhiteBox
            string cpath;

            for (int i=0; i<pluginWhiteDirs.Length;i+=1)
            {
                cpath = pluginWhiteDirs[i] + "\\config.ini";
                if (!File.Exists(cpath))
                {
                    System.IO.File.Create(cpath).Close();
                }
                if (File.Exists(cpath))
                {
                    pluginConfig = new Ini(cpath);  //load contents of .ini file
                    VulOption pluginInstance = new VulOption(pluginConfig, 2, cpath);
                    if (pluginInstance.name != "" && pluginInstance.exeCommand != "")
                    {
                        pluginInstance.hasConfig = true;
                    }
                    this.VulsList.Add(pluginInstance);
                }
            }

            for (int i = 0; i < pluginBlackDirs.Length; i += 1)
            {
                cpath = pluginBlackDirs[i] + "\\config.ini";
                if (!File.Exists(cpath))
                {
                    System.IO.File.Create(cpath).Close();
                }
                if (File.Exists(cpath))
                {
                    pluginConfig = new Ini(cpath);
                    VulOption pluginInstance2 = new VulOption(pluginConfig, 1, cpath);
                    if (pluginInstance2.name != "" && pluginInstance2.exeCommand != "")
                    {
                        pluginInstance2.hasConfig = true;
                    }
                    this.VulsList.Add(pluginInstance2);
                }
            }

            return;
        }
    }
}
