using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Supplier.CreateSupplier;

public static partial class CreateSupplier
{
    public sealed record Request : ICommand<Response>
    {
        public string Name { get; set; }
    }
    public sealed record Response(Guid Reference);
}