using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel.user
{
    internal class activeOrderVM
    {
        private USER user = accountSettingsVM._user;
        public ORDER lastOrder { get; set; }
        public activeOrderVM()
        {
            lastOrder = Requests.GetLastUserOrder(user);
        }
    }
}
