using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Employee.DeleteEmployee;

public static partial class DeleteEmployee
{
    public record Request(Guid Reference) : ICommand<Response>;

    public record Response(bool IsDeleted);
}
