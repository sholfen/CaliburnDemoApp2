using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnDemoApp2
{
    public class DesignTimePageViewModel : ViewModelBase
    {
        public DesignTimePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public DesignTimePageViewModel()
            :base(null)
        {
        }

        private string _title;
        public string Title
        {
            get { return this._title; }
            set 
            {
                this._title = value;
                NotifyOfPropertyChange("Title");
            }
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            if (Execute.InDesignMode) {
                this.Title = "aaa3";
                return;
            }

            this.Title = "aaa4";
        }
    }
}
