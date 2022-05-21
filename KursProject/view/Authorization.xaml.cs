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

namespace KursProject
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        singVM model;
        public Authorization()
        {
            InitializeComponent();
            model = new singVM();
            model.Win = this;
            DataContext = model;
            login.Focus();
        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox txtBox = e.Source as TextBox;
                if (txtBox != null)
                {
                    model.pass = txtBox.Text;
                    model.SingButton();
                }
            }
        }
    }
}
