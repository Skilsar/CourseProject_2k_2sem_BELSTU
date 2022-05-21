using LightBooking.Commands;
using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Uwp.Notifications;

namespace LightBooking.viewModel
{
    public class newFlightVM: ViewModelBase
    {

        public string direction { get; set; }
        private DateTime Date;
        public DateTime date { get => Date; set { 
                Date = value;
                OnPropertyChanged("date");
            } }
        public string time { get; set; }

        public List<DRIVER> drivers { get; set; }

        public DRIVER selectDriver { get; set; }

        public ICommand choiceDriver => new DelegateCommand(AddFlight);
        public void AddFlight()
        {
            if (Requests.AddFlight(direction, date, time, selectDriver))
            {
                new ToastContentBuilder().AddAppLogoOverride(new Uri("ms-appdata:///local/images/logo.png"),
                    ToastGenericAppLogoCrop.Circle).AddText("Уведомление для администратора").AddText("Рейс успешно добавлен!").Show();
            }
            else new ToastContentBuilder().AddText("ОШИБКА! Не удалось добавить рейс!").Show();

        }

        public newFlightVM()
        {
            drivers = Requests.GetDrivers(); 
        }
    }
}
    
