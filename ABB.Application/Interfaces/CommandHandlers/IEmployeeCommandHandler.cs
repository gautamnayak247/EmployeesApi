using ABB.Application.Models.v1.Employee;
using MediatR;

namespace ABB.Application.Interfaces.CommandHandlers
{
    public interface IEmployeeCommandHandler :
         IRequestHandler<CreateEmployeeRequestModel, string>,
        IRequestHandler<DeleteEmployeeRequestModel, DeleteEmployeeResponseModel>
    {
    }
}
