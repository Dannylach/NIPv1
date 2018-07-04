using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIPv1.Models
{
    public class LogModel
    {
        public int Id { get; set; }
        
        public string Number { get; set; }
        
        public int TimesSearched { get; set; }
    }
}