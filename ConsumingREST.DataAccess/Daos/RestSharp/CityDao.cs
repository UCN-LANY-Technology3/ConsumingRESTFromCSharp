using ConsumingREST.DataAccess.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumingREST.DataAccess.Daos.RestSharp;

class CityDao : BaseDao<IRestClient>, ICityDao
{
    public CityDao(IDataContext dataContext) : base(dataContext as IDataContext<IRestClient>)
    {
    }

    #region Not Implemented

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
        // getting the client from IDataContext
        IRestClient client = DataContext.Open();

        // defining, sending, and parsing GET request
        IRestRequest request = new RestRequest("/postnumre", Method.GET);
        IRestResponse<IEnumerable<City>> response = client.Get<IEnumerable<City>>(request);

        // No need to use json deserialize, since it is built into RestSharp
        return response.Data;
    }

    public IEnumerable<City> ReadByPostNummer(string postnr)
    {
        // getting the client from IDataContext
        IRestClient client = DataContext.Open();

        // defining, sending, and parsing GET request
        IRestRequest request = new RestRequest($"/postnumre/{postnr}", Method.GET);
        IRestResponse<IEnumerable<City>> response = client.Get<IEnumerable<City>>(request);

        // No need to use json deserialize, since it is built into RestSharp
        return response.Data;
    }
}
