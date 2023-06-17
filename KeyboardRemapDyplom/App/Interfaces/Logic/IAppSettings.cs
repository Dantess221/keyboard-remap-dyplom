namespace App.Interfaces.Logic
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using App.Logic;

    public interface IAppSettings : INotifyPropertyChanged
    {
        AppThemes AppTheme { get; set; }

        IReadOnlyDictionary<int, int> KeyMappings { get; set; }

        int SettingsVersion { get; set; }

        bool StartMinimized { get; set; }
    }
}