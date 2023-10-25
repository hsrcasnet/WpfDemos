using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Services;

namespace WpfDependencyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILogger logger;
        private readonly IEmployeeRepository employeeRepository;

        private ObservableCollection<EmployeeViewModel> employees;

        public MainViewModel(
            ILogger<MainViewModel> logger,
            IEmployeeRepository employeeRepository)
        {
            this.logger = logger;
            this.employeeRepository = employeeRepository;

            this.DisplayAllEmployees();
        }

        private async void DisplayAllEmployees()
        {
            try
            {
                this.logger.LogInformation("Trying to load employees...");

                var employees = (await this.employeeRepository.GetEmployeesAsync()).ToList();
                var employeeViewModels = employees.Select(e => new EmployeeViewModel(e)).ToList();
                this.Employees = new ObservableCollection<EmployeeViewModel>(employeeViewModels);

                this.logger.LogInformation($"Successfully loaded {employees.Count} employees");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to load employees");
                MessageBox.Show("Failed to load employees");
            }
        }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => this.employees;
            private set
            {
                if (this.employees != value)
                {
                    this.employees = value;
                    this.OnPropertyChanged(nameof(this.Employees));
                }
            }
        }
    }
}
