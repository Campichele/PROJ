using System;
using System.Collections.Generic;

namespace MovieToGo.Models
{
    public partial class Users
    {
        public Users()
        {
            Commentaire = new HashSet<Commentaire>();
            FilmPossede = new HashSet<FilmPossede>();
            List = new HashSet<List>();
            Note = new HashSet<Note>();
            Wishlist = new HashSet<Wishlist>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<FilmPossede> FilmPossede { get; set; }
        public virtual ICollection<List> List { get; set; }
        public virtual ICollection<Note> Note { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
