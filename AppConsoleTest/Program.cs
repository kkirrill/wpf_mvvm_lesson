using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppConsoleTest
{
    class Program
    {
        private const string url_data = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url_data, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using (var data_stream = GetDataStream().Result)
            {
                using (var data_reader = new StreamReader(data_stream))
                {
                    while (!data_reader.EndOfStream)
                    {
                        var line = data_reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        yield return line;
                    }
                }             
            }        
        }

        private static DateTime[] GetDates() => GetDataLines().First().Split(',').Skip(4).Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture)).ToArray();


        static void Main(string[] args)
        {

            /*var client = new HttpClient();

            var response = client.GetAsync(url_data).Result;
            var csv_str = response.Content.ReadAsStringAsync().Result;
            Console.ReadLine();*/
            var dates = GetDates();
            Console.WriteLine(string.Join("\r\n", dates));
            Console.ReadLine();

        }
    }
}
