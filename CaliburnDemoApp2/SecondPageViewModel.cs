using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnDemoApp2
{
    public class SecondPageViewModel : ViewModelBase
    {
        public SecondPageViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            
        }

        protected override void OnViewLoaded(object view)
        {
            if (!string.IsNullOrEmpty(this.Parameter)) {
                this.MyTextBlock = this.Parameter;
            }
            base.OnViewLoaded(view);
        }

        private string _myTextBlock;
        public string MyTextBlock
        {
            get { return this._myTextBlock; }
            set 
            {
                this._myTextBlock = value;
                this.NotifyOfPropertyChange("MyTextBlock");
            }
        }

        public string Parameter { get; set; }

        public void NextPageButton()
        {
            this.navigationService.NavigateToViewModel<ThirdPageViewModel>("aaa3");
        }
    }
}
