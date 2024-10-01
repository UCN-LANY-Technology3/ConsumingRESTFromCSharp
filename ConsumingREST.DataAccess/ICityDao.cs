using ConsumingREST.DataAccess;
using ConsumingREST.DataAccess.Entities;
using System.Collections.Generic;

namespace ConsumingREST.DataAccess;

public interface ICityDao : IDao<City>
{
    IEnumerable<City> ReadByPostNummer(string postnr);

}