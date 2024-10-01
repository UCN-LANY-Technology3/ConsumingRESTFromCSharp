using ConsumingREST.DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ConsumingREST.DataAccess.Daos.Http
{
    class CityDao : BaseDao<HttpClient>, IDao<City>
    {
        public CityDao(IDataContext dataContext) : base(dataContext as IDataContext<HttpClient>)
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
            using HttpClient client = DataContext.Open();

            string resource = "/postnumre";

            HttpResponseMessage response = client.GetAsync(resource).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;
                IEnumerable<City> result = JsonConvert.DeserializeObject<IEnumerable<City>>(responseJson);
                return result;
            }
            return null;
        }

        public IEnumerable<City> Read(Func<City, bool> predicate)
        {
            using HttpClient client = DataContext.Open();

            string resource = "/postnumre";

            HttpResponseMessage response = client.GetAsync(resource).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;
                IEnumerable<City> result = JsonConvert.DeserializeObject<IEnumerable<City>>(responseJson);
                return result.Where(predicate);
            }
            return null;
        }
    }
}
