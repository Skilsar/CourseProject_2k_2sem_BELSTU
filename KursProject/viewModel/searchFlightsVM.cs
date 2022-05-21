using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel
{
    internal class searchFlightsVM
    {
        public List<FLIGHT> list { get; set; }
        public searchFlightsVM()
        {
            list = Requests.GetFlights();
        }
    }
}
