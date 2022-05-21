using KursProject.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KursProject.repository;
using KursProject.modelDB;
using System.Windows;
using KursProject.view;
using Microsoft.Toolkit.Uwp.Notifications;

namespace KursProject.viewModel
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
                        break;
                    }
                case 3:
                    {
                        viewModel.accountSettingsVM.SetUser(result);
                        UserWindow main = new UserWindow();
                        main.Show();
                        break;
                    }
            }
            Win.Close();
            new ToastContentBuilder().AddText("Уведомление").AddText("Вы успешно вошли!").Show();
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
