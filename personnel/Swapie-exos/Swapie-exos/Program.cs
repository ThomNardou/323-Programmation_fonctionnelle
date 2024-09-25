using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Swapie_exos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string URL = "https://swapi.dev/api/films";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            HttpResponseMessage response = client.GetAsync("").Result;

            Console.WriteLine(ConvertToJSon(response.Content.ReadAsStringAsync().Result));

            Console.ReadLine();
        }

        public static string ConvertToJSon(string value)
        {
            return JsonConvert.DeserializeObject<string>(value);
        }
    }
}
