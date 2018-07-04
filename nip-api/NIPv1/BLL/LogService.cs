using System.Collections.Generic;
using System.Linq;
using NIPv1.BLL_Interfaces;
using NIPv1.DAL;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.BLL
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;
        private readonly INumberService numberService;
        private readonly DataContext dataContext;

        public LogService(ILogRepository logRepository, INumberService numberService)
        {
            this.numberService = numberService;
            this.logRepository = logRepository;
            dataContext = new DataContext();
        }

        public void CountTimesSearched(string id)
        {
            var data = numberService.GetById(id);
            if (data != null)
            {
                var log = logRepository.GetById(id);
                if (log != null)
                {
                    log.TimesSearched++;
                }
                else
                {
                    logRepository.AddNumberSearched(id);
                }
                    logRepository.Save();
            }
        }

        public List<LogEntity> GetAllLogs()
        {
                return dataContext.Logs.ToList();
        }
    }
}