using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.Phone.UI.Input;

namespace CaliburnDemoApp2
{
    public class ThirdPageViewModel : ViewModelBase
    {
        public ThirdPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
                    
        }

        void navigationService_BackPressed(object sender, BackPressedEventArgs e)
        {
            Caliburn.Micro.FrameAdapter adapter = sender as Caliburn.Micro.FrameAdapter;

            this.count++;
            if (this.count < 3) {
                e.Handled = true;
            }
        }


        protected override void OnViewLoaded(object view)
        {
            this.navigationService.BackPressed += navigationService_BackPressed;  
            if (this.navigationService.ResumeState()) {
                this.StateTextBlock = "Resume";
            }
            else {
                this.StateTextBlock = "Not Resume";
            }

            if (this.Parameter != null) {
                this.MessageText = this.Parameter;
            }

            //register key back event


            base.OnViewLoaded(view);
        }

        protected override void OnDeactivate(bool close)
        {
            this.navigationService.BackPressed -= navigationService_BackPressed; 
        }

        private int count { get; set; }

        public string Parameter { get; set; }

        private string _messageText;
        public string MessageText
        {
            get { return this._messageText; }
            set
            {
                this._messageText = value;
                this.NotifyOfPropertyChange("MessageText");
            }
        }

        private string _stateTextBlock;
        public string StateTextBlock
        {
            get { return this._stateTextBlock; }
            set
            {
                this._stateTextBlock = value;
                this.NotifyOfPropertyChange("StateTextBlock");
            }
        }

        public void TheSamePageButton()
        {
            this.navigationService.NavigateToViewModel<ThirdPageViewModel>(DateTime.Now.ToString());
        }

        public void OnGoBack(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
