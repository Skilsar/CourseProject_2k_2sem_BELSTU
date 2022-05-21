using LightBooking.Commands;
using LightBooking.view;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace LightBooking.viewModel
{
    public class adminVM : ViewModelBase
    {
        private Page currentPage
        {
            get; set;
        }

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public adminVM()
        {
            CurrentPage = new helloAdmin();
        }

        public ICommand addFlight => new DelegateCommand(AddFlight);

        public void AddFlight()
        {
            newFlight newFlight = new newFlight();
            CurrentPage = newFlight;

        }
        
        public ICommand addDriver => new DelegateCommand(AddDriver);

        public void AddDriver()
        {
            newDriver newDriver = new newDriver();
            CurrentPage = newDriver;

        }
       
        public ICommand allFlights => new DelegateCommand(HistoryFlight);

        public void HistoryFlight()
        {
            allFlights allFlights = new allFlights();
            CurrentPage = allFlights;

        }
        public ICommand newOrder => new DelegateCommand(NewOrder);

        public void NewOrder()
        {
            newOrder newOrder = new newOrder();
            CurrentPage = newOrder;

        }

        public ICommand allDrivers => new DelegateCommand(AllDrivers);
        public void AllDrivers()
        {
            allDrivers allDrivers = new allDrivers();
            CurrentPage = allDrivers;

        }
        public ICommand allClients => new DelegateCommand(AllClients);
        public void AllClients()
        {
            allUsers allUsers = new allUsers();
            CurrentPage = allUsers;

        }
        public ICommand allOrders => new DelegateCommand(AllOrders);
        public void AllOrders()
        {
            allOrders allOrders = new allOrders();
            CurrentPage = allOrders;

        }
        public ICommand logOut => new DelegateCommand(LogOut);

        public void LogOut()
        {
            Authorization auth = new Authorization();
            Application.Current.Windows[0].Close();
            new ToastContentBuilder().AddText("Уведомление ПУ администратора").AddText("Вы вышли из аккаунта администратора!").Show();
            auth.Show();
        }

        public AdminWindow win { get; set; }
        
        public ICommand goBackPage => new DelegateCommand(BackPage);

        public void BackPage()
        {
            if(win.adminFrame.CanGoBack == true)
            {
                win.adminFrame.GoBack();
            }
        }
        public ICommand goForwardPage => new DelegateCommand(ForwardPage);

        public void ForwardPage()
        {
            if(win.adminFrame.CanGoForward == true)
            {
                win.adminFrame.GoForward();
            }
        }

    }
}
