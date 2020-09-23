using MediatR;
using System.Collections.Generic;

namespace ABB.Application.Models.v1.Employee
{
    public class GetAllEmployeesRequestModel : IRequest<List<GetAllEmployeesResponseModel>>
    {
    }
    public class GetAllEmployeesResponseModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
