namespace MOJ.SharedKernel.Exceptions;
public sealed class ConcurrencyException : System.Exception
{
    public ConcurrencyException() { }
    public ConcurrencyException(string message) : base(message) { }
    public ConcurrencyException(string message, System.Exception innerException)
        : base(message, innerException){}
}