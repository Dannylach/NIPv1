using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NIPv1.DAL_Interfaces;

namespace NIPv1.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Context;

        public Repository(DataContext context)
        {
            this.Context = context;
        }

        protected Repository()
        {
            Context = new DataContext();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }
    }
}