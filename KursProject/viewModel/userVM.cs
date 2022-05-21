using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using KursProject.repository;
using System.Windows;
using Microsoft.Win32;
using KursProject.Commands;
using KursProject.view.user;
using KursProject.view;
using KursProject.modelDB;
using Microsoft.Toolkit.Uwp.Notifications;

namespace KursProject.viewModel
{
    public class userVM : ViewModelBase
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

        private USER user = accountSettingsVM._user;
        public string photo
        {
            get => user.photo; set
            {
                user.photo = value;
                OnPropertyChanged("photo");
            }
        }
        public string name
        {
            get => user.name; set
            {
                user.name = value;
                OnPropertyChanged("name");
            }
        }

        public userVM(){
            CurrentPage = new searchFlights();
        }

        public ICommand accountSettings => new DelegateCommand(AccountSettings);

        public void AccountSettings()
        {
            accountSettings accountSettings = new accountSettings();
            CurrentPage = accountSettings;

        }
        public ICommand activeOrder => new DelegateCommand(ActiveOrder);

        public void ActiveOrder()
        {
            activeOrder activeOrder = new activeOrder();
            CurrentPage = activeOrder;

        }
        public ICommand Feedback => new DelegateCommand(FeedbackPage);

        public void FeedbackPage()
        {
            Feedback feedback = new Feedback();
            CurrentPage = feedback;

        }
        public ICommand historyOrder => new DelegateCommand(HistoryOrder);

        public void HistoryOrder()
        {
            historyOrder historyOrder = new historyOrder();
            CurrentPage = historyOrder;

        }
        
        public ICommand searchFlights => new DelegateCommand(SearchFlights);

        public void SearchFlights()
        {
            searchFlights searchFlights = new searchFlights();
            CurrentPage = searchFlights;

        }

        public UserWindow win { get; set; }

        public ICommand goBackPage => new DelegateCommand(BackPage);

        public void BackPage()
        {
            if (win.userFrame.CanGoBack == true)
            {
                win.userFrame.GoBack();
            }
        }
        public ICommand goForwardPage => new DelegateCommand(ForwardPage);

        public void ForwardPage()
        {
            if (win.userFrame.CanGoForward == true)
            {
                win.userFrame.GoForward();
            }
        }

        public ICommand logOut => new DelegateCommand(LogOut);

        public void LogOut()
        {
            Authorization auth = new Authorization();
            Application.Current.Windows[0].Close();
            new ToastContentBuilder().AddText("Уведомление").AddText("Вы вышли из аккаунта!").Show();
            auth.Show();
        }

    }
}
