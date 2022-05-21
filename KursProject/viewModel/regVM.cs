using KursProject.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KursProject.repository;
using System.Windows;
using Microsoft.Win32;

namespace KursProject.viewModel
{
    public class regVM : ViewModelBase
    {
        public string login { get; set; }
        public string password { get; set; }
        public string password2 { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string Photo { get { return photo; } set {
                photo = value;
                OnPropertyChanged("Photo");
            } }

        public regVM( Registration _win)
        {
            win = _win;
            Photo = "images/avatar.png";
        }
        Registration win;
        public ICommand registrButton => new DelegateCommand(regButton);
        public void regButton()
        {
            if (password == password2 && login != null)
                {
                    Requests.Reg(login, password, name, surname, phone, email, photo);
                }
            else
                {
                    MessageBox.Show("Данные введены некорректно");
                }

            Authorization auth = new Authorization();
            auth.Show();
            win.Close();
        }
        public ICommand logButton => new DelegateCommand(LogButton);
        public void LogButton()
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            win.Close();
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


    }
}
