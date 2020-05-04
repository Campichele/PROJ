using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class Film
    {
        public Film()
        {
            Commentaire = new HashSet<Commentaire>();
            FaitPartie = new HashSet<FaitPartie>();
            FilmPossede = new HashSet<FilmPossede>();
            Joue = new HashSet<Joue>();
            ListF = new HashSet<ListF>();
            Note = new HashSet<Note>();
            Realise = new HashSet<Realise>();
            Wishlist = new HashSet<Wishlist>();
        }

        public short IdFilm { get; set; }
        public short IdDistributeur { get; set; }
        public short IdSousTitre { get; set; }
        public short IdLangue { get; set; }
        public short IdNationalite { get; set; }
        public string Nom { get; set; }
        public DateTime DateDeSortie { get; set; }
        public string Description { get; set; }
        public short Duree { get; set; }

        public virtual Distributeur IdDistributeurNavigation { get; set; }
        public virtual Langue IdLangueNavigation { get; set; }
        public virtual Nationalite IdNationaliteNavigation { get; set; }
        public virtual SousTitre IdSousTitreNavigation { get; set; }
        public virtual ICollection<Commentaire> Commentaire { get; set; }
        public virtual ICollection<FaitPartie> FaitPartie { get; set; }
        public virtual ICollection<FilmPossede> FilmPossede { get; set; }
        public virtual ICollection<Joue> Joue { get; set; }
        public virtual ICollection<ListF> ListF { get; set; }
        public virtual ICollection<Note> Note { get; set; }
        public virtual ICollection<Realise> Realise { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
