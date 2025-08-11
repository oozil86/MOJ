using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MOJ.SharedKernel.Extensions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, string> NotNullOrWhiteSpaceString<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
          .Must(x => !string.IsNullOrWhiteSpace(x))
          .WithMessage("{PropertyName} cannot be null or whitespace.");
    }

    public static IRuleBuilderOptions<T, Guid> NotEmptyGuid<T>(
        this IRuleBuilder<T, Guid> ruleBuilder)
    {
        return ruleBuilder
            .Must(guid => guid != Guid.Empty)
            .WithMessage("{PropertyName} cannot be empty.");
    }

    public static IRuleBuilderOptions<T, string> IsEmail<T>(
      this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .EmailAddress()
            .WithMessage("{PropertyName} Is Not Email.");
    }

    public static IServiceCollection AddCustomFluentValidation(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddValidatorsFromAssembly(typeof(FluentValidationExtensions).Assembly);
        services.AddValidatorsFromAssemblies(assemblies);
        return services;
    }
}