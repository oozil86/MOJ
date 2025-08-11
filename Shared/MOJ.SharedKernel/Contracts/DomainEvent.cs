using MediatR;

namespace MOJ.SharedKernel.Contracts;

public abstract record DomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = Clock.Now;
}
