using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Popups;

namespace CaliburnDemoApp2
{
    public class TestUserControlPageViewModel : ViewModelBase
    {
        public TestUserControlPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.Model = IoC.Get<MyUserControlViewModel>();
            this.Model.Parameter = "aaaaaaa3";
        }

        protected override void OnViewAttached(object view, object context)
        {
            //this.Model = IoC.Get<MyUserControlViewModel>();
            //this.Model = new MyUserControlViewModel(this.navigationService);
            //this.Model.Parameter = "aaaaaaa3";
        }

        public MyUserControlViewModel Model { get; set; }

        public void TestButton()
        {
            throw new Exception("Test Message");
        }
    }
}
