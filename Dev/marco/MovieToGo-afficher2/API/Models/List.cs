using System;
using System.Collections.Generic;

namespace API.Models
{
    public partial class List
    {
        public List()
        {
            ListF = new HashSet<ListF>();
        }

        public short IdList { get; set; }
        public string IdUser { get; set; }
        public string Nom { get; set; }

        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<ListF> ListF { get; set; }
    }
}
