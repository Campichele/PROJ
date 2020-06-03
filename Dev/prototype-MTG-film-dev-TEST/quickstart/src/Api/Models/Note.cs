using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("NOTE")]
    public partial class Note
    {
        [Key]
        [Column("ID_NOTE")]
        public short IdNote { get; set; }
        [Column("ID_USER")]
        public short IdUser { get; set; }
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Column("NOTE")]
        public byte Note1 { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Notes))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Utilisateur.Notes))]
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
