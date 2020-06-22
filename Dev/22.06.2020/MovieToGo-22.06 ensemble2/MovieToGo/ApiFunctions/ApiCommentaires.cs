using Microsoft.AspNetCore.Mvc;
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
    public class ApiCommentaires
    {
        //delete a comment
        [HttpPost]
        internal static async Task<Commentaire> DeleteComment(short Id)
        {
            Commentaire apiResponse;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(ConfigureHttpClient.apiUrl + "api/Commentaires/" + Id))
                {
                    apiResponse = await response.Content.ReadAsAsync<Commentaire>();
                }
            }

            return apiResponse;
        }
        //create new Comment
        internal static async Task<Commentaire> AddComment(Commentaire commentaire)
        {
            Commentaire responseCommentaire;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(commentaire), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(ConfigureHttpClient.apiUrl + "api/Commentaires", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseCommentaire = JsonConvert.DeserializeObject<Commentaire>(apiResponse);
                }
            }
            return responseCommentaire;
        }
        //get comment by id
        internal static async Task<Commentaire> GetCommentAsync(HttpClient client, short? id)
        {
            Commentaire product = null;
            HttpResponseMessage response = await client.GetAsync("api/Commentaires/" + id);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Commentaire>();
            }
            return product;
        }

        //get all comments
       internal static async Task<Commentaire[]> GetCommentsAsync(HttpClient client)
        {
            Commentaire[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/Commentaires");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Commentaire[]>();
            }
            return product;
        }
    }
}
