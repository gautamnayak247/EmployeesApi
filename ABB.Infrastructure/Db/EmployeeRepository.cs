using ABB.Domain.Entities;
using ABB.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABB.Infrastructure.Db
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlDbRepository<Employee> _sqlRepo;
        public EmployeeRepository(ISqlDbRepository<Employee> sqlRepo)
            => _sqlRepo = sqlRepo ?? throw new ArgumentNullException(nameof(sqlRepo));

        public async Task AddEmployee(Employee employee)
            => await _sqlRepo.InsertAsync(employee);

        public async Task DeleteEmployee(string id)
        {
            var entity = await GetEmployee(id);
            await _sqlRepo.DeleteAsync(entity);
        }
        public async Task<List<Employee>> GetAllEmployees()
        => await _sqlRepo.GetAll();
        public async Task<Employee> GetEmployee(string id)
            => await _sqlRepo.GetAsync(id);
    }
}
