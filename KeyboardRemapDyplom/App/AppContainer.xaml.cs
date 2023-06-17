namespace App
{
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;

    using App.Interfaces.Logic;
    using App.Interfaces.Logic.Utils;
    using App.Interfaces.ViewModels;
    using App.Logic;
    using App.Logic.Operations;
    using App.Logic.Utils;
    using App.ViewModels;
    using App.Windows;

    using Autofac;

    using SettingsManager;
    using SettingsManager.ModelProcessors;

    public partial class AppContainer
    {
        private IContainer _container;

        protected override void OnExit(ExitEventArgs e)
        {
            this._container.Resolve<IKeyMappingsHandler>().Dispose();
            this._container.Resolve<IHooksHandler>().Dispose();
            this._container.Resolve<INotifyIconHolder>().Dispose();

            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new ContainerBuilder();

            // windows
            container.RegisterType<MainWindow>().SingleInstance();
            container.RegisterType<NewMappingWindow>();

            // view models
            container.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();
            container.RegisterType<NewMappingWindowViewModel>().As<INewMappingWindowViewModel>();

            // operations
            container.RegisterType<MappingOperation>().SingleInstance();

            // utils
            container.RegisterType<AppUtils>().As<IAppUtils>().SingleInstance();
            container.RegisterType<ThemingUtils>().As<IThemingUtils>().SingleInstance();

            // other
            container.Register(
                    context => new SettingsBuilder<AppSettings>()
                        .WithFile(
                            Path.Combine(
                                context.Resolve<IAppUtils>().GetExecutableDir() ?? string.Empty,
                                "appSettings.json")).WithProcessor(new JsonModelProcessor()).Build()).SingleInstance()
                .As<IAppSettings>();
            container.RegisterType<HooksHandler>().As<IHooksHandler>().SingleInstance();
            container.RegisterGeneric(typeof(Provider<>)).As(typeof(IProvider<>)).SingleInstance();
            container.RegisterType<NotifyIcon>().SingleInstance();
            container.RegisterType<NotifyIconHolder>().As<INotifyIconHolder>().SingleInstance();
            container.RegisterType<KeyMappingsHandler>().As<IKeyMappingsHandler>().SingleInstance();

            this._container = container.Build();

            this.Initialize();
        }

        private void Initialize()
        {
            // constructor invocation starts hooking
            this._container.Resolve<IKeyMappingsHandler>();

            // apply app theme
            this._container.Resolve<IThemingUtils>().ApplyCurrent();

            // show main window or tray icon
            if (this._container.Resolve<IAppSettings>().StartMinimized)
                this._container.Resolve<INotifyIconHolder>().NotifyIcon.Visible = true;
            else this._container.Resolve<MainWindow>().Show();
        }
    }
}