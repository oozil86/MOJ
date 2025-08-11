using MOJ.Contracts;
using MOJ.SharedKernel.Contracts;

namespace MOJ.Setups;

internal static class ConfigurationSetup
{
    public static WebApplicationBuilder AddConfigurationSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICurrentUser, CurrentUser>();
        builder.Configuration.Bind(MOJSettings.Instance.CONFIG_NAME, MOJSettings.Instance);
        return builder;
    }
}
