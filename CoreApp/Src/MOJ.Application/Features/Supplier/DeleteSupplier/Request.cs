using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Supplier.DeleteSupplier;

public static partial class DeleteSupplier
{
    public record Request(Guid Reference) : ICommand<Response>;

    public record Response(bool IsDeleted);
}
