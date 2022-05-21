using KursProject.Commands;
using KursProject.modelDB;
using KursProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KursProject.viewModel
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
                
                MessageBox.Show("Рейс добавлен");
            }
            else MessageBox.Show("ОШИБКА! Не удалось добавить рейс!");

        }

        public newFlightVM()
        {
            drivers = Requests.GetDrivers(); 
        }
    }
}
    
