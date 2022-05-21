﻿using KursProject.modelDB;
using KursProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.viewModel
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