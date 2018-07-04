using System.ComponentModel.DataAnnotations;

namespace NIPv1.Entities
{
    public class CompanyEntity
    {
        [Key]
        public int Id { get; set; }

        public string Nip { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string Krs { get; set; }

        public string Regon { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Street { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }
        
        public int Rating { get; set; }
    }

}