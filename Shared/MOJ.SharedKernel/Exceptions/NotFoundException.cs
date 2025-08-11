namespace MOJ.SharedKernel.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message)
    {

    }
    public NotFoundException(string message, System.Exception innerException) : base(message, innerException)
    {

    }

    public NotFoundException(string key, string objectName)
        : base($"The queried object {objectName} was not found, Key: {key}")
    {
    }
    public NotFoundException(Guid key1, Guid key2, string objectName)
        : base($"The queried object {objectName} was not found, Keys: {key1}, {key2}")
    {
    }
    public NotFoundException(string key, string objectName, System.Exception innerException)
        : base($"The queried object {objectName} was not found, Key: {key}", innerException)
    {
    }
}