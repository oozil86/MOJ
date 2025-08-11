namespace MOJ.SharedKernel.Contracts;

public static class DomainResults
{
    private const string DefaultNotFoundMessage = "The requested resource was not found";

    private const string DefaultDuplicateMessage = "A record with the same details already exists. Please review and try again.";

    public static Result<T> NotFound<T>(
       string? entity = null,
       string? customMessage = null,
       Guid? id = null)
    {
        var message = BuildNotFoundMessage(customMessage, entity, id);

        Error error = Error.NotFound(
            code: "Entity.NotFound",
            description: message);

        return Result.Failure<T>(error);
    }

    public static Result NotFound(
        string? entity = null,
        string? customMessage = null,
        Guid? id = null)
    {
        var message = BuildNotFoundMessage(customMessage, entity, id);

        Error error = Error.NotFound(
            code: "Entity.NotFound",
            description: message);

        return Result.Failure(error);
    }

    public static Result DuplicateFound(
        string? entity = null,
        string? customMessage = null)
    {
        var message = customMessage ?? (entity == null
            ? DefaultDuplicateMessage
            : $"{entity} with the same details already exists");

        var error = Error.Conflict(
            code: "Entity.DuplicateFound",
            description: message);

        return Result.Failure(error);

    }

    public static Result<T> NotAuthorize<T>(
       string customMessage)
    {

        var error = Error.NotAuthorize(
            code: "Not Authorize",
            description: customMessage);

        return Result.Failure<T>(error);

    }

    public static Result<T> DuplicateFound<T>(
       string? entity = null,
       string? customMessage = null)
    {
        var message = customMessage ?? (entity == null
            ? DefaultDuplicateMessage
            : $"{entity} with the same details already exists");

        var error = Error.Conflict(
            code: "Entity.DuplicateFound",
            description: message);

        return Result.Failure<T>(error);
    }

    public static Result<T> Conflict<T>(
        string? entity = null,
        string? customMessage = null,
        Guid? id = null)
    {
        var message = BuildNotFoundMessage(customMessage, entity, id);

        Error error = Error.Problem(
            code: "DbTransaction.Problem",
            description: message);

        return Result.Failure<T>(error);
    }


    private static string BuildNotFoundMessage(
        string? customMessage,
        string? entity,
        Guid? id)
    {
        if (customMessage != null)
            return customMessage;

        if (entity == null)
            return DefaultNotFoundMessage;

        if (id == null)
            return $"{entity} not found.";

        return $"{entity} with ID '{id}' not found.";
    }
}
