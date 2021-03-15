using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class Wishlist
    {
        public short IdWishlist { get; set; }
        public short IdFilm { get; set; }
        public short IdUser { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Utilisateur IdUserNavigation { get; set; }
    }
}
