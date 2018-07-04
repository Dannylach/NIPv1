using System.Web.Mvc;
using NIPv1.BLL_Interfaces;

namespace NIPv1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogService logService;

        public HomeController(ILogService logService)
        {
            this.logService = logService;
        }
        
        /// <summary>
        /// Shows main page of the Api
        /// </summary>
        /// <returns>Retursn View of main page</returns>
        public ActionResult Index()
        {
            return View(logService.GetAllLogs());
        }
    }

}