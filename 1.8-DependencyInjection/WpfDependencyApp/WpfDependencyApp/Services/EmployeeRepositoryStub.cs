using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Model;

namespace WpfDependencyApp.Services
{
    public class EmployeeRepositoryStub : IEmployeeRepository
    {
        private readonly ILogger logger;

        public EmployeeRepositoryStub(ILogger<EmployeeRepositoryStub> logger)
        {
            this.logger = logger;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            this.logger.LogInformation("GetEmployeesAsync started...");

            await Task.Delay(2000); // Simulate some loading delay...

            var employees = new List<Employee>
            {
                new Employee {Id = 100, FirstName ="John", LastName = "Doe"},
                new Employee {Id = 101, FirstName ="Nicole", LastName = "Martha"},
                new Employee {Id = 102, FirstName ="Steve", LastName = "Johnson"},
                new Employee {Id = 103, FirstName ="Thomas", LastName = "Bond"},
            };

            this.logger.LogInformation("GetEmployeesAsync finished");
            return employees;
        }
    }
}
