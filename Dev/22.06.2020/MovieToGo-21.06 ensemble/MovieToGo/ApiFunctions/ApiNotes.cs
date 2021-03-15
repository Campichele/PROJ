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
        internal static async Task<List<Note>> GetNoteAsync(HttpClient client, short? id)
        {
            List<Note> notes = new List<Note>();
            HttpResponseMessage response = await client.GetAsync("api/Notes/" + id);
            if (response.IsSuccessStatusCode)
            {
                List<Note> res = response.Content.ReadAsAsync<Note[]>().Result.ToList();
                

                foreach (var item in res)
                {
                    if (item.IdFilm == id)
                    {
                        //notes.AsEnumerable().ToList().Add(item);
                        notes.Add(item);
                    }
                }

            }
            return notes;
        }
    }
}
