using LightBooking.modelDB;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class newFlight : Page
    {
        newFlightVM model;
        public newFlight()
        {
            InitializeComponent();
            model = new newFlightVM();
            DataContext = model;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.selectDriver = SelectDrivers.SelectedItem as DRIVER;
        }

        private void selectDirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)selectDirection.SelectedItem;
            model.direction = item.Content.ToString();
        }

        //private void datePicker1_SourceUpdated(object sender, DataTransferEventArgs e)
        //{
        //    model.date = datePicker1.SelectedDate.Value;
        //}
    }
}
