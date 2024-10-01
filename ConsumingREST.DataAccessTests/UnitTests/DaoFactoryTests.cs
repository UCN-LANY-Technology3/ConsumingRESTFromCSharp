using ConsumingREST.DataAccess;
using ConsumingREST.DataAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;
using System.Net.Http;

namespace ConsumingREST.DataAccessTests.UnitTests
{
    [TestClass]
    public class DaoFactoryTests
    {
        [TestMethod]
        public void ShouldCreateCityDaoWithHttpClient()
        {
            IDataContext<HttpClient> dataContext = Mock.Of<IDataContext<HttpClient>>();

            IDao<City> dao = DaoFactory.Create<City>(dataContext);

            Assert.IsNotNull(dao);
        }

        [TestMethod]
        public void ShouldCreateCityDaoWithIDbConnection()
        {
            IDataContext<IDbConnection> dataContext = Mock.Of<IDataContext<IDbConnection>>();

            IDao<City> dao = DaoFactory.Create<City>(dataContext);

            Assert.IsNotNull(dao);
        }

    }
}
