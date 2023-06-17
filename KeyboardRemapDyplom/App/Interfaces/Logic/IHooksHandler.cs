namespace App.Interfaces.Logic
{
    using System;

    using JetBrains.Annotations;

    public interface IHooksHandler : IDisposable
    {
        void RemoveAllHooks();

        bool RemoveHook(int keyCode);

        void SetAllKeysHandler([CanBeNull] Func<int, bool> keyHandler);

        void SetHook(int keyCode, [NotNull] Action handler);
    }
}