using FluentValidation;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Product.DeleteProduct.DeleteProduct;

namespace MOJ.Application.Features.Employee.DeleteProduct;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Reference).NotEmptyGuid();
    }
}