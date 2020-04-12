using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SuperShop.BLL.Abstraction.Base
{
    public interface IManager<T> where T:class
    {
        bool Add(T customer);
        bool Update(T customer);
        bool Remove(T customer);
        ICollection<T> GetAll();
        T GetFirstorDefault(Expression<Func<T, bool>> predicate);
    }
}
