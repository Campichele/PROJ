using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BergerSebastien2.Models
{
    

    [Table("FormGeom")]
    public partial class FormGeom
    {
        [Key]
        public int IDForm { get; set; }

        [Required]
        [StringLength(20)]
        public string FormName { get; set; }

        public double Dim1 { get; set; }

        public double? Dim2 { get; set; }

        public virtual double calculateSurface()
        {
            double result = 0;

            if(Dim2 is double)
            {
                result += Dim1 * (double)Dim2;
            }

            return result;
        }
    }
}
