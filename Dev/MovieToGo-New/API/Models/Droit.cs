using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("DROIT")]
    public partial class Droit
    {
        public Droit()
        {
            Utilisateur = new HashSet<Utilisateur>();
        }

        [Key]
        [Column("ID_DROIT")]
        public short IdDroit { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdDroitNavigation")]
        public virtual ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
