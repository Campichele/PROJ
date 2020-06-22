using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class Wishlist
    {
        public short IdWishlist { get; set; }
        public short IdFilm { get; set; }
        public string IdUser { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
