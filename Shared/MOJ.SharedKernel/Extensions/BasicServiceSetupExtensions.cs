using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MOJ.SharedKernel.Extensions;

public static class BasicServiceSetupExtensions
{
    public static WebApplicationBuilder RegisterBasicServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddAuthorization();

        return builder;
    }
}
