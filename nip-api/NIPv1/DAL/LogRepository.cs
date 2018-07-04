using System.Data.Entity;
using System.Linq;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;

namespace NIPv1.DAL
{
    public class LogRepository : Repository<DataContext>, ILogRepository
    {
        public DbSet<LogEntity> Logs;
        public LogRepository(DataContext context) : base(context)
        {
            Logs = context.Logs;
        }

        public LogEntity GetById(string id)
        {
            return Logs.FirstOrDefault(checkedData => checkedData.Number.Equals(id));  
        }

        public void AddNumberSearched(string id)
        {
            Logs.Add(new LogEntity { Number = id, TimesSearched = 1 });
        }
    }
}