using ABB.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABB.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(string id);
        Task AddEmployee(Employee employee);
        Task DeleteEmployee(string id);
    }
}
