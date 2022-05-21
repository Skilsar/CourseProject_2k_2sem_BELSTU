using KursProject.modelDB;
using KursProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.viewModel
{
    internal class allFlightsVM
    {
        public List<FLIGHT> list { get; set; }
        public allFlightsVM()
        {
            list = Requests.GetFlights();
        }
    }
}
