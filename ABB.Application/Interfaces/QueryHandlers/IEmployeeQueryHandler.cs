using ABB.Application.Models.v1.Employee;
using MediatR;
using System.Collections.Generic;

namespace ABB.Application.Interfaces.QueryHandlers
{
    public interface IEmployeeQueryHandler :
        IRequestHandler<GetEmployeeByIdRequestModel, GetEmployeeByIdResponseModel>,
        IRequestHandler<GetAllEmployeesRequestModel, List<GetAllEmployeesResponseModel>>
    {
    }
}
