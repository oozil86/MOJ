namespace MOJ.SharedKernel.Data;

public abstract class ApiSettings
{
    public abstract string CONFIG_NAME { get; }

    public virtual string IdentityProvider { get; set; } = default!;
}
