using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grocery.UI.Contract;
using Grocery.Service.Client.Contract;
using Grocery.Service.Client;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.UI.Control;
using Grocery.UI.ViewModel;

namespace Grocery.UI.Shell
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application, IApp
    {
        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {
                IMainWindowController mainWindowController = new MainWindowController(this);
                IFrontServiceClient frontServiceClient = new FrontServiceClient();
                IValidationRuleFactory validationRuleFactory = new ValidationRuleFactory();
                IViewModelFactory viewModelFactory = new ViewModelFactory(validationRuleFactory, mainWindowController, frontServiceClient);
                IViewFactory viewFactory = new ViewFactory(viewModelFactory);
                mainWindowController.SetView(viewFactory);
                mainWindowController.LoadLogin();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Событие выполняется при выходе
        private void AppExit(object sender, ExitEventArgs args)
        {
            this.Shutdown();
        }

        void IApp.Exit()
        {
            this.Shutdown();
        }
    }
}
