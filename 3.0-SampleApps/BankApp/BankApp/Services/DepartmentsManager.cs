using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services
{
    public class DepartmentsManager
    {
        private readonly DepartmentRepository departmentRepository;

        public DepartmentsManager(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IList<IDepartment> Departments => this.departmentRepository.GetAll();

        public IDepartment Get(string name) => this.departmentRepository.Get(name);
    }
}
