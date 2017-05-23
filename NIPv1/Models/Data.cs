using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NIPv1.Validators;

namespace NIPv1.Models
{
    public class Data
    {
        [Key]
        public int CompanyId { get; set; }
    
        [Nip]
        [StringLength(10, MinimumLength = 10)]
        public string NIP { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string KRS { get; set; }

        [Regon]
        [StringLength(10, MinimumLength = 10)]
        public string REGON { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Street { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required, RegularExpression(@"[0-9][0-9][-][0-9][0-9][0-9]")]
        public string PostalCode { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }
    }

}