using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public interface IRepository<T>
    {
        List<T> Listele();

        void Insert(T p);

        void Update(T p);

        void Delete(T p);

        List<T> Listele(Expression<Func<T, bool>> filter);
    }
}
