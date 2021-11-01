using ConsumingREST.Model;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccess.Daos.Flurl
{
    class CityDao : BaseDao<string>, IDao<City>
    {
        public CityDao(IDataContext dataContext) : base(dataContext as IDataContext<string>)
        {
        }

        #region Not implemented

        public City Create(City model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(City model)
        {
            throw new NotImplementedException();
        }

        public bool Update(City model)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        public IEnumerable<City> Read()
        {
            IEnumerable<City> cities = "https://api.dataforsyningen.dk"
                .AppendPathSegment("postnumre")
                .GetJsonAsync<IEnumerable<City>>()
                .Result;

            return cities;
        }

        public IEnumerable<City> Read(Func<City, bool> predicate)
        {
            IEnumerable<City> cities = "https://api.dataforsyningen.dk"
                .AppendPathSegment("postnumre")
                .GetJsonAsync<IEnumerable<City>>()
                .Result;

            return cities.Where(predicate);
        }
    }
}
