using AutoMapper;
using MOJ.Application.Features.Product.CreateProduct;
using MOJ.Application.Features.Product.UpdateProduct;
using MOJ.Application.Features.Product.GetProducts;
using MOJ.Domain.Enums;
using MOJ.Domain.ValueObjects;
using MOJ.Domain.DTOs.Supplier;

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

        CreateMap<UpdateProduct.Request, ProductBasicInfo>()
           .ConvertUsing((src, dest, ctx) =>
               {
                   dest.UpdateProductUnit(ProductUnit.FromName(src.ProductUnit));
                   dest.UpdateUnitPrice(src.UnitPrice);
                   dest.UpdateReorderLevel(src.ReorderLevel);
                   return dest;
               });

        CreateMap<UpdateProduct.Request, Domain.Entities.Product>()
            .ConvertUsing((src, dest, ctx) =>
            {
                var productBasicInfo = ctx.Mapper.Map(src, dest.ProductBasicInfo);
                dest.UpdateName(src.Name);
                dest.UpdateQuantity(src.Quantity);
                dest.UpdateUnitsInStock(src.UnitsInStock);
                dest.UpdateUnitsOnOrder(src.UnitsOnOrder);
                dest.UpdateBasicInfo(productBasicInfo);
                return dest;
            });

        CreateMap<Domain.Entities.Product, UpdateProduct.Response>();

        CreateMap<Domain.Entities.Product, ProductDto>()
            .ForMember(x => x.SupplierReference, opt => opt.MapFrom(src => src.Supplier.Reference))
            .ForMember(x => x.UnitPrice, opt => opt.MapFrom(src => src.ProductBasicInfo.UnitPrice))
            .ForMember(x => x.ReorderLevel, opt => opt.MapFrom(src => src.ProductBasicInfo.ReorderLevel))
            .ForMember(x => x.ProductUnit, opt => opt.MapFrom(src => src.ProductBasicInfo.ProductUnit.Name));

        CreateMap<List<ProductDto>, GetProducts.Response>()
            .ConvertUsing((src, dest, ctx) =>
            {             
                return new GetProducts.Response { Products = src };
            });

    }
}
