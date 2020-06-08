using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.UI.Contract;
using Grocery.Service.Client.Contract;
using Grocery.BLL.Entities;
using Grocery.UI.Control;
using System.Windows.Controls;
using System.Windows;

namespace Grocery.UI.Shell
{
    public class MainWindowController : IMainWindowController
    {
        private MainWindow mainWindow;
        private IViewFactory viewFactory;
        private IApp app;

        public MainWindowController(IApp app)
        {
            this.mainWindow = new MainWindow();
            this.app = app;
        }

        public void SetView(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public void LoadLogin()
        {
            mainWindow.WindowState = WindowState.Normal;
            this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.mainWindow.Show();

            this.SetElement(mainWindow, (UIElement)viewFactory.CreateViewLogin());
        }

        public void LoadMain(User user, IFrontServiceClient frontServiceClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewFactory.CreateViewMain(user, frontServiceClient));
        }

        public void LoadProduct(int id, User user, ArrivedGoods arrivedGoods, Product product, Seller seller, IFrontServiceClient frontServiceClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewFactory.CreateViewProduct(id, arrivedGoods, product, seller, user, frontServiceClient));
        }

        public void LoadSale(User user, Seller seller, IFrontServiceClient frontServiceClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewFactory.CreateViewSale(user, seller, frontServiceClient));
        }

        public void LoadReport(User user, IFrontServiceClient frontServiceClient)
        {
            this.mainWindow.Dispatcher.Invoke(() =>
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            });

            this.SetElement(mainWindow, (UIElement)viewFactory.CreateViewReport(user, frontServiceClient));
        }

        public void SetElement<T>(UIElement container, T element) where T : UIElement
        {
            ContentControl contentContainer = container as ContentControl;
            ContentControl contentElement = element as ContentControl;

            object curRegion = contentContainer.FindName("MainRegion");

            if (curRegion.GetType() == typeof(Grid))
            {
                ((Grid)curRegion).Children.Clear();
                if (contentElement != null)
                {
                    ((Grid)curRegion).Children.Add(contentElement);
                }
                return;
            }

            ContentControl regionControl = curRegion as ContentControl;
            if (contentElement != null && regionControl != null)
            {
                regionControl.Content = contentElement;
            }
        }

        public void Exit()
        {
            this.app.Exit();
        }
    }
}
