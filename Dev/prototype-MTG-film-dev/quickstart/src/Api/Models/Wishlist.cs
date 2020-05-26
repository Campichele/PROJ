using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("WISHLIST")]
    public partial class Wishlist
    {
        [Key]
        [Column("ID_WISHLIST")]
        public short IdWishlist { get; set; }
        [Column("ID_FILM")]
        public short IdFilm { get; set; }
        [Column("ID_USER")]
        public short IdUser { get; set; }

        [ForeignKey(nameof(IdFilm))]
        [InverseProperty(nameof(Film.Wishlists))]
        public virtual Film IdFilmNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Utilisateur.Wishlists))]
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
