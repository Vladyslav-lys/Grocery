using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Grocery.UI.Contract;

namespace Grocery.UI.Control
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl, IViewLogin
    {
        public LoginView(IViewModelLogin viewModelLogin)
        {
            viewModelLogin.ViewLogin = this;
            InitializeComponent();
            this.DataContext = viewModelLogin;
        }

        public string Login
        {
            get { return this.Dispatcher.Invoke(() => this.loginTxt.Text); }
        }

        public string Password
        {
            get { return this.Dispatcher.Invoke(() => this.passwordTxt.Password); }
        }

        public string ErrorLogin
        {
            get { return this.Dispatcher.Invoke(() => this.lblLoginError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblLoginError.Content = value); }
        }

        public string ErrorPassword
        {
            get { return this.Dispatcher.Invoke(() => this.lblPasswordError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblPasswordError.Content = value); }
        }

        //Показывает текст ошибки
        public void ShowError(string errorMessage)
        {
            //this.lblError.Content = errorMessage;
            this.Dispatcher.Invoke(() => MessageBox.Show(errorMessage, "Error!", MessageBoxButton.OK, MessageBoxImage.Error));
        }

        public void ClearError(string error)
        {
            this.Dispatcher.Invoke(() => error = "");
        }
    }
}
