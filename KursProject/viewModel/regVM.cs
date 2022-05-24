using LightBooking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LightBooking.repository;
using System.Windows;
using Microsoft.Win32;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Text.RegularExpressions;

namespace LightBooking.viewModel
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
        public bool photoTrue = false;

        public regVM( Registration _win)
        {
            win = _win;
            Photo = "images/avatar.png";
        }
        Registration win;
        public ICommand registrButton => new DelegateCommand(regButton);
        public void regButton()
        {
            bool error = false;
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (Regex.Match(email, @"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$").Success == false)
                            {
                                MessageBox.Show("Email не может начинаться или заканчиваться точкой\nЭлектронная почта не должна содержать пробелов в строке\nEmail не должен содержать специальных символов(<:, *, ecc)\nEmail не может содержать точки в середине почтового адреса перед символом @.\nEmail может содержать двойной домен(«.de.org» или аналогичная редкость).");
                                error = true;
                            }
                            break;
                        }
                    case 1:
                        {
                            if(Regex.Match(password, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9@#!^&*.]{4,})$").Success == false)
                            {
                                MessageBox.Show("Минимальнаяя длина пароля 4 символа.\nПароль должен содержать только английские буквы и по крайней мере одну цифру и одну букву (может содержать @#!^&*.)");
                                error = true;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (password != password2)
                            {
                                MessageBox.Show("Введенные пароли не совпадают");
                                error = true;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (Regex.Match(phone, @"^(\+375|80|375) \((29|25|44|33|17)\) [0-9]{3}-[0-9]{2}-[0-9]{2}$").Success == false)
                            {
                                MessageBox.Show("Неверный формат номера телефона\nВведите номер телефона в формате\n+375 (25|29|33|44|17) 111-11-11\n+375 (25|29|33|44|17) 111-11-11\n80 (25|29|33|44|17) 111-11-11\n");
                                error = true;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (photoTrue == false)
                            {
                                MessageBox.Show("Выберите фото профиля\nДля этого кликните по круглой иконке с изображением.");
                                error = true;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (Regex.Match(name, @"^([А-я]+|[A-z]+)$").Success == false && Regex.Match(surname, @"^([А-я]+|[A-z]+)$").Success == false)
                            {
                                MessageBox.Show("Имя или фамилия введены неверно.\nВ имени или фамилии должны быть только буквы русского или английского алфавита\nПример: Админ или Admin");
                                error = true;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (Regex.Match(login, @"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$").Success == false)
                            {
                                MessageBox.Show("Ошибка в Логине\nЛогин должен содержать только буквы анлийского алфавита и цифры, без пробелов и спец. символо.");
                                error = true;
                            }
                            break;
                        }
                }
                if (error == true) break;
            }
            if (error == false)
            {
                if (password == password2 && login != null && password != null && password != "" && login != "")
                {
                    Requests.Reg(login, password, name, surname, phone, email, photo);
                    Authorization auth = new Authorization();
                    new ToastContentBuilder().AddText("Уведомление").AddText($"Пользователь {name} успешно зарегитрирован!").Show();
                    auth.Show();
                    win.Close();
                }
                else
                {
                    new ToastContentBuilder().AddText("Уведомление").AddText("Данные регистрации введены некорректно").Show();
                }

            }
            else
            {
                new ToastContentBuilder().AddText("Уведомление").AddText("Ошибка! Данные регистрации введены некорректно").Show();
            }
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
                photoTrue = true;
            }
        }


    }
}
