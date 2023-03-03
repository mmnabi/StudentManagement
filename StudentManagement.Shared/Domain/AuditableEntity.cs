namespace StudentManagement.Shared.Domain
{
    public class AuditableEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
