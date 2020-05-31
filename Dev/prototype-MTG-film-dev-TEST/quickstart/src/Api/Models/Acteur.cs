using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("ACTEURS")]
    public partial class Acteur
    {
        public Acteur()
        {
            Joues = new HashSet<Joue>();
        }

        [Key]
        [Column("ID_ACTEUR")]
        public short IdActeur { get; set; }
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }
        [Column("PRENOM")]
        [StringLength(32)]
        public string Prenom { get; set; }

        [InverseProperty(nameof(Joue.IdActeurNavigation))]
        public virtual ICollection<Joue> Joues { get; set; }
    }
}
