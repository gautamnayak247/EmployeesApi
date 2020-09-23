using MediatR;

namespace ABB.Application.Models.v1.Employee
{
    public class GetEmployeeByIdRequestModel : IRequest<GetEmployeeByIdResponseModel>
    {
        public string Id { get; set; }
    }
    public class GetEmployeeByIdResponseModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
