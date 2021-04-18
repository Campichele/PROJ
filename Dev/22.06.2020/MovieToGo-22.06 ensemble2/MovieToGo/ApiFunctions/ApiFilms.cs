﻿using Microsoft.AspNetCore.Mvc;
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
        //update a film
        //public async Task<IActionResult> UpdateFilmPatch(short Id)
        //{
        //    Film film = new Film();
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync(ConfigureHttpClient.apiUrl + "api/Films/" + Id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            film = JsonConvert.DeserializeObject<Film>(apiResponse);
        //        }
        //    }
        //    return View(film);
        //}

        //internal async Task<Film> UpdateFilmPatch(short Id, Film film)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            RequestUri = new Uri(ConfigureHttpClient.apiUrl + "api/Films/" + Id),
        //            Method = new HttpMethod("Patch"),
        //            Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Name\", \"value\": \"" + reservation.Name + "\"},{ \"op\": \"replace\", \"path\":\"StartLocation\", \"value\": \"" + reservation.StartLocation + "\"}]", Encoding.UTF8, "application/json")
        //        };

        //        var response = await httpClient.SendAsync(request);
        //        var film = response.Content.ReadAsAsync<Film>();
        //    }
        //    return RedirectToAction("Index");
        //}

        ///get all wishlist
        internal static async Task<Wishlist[]> GetWishlistsAsync(HttpClient client, short? id)
        {
            Wishlist[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/Wishlists" + id);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Wishlist[]>();
            }
            return product;
        }

        //ADD WISHLISTS///////////////////////////////////////////////////////
        internal static async Task<Wishlist> AddWishlist(Wishlist wishlist)
        {
            Wishlist responseWish;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(wishlist), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(ConfigureHttpClient.apiUrl + "api/Wishlists", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseWish = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                }
            }
            return responseWish;
        }

        //DELETE Wishlists///////////////////////////////////////////////////////

        [HttpPost]
        internal static async Task<Wishlist> DeleteWishlist(short Id)
        {
            Wishlist apiResponse;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(ConfigureHttpClient.apiUrl + "api/Wishlists/" + Id))
                {
                    apiResponse = await response.Content.ReadAsAsync<Wishlist>();
                }
            }

            return apiResponse;
        }


        //DELETE MOVIES///////////////////////////////////////////////////////

        [HttpPost]
        internal static async Task<Film> DeleteFilm(HttpClient client, short Id)
        {
            Film apiResponse;

                using (var response = await client.DeleteAsync(ConfigureHttpClient.apiUrl + "api/Films/" + Id))
                {
                    apiResponse = await response.Content.ReadAsAsync<Film>();
                }


            return apiResponse;
        }

        //create new film
        internal static async Task<Film> AddFilm(HttpClient client, Film film)
        {
            Film responseFilm;

            StringContent content = new StringContent(JsonConvert.SerializeObject(film), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(ConfigureHttpClient.apiUrl + "api/Films", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseFilm = JsonConvert.DeserializeObject<Film>(apiResponse);
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