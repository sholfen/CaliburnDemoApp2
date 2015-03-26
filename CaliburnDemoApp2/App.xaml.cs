using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace CaliburnDemoApp2
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : CaliburnApplication
    {
        private WinRTContainer _container;
        private INavigationService _navigationService;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Initialize();
            await StatusBar.GetForCurrentView().HideAsync();

            var resumed = false;

            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated) {
                resumed = _navigationService.ResumeState();
            }

            if (resumed) {
                Window.Current.Activate();
                return;
            }

            if (e.PreviousExecutionState != ApplicationExecutionState.Running) {
                //DisplayRootViewFor<MainPageViewModel>();


                //DisplayRootView<TestUserControlPage>();
                //DisplayRootView<MainPage>();
                DisplayRootView<ValidationPage>();
            }
        }

        protected override void Configure() 
        {
            //LogManager.GetLog = t => new DebugLog(t);

            //string[] namespaces = new string[] { "CaliburnDemoApp2" };
            ViewModelLocator.AddNamespaceMapping("CaliburnDemoApp2", "CaliburnDemoApp2");

            var baseLocate = ViewLocator.LocateTypeForModelType;
            ViewLocator.LocateTypeForModelType = (modelType, displayLocation, context) => {

                var attribute = modelType.GetTypeInfo().GetCustomAttributes(typeof(ViewAttribute), false).OfType<ViewAttribute>().Where(x => x.Context == context).FirstOrDefault();
                return attribute != null ? attribute.ViewType : baseLocate(modelType, displayLocation, context);
            };

            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            // Register your view models at the container
            //_container.PerRequest<MainPageViewModel>();
            //_container.PerRequest<SecondPageViewModel>();
            //_container.PerRequest<WebViewPageViewModel>();
            //_container.PerRequest<TestUserControlPageViewModel>();   
            //_container.PerRequest<ThirdPageViewModel>();

            //_container.PerRequest<MyUserControlViewModel>(key: typeof(MyUserControlViewModel).FullName);
            this.RegisterContainer();

            // We want to use the Frame in OnLaunched so set it up here
            PrepareViewFirst();
        }

        /// <summary>
        /// 自動尋找在這個Assembly裡面繼承自ViewModelBase or Screen的class並註冊到Container裡面
        /// </summary>
        private void RegisterContainer()
        {
            Assembly assembly = this.GetType().GetTypeInfo().Assembly;
            Type viewModelBaseType = typeof(ViewModelBase);
            Type screenType = typeof(Screen);

            //load ViewModel type that inherited ViewModelBase or Screen
            var types = from modelType in assembly.GetExportedTypes()
                        where modelType.GetTypeInfo().BaseType == viewModelBaseType ||
                              modelType.GetTypeInfo().BaseType == screenType
                        select modelType;

            foreach (var type in types)
            {
                System.Diagnostics.Debug.WriteLine("Registerd ViewModel:{0}", type);
                _container.RegisterPerRequest(type, type.FullName, type);
            }
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new Exception("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            //rootFrame.ContentTransitions = new TransitionCollection() { new NavigationThemeTransition() };
            _navigationService = _container.RegisterNavigationService(rootFrame);
        }


        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        protected override void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity

            _navigationService.SuspendState();
            deferral.Complete();
        }

        protected override void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
        }
    }
}