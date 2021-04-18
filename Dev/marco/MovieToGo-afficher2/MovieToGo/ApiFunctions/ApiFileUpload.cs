using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieToGo.ApiFunctions
{
    public class ApiFileUpload
    {
        [HttpPost]
        internal static async void uploadImg(HttpClient client, short id, IFormFile file, string fileType, bool check)
        {
            if (file.Length > 0)
            {
                var fileName = file.FileName;

                if (!check)
                {
                    using (var stream = new MultipartFormDataContent())
                    {
                        stream.Add(new StreamContent(file.OpenReadStream()), "File", fileName);
                        await client.PostAsync(client.BaseAddress + "api/" + fileType + "/" + id, stream);
                    }
                }


            }
        }
    }
}