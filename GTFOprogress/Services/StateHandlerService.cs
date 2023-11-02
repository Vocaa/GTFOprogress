using Blazored.LocalStorage;
using GTFOprogress.Models;
using GTFOprogress.Common;
using System.Reflection.Metadata.Ecma335;

namespace GTFOprogress.Services
{
    public class StateHandlerService
    {
        protected RundownRepository _rundownRepository;
        private readonly LocalStorageServiceFactory _localStorageServiceFactory;
        protected IConfiguration _config;
        protected State _state;

        public StateHandlerService(RundownRepository rundownRepository,
                                   IConfiguration config,
                                   LocalStorageServiceFactory localStorageServiceFactory)
        {
            _rundownRepository = rundownRepository;
            _config = config;
            _localStorageServiceFactory = localStorageServiceFactory;
            InitializeState();
        }
        private async void InitializeState()
        {
            _state = await LoadState();
            _state.Version = _config["version"];
        }

        private async Task<State> LoadState()
        {
            var localStorage = _localStorageServiceFactory.Create();
            bool local = await localStorage.ContainKeyAsync("data");
            return local ? await localStorage.GetItemAsync<State>("data") : _rundownRepository.GetData();
        }

        public void SaveState()
        {
            var localStorage = _localStorageServiceFactory.Create();
            localStorage.SetItemAsync("data", _state);
        }

        public State GetState() { return _state; }
        public List<Rundown> GetRundowns() { return _state.Data; }

    }
}
