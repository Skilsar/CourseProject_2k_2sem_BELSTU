using LightBooking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LightBooking.services;
using System.Windows;

namespace LightBooking.viewModel
{
    internal class FeedbackVM : ViewModelBase
    {
        private string _sender { get; set; }
        public string sender { get => _sender; set { _sender = value; OnPropertyChanged("sender"); } }
        private string _theme { get; set; } 
        public string theme { get => _theme; set { _theme = value; OnPropertyChanged("theme"); } } 
        public string _message { get; set; }
        public string message { get => _message; set { _message = value; OnPropertyChanged("message"); } }

        public ICommand sendMessage => new DelegateCommand(SendFeedback);
        public void SendFeedback()
        {
            try
            {
                EmailSenderService.SendFeedback(sender, theme, message).GetAwaiter();
                sender = "";
                theme = "";
                message = "";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
