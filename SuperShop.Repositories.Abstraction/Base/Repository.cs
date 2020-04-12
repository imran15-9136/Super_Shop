﻿using Microsoft.EntityFrameworkCore;
using SuperShop.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SuperShop.Repositories.Abstraction.Base
{
    public abstract class Repository<T> where T:class
    {
        DbContext _db;
        public Repository(DbContext db)
        {
            _db = db;
        }
        public virtual bool Add(T entity)
        {
             _db.Set<T>().Add(entity);
            return _db.SaveChanges() > 0;
        }
        public virtual bool Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }
        public virtual bool Remove(T entity)
        {
            if(entity is IDelatable)
            {
                ((IDelatable)entity).Delete();
                return Update(entity);
            }
            _db.Set<T>().Remove(entity);
            return _db.SaveChanges() > 0;
        }
        public virtual ICollection<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
        public virtual T GetFirstorDefault (Expression <Func<T, bool>> predicate)
        {
            return _db.Set<T>().FirstOrDefault(predicate);
        }
    }
}
