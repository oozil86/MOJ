using MOJ.Application;
using MOJ.Extensions;
using MOJ.Infrastructure;
using MOJ.Setups;
using MOJ.SharedKernel.Extensions;
using System.Reflection;

namespace MOJ;

internal static class DependencySetup
{
    public static Assembly Assembly => typeof(DependencySetup).Assembly;

    internal static WebApplicationBuilder RegisterServices(
        this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.RegisterBasicServices();

        builder.Services.AddSwaggerConfiguration();

        builder.AddConfigurationSetup();


        builder.Services.RegisterApplicationServices();

        builder.Services.RegisterInfrastructureServices(configuration);

        return builder;
    }

    internal static WebApplication RegisterMiddlewares(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseCustomSwagger();

            app.UseExceptionHandler("/Error");
        }

        app.RegisterBasicMiddleware();

        app.Run();

        return app;
    }
}
