using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.Domain
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
