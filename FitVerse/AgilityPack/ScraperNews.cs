using FitVerse.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityPack
{
    public class ScraperNews
    {
        public ScraperNews()
        {

        }

        public List<NewsDTO> Scrape(string urlToScrape)
        {
            var url = urlToScrape;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var xpath = "//ul[@class='secondary-articles']/li/div/div/h2/a";
            var xpathShortDescriptions = "//ul[@class='secondary-articles']/li/div/div/p[2]";
            var xpathimages = "//ul[@class='secondary-articles']/li/div/a";
            var xpathimagespictures = "//ul[@class='secondary-articles']/li/div/a/img";
            var poolHashrate = doc.DocumentNode.SelectNodes(xpath);
            var poolHashrateShortDescriptions = doc.DocumentNode.SelectNodes(xpathShortDescriptions);
            var poolHashrateForImages = doc.DocumentNode.SelectNodes(xpathimages);
            var poolHashrateForImagesPictures = doc.DocumentNode.SelectNodes(xpathimagespictures);
            List<NewsDTO> scraped = new List<NewsDTO>();
            if (poolHashrate != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    NewsDTO newNews = new NewsDTO();
                    newNews.Header = poolHashrate[i].InnerText;
                    newNews.ShortDescription = poolHashrateShortDescriptions[i].InnerText;
                    newNews.HrefAttribute = poolHashrateForImages[i].Attributes["href"].Value;
                    newNews.PictureAttribute = poolHashrateForImagesPictures[i].Attributes["src"].Value;
                    scraped.Add(newNews);
                }
            }
            return scraped;
        }
    }
}
