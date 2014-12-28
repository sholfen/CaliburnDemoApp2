using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Popups;

namespace CaliburnDemoApp2
{
    public class MyUserControlViewModel : ViewModelBase
    {
        public MyUserControlViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.MyTextBlock = DateTime.Now.ToString();
            this.MyTextBlock2 = "3065";
        }

        protected override void OnViewLoaded(object view)
        {
            if (!string.IsNullOrEmpty(this.Parameter)) {
                this.MyTextBlock = this.Parameter;
            }
        }

        public string MyTextBlock { get; set; }
        public string MyTextBlock2 { get; set; }
        public string Parameter { get; set; }

        public async void TestButton()
        {
            MessageDialog messageDialog = new MessageDialog("aaa3");
            await messageDialog.ShowAsync();
        }
    }
}
