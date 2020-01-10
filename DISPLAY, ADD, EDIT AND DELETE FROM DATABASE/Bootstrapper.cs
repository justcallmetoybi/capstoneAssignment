using Caliburn.Micro;
using DISPLAY__ADD__EDIT_AND_DELETE_FROM_DATABASE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DISPLAY__ADD__EDIT_AND_DELETE_FROM_DATABASE
{
    public class Bootstrapper : BootstrapperBase
    {

        public Bootstrapper()
        {
            Initialize();
            
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}
