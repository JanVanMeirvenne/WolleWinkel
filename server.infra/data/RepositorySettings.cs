using server.core.interfaces;
using shared.interfaces;

namespace server.infra.data
{
    public class RepositorySettings:IRepositorySettings
    {
        private ISettingsService _settingsService;

        public RepositorySettings(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public string ConnectionString => _settingsService.Get("DataConnectionString");

    }
}