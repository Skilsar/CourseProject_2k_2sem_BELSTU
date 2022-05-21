using KursProject.modelDB;
using KursProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.viewModel
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
