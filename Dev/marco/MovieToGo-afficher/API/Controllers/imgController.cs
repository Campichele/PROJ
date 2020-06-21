using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imgController : ControllerBase
    {

        private readonly IWebHostEnvironment _env; //donne le chemien de l'environnement de l'application en cours
        string extension = ".jpg";

        public imgController( IWebHostEnvironment env)
        {
            _env = env;
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, IFormFile file)
        {
            string root = Path.Combine(_env.WebRootPath, "img");

            string filePath = Path.Combine(root, id + extension);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }

            return Ok();
        }

        //[HttpPost("{id}")]
        //public void DeleteFile(string id)
        //{

        //    string root = Path.Combine(_env.WebRootPath, "img");
        //    string filePath = Path.Combine(root, id + extension);
        //    System.IO.File.Delete(filePath);

        //}

    }
}
