namespace DapperTest.Data.Entities
{
    public class EmployeeSearchCriteria : SearchCriteria
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDateFrom { get; set; }
        public DateTime? BirthDateTo { get; set; }
    }
}