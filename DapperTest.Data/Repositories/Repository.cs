using Microsoft.Extensions.Configuration;

namespace DapperTest.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration?.GetConnectionString("Default");
    }
}
