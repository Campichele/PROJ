using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("LIST")]
    public partial class List
    {
        public List()
        {
            ListF = new HashSet<ListF>();
        }

        [Key]
        [Column("ID_LIST")]
        public short IdList { get; set; }
        [Column("ID_USER")]
        public short IdUser { get; set; }
        [Required]
        [Column("NOM")]
        [StringLength(32)]
        public string Nom { get; set; }

        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Utilisateur.List))]
        public virtual Utilisateur IdUserNavigation { get; set; }
        [InverseProperty("IdListNavigation")]
        public virtual ICollection<ListF> ListF { get; set; }
    }
}
