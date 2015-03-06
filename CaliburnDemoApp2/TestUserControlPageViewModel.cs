using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

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
            this.TestField = "aaaaaaaaaaaaaaaaaa3";
            this.TestButton2 = "{Binding TestField}";

           // MyContentControl
            Page page = view as Page;
            //    ViewModelBinder.Bind(rootModel, view, null);
            ContentControl contentControl = page.FindName("MyContentControl") as ContentControl;
            MyUserControl myControl = new MyUserControl();
            MyUserControlViewModel viewModel = IoC.Get<MyUserControlViewModel>();
            viewModel.MyTextBlock2 = DateTime.Now.ToString("yyyy/MM/dd");
            ViewModelBinder.Bind(viewModel, myControl, null);
            contentControl.Content = myControl;
        }

        public MyUserControlViewModel Model { get; set; }

        private string _testField;
        public string TestField
        { 
            get { return this._testField; }
            set
            {
                this._testField = value;
                this.NotifyOfPropertyChange(() => TestField);
            }
        }

        private string _testButton2;
        public string TestButton2
        {
            get { return this._testButton2; }
            set
            {
                this._testButton2 = value;
                this.NotifyOfPropertyChange(() => _testButton2);
            }
    }

        public void TestButton()
        {
            throw new Exception("Test Message");
        }
    }
}
