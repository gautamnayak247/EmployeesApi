using ABB.Application.Models.v1.Employee;
using FluentValidation;

namespace ABB.Application.Validators.v1.Employee
{
    public class CreateEmployeeRequestModelValidator : AbstractValidator<CreateEmployeeRequestModel>
    {
        public CreateEmployeeRequestModelValidator()
        {
            //RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3);
            //RuleFor(x => x.LastName).NotEmpty().MinimumLength(3);
            //RuleFor(x => x.Age).NotEmpty();
        }
    }
}
