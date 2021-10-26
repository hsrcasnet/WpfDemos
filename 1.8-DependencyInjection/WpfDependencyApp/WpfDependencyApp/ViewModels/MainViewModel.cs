using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.Logging;
using WpfDependencyApp.Model;
using WpfDependencyApp.Services;

namespace WpfDependencyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILogger logger;
        private readonly IEmployeeRepository employeeRepository;
        private ObservableCollection<Employee> employees;

        public MainViewModel(ILogger<MainViewModel> logger, IEmployeeRepository employeeRepository)
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
                this.Employees = new ObservableCollection<Employee>(employees);

                this.logger.LogInformation($"Successfully loaded {employees.Count} employees");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to load employees");
                MessageBox.Show("Failed to load employees");
            }
        }

        public ObservableCollection<Employee> Employees
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
