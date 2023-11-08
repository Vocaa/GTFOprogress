using Blazored.LocalStorage;

namespace GTFOprogress.Services
{
    public class SettingsService
    {
        private IConfiguration _config;
        private ILocalStorageService _localStorage;

        private Dictionary<string, string> _settings = new Dictionary<string, string>();

        public SettingsService(IConfiguration config, ILocalStorageService storage) 
        {
            _config = config;
            _localStorage = storage;
        }

        public async Task SaveSettings()
        {
            await _localStorage.SetItemAsync<Dictionary<string, string>>("settings", _settings);
        }

        public async Task<bool> HasSettings()
        {
            return await _localStorage.ContainKeyAsync("settings");
        }

        public async Task LoadSettings()
        {
            if (await HasSettings())
            {
                _settings = await _localStorage.GetItemAsync<Dictionary<string, string>>("settings");
            }
            else
            {
                return;
            }
        }

        public Dictionary<string, string> GetSettings()
        {
            return _settings;
        }

        public string? GetSetting(string key)
        {
            return _settings.TryGetValue(key, out string? value) ? value : default;
        }

        public async Task UpdateSettings(Dictionary<string, string> settings)
        {
            _settings = settings;
            await SaveSettings();
        }

        public async Task UpdateSetting(string key, string value)
        {
            _settings[key] = value;
            await SaveSettings();
        }
    }
}
