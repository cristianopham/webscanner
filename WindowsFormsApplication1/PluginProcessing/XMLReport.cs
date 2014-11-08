using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace VulScanner.PluginProcessing
{
    class XMLReport
    {
        public void CreateXML(Object resultObject, string outputFile)
        {
            string pathOfXMLResultFile = Directory.GetCurrentDirectory() + outputFile;

            // Represents an XML document, Initializes a new instance of the XmlDocument class.
            XmlDocument xmlDoc = new XmlDocument();

            XmlSerializer xmlSerializer = new XmlSerializer(resultObject.GetType());

            // Creates a stream whose backing store is memory. Initializes a new instance of the MemoryStream class with an expandable capacity initialized to zero.
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, resultObject);
                xmlStream.Position = 0;

                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);

                xmlDoc.InnerXml = xmlDoc.InnerXml.Insert(21, "<?xml-stylesheet type=\"text/xsl\" href=\"results.xsl\"?>");

                //Write the result to file .xml
                System.IO.File.WriteAllText(pathOfXMLResultFile, xmlDoc.InnerXml);

                //return xmlDoc.InnerXml;
            }
            
        }
    }
}
