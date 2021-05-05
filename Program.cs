using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static async Task  Main(string[] args)
        {  Program program = new Program();
            string  dirPath, url;
            Console.WriteLine("Введите полный url страницы");
             url = Console.ReadLine();
             while (!(Uri.IsWellFormedUriString(url, UriKind.Absolute)))
             {
                 Console.WriteLine("Неверно. Попробуйте еще раз");
                 url = Console.ReadLine();
             }
            Console.WriteLine("Куда сохраняем?");
           dirPath  = @"" + Console.ReadLine();
           while (!(Directory.Exists(dirPath)))
           {
               Console.WriteLine("Неверно. Попробуйте еще раз");
               url = Console.ReadLine();
           }
            program.Start(url,dirPath);

        }
        public void Start(string url,string path)
        {
            HTML_Handler htmlHandler = new HTML_Handler(url,path);
            htmlHandler.DownloadPage();
            Word_analysys wordAnalysys = new Word_analysys(url);
            wordAnalysys.analyse();

        }
    }
}