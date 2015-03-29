using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnDemoApp2
{
    [View(typeof(ViewAttributePage2))]
    public class ViewAttributePageViewModel : ViewModelBase
    {
        public ViewAttributePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
             
        }
    }
}
