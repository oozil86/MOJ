using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Employee.DeleteEmployee.DeleteEmployee;

namespace MOJ.Application.Features.Employee.DeleteEmployee;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference).NotEmptyGuid();
    }
}