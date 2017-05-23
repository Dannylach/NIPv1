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
        private DataContext db;
        private const string nipRegex = @"L|\-|P|\ ";

        // GET: Data
        public ViewResult Index(string searchNumber)
        {
            db = new DataContext();
            if (!String.IsNullOrEmpty(searchNumber))
            {   
                Regex rgx = new Regex(nipRegex);
                searchNumber = rgx.Replace(searchNumber, "");
                Statistics statistics;

                if (IsValidNIP(searchNumber) || IsValidREGON(searchNumber))
                {
                    statistics = db.Statistics.FirstOrDefault(q => q.Number.Equals(searchNumber));
                }
                else
                {
                    statistics = db.Statistics.FirstOrDefault(q => q.Number.Equals(searchNumber));
                }
                
                if (statistics != null)
                {
                    statistics.TimesSearched++;
                    db.SaveChanges();
                }
                else
                {
                    statistics = new Statistics();
                    statistics.Number = searchNumber;
                    statistics.TimesSearched = 1;
                    db.Statistics.Add(statistics);
                    db.SaveChanges();
                }
                return View((db.Datas.Where(s => s.NIP.Equals(searchNumber)
                                                 || s.KRS.Equals(searchNumber)
                                                 || s.REGON.Equals(searchNumber))).ToList());

            }
            return View(db.Datas);
        }
        public bool IsValidNIP(string input)
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (input.Length == 10)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        public bool IsValidREGON(string input)
        {
            int controlSum;
            if (input.Length == 7 || input.Length == 9)
            {
                int[] weights = { 8, 9, 2, 3, 4, 5, 6, 7 };
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, weights, offset);
            }
            else if (input.Length == 14)
            {
                int[] weights = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                controlSum = CalculateControlSum(input, weights);
            }
            else
            {
                return false;
            }

            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            return controlNum == lastDigit;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}
