using MOJ.SharedKernel.Abstractions;

namespace MOJ.SharedKernel.Contracts;

public class Check : ICheckClause
{
    private Check() { }

    public static ICheckClause For { get; } = new Check();
}

