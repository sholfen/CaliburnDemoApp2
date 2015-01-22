using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnDemoApp2
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }
    }

    public class AzureMobileServiceTestPageViewModel : ViewModelBase
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
                                                                "https://peterazuretest.azure-mobile.net/",
                                                                "IgiHrTTfotmhhwkrqEAMUAqAHcUKla38");

        public AzureMobileServiceTestPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public async Task SubmitButton()
        {
            TodoItem item = new TodoItem { Text = "Awesome item", Complete = false };
            await MobileService.GetTable<TodoItem>().InsertAsync(item);
        }
    }
}
