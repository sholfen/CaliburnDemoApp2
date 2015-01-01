using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace CaliburnDemoApp2
{
    public class EventTest2PageViewModel : ViewModelBase
    {
        public EventTest2PageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.DataList = new List<dynamic>();
            dynamic dynObject = new ExpandoObject();
            dynObject.Name = "A1";
            this.DataList.Add(dynObject);
            dynObject = new ExpandoObject();
            dynObject.Name = "A2";
            this.DataList.Add(dynObject);
        }

        public List<dynamic> DataList { get; set; }

        public async void ListViewItemClick(ItemClickEventArgs e)
        {
            dynamic dynObj = e.ClickedItem;
            MessageDialog message = new MessageDialog(dynObj.Name);
            await message.ShowAsync();
        }
    }
}
