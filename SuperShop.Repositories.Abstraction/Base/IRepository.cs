using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuperShop.Repositories.Abstraction.Base
{
    public interface IRepository<T> where T:class
    {
        bool Add(T customer);
        bool Update(T customer);
        bool Remove(T customer);
        ICollection<T> GetAll();
        T GetFirstorDefault(Expression <Func<T,bool>> predicate);
    }
}
