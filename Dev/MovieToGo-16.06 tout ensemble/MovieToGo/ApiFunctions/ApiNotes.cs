using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieToGo.Models;

namespace MovieToGo.ApiFunctions
{
    public class ApiNotes
    {
        //get notes by film id?
        internal static async Task<Note[]> GetNoteAsync(HttpClient client, short? id)
        {
            Note[] product = null;
            HttpResponseMessage response = await client.GetAsync("api/Films/" + id);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Note[]>();
            }
            return product;
        }
    }
}
