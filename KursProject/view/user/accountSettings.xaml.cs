using KursProject.modelDB;
using KursProject.viewModel;
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

namespace KursProject.view.user
{
    /// <summary>
    /// Логика взаимодействия для accountSettings.xaml
    /// </summary>
    public partial class accountSettings : Page
    {
        userAccauntVM model;
        public accountSettings()
        {
            InitializeComponent();
            
            model = new userAccauntVM();
            DataContext = model;
        }
    }
}
