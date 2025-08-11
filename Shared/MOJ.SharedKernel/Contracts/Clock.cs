﻿using MOJ.SharedKernel.Abstractions;

namespace MOJ.SharedKernel.Contracts;


public class Clock
{
    private static readonly object _lock = new();

    private static IDateTime? _dateTimeProvider;
    public static IDateTime Provider => _dateTimeProvider ?? throw new NotImplementedException();
    public static DateTime Now => _dateTimeProvider?.Now ?? throw new NotImplementedException();
    public static DateTime UtcNow => _dateTimeProvider?.UtcNow ?? throw new NotImplementedException();
    public static DateTime Today => _dateTimeProvider?.Today ?? throw new NotImplementedException();

    public static IDateTime Initialize(IDateTime? dateTimeProvider = null)
    {
        if (_dateTimeProvider is null)
        {
            lock (_lock)
            {
                _dateTimeProvider ??= dateTimeProvider ?? DateTimeProvider.Implementation;
            }
        }

        return _dateTimeProvider;
    }

    private sealed class DateTimeProvider : IDateTime
    {
        public static readonly DateTimeProvider Implementation = new();
        private DateTimeProvider() { }

        public DateTime Now => DateTime.Now;
        public DateOnly NowAsDateOnly => DateOnly.FromDateTime(DateTime.Now);
        public DateTime UtcNow => DateTime.UtcNow;
        public DateTime Today => DateTime.Today;
    }
}