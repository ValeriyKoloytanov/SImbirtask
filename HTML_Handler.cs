using System.IO;
using System.Net.Http;

namespace ConsoleApp1
{
    public class HTML_Handler
    {        public  string url  { get; }
        public  string save_path  { get; }

        public HTML_Handler(string siteurl,string path)
        {
            url = siteurl;
            save_path = path;
        }

        public void DownloadPage()
        { HttpClient client = new HttpClient();
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    string result = content.ReadAsStringAsync().Result;
                    string path = save_path + "Page.html";
                    File.WriteAllText(path, result);
                }
             

            }
        }
    }
}