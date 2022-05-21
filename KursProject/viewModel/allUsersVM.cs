using KursProject.Commands;
using KursProject.modelDB;
using KursProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursProject.viewModel
{
    internal class allUsersVM : ViewModelBase
    {
        private List<USER> List;
        public List<USER> list { get => List; set { 
                List = value;
                OnPropertyChanged("list");
            } }
        public allUsersVM()
        {
            list = Requests.GetUsers();
        }
        private USER User;
        public USER user
        {
            get => User; set
            {
                User = value;
                OnPropertyChanged("User");
            }
        }

        public ICommand delete => new DelegateCommand(Delete);
        public void Delete()
        {
            if (Requests.DeleteUser(user))
            {
                list = Requests.GetUsers();
            }
        }
    }
}
