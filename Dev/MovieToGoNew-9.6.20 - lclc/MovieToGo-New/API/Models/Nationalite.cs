using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("NATIONALITE")]
    public partial class Nationalite
    {
        public Nationalite()
        {
            Film = new HashSet<Film>();
        }

        [Key]
        [Column("ID_NATIONALITE")]
        public short IdNationalite { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [InverseProperty("IdNationaliteNavigation")]
        public virtual ICollection<Film> Film { get; set; }
    }
}
