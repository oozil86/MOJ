using MOJ.SharedKernel.Abstractions.Messaging;

namespace MOJ.Application.Features.Employee.UpdateEmployee;

public static partial class UpdateEmployee
{
    public sealed record Request : ICommand<Response>
    {
        public Guid Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
    }
    public sealed record Response
    {
        public Guid Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
    }
}