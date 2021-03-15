using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("SOUS_TITRE")]
    public partial class SousTitre
    {
        public SousTitre()
        {
            Films = new HashSet<Film>();
        }

        [Key]
        [Column("ID_SOUS_TITRE")]
        public short IdSousTitre { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty(nameof(Film.IdSousTitreNavigation))]
        public virtual ICollection<Film> Films { get; set; }
    }
}
