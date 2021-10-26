using System.Collections.Generic;
using System.Threading.Tasks;
using WpfDependencyApp.Model;

namespace WpfDependencyApp.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}