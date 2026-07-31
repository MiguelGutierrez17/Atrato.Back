namespace Atrato.Api.ConfigurationMapper;

public static class DependencyInjection
{
    public static IServiceCollection InjectDependencies(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromApplicationDependencies(a =>
                a.GetName().Name.StartsWith("Atrato"))
            .AddClasses(c => c.InNamespaces(
                "Atrato.Services",
                "Atrato.Commands",
                "Atrato.QueryObjects"
            ))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        return services;
    }
}