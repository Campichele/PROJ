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
        [Column("ID_DOIT")]
        public short IdDoit { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdDoitNavigation")]
        public virtual ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
