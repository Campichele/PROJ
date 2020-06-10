using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieToGo.ApiFunctions
{
    public class ConfigureHttpClient
    {
        internal static string apiUrl = "https://movietogoapi.azurewebsites.net/";
        public static HttpClient configureHttpClient(HttpClient client) 
        {
            if (client.BaseAddress != null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
