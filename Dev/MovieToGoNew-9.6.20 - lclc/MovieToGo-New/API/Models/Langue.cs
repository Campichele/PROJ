using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("LANGUE")]
    public partial class Langue
    {
        public Langue()
        {
            Film = new HashSet<Film>();
        }

        [Key]
        [Column("ID_LANGUE")]
        public short IdLangue { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdLangueNavigation")]
        public virtual ICollection<Film> Film { get; set; }
    }
}
