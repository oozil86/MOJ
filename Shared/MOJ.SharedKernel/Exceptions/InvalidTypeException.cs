namespace MOJ.SharedKernel.Exceptions;

public class InvalidTypeException : AppException
{
    public InvalidTypeException(string message) : base(message)
    {
    }

    public InvalidTypeException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}