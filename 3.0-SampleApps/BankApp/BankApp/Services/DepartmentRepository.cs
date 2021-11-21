using System.Linq;
using BankApp.Models;

namespace BankApp.Services
{
    public class DepartmentRepository : RepositoryInMemory<IDepartment>
    {
        public DepartmentRepository() : base(TestData.Departments)
        {
        }

        public IDepartment Get(string nameDepartment)
        {
            return this.GetAll().FirstOrDefault(d => d.Name == nameDepartment);
        }

        protected override void Update(IDepartment source, IDepartment destination)
        {
            destination.BankCustomers = source.BankCustomers;
            destination.Id = source.Id;
            destination.Name = source.Name;
        }
    }
}
