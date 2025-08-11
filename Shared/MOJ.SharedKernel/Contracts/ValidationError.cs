﻿using MOJ.SharedKernel.Enums;

namespace MOJ.SharedKernel.Contracts;

public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors)
        : base(
            "General.Validation",
            "One or more validation errors occurred",
            ErrorType.Validation)
    {
        Errors = errors;
    }
    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => !r.IsSuccess).Select(r => r.Error).ToArray());
}
