using MOJ.SharedKernel.Abstractions.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace MOJ.Application.Features.Employee.GetEmployee;

public static partial class GetEmployee
{
    public sealed record Request : IQuery<Response>
    {
        [FromRoute]
        public Guid Reference { set; get; }
    }
    public sealed record Response
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
    }
}
