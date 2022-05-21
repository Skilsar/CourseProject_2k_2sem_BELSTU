﻿using KursProject.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursProject.view
{
    /// <summary>
    /// Логика взаимодействия для allOrders.xaml
    /// </summary>
    public partial class allOrders : Page
    {
        public allOrders()
        {
            InitializeComponent();
            allOrdersVM model = new allOrdersVM();
            DataContext = model;
            ListOrders.ItemsSource = model.list;
        }
    }
}