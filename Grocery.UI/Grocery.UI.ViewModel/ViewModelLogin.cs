using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.UI.Contract;
using Grocery.BLL.Entities;
using Grocery.UI.Utility;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using Grocery.Service.Client.Contract;
using System.Windows.Input;

namespace Grocery.UI.ViewModel
{
    public class ViewModelLogin : ViewModelBase, IViewModelLogin
    {
        private IViewLogin viewLogin;

        private RelayCommand enterCommand;
        private RelayCommand exitCommand;

        private IEnterValidationRule enterValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;

        public ViewModelLogin() { }

        public ViewModelLogin(IEnterValidationRule enterValidationRule, IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient)
        {
            this.validatablePropertyCollection.Add("Login");
            this.validatablePropertyCollection.Add("Password");

            this.enterValidationRule = enterValidationRule;
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
        }

        //Команда входа
        public ICommand EnterCommand
        {
            get
            {
                if (this.enterCommand == null)
                {
                    this.enterCommand = new RelayCommand(() => this.Enter(), param => this.CanEnter);
                }
                return this.enterCommand;
            }
        }

        //Команда выхода
        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand(() => this.Exit(), param => true);
                }
                return this.exitCommand;
            }
        }

        private bool CanEnter => this.IsValid;

        public IViewLogin ViewLogin
        {
            get { return this.viewLogin; }
            set { this.viewLogin = value; }
        }

        #region MainActive

        public void Enter()
        {
            try
            {
                string login = this.viewLogin.Login;
                string password = this.viewLogin.Password;
                User user = null;

                Task task = Task.Run(async () =>
                {
                    if (!this.frontServiceClient.IsConnected)
                    {
                        await this.frontServiceClient.ConnectAsync();
                        this.frontServiceClient.IsConnected = true;
                    }

                    if (this.frontServiceClient.IsConnected)
                    {
                        user = await this.frontServiceClient.EnterAsync(login, password);
                    }
                });
                task.Wait();

                if (user != null)
                {
                    this.mainWindowController.LoadMain(user, frontServiceClient);
                }
            }
            catch (Exception ex)
            {
                this.viewLogin.ShowError(ex.InnerException.Message);
            }
        }

        public void Exit()
        {
            try
            {
                if (this.frontServiceClient.IsConnected)
                {
                    Task task = Task.Run(async () =>
                    {
                        await this.frontServiceClient.DisconnectAsync();
                        this.frontServiceClient.IsConnected = false;
                    });
                    task.Wait();
                }

                if (!this.frontServiceClient.IsConnected)
                    this.mainWindowController.Exit();
            }
            catch (Exception ex)
            {
                this.viewLogin.ShowError(ex.InnerException.Message);
            }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "Login":
                    error = this.enterValidationRule.ValidateLogin(this.viewLogin.Login).GetError();
                    this.viewLogin.ErrorLogin = error;
                    break;
                case "Password":
                    error = this.enterValidationRule.ValidatePassword(this.viewLogin.Password).GetError();
                    this.viewLogin.ErrorPassword = error;
                    break;
                default:
                    this.viewLogin.ClearError(this.viewLogin.ErrorLogin);
                    this.viewLogin.ClearError(this.viewLogin.ErrorPassword);
                    break;
            }
            this.enterValidationRule.RefreshValidResult();

            return error;
        }
        #endregion
    }
}
