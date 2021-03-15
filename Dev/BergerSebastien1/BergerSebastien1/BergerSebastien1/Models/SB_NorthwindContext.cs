using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BergerSebastien1.Models;

namespace BergerSebastien1.Models
{
    public class SB_NorthwindContext : DbContext
    {
        public SB_NorthwindContext (DbContextOptions<SB_NorthwindContext> options)
            : base(options)
        {
        }

        public DbSet<BergerSebastien1.Models.Product> Products { get; set; }
    }
}
