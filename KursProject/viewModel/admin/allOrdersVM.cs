﻿using LightBooking.modelDB;
using LightBooking.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightBooking.viewModel
{
    internal class allOrdersVM
    {
        public List<ORDER> list { get; set; }
        public allOrdersVM()
        {
            list = Requests.GetOrders();
        }
    }
}