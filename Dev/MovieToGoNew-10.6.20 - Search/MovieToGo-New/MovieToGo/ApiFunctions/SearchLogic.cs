using MovieToGo.Models;
using MovieToGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieToGo.ApiFunctions
{
    public class SearchLogic
    {
        static HttpClient client = new HttpClient();
        public SearchLogic()
        {
            client = ConfigureHttpClient.configureHttpClient(client);
        }

        public IQueryable<Film> GetFilms(SearchViewModel searchModel)
        {
            var result = ApiFilms.GetFilmsAsync(client).Result.AsQueryable();
            
            if (searchModel != null)
            {
                if (searchModel.Id.HasValue)
                    result = result.Where(x => x.IdFilm == searchModel.Id);
                if (!string.IsNullOrEmpty(searchModel.Name))
                    result = result.Where(x => x.Nom.Contains(searchModel.Name));
                if (searchModel.PriceFrom.HasValue)
                    result = result.Where(x => x.Prix >= searchModel.PriceFrom);
                if (searchModel.PriceTo.HasValue)
                    result = result.Where(x => x.Prix <= searchModel.PriceTo);
            }
            return result;
        }
    }
}
