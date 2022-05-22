using LightBooking.viewModel.user;
using System.Windows.Controls;

namespace LightBooking.view.user
{
    /// <summary>
    /// Логика взаимодействия для historyOrder.xaml
    /// </summary>
    public partial class historyOrder : Page
    {
        public historyOrder()
        {
            InitializeComponent();
            historyOrderVM model = new historyOrderVM();
            DataContext = model;
            ListOrders.ItemsSource = model.list;
        }
    }
}
