using FluentValidation;
using MOJ.Domain.Enums;
using MOJ.SharedKernel.Extensions;
using static MOJ.Application.Features.Product.CreateProduct.CreateProduct;



namespace MOJ.Application.Features.Product.CreateProduct;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .NotNullOrWhiteSpaceString()
            .MaximumLength(250);

        RuleFor(x => x.SupplierReference)
            .NotNull()
            .NotEmpty()
            .WithMessage("SupplierId Should Be Not Empty");

        RuleFor(x => x.UnitsInStock)
            .NotNull()
            .NotEmpty()
            .WithMessage("UnitsInStock Should Be Not Empty");

        RuleFor(x => x.UnitsInStock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("UnitsInStock Should Be Grater Than 0");

        RuleFor(x => x.UnitsOnOrder)
            .NotNull()
            .NotEmpty()
            .WithMessage("UnitsOnOrder Should Be Not Empty");

        RuleFor(x => x.UnitsOnOrder)
            .GreaterThanOrEqualTo(0)
            .WithMessage("UnitsOnOrder Should Be Grater Than 0");

        RuleFor(x => x.UnitPrice)
            .NotNull()
            .NotEmpty()
            .WithMessage("UnitPrice Should Be Not Empty");

        RuleFor(x => x.UnitPrice)
          .GreaterThanOrEqualTo(0)
          .WithMessage("UnitPrice Should Be Grater Than 0");

        RuleFor(x => x.ReorderLevel)
            .NotNull()
            .NotEmpty()
            .WithMessage("ReorderLevel Should Be Not Empty");

        RuleFor(x => x.ReorderLevel)
         .GreaterThanOrEqualTo(0)
         .WithMessage("UnitPrice Should Be Grater Than 0");

        RuleFor(x => x.ProductUnit)
            .NotNull()
            .NotEmpty()
            .WithMessage("ProductUnit Should Be Not Empty");

        RuleFor(x => x.ProductUnit)
           .Must(c => ProductUnit.TryFromName(c, out var result))
           .WithMessage("ProductUnit Is Not Valid");
    }
}