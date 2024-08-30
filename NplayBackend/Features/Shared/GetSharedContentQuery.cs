
using NPlay.Shared.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NplayBackend.Data;
using NplayBackend.Models.ViewModels;

namespace NplayBackend.Features.Shared
{
    public interface IGetSharedContentQuery
    {
        Task<SharedContentModel> ExecuteAsync();
    }
    public class GetSharedContentQuery : IGetSharedContentQuery
    {
        private readonly ILogger<GetSharedContentQuery> _logger;
        private readonly OrganisationSettings _organisationSettings;
        private readonly NplayDbContext _dbContext;

        public GetSharedContentQuery(NplayDbContext dbContext, ILogger<GetSharedContentQuery> logger, IOptions<OrganisationSettings> organisationSettings)
        {
            _dbContext = dbContext;
            _logger = logger;
            _organisationSettings = organisationSettings.Value;
        }


        public async Task<SharedContentModel> ExecuteAsync()
        {
            //var content = await _dbContext.CustomContents.FirstOrDefaultAsync(c => c.Domain == _organisationSettings.Domain);

            var contentModel = new SharedContentModel
            {
                SiteName = "New Playground",
                HeaderHtml = "<h1>Heelo</h1>",
                ImagesHtml = "<img src='https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png' />",
            };
            return contentModel;
        }
    }
}
