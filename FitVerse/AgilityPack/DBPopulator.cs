using FitVerse.Model.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityPack
{
    public class DBPopulator
    {
        public DBPopulator()
        {

        }
        public List<ThingToEat> Scrape(string urlToScrape)
        {
            var url = urlToScrape;
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.GetEncoding(1251);
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);
            var xpath = "//table[@class='txt11'][1]/tr";

            var poolHashrate = doc.DocumentNode.SelectNodes(xpath);
            var veggieSwitch = false;
            List<ThingToEat> scraped = new List<ThingToEat>();
            if (poolHashrate != null)
            {
                foreach (var food in poolHashrate)
                {
                    ThingToEat tte = new ThingToEat();
                    
                    var parameters = food.InnerText.Trim().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    /*foreach (var p in parameters)
                    {
                        Console.WriteLine(p);
                    }*/

                    //Console.WriteLine(food.InnerText.Trim());

                    

                    if (parameters[0] != null &&
                        parameters[1] != null &&
                        parameters[2] != null &&
                        parameters[3] != null)
                    {
                        if (checkIfNumber(parameters))
                        {
                            tte.Name = parameters[0];
                            tte.Calories = Double.Parse(parameters[1]);
                            tte.Fat = Double.Parse(parameters[2]);
                            tte.Protein = Double.Parse(parameters[3]);
                            tte.Carbs = Double.Parse(parameters[4]);
                            var nameToLower = tte.Name.ToLower();
                            if (nameToLower.Contains("масло") ||
                                nameToLower.Contains("сланина") ||
                                nameToLower.Contains("сметана"))
                            {
                                continue;
                            }
                            if(nameToLower.Contains("мляко") ||
                                nameToLower.Contains("извара") ||
                                nameToLower.Contains("кашкавал") ||
                                nameToLower.Contains("пармезан") ||
                                nameToLower.Contains("моцарела") ||
                                nameToLower.Contains("сирене") ||
                                nameToLower.Contains("яйце") ||
                                nameToLower.Contains("белтък") ||
                                nameToLower.Contains("жълтък"))
                            {
                                tte.TypeOfFood = TypeOfFood.Dairy;
                            }
                            else if (nameToLower.Contains("агнеш") ||
                                nameToLower.Contains("бекон") ||
                                nameToLower.Contains("език") ||
                                nameToLower.Contains("заешко") ||
                                nameToLower.Contains("луканка") ||
                                nameToLower.Contains("пилеш") ||
                                nameToLower.Contains("свин") ||
                                nameToLower.Contains("сланина") ||
                                nameToLower.Contains("телеш") ||
                                nameToLower.Contains("шунка") ||
                                nameToLower.Contains("шкембе") ||
                                nameToLower.Contains("аншоа") ||
                                nameToLower.Contains("пъстърва") ||
                                nameToLower.Contains("риба") ||
                                nameToLower.StartsWith("ск"))
                            {
                                tte.TypeOfFood = TypeOfFood.Meat;
                            }
                            else if(veggieSwitch == true)
                            {
                                tte.TypeOfFood = TypeOfFood.Vegetable;
                            }
                            if (nameToLower.Equals("авокадо"))
                            {
                                veggieSwitch = true;
                                tte.TypeOfFood = TypeOfFood.Vegetable;
                            }

                            /*var fr = Encoding.GetEncoding("Windows-1251");
                            var b = Encoding.Convert(fr, Encoding.UTF8, Encoding.Unicode.GetBytes(tte.Name));
                            Console.WriteLine(Encoding.UTF8.GetString(b));

                            Console.OutputEncoding = Encoding.UTF8;*/
                            if(tte.TypeOfFood == TypeOfFood.Dairy ||
                                tte.TypeOfFood == TypeOfFood.Fruit ||
                                tte.TypeOfFood == TypeOfFood.Vegetable ||
                                tte.TypeOfFood == TypeOfFood.Meat)
                            scraped.Add(tte);
                            //byte[] bytes = Encoding.Default.GetBytes(tte.Name);
                            //tte.Name = Encoding.UTF8.GetString(bytes);
                            //Console.WriteLine(tte.Name);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(url + " NULL");
            }
            return scraped;
        }

        private bool checkIfNumber(string[] potentialNumbers)
        {
            int i = 0;
            foreach (var stringche in potentialNumbers)
            {
                if (i == 0) { i++; continue; }
                var characters = stringche.Trim().ToLower().ToCharArray();
                foreach (var item in characters)
                {
                    if(item < '0' || item > '9')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
