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
    internal class FeedbackVM
    {
        public string sender { get; set; }
        public string theme { get; set; } 
        public string message { get; set; }

        public ICommand sendMessage => new DelegateCommand(SendFeedback);
        public void SendFeedback()
        {
            try
            {
                EmailSenderService.SendFeedback(sender, theme, message).GetAwaiter();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
