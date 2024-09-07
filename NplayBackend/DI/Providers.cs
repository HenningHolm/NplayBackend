using NplayBackend.Features.Shared;
using NplayBackend.Features;

namespace NplayBackend.DI;

public static class Providers
{
    public static void AddApplicationTypes(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IGetSharedContentQuery, GetSharedContentQuery>();
        
        services.AddTransient<IGetSongQuery, GetSongQuery>();
        services.AddTransient<IAddSongCommand, AddSongCommand>();
        services.AddTransient<IGetAllSongsQuery, GetAllSongsQuery>();

        services.AddTransient<IGetAllSongWithSimpleChordsQuery, GetAllSongWithSimpleChordsQuery>();
        services.AddTransient<ISearchSongWithSimpleChordsQuery, SearchSongWithSimpleChordsQuery>();
        services.AddTransient<IApprovePrimarySimpleChordsCommand, ApprovePrimarySimpleChordsCommand>();
        services.AddTransient<IGetSongAndPrimarySimpleChordsQuery, GetSongAndPrimarySimpleChordsQuery>();
        services.AddTransient<IGetAllNonApprovedSimpleChordsQuery, GetAllNonApprovedSimpleChordsQuery>();
        services.AddTransient<IGetSongAndNonApprovedSimpleChords, GetSongAndNonApprovedSimpleChords>();
        services.AddTransient<IAddSimpleChordsCommand, AddSimpleChordsCommand>();



    }
}

