using ConsumingREST.DataAccess;
using ConsumingREST.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsumingREST.IntegrationTest
{
    [TestClass]
    public class CityIntegrationTests
    {
        [TestMethod]
        public void ShouldGetListOfCities()
        {
            IDao<City> dao = DaoFactory.Create<City>(null);
        }
    }
}
