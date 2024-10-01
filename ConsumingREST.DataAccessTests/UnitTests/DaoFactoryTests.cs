using ConsumingREST.DataAccess;
using ConsumingREST.DataAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;

namespace ConsumingREST.DataAccessTests.UnitTests
{
    [TestClass]
    public class DaoFactoryTests
    {
        [TestMethod]
        public void ShouldCreateCityDao()
        {
            IDataContext<HttpClient> dataContext = Mock.Of<IDataContext<HttpClient>>();

            IDao<City> dao = DaoFactory.Create<City>(dataContext);

            Assert.IsNotNull(dao);
        }
    }
}
