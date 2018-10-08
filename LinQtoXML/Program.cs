using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument _xmlDir = XDocument.Load("counries.xml");
            XElement root = _xmlDir.Root;

            #region FIRST
            //Вывод: <название страны>  <количество человек>

            IEnumerable<XElement> countries = from cntr in _xmlDir.Root.Elements("country") select cntr;
            //foreach (XElement item in countries)
            //{
            //    Console.WriteLine("{0}   -    {1}", item.Attribute("name").Value, item.Attribute("population").Value);
            //}
            #endregion

            #region SECOND
            //Вывод: <название города>  <количество человек>

            IEnumerable<XElement> cities = from cntr in _xmlDir.Root.Elements("country").Elements("city")
                                           where cntr.Element("population") != null && Int32.Parse(cntr.Element("population").Value) > 100000
                                           select cntr;
            //foreach (XElement item in cities)
            //{
            //    Console.WriteLine("{0}    -    {1}", item.Element("name").Value, item.Element("population").Value);
            //}
            #endregion

            #region THIRD
            //Вывод: <название континента>  <количество стран на континенте <суммарное количество проживающих>   <суммарная площадь стран>

            var continents = from cntr in _xmlDir.Root.Elements("country")
                             where cntr.Element("encompassed") != null
                             group cntr by cntr.Element("encompassed").Attribute("continent").Value into gr
                             select new
                             {
                                 Name = gr.Key,
                                 Count = gr.Count(),
                                 Population = gr.Sum(n => Decimal.Parse(n.Attribute("population").Value, CultureInfo.InvariantCulture)),
                                 Square = gr.Sum(n => Decimal.Parse(n.Attribute("total_area").Value, CultureInfo.InvariantCulture))
                             };

            //foreach (var cont in continents)
            //{
            //    Console.WriteLine("{0} - {1} - {2} - {3}", cont.Name, cont.Count, cont.Population, cont.Square);
            //}
            #endregion

            #region FOURTH
            //Вывод: <название страны>  <название столицы>

            var capital_prov_out = from cntr in _xmlDir.Root.Elements("country")
                                   join cap in _xmlDir.Root.Elements("country") on cntr.Attribute("capital").Value equals cap.Element("city")?.Attribute("id").Value
                                   where cap.Element("city")?.Element("name")?.Value != null
                                   select new
                                   {
                                       CapName = cap.Element("city").Element("name").Value,
                                       CountryName = cntr.Attribute("name").Value
                                   };
            var capital_prov = from cntr in _xmlDir.Root.Elements("country")
                               join anothercap in _xmlDir.Root.Elements("country") on cntr.Attribute("capital").Value equals anothercap.Element("province")?.Element("city")?.Attribute("id").Value
                               where anothercap.Element("province")?.Element("city")?.Value != null
                               select new
                               {
                                   CapName = anothercap.Element("province").Element("city").Element("name").Value,
                                   CountryName = cntr.Attribute("name").Value
                               };


            //foreach (var item in capital_prov_out)
            //{
            //    Console.WriteLine("Country  {0} {1}", item.CountryName, item.CapName);
            //}
            //foreach (var item in capital_prov)
            //{
            //    Console.WriteLine("Country  {0}{1}", item.CountryName, item.CapName);
            //}
            #endregion
            

            var biggest = from cntr in _xmlDir.Root.Elements("country")
                          join chn in _xmlDir.Root.Elements("country") on cntr.Attribute("id").Value equals chn.Element("border")?.Attribute("country").Value
                          //group cntr by chn.Element("border")?.Attribute("country").Value into gr
                          select new
                          {
                              Name = cntr.Attribute("name").Value,
                              CountriesName = chn.Element("name").Value,
                              Count = chn.Value.Count()
                          };

            Console.WriteLine(biggest.Count());
            int i = 1;
            foreach (var border in biggest)
            {
                Console.WriteLine(i + " {0} - {1} - {2}", border.Name, border.CountriesName, border.Count);
                i++;
            }

            Console.Read();
        }
    }
}
