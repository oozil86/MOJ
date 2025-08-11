using AutoMapper;
using MOJ.Application.Features.Product.CreateProduct;
using MOJ.Domain.Enums;
using MOJ.Domain.ValueObjects;

namespace MOJ.Application.Features.Employee;

internal sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProduct.Request, ProductBasicInfo>()
            .ConvertUsing((src, dest)
                => new ProductBasicInfo(src.UnitPrice, src.ReorderLevel, ProductUnit.FromName(src.ProductUnit)));


        CreateMap<CreateProduct.Request, Domain.Entities.Product>()
            .ConvertUsing((src, dest, ctx) =>
            {
                var productBasicInfo = ctx.Mapper.Map<ProductBasicInfo>(src);
                var employee = new Domain.Entities.Product(src.Name, src.Quantity, src.UnitsInStock, src.UnitsOnOrder, productBasicInfo);
                return employee;
            });

    }
}
