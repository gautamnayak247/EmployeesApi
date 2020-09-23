using ABB.Application.Interfaces.QueryHandlers;
using ABB.Application.Models.v1.Employee;
using ABB.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Application.Handlers.QueryHandlers
{
    public class EmployeeQueryHandler : IEmployeeQueryHandler
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<GetAllEmployeesResponseModel>> Handle(GetAllEmployeesRequestModel request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllEmployees().ConfigureAwait(false);
            var result = _mapper.Map<List<GetAllEmployeesResponseModel>>(employees);
            return result;
        }

        public async Task<GetEmployeeByIdResponseModel> Handle(GetEmployeeByIdRequestModel request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetEmployee(request.Id).ConfigureAwait(false);
            var result = _mapper.Map<GetEmployeeByIdResponseModel>(employees);
            return result;
        }
    }
}