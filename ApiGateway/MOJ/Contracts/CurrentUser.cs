using MOJ.SharedKernel.Contracts;
using System.Security.Claims;

namespace MOJ.Contracts;

public class CurrentUser : ICurrentUser
{
    public Guid UserReference { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public Guid TenantReference { get; }
    public string LanguageCode { get; set; }
    public bool IsManager { get; set; }
    public bool IsSignedUp { get; set; }

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user is null) return;

        var userReference = user.Claims.FirstOrDefault(c => c.Type.Equals("extension_UserReference", StringComparison.OrdinalIgnoreCase))?.Value;

        if (userReference is not null)
        {
            UserReference = Guid.Parse(userReference);
        }

        FirstName = user.FindFirstValue(ClaimTypes.GivenName);
        LastName = user.FindFirstValue(ClaimTypes.Surname);
        Email = user.Claims.LastOrDefault(c => c.Type.Equals("email"))?.Value;
        var isManager = user.Claims.LastOrDefault(c => c.Type.Equals("IsManager"))?.Value;
        if (isManager is not null)
            IsManager = bool.Parse(isManager);

        var tenantReference = user.Claims.FirstOrDefault(c => c.Type.Equals("extension_TenantReference", StringComparison.OrdinalIgnoreCase))?.Value;
        if (tenantReference is not null)
            TenantReference = Guid.Parse(tenantReference);
    }
}