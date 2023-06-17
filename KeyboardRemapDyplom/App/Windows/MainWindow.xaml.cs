namespace App.Windows
{
    using System;
    using System.Windows;

    using App.Interfaces.Logic;
    using App.Interfaces.ViewModels;

    using JetBrains.Annotations;

    public partial class MainWindow
    {
        [NotNull]
        private readonly INotifyIconHolder _notifyIconHolder;

        public MainWindow([NotNull] IMainWindowViewModel viewModel, [NotNull] INotifyIconHolder notifyIconHolder)
        {
            this._notifyIconHolder = notifyIconHolder;
            this.DataContext = viewModel;
            this.InitializeComponent();
        }

        private void Window_OnStateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Minimized:
                    this.ShowInTaskbar = false;
                    this._notifyIconHolder.NotifyIcon.Visible = true;
                    break;
                default:
                    this.ShowInTaskbar = true;
                    this._notifyIconHolder.NotifyIcon.Visible = false;
                    break;
            }
        }
    }
}