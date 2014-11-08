using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VulScanner.PluginProcessing
{
    public class Result
    {
        /**
        * ID of the plugin
        * @var string
        */
        [XmlElement("plugin_id")]
        public string PluginID { set; get; }               

        /**
        *  Target for blackbox scanning
        *  @var string
        */
        [XmlElement("site")]
        public string Site { set; get; }

        /**
        *  Set of the vulnerabilities
        *  @var SetOfVuls
        */
        [XmlElement("vuls")]
        public SetOfVuls Vuls = new SetOfVuls();

    }

    public class SetOfVuls
    {
        /**
        *  List of the vulnerabilities
        *  @var VulDetails
        */
        [XmlElement("vul")]
        public List<VulDetails> VulList = new List<VulDetails>();
    }
    
    public class VulDetails
    {   //There is 12 tag elements

        /**
        * Name of the plugin
        * @var string
        */
        [XmlElement("plugin_name")]
        public string PluginName { set; get; }

        /**
        *  Name of the file
        *  @var string
        */
        [XmlElement("file_name")]
        public string FileName { set; get; }

        /**
        * Informational. Default is 5.
        * Must be in the range 1-5, 5 being the least severe.
        * @var int
        */
        [XmlElement("severity")]
        public string Severity { set; get; }

        
        [XmlElement("reliability")]
        public string Reliability { set; get; }

        [XmlElement("url")]
        public string Url { set; get; }

        [XmlElement("param")]
        public string Param { set; get; }

        /**
        * Category of result. Default is "General".
        * @var string
        */
        [XmlElement("category")]
        public string Category { set; get; }

        /**
        * URL pointing to information about the category
        * @var string
        */
        [XmlElement("category_link")]
        public string CategoryLink { set; get; }

        /**
        * Format the message as source code?
        * @var string
        */
        [XmlElement("is_source_code")]
        public string IsSourceCode { set; get; }

        /**
        * Source line or message
        * @var string
        */
        [XmlElement("source")]
        public string Source { set; get; }

        /**
        * Line number within the source file
        * @var string
        */
        [XmlElement("line_number")]
        public string LineNumber { set; get; }
     
        /**
        * Description (long, html) of the item
        * @var string
        */
        [XmlElement("description")]
        public string Description { set; get; }
    }   
}
