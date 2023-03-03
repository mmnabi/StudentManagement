using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentManagement.Shared.Domain
{
    public class Class : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        [MaxLength(255)]
        public string ClassName { get; set; }
    }
}
