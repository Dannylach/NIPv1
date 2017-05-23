using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using NIPv1.DAL;
using NIPv1.Models;

namespace NIPv1.Controllers
{
    public class HomeController : Controller
    {
        private DataContext dataContext;


        public ActionResult Index()
        {
            dataContext = new DataContext();
            return View(dataContext.Statistics);
        }
        
    }

}