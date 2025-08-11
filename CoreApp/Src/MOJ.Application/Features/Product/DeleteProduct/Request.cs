using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Product.DeleteProduct;

public static partial class DeleteProduct
{
    public record Request(Guid Reference) : ICommand<Response>;

    public record Response(bool IsDeleted);
}
