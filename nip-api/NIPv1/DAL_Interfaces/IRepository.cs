using System.Collections.Generic;
using NIPv1.DAL;

namespace NIPv1.DAL_Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Update(T item);
        void Save();
    }
}
