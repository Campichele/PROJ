using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("GENRE")]
    public partial class Genre
    {
        public Genre()
        {
            FaitParties = new HashSet<FaitPartie>();
        }

        [Key]
        [Column("ID_GENRE")]
        public short IdGenre { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty(nameof(FaitPartie.IdGenreNavigation))]
        public virtual ICollection<FaitPartie> FaitParties { get; set; }
    }
}
