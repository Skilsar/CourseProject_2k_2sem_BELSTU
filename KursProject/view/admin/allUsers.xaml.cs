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
    /// Логика взаимодействия для allUsers.xaml
    /// </summary>
    public partial class allUsers : Page
    {
        public allUsers()
        {
            InitializeComponent();
            allUsersVM model = new allUsersVM();
            DataContext = model;
            ListUsers.ItemsSource = model.list;
        }
    }
}
