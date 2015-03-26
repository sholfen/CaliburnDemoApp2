using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace CaliburnDemoApp2
{
    public class ValidationPageViewModel : ViewModelBase
    {
        public ValidationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {//System.ComponentModel.DataAnnotations.ValidationAttribute

            //FluentValidation.ValidatorFactoryBase
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            #region Design time sample data
#if DEBUG
            if (Execute.InDesignMode) {
                return;
            }
#endif
            #endregion
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            #region Design time sample data
#if DEBUG
            if (Execute.InDesignMode) {
                return;
            }
#endif
            #endregion
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            #region Design time sample data
#if DEBUG
            if (Execute.InDesignMode) {
                return;
            }
#endif
            #endregion
        }
    }
}
