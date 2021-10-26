using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows;
using WpfDependencyApp.Services;

namespace WpfDependencyApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> logger;
        private readonly IEmployeeRepository employeeRepository;

        public MainWindow(ILogger<MainWindow> logger, IEmployeeRepository employeeRepository)
        {
            this.InitializeComponent();

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
                this.EmployeesDataGrid.ItemsSource = employees;

                this.logger.LogInformation($"Successfully loaded {employees.Count} employees");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Failed to load employees");
                MessageBox.Show("Failed to load employees");
            }
        }
    }
}
