using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("REALISATEUR")]
    public partial class Realisateur
    {
        public Realisateur()
        {
            Realises = new HashSet<Realise>();
        }

        [Key]
        [Column("ID_REALISATEUR")]
        public short IdRealisateur { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }
        [Required]
        [Column("PRENOM")]
        [StringLength(32)]
        public string Prenom { get; set; }

        [InverseProperty(nameof(Realise.IdRealisateurNavigation))]
        public virtual ICollection<Realise> Realises { get; set; }
    }
}
