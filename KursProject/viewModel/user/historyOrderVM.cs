using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel.user
{
    public class historyOrderVM
    {
        private USER user = accountSettingsVM._user;
        public List<ORDER> list { get; set; }
        public historyOrderVM()
        {
            list = Requests.GetUserOrders(user);
        }
    }
}
