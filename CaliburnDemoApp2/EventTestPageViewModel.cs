using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CaliburnDemoApp2
{
    public class EventTestPageViewModel : ViewModelBase
    {
        public EventTestPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public async void TestButton1()
        {
            MessageDialog dialog = new MessageDialog("Test1");
            await dialog.ShowAsync();
        }

        public async void TestEventMethod()
        {
            MessageDialog dialog = new MessageDialog("Test2");
            await dialog.ShowAsync();
        }

        public async void TestButton3(object view)
        {
            string typeName = view.GetType().FullName;
            MessageDialog dialog = new MessageDialog(typeName);
            await dialog.ShowAsync();
        }

        public async void TestButton4(string text)
        {
            MessageDialog dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
