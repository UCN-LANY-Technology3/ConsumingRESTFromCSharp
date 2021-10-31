using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingREST.DataAccess
{
    public interface IDao<TModel>
    {
        TModel Create(TModel model);

        IEnumerable<TModel> Read();

        IEnumerable<TModel> Read(Func<TModel, bool> predicate);

        bool Update(TModel model);

        bool Delete(TModel model);
    }
}
