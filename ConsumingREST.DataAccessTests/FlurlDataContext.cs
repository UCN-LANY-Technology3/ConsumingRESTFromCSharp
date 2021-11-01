using ConsumingREST.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccessTests
{
    class FlurlDataContext : IDataContext<string>
    {
        private readonly string _baseAddress = "https://api.dataforsyningen.dk";

        public static IDataContext<string> Instance => new FlurlDataContext();

        public string Open()
        {
            return _baseAddress;
        }
    }
}
