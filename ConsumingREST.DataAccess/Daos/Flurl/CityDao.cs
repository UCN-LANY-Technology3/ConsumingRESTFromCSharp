using ConsumingREST.DataAccess.Entities;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumingREST.DataAccess.Daos.Flurl;

class CityDao : BaseDao<string>, ICityDao
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
    
    public IEnumerable<City> ReadAll()
    {
        IEnumerable<City> cities = "https://api.dataforsyningen.dk"
            .AppendPathSegment("postnumre")
            .GetJsonAsync<IEnumerable<City>>()
            .Result;

        return cities;
    }

    public IEnumerable<City> ReadByPostNummer(string postnr)
    {
        IEnumerable<City> cities = "https://api.dataforsyningen.dk"
            .AppendPathSegment($"postnumre/{postnr}")
            .GetJsonAsync<IEnumerable<City>>()
            .Result;

        return cities;
    }
}
