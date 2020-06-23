using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BergerSebastien2.Models;

namespace BergerSebastien2.Models
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<FormGeom> FormGeoms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormGeom>()
                .Property(e => e.FormName)
                .IsFixedLength();
        }
    }
}
