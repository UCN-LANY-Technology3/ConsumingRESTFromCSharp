using ConsumingREST.DataAccess;
using ConsumingREST.DataAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ConsumingREST.DataAccessTests
{

    [TestClass]
    public class CityIntegrationTests
    {
        IDao<City> _dao;

        [TestInitialize]
        public void Init()
        {
            _dao = DaoFactory.Create<City>(SqlMemoryDataContext.Instance);
        }

        [TestMethod]
        public void ShouldGetListOfCities()
        {
            IEnumerable<City> cities = _dao.ReadAll();

            Assert.IsNotNull(cities);
            Assert.IsTrue(cities.Any(c => c.Nr == "9000"));
        }

        [TestMethod]
        public void ShouldGetListOfCitiesWithPostalCodeStartsWithNine()
        {
            IEnumerable<City> cities = _dao.ReadAll().Where(c => c.Nr.StartsWith("9"));

            Assert.IsNotNull(cities);
            Assert.IsTrue(cities.Any(c => c.Nr == "9000"));
            Assert.IsTrue(cities.All(c => c.Nr.StartsWith("9")));
        }
    }
}
