using ConsumingREST.DataAccess;
using RestSharp;

namespace ConsumingREST.DataAccessTests
{
    class RestSharpDataContext : IDataContext<IRestClient>
    {
        private readonly string _baseAddress = "https://api.dataforsyningen.dk";

        public static IDataContext<IRestClient> Instance => new RestSharpDataContext();

        public IRestClient Open()
        {
            return new RestClient(_baseAddress);
        }
    }
}
