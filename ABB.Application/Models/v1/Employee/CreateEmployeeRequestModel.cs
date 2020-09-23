using MediatR;

namespace ABB.Application.Models.v1.Employee
{
    public class CreateEmployeeRequestModel : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
