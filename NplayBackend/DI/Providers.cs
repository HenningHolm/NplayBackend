using NplayBackend.Features.Shared;
using NplayBackend.Features.Song;

namespace NplayBackend.DI;

public static class Providers
{
    public static void AddApplicationTypes(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IGetSharedContentQuery, GetSharedContentQuery>();
        services.AddTransient<IGetSongQuery, GetSongQuery>();
        services.AddTransient<ISetSongCommand, SetSongCommand>();
    }
}

