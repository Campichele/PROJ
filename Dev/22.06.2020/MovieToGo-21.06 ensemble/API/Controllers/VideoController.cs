using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env; //donne le chemien de l'environnement de l'application en cours

        public VideoController( IWebHostEnvironment env)
        {
            _env = env;
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, IFormFile file)
        {
            string extension = ".mp4";
            string wwwroot = Path.Combine(_env.WebRootPath, "video");
            string filePath = Path.Combine(wwwroot, id + extension);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }

            return Ok();
        }
    }
}
