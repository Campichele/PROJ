using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("LANGUE")]
    public partial class Langue
    {
        public Langue()
        {
            Films = new HashSet<Film>();
        }

        [Key]
        [Column("ID_LANGUE")]
        public short IdLangue { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty(nameof(Film.IdLangueNavigation))]
        public virtual ICollection<Film> Films { get; set; }
    }
}
