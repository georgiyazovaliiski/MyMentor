using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace AgilityPack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var url = "https://news.bg/sport";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var xpath = "//ul[@class='secondary-articles']/li/div/div/h2/a";
            var xpathimages = "//ul[@class='secondary-articles']/li/div/a";
            var poolHashrate = doc.DocumentNode.SelectNodes(xpathimages);
            List<String> scraped = new List<String>();
            if (poolHashrate != null)
            {
                Console.WriteLine(poolHashrate.Count);
                // do stuff with hash
                foreach (var item in poolHashrate)
                {
                    Console.WriteLine(item.Attributes["href"].Value);
                    
                }
            }*/
            string url = "http://spidersport.com/calories.php";
            DBPopulator pop = new DBPopulator();
            pop.Scrape(url);

        }
    }
}
