namespace MOJ.SharedKernel.Contracts;

public static class SqlQueries
{
    public const string CurrentUtcTimestamp = "GETUTCDATE()";
    public const string ExcludeSoftDeletedRecords = "IsDeleted = 0";
    public const string NewReference = "newid()";
}
