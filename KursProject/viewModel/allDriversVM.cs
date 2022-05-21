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
    internal class allDriversVM: ViewModelBase
    {
        public List<DRIVER> list { get; set; }
        public allDriversVM()
        {
            list = Requests.GetDrivers();
        }
        private DRIVER Sel;
        public DRIVER sel { get => Sel; set { 
                Sel = value;
                OnPropertyChanged("sel");
            } }

    }
}
