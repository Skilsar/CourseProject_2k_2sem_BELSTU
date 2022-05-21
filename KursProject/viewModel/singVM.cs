using LightBooking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LightBooking.repository;
using LightBooking.modelDB;
using System.Windows;
using LightBooking.view;
using Microsoft.Toolkit.Uwp.Notifications;

namespace LightBooking.viewModel
{
    public class singVM
    {
        public string login { get; set; }
        public string pass { get; set; }
        public Authorization Win;

        public ICommand singButton => new DelegateCommand(SingButton);
        public void SingButton()
        {
            if (login == null || pass == null)
            {
                return;
            }
            Dictionary<string, string> result = Requests.Login(login, pass);
            if (result == null)
            {
                return;
            }
            int acceslevel = int.Parse(result["status"]);
            switch (acceslevel)
            {
                case 1:
                    {
                        AdminWindow main = new AdminWindow();
                        main.Show();
                        new ToastContentBuilder().AddText("Уведомление ПУ администратора").AddText("Вы вошли как администратор!").Show();
                        break;
                    }
                case 3:
                    {
                        viewModel.accountSettingsVM.SetUser(result);
                        UserWindow main = new UserWindow();
                        main.Show();
                        new ToastContentBuilder().AddText("Уведомление").AddText("Вы успешно вошли!").Show();
                        break;
                    }
            }
            Win.Close();
        }

        public ICommand regButton => new DelegateCommand(RegButton);

        public object MainWondow { get; private set; }

        public void RegButton()
        {
            Registration Registration = new Registration();
            Registration.Show();
            Win.Close();
        }
    }

    public class currentUser{
        
    }

}
