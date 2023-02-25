namespace StudentManagement.Shared.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Class Class { get; set; }
        public Country Country { get; set; }
    }
}
