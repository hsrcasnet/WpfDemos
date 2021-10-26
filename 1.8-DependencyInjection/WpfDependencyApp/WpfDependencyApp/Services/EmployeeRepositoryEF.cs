using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfDependencyApp.Model;

namespace WpfDependencyApp.Services
{
    public class EmployeeRepositoryEF : IEmployeeRepository
    {
        private readonly ILogger logger;

        public EmployeeRepositoryEF(ILogger<EmployeeRepositoryEF> logger)
        {
            this.logger = logger;
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            throw new NotImplementedException("EF Core implementation not implemented yet");
        }
    }
}
