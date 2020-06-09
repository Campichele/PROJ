using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("ACTEURS")]
    public partial class Acteurs
    {
        public Acteurs()
        {
            Joue = new HashSet<Joue>();
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

        [InverseProperty("IdActeurNavigation")]
        public virtual ICollection<Joue> Joue { get; set; }
    }
}
