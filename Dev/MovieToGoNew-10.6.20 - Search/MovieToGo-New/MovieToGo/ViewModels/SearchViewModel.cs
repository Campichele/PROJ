using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieToGo.ViewModels
{
    public class SearchViewModel
    {
        public int? Id { get; set; }
        public DateTime? DateDeSortie { get; set; }
        public int? Time { get; set; }
        public int? PriceTo { get; set; }
        public int? PriceFrom { get; set; }
        public string Name { get; set; }
    }
}
