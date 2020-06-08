using MovieToGo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieToGo.ApiFunctions
{
    public class ApiFilms
    {
        //create new film
        internal static async Task<Film> AddFilm(Film film)
        {
            Film responseFilm;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://movietogoapi.azurewebsites.net/api/Films", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseFilm = JsonConvert.DeserializeObject<Film>(apiResponse);
                }
            }
            return responseFilm;
        }
        ///get all film
        internal static async Task<Film[]> GetFilmsAsync(HttpClient client)
        {
            Film[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/Films");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Film[]>();
            }
            return product;
        }
        ///get film by id 
        internal static async Task<Film> GetFilmAsync(HttpClient client, short? id)
        {
            Film product = null;
            HttpResponseMessage response = await client.GetAsync("api/Films/" + id);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Film>();
            }
            return product;
        }
    }
}
