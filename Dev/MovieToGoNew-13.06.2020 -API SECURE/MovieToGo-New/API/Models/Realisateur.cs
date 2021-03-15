using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("REALISATEUR")]
    public partial class Realisateur
    {
        public Realisateur()
        {
            Realise = new HashSet<Realise>();
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

        [InverseProperty("IdRealisateurNavigation")]
        public virtual ICollection<Realise> Realise { get; set; }
    }
}
