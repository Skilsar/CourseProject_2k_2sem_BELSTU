using LightBooking.Commands;
using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LightBooking.viewModel
{
    internal class allFlightsVM : ViewModelBase
    {
        private ComboBoxItem _selectDirection;
        public ComboBoxItem selectDirection { get => _selectDirection; set { _selectDirection = value; OnPropertyChanged("selectDirection"); } }

        private DateTime _date;
        public DateTime date { get => _date; set { _date = value; OnPropertyChanged("date"); } }
        private List<FLIGHT> _list { get; set; }
        private List<FLIGHT> fulllist;
        public List<FLIGHT> list { get => _list; set { _list = value; OnPropertyChanged("list"); } }
        public allFlightsVM()
        {
            list = Requests.GetFlights();
            fulllist = list;
        }

        public ICommand SearchFlight => new DelegateCommand(_SearchFlight);

        public void _SearchFlight()
        {
            list = fulllist;
            if (_selectDirection != null)
            {
                list = list.Where(x => x.direction == _selectDirection.Content.ToString()).ToList();
            }
            if (_date != null)
            {
                list = list.Where(x => x.date == _date).ToList();
            }
        }

        public view.allFlights allFlights
        {
            get => default;
            set
            {
            }
        }
    }
}
