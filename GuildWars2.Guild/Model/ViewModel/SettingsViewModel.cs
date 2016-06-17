﻿using GuildWars2Guild.Model.ViewModel.Bases;

namespace GuildWars2Guild.Model.ViewModel
{
    class SettingsViewModel : BaseViewModel
    {
        private string _apiKey;

        public string ApiKey
        {
            get { return _apiKey; }
            set {
                _apiKey = value;
                NotifyPropertyChanged(nameof(ApiKey));
                Properties.Settings.Default.ApiKey = value;
                Properties.Settings.Default.Save();
            }
        }

        public SettingsViewModel() {
            ApiKey = Properties.Settings.Default.ApiKey;
        }
    }
}
