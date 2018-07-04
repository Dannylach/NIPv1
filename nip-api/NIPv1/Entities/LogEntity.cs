using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NIPv1.Entities
{
    public class LogEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required, StringLength(14, MinimumLength = 7)]
        public string Number { get; set; }

        [Required, DefaultValue(0)]
        public int TimesSearched { get; set; }

    }
}