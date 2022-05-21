using KursProject.Commands;
using KursProject.modelDB;
using KursProject.repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursProject.viewModel
{
    public class userAccauntVM: ViewModelBase
    {
        private USER user = accountSettingsVM._user;
        public string photo { get => user.photo; set{ 
                user.photo = value;
                OnPropertyChanged("photo");
            } }
        public string name {
            get => user.name; set
            {
                user.name = value;
                OnPropertyChanged("name");
            }
        }
        public string surname {
            get => user.surname; set
            {
                user.surname = value;
                OnPropertyChanged("surname");
            }
        }
        public string phone {
            get => user.phone_number; set
            {
                user.phone_number = value;
                OnPropertyChanged("phone");
            }
        }
        public string email {
            get => user.email; set
            {
                user.email = value;
                OnPropertyChanged("email");
            }
        }
        private string Password;
        public string password
        {
            get => Password; set
            {
                Password = value;
                OnPropertyChanged("password");
            }
        }
        private string Password2;
        public string password2
        {
            get => Password2; set
            {
                Password2 = value;
                OnPropertyChanged("password2");
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
                photo = selFileName;
            }
        }

        public ICommand save => new DelegateCommand(Save);

        public void Save()
        {
            if(password == password2)
            {
                if (Requests.UpdateUser(user, password))
                {
                    //что напиши
                }
            }
        }
    }
}
