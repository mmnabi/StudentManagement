using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.Domain
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name= "Class")]
        [Range(1, int.MaxValue, ErrorMessage = "The value is invalid.")]
        public int ClassId { get; set; }

        [Required]
        [Display(Name= "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "The value is invalid.")]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        public Class? Class { get; set; }

        public Country? Country { get; set; }
    }
}
