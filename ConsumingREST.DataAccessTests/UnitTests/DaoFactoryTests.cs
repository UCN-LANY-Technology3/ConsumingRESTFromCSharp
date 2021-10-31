using ConsumingREST.DataAccess;
using ConsumingREST.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
