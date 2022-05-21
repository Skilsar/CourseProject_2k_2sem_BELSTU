using LightBooking.viewModel;
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

namespace LightBooking.view
{
    /// <summary>
    /// Логика взаимодействия для allFlights.xaml
    /// </summary>
    public partial class allFlights : Page
    {
        public allFlights()
        {
            InitializeComponent();
            allFlightsVM model = new allFlightsVM();
            DataContext = model;
            ListFlights.ItemsSource = model.list;

        }
    }
}
