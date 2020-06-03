using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class MovieToGoContext : DbContext
    {
        public MovieToGoContext (DbContextOptions<MovieToGoContext> options)
            : base(options)
        {
        }

        public DbSet<Api.Models.Movie> Movie { get; set; }
    }
}
