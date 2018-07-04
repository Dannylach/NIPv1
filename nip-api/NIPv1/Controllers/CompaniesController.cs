using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using NIPv1.BLL_Interfaces;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly INumberService numberService;
        private readonly ILogService logService;
        private readonly ICompanyService companyService;
        private const string nipRegex = @"K|R|S|L|\-|P|\ ";
        private readonly Regex nipReplaceRegex = new Regex(nipRegex);

        public CompaniesController(INumberService numberService, ILogService logService, ICompanyService companyService) 
        {
            this.numberService = numberService;
            this.logService = logService;
            this.companyService = companyService;
        }

        /// <summary>
        /// Searches after the company in database.
        /// </summary>
        /// <param name="id">Number seearched</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Companies/SearchCompany")]
        public ResponseResult<CompanyModel> SearchCompany(string id)
        {
            id = nipReplaceRegex.Replace(id, "");
            var data = numberService.GetById(id);
            if (data != null && data.Id == 0)
            {
                data = numberService.GetById(id);
                return new ResponseResult<CompanyModel>(data);
            }
            logService.CountTimesSearched(id);
            return new ResponseResult<CompanyModel>(data);
        }

        /// <summary>
        /// Gets the logs about times number was searched.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Companies/GetLogs")]
        public ResponseResult<List<LogEntity>> GetLogs()
        {
            return new ResponseResult<List<LogEntity>>(logService.GetAllLogs());
        }

        /// <summary>
        /// Updates the logs about times number was searched.
        /// </summary>
        /// <param name="id">number searched</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Companies/UpdateLogs")]
        public ResponseResult<List<LogEntity>> UpdateLogs(string id)
        {
            id = nipReplaceRegex.Replace(id, "");
            logService.CountTimesSearched(id);
            return new ResponseResult<List<LogEntity>>(logService.GetAllLogs());
        }

        /// <summary>
        /// Adds the new company to database.
        /// </summary>
        /// <param name="data">company data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Companies/AddCompany")]
        public ResponseResult<CompanyModel> AddNewCompany([FromBody] CompanyModel data)
        {
            return new ResponseResult<CompanyModel>(companyService.AddNewCompany(data));
        }

        /// <summary>
        /// Edits the company in database.
        /// </summary>
        /// <param name="data">company data</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/Companies/EditCompany")]
        public ResponseResult<CompanyModel> EditCompany([FromBody] CompanyModel data)
        {
            return new ResponseResult<CompanyModel>(companyService.EditCompany(data));
        }
    }
}
