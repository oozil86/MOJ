using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Employee.UpdateEmployee.UpdateEmployee;


namespace MOJ.Application.Features.Employee.UpdateEmployee;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference).NotEmptyGuid();
        RuleFor(x => x.FirstName).NotNullOrWhiteSpaceString();
        RuleFor(x => x.LastName).NotNullOrWhiteSpaceString();
        RuleFor(x => x.Email).NotNullOrWhiteSpaceString().IsEmail();
        RuleFor(x => x.Department).NotNullOrWhiteSpaceString();
    }
}