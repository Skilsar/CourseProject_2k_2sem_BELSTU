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

namespace LightBooking
{
    /// <summary>
    /// Логика взаимодействия для booking.xaml
    /// </summary>
    public partial class searchFlights : Page
    {
        public searchFlights()
        {
            InitializeComponent();
            searchFlightsVM model = new searchFlightsVM();
            DataContext = model;
            ListFlights.ItemsSource = model.list;
        }
    }
}
