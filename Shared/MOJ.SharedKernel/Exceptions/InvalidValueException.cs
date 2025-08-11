namespace MOJ.SharedKernel.Exceptions;

public class InvalidValueException : AppException
{
    public InvalidValueException(string message) : base(message)
    {
    }

    public InvalidValueException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}

