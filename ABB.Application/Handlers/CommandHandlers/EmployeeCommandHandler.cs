using ABB.Application.Interfaces.CommandHandlers;
using ABB.Application.Models.v1.Employee;
using ABB.Domain.Entities;
using ABB.Domain.Interfaces;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Application.Handlers.CommandHandlers
{
    public class EmployeeCommandHandler : IEmployeeCommandHandler
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<string> Handle(CreateEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            employee.Id = Guid.NewGuid().ToString();
            await _repository.AddEmployee(employee);
            return employee.Id;
        }
        public async Task<DeleteEmployeeResponseModel> Handle(DeleteEmployeeRequestModel request, CancellationToken cancellationToken)
        {
            await _repository.DeleteEmployee(request.Id);
            return default;
        }
    }
}
