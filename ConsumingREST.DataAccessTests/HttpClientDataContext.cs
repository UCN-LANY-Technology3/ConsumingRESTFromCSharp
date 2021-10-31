using ConsumingREST.DataAccess;
using System;
using System.Net.Http;

namespace ConsumingREST.DataAccessTests
{
    class HttpClientDataContext : IDataContext<HttpClient>
    {
        private readonly string _baseAddress = "https://api.dataforsyningen.dk";

        public static IDataContext<HttpClient> Instance => new HttpClientDataContext();

        public HttpClient Open()
        {
            HttpClient client = new();
            client.BaseAddress = new Uri(_baseAddress);
            return client;
        }
    }
}
