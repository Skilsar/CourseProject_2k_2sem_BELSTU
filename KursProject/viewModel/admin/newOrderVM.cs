using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel.admin
{
    public class newOrderVM : ViewModelBase
    {
        public List<FLIGHT> flights { get; set; }

        public newOrderVM()
        {
            flights = Requests.GetFlights();
        }
    }
}
