using MOJ;

internal sealed class Program
{
    internal static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        builder.RegisterServices(configuration);

        var app = builder.Build();

        app.RegisterMiddlewares(configuration);
    }
}