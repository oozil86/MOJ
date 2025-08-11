using Microsoft.AspNetCore.Http;
using MOJ.SharedKernel.Contracts;
using System.Text.Json;

namespace MOJ.SharedKernel.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var result = Result.Failure(Error.Problem("Unknown Error", "We Will Fix This Error Soon."));
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(result);
            await context.Response.WriteAsync(json);
        }
    }
}
