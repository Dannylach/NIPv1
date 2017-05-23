using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NIPv1.Models
{
    public class Statistics
    {
        [Key]
        public int SearchId { get; set; }
        
        [Required, StringLength(10, MinimumLength = 10)]
        public string Number { get; set; }

        [Required, DefaultValue(0)]
        public int TimesSearched { get; set; }

    }
}