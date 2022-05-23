using LightBooking.modelDB;
using LightBooking.viewModel.user;
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

namespace LightBooking.view.user
{
    /// <summary>
    /// Логика взаимодействия для activeOrder.xaml
    /// </summary>
    public partial class activeOrder : Page
    {
        //public DateTime date { get; set; }

        //public TimeSpan time { get; set; }
        public List<ORDER> list { get; set; }
        public activeOrder()
        {
            InitializeComponent();
            activeOrderVM model = new activeOrderVM();
            DataContext = model;
            LastOrder.ItemsSource = list;
            LastOrder.Items.Add(model.lastOrder);
        }
    }
}
