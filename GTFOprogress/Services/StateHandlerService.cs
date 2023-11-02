using Blazored.LocalStorage;
using GTFOprogress.Models;
using GTFOprogress.Common;
using System.Reflection.Metadata.Ecma335;

namespace GTFOprogress.Services
{
    public class StateHandlerService
    {
        protected RundownRepository _rundownRepository;
        private readonly ILocalStorageService _localStorage;
        protected IConfiguration _config;
        protected State _state;

        public StateHandlerService(RundownRepository rundownRepository,
                                   IConfiguration config,
                                   ILocalStorageService localStorage)
        {
            _rundownRepository = rundownRepository;
            _config = config;
            _localStorage = localStorage;
        }
        private async Task InitializeState()
        {
            _state = await LoadState();
            _state.Version = _config["version"];
        }

        private async Task<State> LoadState()
        {
            bool local = await _localStorage.ContainKeyAsync("data");
            return local ? await _localStorage.GetItemAsync<State>("data") : await _rundownRepository.GetData();
        }

        public void SaveState()
        {
            _localStorage.SetItemAsync("data", _state);
        }

        public State GetState() { return _state; }
        public List<Rundown> GetRundowns() { return _state.Data; }

    }
}
