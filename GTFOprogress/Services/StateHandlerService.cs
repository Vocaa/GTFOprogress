﻿using Blazored.LocalStorage;
using GTFOprogress.Models;
using GTFOprogress.Common;

namespace GTFOprogress.Services
{
    public class StateHandlerService
    {
        protected ILocalStorageService _localStorage;

        protected RundownRepository _rundownRepository;

        protected IConfiguration _config;

        protected State _state;

        public StateHandlerService(ILocalStorageService _localStorage, RundownRepository _rundownRepository, IConfiguration _config)
        {
            this._localStorage = _localStorage;
            this._rundownRepository = _rundownRepository;
            this._config = _config;
            _state = this.LoadState().Result;
            _state.Version = _config["version"];

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
            _state.Data.Where(e => e.Levels == e.Levels.Where(i => i.Name == level.Name)).First().Levels.FindIndex(e => e.Name == level.Name);
        }

        public void UpdateRundown(Rundown rundown)
        {
            //_state.Data.First(e => e.id == rundown.id) = rundown;
        }



    }
}
