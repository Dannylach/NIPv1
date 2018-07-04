using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using NIPv1.BLL_Interfaces;

namespace NIPv1.Controllers
{
    public class DataController : Controller
    {
        private readonly INumberService numberService;
        private readonly ILogService logService;
        private const string nipRegex = @"K|R|S|L|\-|P|\ ";

        public DataController(INumberService numberService, ILogService logService)
        {
            this.numberService = numberService;
            this.logService = logService;
        }
        
        // GET: Data
        public ViewResult Index(string searchNumber)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(searchNumber))
            {
                Regex nipReplaceRegex = new Regex(nipRegex);
                searchNumber = nipReplaceRegex.Replace(searchNumber, "");
                var data = numberService.GetById(searchNumber);
                if (data != null)
                {
                    logService.CountTimesSearched(searchNumber);
                    return View(data);
                }

                ViewBag.ErrorMessage = "Nie znaleziono w bazie: " + searchNumber;
            }

            return View();
        }

        
    }
}
