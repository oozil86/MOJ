using MOJ.SharedKernel.Abstractions;
using MOJ.SharedKernel.Contracts;
using MOJ.SharedKernel.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace MOJ.SharedKernel.Extensions;

public static class CheckExtensions
{
    public static T NullWithMessage<T>(this ICheckClause checkClause, [NotNull] T? input, string message)
    {
        if (input is null)
        {
            throw new ArgumentNullException(message, (System.Exception?)null);
        }

        return input;
    }

    public static T Null<T>(this ICheckClause checkClause, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        return checkClause.NullWithMessage(input, $"Required input {parameterName} was null.");
    }

    public static T Null<T>(this ICheckClause checkClause, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null) where T : struct
    {
        if (input is null)
        {
            throw new ArgumentNullException(parameterName, $"Required input {parameterName} was null.");
        }

        return input.Value;
    }

    public static string NullOrEmpty(this ICheckClause checkClause, [NotNull] string? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input == string.Empty)
        {
            throw new ArgumentException($"Required input {parameterName} was empty.", parameterName);
        }

        return input;
    }

    public static IEnumerable<T> NullOrEmpty<T>(this ICheckClause checkClause, [NotNull] IEnumerable<T>? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (!input.Any())
        {
            throw new ArgumentException($"Required input {parameterName} was empty.", parameterName);
        }

        return input;
    }

    public static Guid NullOrEmpty(this ICheckClause checkClause, [NotNull] Guid? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        checkClause.Empty(input.Value, parameterName);

        return input.Value;
    }

    public static Guid Empty(this ICheckClause checkClause, Guid input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input == Guid.Empty)
        {
            throw new ArgumentException($"Required input {parameterName} was empty.", parameterName);
        }

        return input;
    }
    public static Guid? Empty(this ICheckClause checkClause, Guid? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input is not null)
        {
            checkClause.Empty(input.Value, parameterName);
        }

        return input;
    }

    public static string NullOrWhiteSpace(this ICheckClause checkClause, [NotNull] string? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"Required input {parameterName} was empty or white space.", parameterName);
        }

        return input;
    }

    public static decimal DecimalLessThanOrEqualToZero(this ICheckClause checkClause, decimal input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input <= 0.0M)
        {
            throw new ArgumentException($"Required input {parameterName} was zero or less than zero.", parameterName);
        }

        return input;
    }

    public static decimal DecimalLessThanZero(this ICheckClause checkClause, decimal input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input < 0.0M)
        {
            throw new ArgumentException($"Required input {parameterName} was less than zero.", parameterName);
        }

        return input;
    }

    public static int IntLessThanZero(this ICheckClause checkClause, int input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input < 0)
        {
            throw new ArgumentException($"Required input {parameterName} was less than zero.", parameterName);
        }

        return input;
    }

    public static decimal DecimalGreaterThanLimit(this ICheckClause checkClause, decimal input, decimal limit, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input > limit)
        {
            throw new ArgumentException($"Required input {parameterName} was greater than limit of {limit}.", parameterName);
        }

        return input;
    }

    public static int IntGreaterThanLimit(this ICheckClause checkClause, int input, int limit, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input > limit)
        {
            throw new ArgumentException($"Required input {parameterName} was greater than limit of {limit}.", parameterName);
        }

        return input;
    }

    public static T NotFound<T>(this ICheckClause checkClause, string? key, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.NullOrEmpty(key);

        if (input is null)
        {
            throw new NotFoundException(key, parameterName ?? string.Empty);
        }

        return input;
    }

    public static T NotFound<T>(this ICheckClause checkClause, Guid? key1, Guid? key2, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.NullOrEmpty(key1);
        checkClause.NullOrEmpty(key2);

        if (input is null)
        {
            throw new NotFoundException(key1.Value, key2.Value, parameterName ?? string.Empty);
        }

        return input;
    }

    public static T NotFound<TKey, T>(this ICheckClause checkClause, TKey key, [NotNull] T? input, [CallerArgumentExpression("input")] string? parameterName = null) where TKey : struct
    {
        if (input is null)
        {
            throw new NotFoundException(key.ToString() ?? string.Empty, parameterName ?? string.Empty);
        }

        return input;
    }

    public static List<T> NotFound<T>(this ICheckClause checkClause, [NotNull] List<T>? input)
    {
        if (input is null || input.Count == 0)
        {
            throw new NotFoundException($"At least one {typeof(T).Name} doesn't exist.");
        }

        return input;
    }

    public static int UpperLimit(this ICheckClause checkClause, [NotNull] int? input, int upperLimit, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input.Value > upperLimit)
        {
            throw new InvalidValueException($"{parameterName} must be less than or equal to {upperLimit}");
        }

        return input.Value;
    }

    public static int LessThanOrEqualToZero(this ICheckClause checkClause, [NotNull] int? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input.Value <= 0)
        {
            throw new InvalidValueException($"{parameterName} must be greater than 0");
        }

        return input.Value;
    }

    public static int Negative(this ICheckClause checkClause, [NotNull] int? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input.Value < 0)
        {
            throw new InvalidValueException($"{parameterName} cannot be negative");
        }

        return input.Value;
    }

    public static void InFuture(this ICheckClause checkClause, DateTime? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input is not null && input.Value > Clock.Now.AddDays(1))
        {
            throw new InvalidValueException($"{parameterName} must not be in the future (accounting for timezones)");
        }
    }

    public static void InPast(this ICheckClause checkClause, [NotNull] DateTime? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input.Value < Clock.Today.AddDays(-1))
        {
            throw new InvalidValueException($"{parameterName} must not be in the past (accounting for timezones)");
        }
    }

    public static void InPastAllowNulls(this ICheckClause checkClause, DateTime? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input is not null && input.Value < Clock.Today.AddDays(-1))
            throw new InvalidValueException($"{parameterName} must not be in the past (accounting for timezones)");
    }

    public static void DatesInAscendingOrder(this ICheckClause checkClause, DateTime earlierDateTime, DateTime laterDateTime,
        [CallerArgumentExpression("earlierDateTime")] string? earlierName = null, [CallerArgumentExpression("laterDateTime")] string? laterName = null)
    {
        if (laterDateTime < earlierDateTime)
        {
            throw new InvalidValueException($"{laterName} must be after {earlierName}");
        }
    }

    public static void DatesInAscendingOrder(this ICheckClause checkClause, DateTime? earlierDateTime, DateTime? laterDateTime,
        [CallerArgumentExpression("earlierDateTime")] string? earlierName = null, [CallerArgumentExpression("laterDateTime")] string? laterName = null)
    {
        if (earlierDateTime is null || laterDateTime is null)
            return;

        checkClause.DatesInAscendingOrder(earlierDateTime.Value, laterDateTime.Value, earlierName, laterName);
    }

    public static void DateWillParse(this ICheckClause checkClause, int year, int month, int day)
    {
        try
        {
            _ = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Unspecified);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new InvalidValueException($"Invalid date supplied: {year}-{month}-{day}");
        }
    }
    public static void TimeSpansInAscendingOrder(this ICheckClause checkClause, TimeSpan lesserTimeSpan, TimeSpan greaterTimeSpan,
        [CallerArgumentExpression("lesserTimeSpan")] string? lesserName = null, [CallerArgumentExpression("greaterTimeSpan")] string? greaterName = null)
    {
        if (greaterTimeSpan <= lesserTimeSpan)
        {
            throw new InvalidValueException($"{greaterTimeSpan} must be greater than {lesserTimeSpan}");
        }
    }

    public static void TimeSpansInAscendingOrder(this ICheckClause checkClause, TimeSpan? lesserTimeSpan, TimeSpan? greaterTimeSpan,
        [CallerArgumentExpression("lesserTimeSpan")] string? lesserName = null, [CallerArgumentExpression("greaterTimeSpan")] string? greaterName = null)
    {
        if (lesserTimeSpan is null || greaterTimeSpan is null)
            return;

        checkClause.TimeSpansInAscendingOrder(lesserTimeSpan.Value, greaterTimeSpan.Value, lesserName, greaterName);
    }

    public static DateTime DefaultLowerLimit(this ICheckClause checkClause, [NotNull] DateTime? input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        checkClause.Null(input, parameterName);

        if (input.Value <= new DateTime(1900, 01, 01))
        {
            throw new InvalidValueException($"{parameterName} must be after {new DateTime(1900, 01, 01):yyyy-MM-dd}");
        }

        return input.Value;
    }

    public static Guid NotEmpty(this ICheckClause checkClause, Guid input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input != Guid.Empty)
        {
            throw new ExistsException($"Attempt to add existing {parameterName} with Id={input}. Use Update method instead.");
        }
        return input;
    }

    public static DateTime MinDateTime(this ICheckClause checkClause, DateTime input, [CallerArgumentExpression("input")] string? parameterName = null)
    {
        if (input == DateTime.MinValue)
        {
            throw new InvalidValueException($"{parameterName} must be greater than minimum datetime");
        }
        return input;
    }

    public static void EmailNotValid(this ICheckClause checkClause, string email)
    {
        bool emailValid;
        try
        {
            var address = new MailAddress(email);
            emailValid = address.Address == email;
        }
        catch
        {
            emailValid = false;
        }
        if (!emailValid)
        {
            throw new InvalidValueException($"Invalid email address supplied: {email}");
        }
    }

}
