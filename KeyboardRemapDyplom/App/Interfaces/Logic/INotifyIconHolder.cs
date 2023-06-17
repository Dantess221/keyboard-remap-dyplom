namespace App.Interfaces.Logic
{
    using System;
    using System.Windows.Forms;

    public interface INotifyIconHolder : IDisposable
    {
        NotifyIcon NotifyIcon { get; }
    }
}