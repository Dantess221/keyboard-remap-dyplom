namespace App.Interfaces.Logic.Utils
{
    using JetBrains.Annotations;

    public interface IAppUtils
    {
        [CanBeNull]
        string GetExecutableDir();

        [NotNull]
        string GetExecutablePath();
    }
}