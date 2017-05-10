using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NIPv1.DAL;
using NIPv1.Models;
using System.Text.RegularExpressions;

namespace NIPv1.Controllers
{
    public class DataController : Controller
    {
        private DataContext db = new DataContext();
        private const string nipRegex = @"L|\-|P|\ ";

        // GET: Data
        public ViewResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                Regex rgx = new Regex(nipRegex);
                searchString = rgx.Replace(searchString, "");
                var data = db.Datas.Where(s => s.NIP.Equals(searchString)
                                       || s.KRS.Equals(searchString)
                                       || s.REGON.Equals(searchString));

                Stat stat = db.Stats.FirstOrDefault(q => q.NIP.Equals(searchString)
                                       || q.KRS.Equals(searchString)
                                       || q.REGON.Equals(searchString));
                if (stat != null)
                {
                    stat.counter++;
                    db.SaveChanges();
                }
                return View(data.ToList());
            }
            return View();
        }
    }
}
