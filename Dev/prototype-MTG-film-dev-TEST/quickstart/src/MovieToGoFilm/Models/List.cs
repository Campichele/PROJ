using System;
using System.Collections.Generic;

namespace MovieToGoFilm.Models
{
    public partial class List
    {
        public List()
        {
            ListF = new HashSet<ListF>();
        }

        public short IdList { get; set; }
        public string Id { get; set; }
        public string Nom { get; set; }

        public virtual AspNetUsers IdNavigation { get; set; }
        public virtual ICollection<ListF> ListF { get; set; }
    }
}
