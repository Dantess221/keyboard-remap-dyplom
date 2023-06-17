namespace App.Interfaces.Logic.Utils
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using App.Logic;

    public interface IThemingUtils : INotifyPropertyChanged
    {
        IReadOnlyList<AppThemes> AvailableThemes { get; }

        AppThemes CurrentTheme { get; set; }

        void ApplyCurrent();
    }
}