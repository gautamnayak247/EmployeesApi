using MediatR;

namespace ABB.Application.Models.v1.Employee
{
    public class DeleteEmployeeResponseModel { }
    public class DeleteEmployeeRequestModel : IRequest<DeleteEmployeeResponseModel>
    {
        public string Id { get; set; }
    }
}
