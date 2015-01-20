using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnDemoApp2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ViewAttribute : Attribute
    {
        public object Context { get; set; }

        public Type ViewType { get; private set; }

        public ViewAttribute(Type viewType)
        {
            ViewType = viewType;
        }
    }

    public class ViewModelBase : Screen
    {
        protected INavigationService navigationService;
        public ViewModelBase(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void GoBack()
        {
            navigationService.GoBack();
        }

        public bool CanGoBack
        {
            get
            {
                return navigationService.CanGoBack;
            }
        }
    }
}
