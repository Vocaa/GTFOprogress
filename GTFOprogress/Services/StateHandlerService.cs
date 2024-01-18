using Blazored.LocalStorage;
using GTFOprogress.Common;
using GTFOprogress.Models;


namespace GTFOprogress.Services
{
    public class StateHandlerService
    {
        protected RundownRepository _rundownRepository;
        private readonly ILocalStorageService _localStorage;
        protected IConfiguration _config;
        protected State _state;

        public event EventHandler StateChanged;

        public StateHandlerService(RundownRepository rundownRepository,
                                   IConfiguration config,
                                   ILocalStorageService localStorage)
        {
            _rundownRepository = rundownRepository;
            _config = config;   
            _localStorage = localStorage;
        }
        public async Task InitializeState()
        {
            _state = await LoadState();
            _state.Version = _config["version"];
        }

        [Obsolete]
        private async Task<State> LoadStateOld()
        {
            bool local = await _localStorage.ContainKeyAsync("data");

            State Result = local ? await LoadFromLocalStorage() : await LoadFromDefaults();

            bool versionMatch = (Result.Version == _config["version"]);

            return versionMatch ? Result : await LoadFromDefaults();
            
        }
        private async Task<State> LoadState()
        {
            bool local = await _localStorage.ContainKeyAsync("data");

            if (local)
            {
                State localData = await LoadFromLocalStorage();
                State result = await LoadFromDefaults();
                result.MergeState(localData);
                return result;
            } else
            {
                return await LoadFromDefaults();
            }
        }

        private async Task<State> LoadFromLocalStorage()
        {
            return await _localStorage.GetItemAsync<State>("data");
        }

        private async Task<State> LoadFromDefaults()
        {
            return await _rundownRepository.GetData();
        }

        public void SaveState()
        {
            _localStorage.SetItemAsync("data", _state);
        }

        public List<Rundown> GetRundowns() { return _state.Data; }

        public Rundown GetRundown(int id)
        {
            return _state.Data.Where(i => i.Id == id).First();
        }

        public void NotifyStateChanged()
        {
            UpdateR8();
            StateChanged?.Invoke(this, EventArgs.Empty);
            SaveState();
            
        }

        public void UpdateR8()
        {
            Rundown rundown = GetRundown(8);
            if (rundown.VisibleCompleted())
            {
                rundown.UnHideLevels(rundown.GetHiddenByDefault());
            } else
            {
                rundown.HideLevels(rundown.GetHiddenByDefault());
            }
        }

    }
}
