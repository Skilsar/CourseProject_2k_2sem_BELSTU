using LightBooking.modelDB;
using LightBooking.repository;
using LightBooking.viewModel;
using Microsoft.Toolkit.Uwp.Notifications;
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

namespace LightBooking
{
    /// <summary>
    /// Логика взаимодействия для booking.xaml
    /// </summary>
    public partial class searchFlights : Page
    {
        public DateTime date = DateTime.Now;
        public string time = DateTime.Now.TimeOfDay.ToString();
        private USER user = accountSettingsVM._user;

        public searchFlights()
        {
            InitializeComponent();
            historyFlightsVM model = new historyFlightsVM();
            DataContext = model;
            ListFlights.ItemsSource = model.list;
        }

        public void newOrder(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            FLIGHT selectedFlight = button.DataContext as FLIGHT;
            time.Substring(0, time.IndexOf('.'));


            if (Requests.AddOrder(date, time.ToString(), user, selectedFlight)){
                new ToastContentBuilder().AddText("Уведомление").AddText("Заказ успешно оформлен").Show();
            }
            else new ToastContentBuilder().AddText("Уведомление").AddText("ОШИБКА! Не удалось оформить заказ!").Show();
        }
    }
}
