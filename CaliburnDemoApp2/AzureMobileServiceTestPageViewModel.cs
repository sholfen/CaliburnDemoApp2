using Caliburn.Micro;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
        public MobileServiceClient _mobileService;

        public AzureMobileServiceTestPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._mobileService = new MobileServiceClient(
                "https://peterazuretest.azure-mobile.net/",
                "IgiHrTTfotmhhwkrqEAMUAqAHcUKla38");
        }

        public async Task SubmitButton()
        {
            TodoItem item = new TodoItem { Text = "Awesome item", Complete = false };
            await _mobileService.GetTable<TodoItem>().InsertAsync(item);

        }

        public async Task GetDataButton()
        {
            var table = _mobileService.GetTable<TodoItem>();
            List<TodoItem> list = await table.ToListAsync();
            MessageDialog message = new MessageDialog(list.Count().ToString());
            await message.ShowAsync();
        }
    }
}
