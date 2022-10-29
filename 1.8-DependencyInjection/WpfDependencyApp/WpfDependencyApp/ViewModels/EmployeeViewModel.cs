using WpfDependencyApp.Model;

namespace WpfDependencyApp.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(Employee employee)
        {
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
        }

        public string FirstName { get; }

        public string LastName { get; }
    }
}