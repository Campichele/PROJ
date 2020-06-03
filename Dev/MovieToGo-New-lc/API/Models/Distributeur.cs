using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("DISTRIBUTEUR")]
    public partial class Distributeur
    {
        public Distributeur()
        {
            Film = new HashSet<Film>();
        }

        [Key]
        [Column("ID_DISTRIBUTEUR")]
        public short IdDistributeur { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdDistributeurNavigation")]
        public virtual ICollection<Film> Film { get; set; }
    }
}
