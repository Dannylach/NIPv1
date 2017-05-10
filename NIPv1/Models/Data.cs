using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIPv1.Models
{
    public class Data
    {
        public int ID { get; set; }
        public string NIP { get; set; }
        public string KRS { get; set; }
        public string REGON { get; set; }
        public string nazwa { get; set; }
        public string ulica { get; set; }
        public int nr_domu { get; set; }
        public string kod_pocztowy { get; set; }
        public string miasto { get; set; }
    }
}