using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("DROIT")]
    public partial class Droit
    {
        public Droit()
        {
            Utilisateurs = new HashSet<Utilisateur>();
        }

        [Key]
        [Column("ID_DOIT")]
        public short IdDoit { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty(nameof(Utilisateur.IdDoitNavigation))]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
