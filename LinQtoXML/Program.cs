using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MainInquiry
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument _xmlDir = XDocument.Load("counries.xml");
            

            IEnumerable<XElement> countries = from cntr in _xmlDir.Root.Elements("country") select cntr;
            //foreach (XElement item in countries)
            //{
            //    Console.WriteLine("{0}   -    {1}", item.Attribute("name").Value, item.Attribute("population").Value);
            //}


            IEnumerable<XElement> cities = from cntr in _xmlDir.Root.Elements("country").Elements("city")
                                           where cntr.Element("population")!=null && Int32.Parse(cntr.Element("population").Value) > 100000
                                           select cntr;

            foreach(XElement item in cities)
            {
                Console.WriteLine("{0}    -    {1}", item.Element("name").Value, item.Element("population").Value);
            }

            Console.Read();
        }
    }
}
