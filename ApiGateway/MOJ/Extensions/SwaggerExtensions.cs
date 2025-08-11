using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MOJ.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {

        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(type => $"{type.Name}_{Guid.NewGuid()}");
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "MOJ Gateway API",
                    Version = "v1",
                    Description = "Entry points for MOJ Gateway API"
                });

            c.EnableAnnotations();
            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        });
    }

    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOJ Gateway API");
            c.RoutePrefix = "swagger";
        });
    }
}
