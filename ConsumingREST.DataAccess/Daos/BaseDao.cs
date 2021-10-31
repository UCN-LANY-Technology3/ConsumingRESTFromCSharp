using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccess.Daos
{
    abstract class BaseDao<TConnection> 
    {
        protected IDataContext<TConnection> DataContext { get; }

        public BaseDao(IDataContext<TConnection> dataContext)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}
