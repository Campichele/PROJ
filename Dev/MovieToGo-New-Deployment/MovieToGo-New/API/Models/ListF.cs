using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("LIST_F")]
    public partial class ListF
    {
        [Key]
        [Column("ID_LIST_F")]
        public short IdListF { get; set; }
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Column("ID_LIST")]
        public short IdList { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.ListF))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdList))]
        [InverseProperty(nameof(List.ListF))]
        public virtual List IdListNavigation { get; set; }
    }
}
