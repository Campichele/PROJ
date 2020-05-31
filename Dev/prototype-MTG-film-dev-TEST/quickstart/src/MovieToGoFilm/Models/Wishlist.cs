using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class Wishlist
    {
        public short IdWishlist { get; set; }
        public short IdFilm { get; set; }
        public string Id { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual AspNetUsers IdNavigation { get; set; }
    }
}
