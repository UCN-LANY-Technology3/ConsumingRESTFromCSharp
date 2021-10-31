using ConsumingREST.Model;
using RestSharp;
using System;
using System.Net.Http;

namespace ConsumingREST.DataAccess
{
    public static class DaoFactory
    {
        public static IDao<TModel> Create<TModel>(IDataContext dataContext)
        {
            if (typeof(IDataContext<HttpClient>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateHttpClientDao<TModel>(dataContext);
            }
            if (typeof(IDataContext<IRestClient>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateRestSharpClientDao<TModel>(dataContext);
            }
            throw new DaoException("DataContext connection not supported");
        }

        private static IDao<TModel> CreateRestSharpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.RestSharp.CityDao(dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }

        private static IDao<TModel> CreateHttpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.Http.CityDao(dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }
    }
}
