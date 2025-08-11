namespace MOJ.SharedKernel.Abstractions;

public interface IDateTime
{
    DateTime Now { get; }
    DateOnly NowAsDateOnly { get; }
    DateTime UtcNow { get; }
    DateTime Today { get; }
}
