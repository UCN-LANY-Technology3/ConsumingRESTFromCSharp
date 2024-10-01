using ConsumingREST.DataAccess.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumingREST.DataAccess.Daos.RestSharp
{
    class CityDao : BaseDao<IRestClient>, IDao<City>
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

        public IEnumerable<City> Read()
        {
            // getting the client from IDataContext
            IRestClient client = DataContext.Open();

            // defining, sending, and parsing GET request
            IRestRequest request = new RestRequest("/postnumre", Method.GET);
            IRestResponse<IEnumerable<City>> response = client.Get<IEnumerable<City>>(request);

            // No need to use json deserialize, since it is built into RestSharp
            return response.Data;
        }

        public IEnumerable<City> Read(Func<City, bool> predicate)
        {
            // getting the client from IDataContext
            IRestClient client = DataContext.Open();

            // defining, sending, and parsing GET request
            IRestRequest request = new RestRequest("/postnumre", Method.GET);
            IRestResponse<IEnumerable<City>> response = client.Get<IEnumerable<City>>(request);

            // No need to use json deserialize, since it is built into RestSharp
            return response.Data.Where(predicate);
        }
    }
}
