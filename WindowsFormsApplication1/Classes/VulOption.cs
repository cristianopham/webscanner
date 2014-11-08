using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulScanner.PluginProcessing
{
    class VulOption
    {
        public VulOption(Ini options, int scannerType, string configPath = "")
        {          
            //init object
            this.name = options.GetValue("name", "config");
            this.version = options.GetValue("version", "config");
            this.validType = options.GetValue("validType", "config");
            this.exeCommand = options.GetValue("exeCommand", "config");
            this.description = options.GetValue("description", "config");
            this.author = options.GetValue("author", "config");
            this.licence = options.GetValue("licence", "config");
            this.scannerType = scannerType;
            this.configPath = configPath;
            this.ready = 0;
        }

        //Name of the plugin
        public string name {get; set;}

        //Version of the plugin
        public string version {get; set;}

        //File extention available for scanner. Example: c,cpp,php,java
        public string validType {get; set;}

        //Path to call plugin. Mark %%path%% as path of the file will be scanned
        public string exeCommand {get; set;}

        //Description of plugin
        public string description {get; set;}

        //Author of the plugin
        public string author {get; set;}

        //Licence
        public string licence { get; set; }

        //Blackbox or Whitebox or Both - 1:Blackbox - 2:Whitebox - 3:Both
        public int scannerType { get; set; }

        //ready for scanner - 0:inactive - 1:active
        public int ready { get; set; }

        //path to config file
        public string configPath { get; set; }

        //config file available
        public bool hasConfig { get; set; }

    }
}
