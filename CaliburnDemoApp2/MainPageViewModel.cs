using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace CaliburnDemoApp2
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.MyTextBlock = DateTime.Now.ToString();
        }

        public string MyTextBlock { get; set; }

        public void GoToSecondPage()
        {

            //this.navigationService.UriFor<SecondPageViewModel>();
            MessageDialog message = new MessageDialog("aaa3");
            //await message.ShowAsync();

            this.navigationService.NavigateToViewModel<SecondPageViewModel>(DateTime.Now.ToString());
            //this.navigationService.NavigateToViewModel(typeof(TestUserControlPageViewModel));
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
