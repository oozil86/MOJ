using MOJ.SharedKernel.Contracts;
using System.Runtime.CompilerServices;

namespace MOJ.SharedKernel.Enums;

public class ErrorType : BaseEnum<ErrorType>
{
    public static readonly ErrorType Failure = new(1);
    public static readonly ErrorType NotFound = new(2);
    public static readonly ErrorType Conflict = new(3);
    public static readonly ErrorType Validation = new(4);
    public static readonly ErrorType Problem = new(5);
    public static readonly ErrorType NotAuthorize = new(6);

    private ErrorType(int value, [CallerMemberName] string name = "")
        : base(value, name)
    {
    }
}