using Blazored.LocalStorage;
using GTFOprogress.Models;
using GTFOProgress.Common.Tier;
using GTFOProgress.Models;

namespace GTFOprogress.Services
{
    public class StateHandlerService
    {
        protected ILocalStorageService _localStorage;

        protected RundownRepository _rundownRepository;

        protected State _state;

        public StateHandlerService(ILocalStorageService _localStorage, RundownRepository _rundownRepository)
        {
            this._localStorage = _localStorage;
            this._rundownRepository = _rundownRepository;
        }

        private async Task<State> LoadState()
        {
            bool local = await _localStorage.ContainKeyAsync("data");

            if (local)
            {
                return await _localStorage.GetItemAsync<State>("data");
            }
            else
            {
                return await Task.FromResult(_rundownRepository.GetData());
            }
        }

        private async void SaveState(State state)
        {
            await _localStorage.SetItemAsync("data", state);
        }

        public State GetState() { return _state; }

        public void UpdateLevel(Level level)
        {
            _state.Data.Where(e => e.levels == e.levels.Where(i => i.name == level.name)).First().levels.FindIndex(e => e.name == level.name);
        }

        public void UpdateRundown(Rundown rundown)
        {
            _state.Data.First(e => e.id == rundown.id) = rundown;
        }



    }
}
