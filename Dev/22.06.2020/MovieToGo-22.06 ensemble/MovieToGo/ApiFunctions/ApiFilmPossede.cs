using Microsoft.AspNetCore.Identity;
using MovieToGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace MovieToGo.ApiFunctions
{
    public class ApiFilmPossede
    {
        internal static async Task<FilmPossede[]> GetFilmPossedeAsync(HttpClient client)
        {
            FilmPossede[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/FilmPossedes");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<FilmPossede[]>();
            }
            return product;
        }

        internal static List<Film> getFilmPossedeFromUser(HttpClient client, string userID)
        {
            var filmPoss = ApiFilmPossede.GetFilmPossedeAsync(client).Result.AsQueryable().Where(f => f.IdUser == userID).ToList();
            List<Film> film = new List<Film>();

            foreach (var item in filmPoss)
            {
                film.Add(ApiFilms.GetFilmAsync(client, item.IdFilm).Result);
            }

            return film;

        }

    }



}
