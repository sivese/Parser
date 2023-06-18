using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChecker.Parser
{
    public class XmlReader
    {
        enum State
        {
            Header,
            Body
        }

        /*
                Xml Document Rule
        
            1. Every XML element must have closing tag
            2. XML tags are case sensitive
            3. XML elements must be properly paired well
            4. All XML document must have a root element
            5. Attiribute values must have quotes
        */
        public static bool DetermineXml(string xml)
        {
            Console.WriteLine(xml);
            return false;
        }

        public static bool DetermineXmlFromFile(string path) => DetermineXml(File.ReadAllText(path));
    }
}
