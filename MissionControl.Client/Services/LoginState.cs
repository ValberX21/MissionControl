﻿using Blazored.LocalStorage;

namespace MissionControl.Services
{
    public class LoginState
    {
        public bool IsLoggedIn { get; private set; } = false;

        public event Action? OnChange;

        public void Login()
        {
            IsLoggedIn = true;
            NotifyStateChanged();
        }

        public async Task RestoreFromLocalStorageAsync(ILocalStorageService localStorage)
        {
            var jediId = await localStorage.GetItemAsync<string>("jediId");
            if (!string.IsNullOrEmpty(jediId))
            {
                IsLoggedIn = true;
                NotifyStateChanged();
            }
        }


        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
