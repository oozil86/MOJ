using MOJ.SharedKernel.Data;

namespace MOJ.Contracts;

public class MOJSettings : ApiSettings
{
    public override string CONFIG_NAME { get; } = "ApiSettings";

    public static MOJSettings Instance { get; } = new MOJSettings();
    private MOJSettings() { }
}