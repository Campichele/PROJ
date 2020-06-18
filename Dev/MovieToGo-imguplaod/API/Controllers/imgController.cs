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
        private readonly MovieToGoDbContext _context;

        private readonly IWebHostEnvironment _env; //donne le chemien de l'environnement de l'application en cours

        public imgController(MovieToGoDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, IFormFile file)
        {
            string jpg = ".jpg";
            string wwwroot = Path.Combine(_env.WebRootPath, "img");
            string filePath = Path.Combine(wwwroot, id + jpg);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }

            return Ok();
        }
    }
}
