using System;
using System.Collections.Generic;

namespace MovieToGoAPI.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Commentaire = new HashSet<Commentaire>();
            FilmPossede = new HashSet<FilmPossede>();
            List = new HashSet<List>();
            Note = new HashSet<Note>();
            Wishlist = new HashSet<Wishlist>();
        }

        public short IdUser { get; set; }
        public short IdDoit { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Statut { get; set; }
        public string Pseudo { get; set; }

        public virtual Droit IdDoitNavigation { get; set; }
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<FilmPossede> FilmPossede { get; set; }
        public virtual ICollection<List> List { get; set; }
        public virtual ICollection<Note> Note { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
