using ConsumingREST.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccess.Daos.Sql;

internal class CityDao : BaseDao<IDbConnection>, ICityDao
{


    public CityDao(IDataContext<IDbConnection> dataContext) : base(dataContext)
    {
        
    }

    #region Not implemented
    public City Create(City model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(City model)
    {
        throw new NotImplementedException();
    }
    public bool Update(City model)
    {
        throw new NotImplementedException();
    }
    #endregion

    public IEnumerable<City> ReadAll()
    {
        string sql = "SELECT Zip, Name FROM Cities";

        
        IDbConnection conn = DataContext.Open();

        IDbCommand selectCommand = conn.CreateCommand();
        selectCommand.CommandText = sql;

        IDataReader reader = selectCommand.ExecuteReader();

        while (reader.Read())
        {
            yield return new City() { Navn = reader["Name"].ToString(), Nr = reader["Zip"].ToString() };
        }
    }

    public IEnumerable<City> ReadByPostNummer(string postnr)
    {
        throw new NotImplementedException();
    }    
}