namespace MOJ.SharedKernel.Exceptions;

public class ExistsException : AppException
{
    public ExistsException(string message) : base(message)
    {

    }

    public ExistsException(string message, System.Exception innerException) : base(message, innerException)
    {

    }
}
