namespace App.Interfaces.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using App.Logic;
    using App.ViewModels;

    using MVVM_Tools.Code.Commands;

    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
        IActionCommand AddMappingCommand { get; }

        AppThemes AppTheme { get; set; }

        IReadOnlyList<AppThemes> AvailableThemes { get; }

        IActionCommand ClearMappingsCommand { get; }

        IActionCommand DeleteMappingCommand { get; }

        IActionCommand ExportMappingsCommand { get; }

        IActionCommand ImportMappingsCommand { get; }

        ObservableCollection<KeyToKeyViewModel> KeyMappings { get; }

        KeyToKeyViewModel SelectedKey { get; set; }

        bool StartMinimized { get; set; }

        bool StartWithWindows { get; set; }
    }
}