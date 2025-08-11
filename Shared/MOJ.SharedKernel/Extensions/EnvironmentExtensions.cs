using Microsoft.Extensions.Hosting;

namespace MOJ.SharedKernel.Extensions;

public static class EnvironmentExtensions
{
    public static readonly string Testing = nameof(Testing);

    public static bool IsTesting(this IHostEnvironment hostEnvironment)
    {
        return hostEnvironment.EnvironmentName.Equals(Testing);
    }
}
