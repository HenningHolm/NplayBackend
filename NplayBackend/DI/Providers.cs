using NplayBackend.Features.Shared;

namespace NplayBackend.DI;

public static class Providers
{
    public static void AddApplicationTypes(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IGetSharedContentQuery, GetSharedContentQuery>();
    }
}

