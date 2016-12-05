using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockGetterTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvData;
            Console.WriteLine("Please input a symbol");
            string Symbol = Console.ReadLine().ToUpper();
            string URL = "http://finance.yahoo.com/d/quotes.csv?s="+Symbol+"&f=snbaopl1";

            using (WebClient web = new WebClient())
            {
                csvData = web.DownloadString(URL);

            }

            List<Stock> myStocks = YahooFinance.Parse(csvData);

            foreach (Stock Company in myStocks)
            {
                Console.WriteLine(string.Format("{0}",Company.Last));
                //Console.WriteLine(string.Format("{0} ({1})  Bid:{2} Offer:{3} Last:{4} Open: {5} PreviousClose:{6}", Company.Name, Company.Symbol, Company.Bid, Company.Ask, Company.Last, Company.Open, Company.PreviousClose));
            }


        }


        }
    }

