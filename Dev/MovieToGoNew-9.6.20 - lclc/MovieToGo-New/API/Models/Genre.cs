using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("GENRE")]
    public partial class Genre
    {
        public Genre()
        {
            FaitPartie = new HashSet<FaitPartie>();
        }

        [Key]
        [Column("ID_GENRE")]
        public short IdGenre { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdGenreNavigation")]
        public virtual ICollection<FaitPartie> FaitPartie { get; set; }
    }
}
