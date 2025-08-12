using MOJ.Contracts;

namespace MOJ.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsConfig(
        this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(MOJConfig.MOJOrigin, builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
        });

        return services;
    }

    public static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors(MOJConfig.MOJOrigin);
        return app;
    }
}
