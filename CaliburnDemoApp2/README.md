CaliburnDemoApp2
================
專案預設會建立 MainPage.xaml，修改如下：

	 <Page
	    x:Class="CaliburnDemoApp2.MainPage"
	    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
	    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	    xmlns:local="using:CaliburnDemoApp2"
	    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
	    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
	    xmlns:caliburn="using:Caliburn.Micro"
	    mc:Ignorable="d"
	    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
	
	    <Grid>
	        <Button x:Name="MyButton" Content="My Button" Margin="140,288,0,295" />
	        <TextBlock x:Name="MyTextBlock" HorizontalAlignment="Left" Margin="140,365,0,0" TextWrapping="Wrap" Text="TextBlock" VerticalAlignment="Top" Width="78"/>
	    </Grid>
	</Page>
除了兩個控制項外，最上面加了一行 Caliburn.Micro 的 namespace，其餘並沒有什麼不同，特別注意的是，兩個控制項一定要有 ID，方便讓之後建立的 View Model 來對應。

接下來建立 MainPageViewModel，在 Caliburn.Micro 的慣例下，View Model 跟 View 的命名只差 “ViewModel”。MainPageViewModel.cs 的程式碼如下：

     public class MainPageViewModel : Screen
    {
        private INavigationService navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.MyTextBlock = DateTime.Now.ToString();
        }

        public string MyTextBlock { get; set; }

        public async void MyButton()
        {
            MessageDialog message = new MessageDialog("My Message");
            await message.ShowAsync();
        }
    }
之前建立的 View中，有兩個控制項分別命名為 MyButton 以及 MyTextBlock，所以在 View Model 中建立 MyTextBlock 這個屬性，以及名稱為 MyButton 的 method，Caliburn.Micro 會自動去對應。

之後打開 App.cs 檔案，做以下的修改，好讓 Caliburn.Micro 能順利運作：

首先修改 OnLaunched：

	protected override void OnLaunched(LaunchActivatedEventArgs e)
	{
	    Initialize();
	
	    var resumed = false;
	
	    if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
	    {
	        resumed = _navigationService.ResumeState();
	    }
	
	    if (resumed)
	    {
	        Window.Current.Activate();
	        return;
	    }
	
	    if (e.PreviousExecutionState != ApplicationExecutionState.Running)
	    {
	        DisplayRootViewFor<MainPageViewModel>();
	    }
	}
程式碼的目的在於程式一開始執行時，所要做的狀態判斷，接下來新增 Configure 這個 method：

	 protected override void Configure()
	 {
	     LogManager.GetLog = t => new DebugLog(t);
	
	     _container = new WinRTContainer();
	     _container.RegisterWinRTServices();
	
	     // Register your view models at the container
	     _container.PerRequest<MainPageViewModel>();
	
	     // We want to use the Frame in OnLaunched so set it up here
	     PrepareViewFirst();
	 }
這邊是做一些必要的註冊，其中最重要的是 View Model 的註冊及一開始要顯示的頁面，之後呼叫 PrepareViewFirst。

後面是 GetInstance 及 GetAllInstances，程式要取得 View Model，會呼叫 GetInstance。

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
