namespace DapperTest.Core.Dto
{
    public class EmployeeCreate
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public Data.Entities.Employee ToEntity()
        {
            return new Data.Entities.Employee()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate.Value,
            };
        }
    }
}
