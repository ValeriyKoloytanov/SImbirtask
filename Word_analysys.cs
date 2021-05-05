using System;
using System.Collections.Generic;
using HtmlAgilityPack;
namespace ConsoleApp1
{
    public class Word_analysys
    {        public string url { get; }

        public  Word_analysys(string site_url)
        {
            url = site_url;
        }

        public void analyse()
        {
            string text = Get_all_Text();
           var result = Calc(text);
           foreach (var word_and_count in result)
                Console.WriteLine("{0} - {1}", word_and_count.Key, word_and_count.Value);
            
        }
        public string Get_all_Text()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            try
            {
                HtmlDocument document = htmlWeb.Load(url);
                return document.DocumentNode.InnerText;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
                return null;
            }
        }

        Dictionary<string, int> Calc(string text)

        {
            char[] separators = {' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t'};
            var res = new Dictionary<string, int>();
            foreach (var word in text.Split(separators,StringSplitOptions.RemoveEmptyEntries))
                if (!res.ContainsKey(word))
                {
                    res.Add(word, 1);
                }
                else
                {
                    res[word] += 1;
                }
            return res;
        }
    }
}