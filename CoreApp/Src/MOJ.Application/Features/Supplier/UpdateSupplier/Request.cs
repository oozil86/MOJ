using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Supplier.UpdateSupplier;

public static partial class UpdateSupplier
{
    public sealed record Request : ICommand<Response>
    {
        public Guid Reference { get; set; }
        public string Name { get; set; }
    }
    public sealed record Response
    {
        public Guid Reference { get; set; }
    }
}