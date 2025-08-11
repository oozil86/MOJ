using Microsoft.AspNetCore.Builder;
using MOJ.SharedKernel.Middlewares;

namespace MOJ.SharedKernel.Extensions;

public static class GeneralMiddlewareSetupExtensions
{
    public static WebApplication RegisterBasicMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
    public static WebApplication RegisterAppMiddleware(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();

        return app;
    }
}
