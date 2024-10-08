﻿using ConsumingREST.DataAccess.Entities;
using RestSharp;
using System;
using System.Data;
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
            if (typeof(IDataContext<string>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateFlurlClientDao<TModel>(dataContext);
            }
            if (typeof(IDataContext<IDbConnection>).IsAssignableFrom(dataContext.GetType()))
            {
                return CreateSqlClientDao<TModel>(dataContext);
            }
            throw new DaoException("DataContext connection not supported");
        }

        private static IDao<TModel> CreateSqlClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.Sql.CityDao((IDataContext<IDbConnection>)dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }

        private static IDao<TModel> CreateFlurlClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.Flurl.CityDao((IDataContext<string>)dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }

        private static IDao<TModel> CreateRestSharpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.RestSharp.CityDao((IDataContext<IRestClient>)dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }

        private static IDao<TModel> CreateHttpClientDao<TModel>(IDataContext dataContext)
        {
            return typeof(TModel) switch
            {
                var dao when dao == typeof(City) => new Daos.Http.CityDao((IDataContext<HttpClient>)dataContext) as IDao<TModel>,
                _ => throw new DaoException("Unknown model type")
            };
        }
    }
}
