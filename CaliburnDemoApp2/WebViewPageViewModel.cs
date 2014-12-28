using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnDemoApp2
{
    public class WebViewPageViewModel : ViewModelBase
    {
        public WebViewPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.HtmlSource = "ms-appdata:///local/Web/HtmlPage1.html";
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
        }

        public string HtmlSource { get; set; }
    }
}
