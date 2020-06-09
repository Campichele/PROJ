using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("SOUS_TITRE")]
    public partial class SousTitre
    {
        public SousTitre()
        {
            Film = new HashSet<Film>();
        }

        [Key]
        [Column("ID_SOUS_TITRE")]
        public short IdSousTitre { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdSousTitreNavigation")]
        public virtual ICollection<Film> Film { get; set; }
    }
}
