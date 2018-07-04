using System.Collections.Generic;
using NIPv1.Entities;

namespace NIPv1.BLL_Interfaces
{
    public interface ILogService
    {
        void CountTimesSearched(string id);

        List<LogEntity> GetAllLogs();
    }
}
