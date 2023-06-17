namespace App.Windows
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using App.Interfaces.Logic;
    using App.Interfaces.ViewModels;

    using JetBrains.Annotations;

    public partial class NewMappingWindow
    {
        [NotNull]
        private readonly IHooksHandler _hooksHandler;

        [NotNull]
        private readonly INewMappingWindowViewModel _viewModel;

        public NewMappingWindow([NotNull] INewMappingWindowViewModel viewModel, [NotNull] IHooksHandler hooksHandler)
        {
            this._viewModel = viewModel;
            this._hooksHandler = hooksHandler;
            this.DataContext = viewModel;
            this.InitializeComponent();

            hooksHandler.SetAllKeysHandler(this.AllKeysHandler);
        }

        private bool AllKeysHandler(int keyCode)
        {
            if (!this._viewModel.RecordKeyCommand.CanExecute(keyCode))
                return false;

            this._viewModel.RecordKeyCommand.Execute(keyCode);
            return true;
        }

        private void Apply_OnClick(object sender, RoutedEventArgs e)
        {
            if (this._viewModel.ApplyCommand.CanExecute(null))
            {
                this._viewModel.ApplyCommand.Execute();
                this.Close();
            }
        }

        private void MappedKeyBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedKey = ((ComboBox)sender).SelectedItem as int?;
            if (selectedKey == null)
                return;

            this._viewModel.SetMappedKeyCommand.Execute(selectedKey);
        }

        private void SourceKeyBox_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedKey = ((ComboBox)sender).SelectedItem as int?;
            if (selectedKey == null)
                return;

            this._viewModel.SetSourceKeyCommand.Execute(selectedKey);
        }

        private void SourceKeyBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Window_OnClosed(object sender, EventArgs e)
        {
            this._hooksHandler.SetAllKeysHandler(null);
        }
    }
}