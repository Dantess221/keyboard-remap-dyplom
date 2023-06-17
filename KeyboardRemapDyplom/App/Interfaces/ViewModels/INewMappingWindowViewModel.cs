namespace App.Interfaces.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using App.Logic;

    using MVVM_Tools.Code.Commands;

    public interface INewMappingWindowViewModel : INotifyPropertyChanged
    {
        IActionCommand ApplyCommand { get; }

        IReadOnlyList<int> AvailableKeys { get; }

        int MappedKey { get; set; }

        RecordingStates RecordingState { get; }

        IActionCommand<int> RecordKeyCommand { get; }

        IActionCommand RecordMappedKeyCommand { get; }

        IActionCommand RecordSourceKeyCommand { get; }

        IActionCommand<int> SetMappedKeyCommand { get; }

        IActionCommand<int> SetSourceKeyCommand { get; }

        int SourceKey { get; set; }

        IActionCommand StopRecordingCommand { get; }
    }
}