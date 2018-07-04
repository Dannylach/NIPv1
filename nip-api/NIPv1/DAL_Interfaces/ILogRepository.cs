using NIPv1.DAL;
using NIPv1.Entities;

namespace NIPv1.DAL_Interfaces
{
    public interface ILogRepository : IRepository<DataContext>
    {
        LogEntity GetById(string id);
        void AddNumberSearched(string id);
    }
}
