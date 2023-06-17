namespace App.Logic
{
    using System.Collections.Generic;

    using App.Interfaces.Logic;

    using SettingsManager;

    public class AppSettings : SettingsModel, IAppSettings
    {
        public virtual AppThemes AppTheme { get; set; } = AppThemes.Light;

        public virtual IReadOnlyDictionary<int, int> KeyMappings { get; set; }

        public virtual int SettingsVersion { get; set; } = 2;

        public virtual bool StartMinimized { get; set; } = true;
    }
}