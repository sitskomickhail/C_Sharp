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
            //    Console.WriteLine("{0}   -    {1}", item.Attribute("name").Value.Trim(), item.Attribute("population").Value.Trim());
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
                                       CapName = cap.Element("city").Element("name").Value.Trim(),
                                       CountryName = cntr.Attribute("name").Value.Trim()
                                   };
            var capital_prov = from cntr in _xmlDir.Root.Elements("country")
                               join anothercap in _xmlDir.Root.Elements("country") on cntr.Attribute("capital").Value equals anothercap.Element("province")?.Element("city")?.Attribute("id").Value
                               where anothercap.Element("province")?.Element("city")?.Value != null
                               select new
                               {
                                   CapName = anothercap.Element("province").Element("city").Element("name").Value.Trim(),
                                   CountryName = cntr.Attribute("name").Value.Trim()
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

            #region FIFTH
            //Вывод: <название страны>  <количество граничащих стран> <название стран>.

            var biggest = from cntr in _xmlDir.Root.Elements("country")
                          where cntr.Elements("border").Count() == (from find in _xmlDir.Root.Elements("country") select find.Elements("border").Count()).Max()
                          select new
                          {
                              Name = cntr.Attribute("name").Value,
                              Countries = (from borders in cntr.Elements("border")
                                           join chnm in _xmlDir.Root.Elements("country") on borders.Attribute("country").Value equals chnm.Attribute("id")?.Value
                                           select new
                                           {
                                               Count = cntr.Elements("border").Count(),
                                               BorName = chnm.Attribute("name").Value.Trim()
                                           })
                          };
            
            int i = 0;
            foreach (var border in biggest)
            {
                    Console.WriteLine("{0}", border.Name);
                foreach (var item in border.Countries)
                {
                    if (i < 1) { Console.WriteLine(item.Count); Console.WriteLine(); }
                    Console.WriteLine("{0}", item.BorName);
                    i++;
                }
            }
            #endregion

            Console.Read();
        }
    }
}
