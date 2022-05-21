using KursProject.Commands;
using KursProject.repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KursProject.viewModel
{
    public class newDriverVM : ViewModelBase
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string password2 { get; set; }
        public string number_car { get; set; }
        public string brand_car { get; set; }
        public string color_car { get; set; }
        public string count_seats { get; set; }
        public string photo { get; set; }
        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged("Photo");
            }
        }

        public ICommand selectImage => new DelegateCommand(selImg);

        public void selImg()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.png;*jpg)|*png;*.jpg";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                Photo = selFileName;
            }
        }

        public ICommand registrDriver => new DelegateCommand(AddDriver);
        public void AddDriver()
        {
            if (password == password2 && login != null)
            {
                if (Requests.AddDriver(name, surname, login, password, phone, number_car, brand_car, color_car, count_seats, photo))
                {
                    MessageBox.Show("Водитель зарегистрирован");
                }
                else MessageBox.Show("ОШИБКА! Водитель не зарегистрирован");

            }
            else
            {
                MessageBox.Show("Данные введены некорректно");
            }
        }
    }
}
