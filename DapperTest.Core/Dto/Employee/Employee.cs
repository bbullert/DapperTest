namespace DapperTest.Core.Dto
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateString => BirthDate.ToShortDateString();

        public Data.Entities.Employee ToEntity()
        {
            return new Data.Entities.Employee()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate
            };
        }

        public static Employee FromEntity(Data.Entities.Employee employee)
        {
            return new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate
            };
        }
    }
}
