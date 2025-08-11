using Microsoft.AspNetCore.Builder;

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
}
