using AutoMapper;

namespace MOJ.Application.Features.Supplier;

internal sealed class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<CreateSupplier.CreateSupplier.Request, Domain.Entities.Supplier>();
        CreateMap<UpdateSupplier.UpdateSupplier.Request, Domain.Entities.Supplier>()
            .ConvertUsing((src, dest, ctx) =>
        {
            dest.UpdateName(src.Name);
            return dest;
        });

        CreateMap<Domain.Entities.Supplier, UpdateSupplier.UpdateSupplier.Response>();
    }
}