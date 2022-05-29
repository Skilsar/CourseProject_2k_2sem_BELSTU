using LightBooking.Commands;
using LightBooking.repository;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LightBooking.viewModel
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
        public bool photoTrue = false;

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

        public ICommand registrDriver => new DelegateCommand(AddDriver);
        public void AddDriver()
        {
            bool error = false;
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (Regex.Match(login, @"^[A-Za-z0-9]+([A-Za-z0-9]*|[._-]?[A-Za-z0-9]+)*$").Success == false)
                            {
                                MessageBox.Show("Ошибка в Логине\nЛогин должен содержать только буквы анлийского алфавита и цифры, без пробелов и спец. символо.");
                                error = true;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (Regex.Match(password, @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9@#!^&*.]{4,})$").Success == false)
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
                    case 4:
                        {
                            if (Regex.Match(name, @"^([А-я]+|[A-z]+)$").Success == false && Regex.Match(surname, @"^([А-я]+|[A-z]+)$").Success == false)
                            {
                                MessageBox.Show("Имя или фамилия введены неверно.\nВ имени или фамилии должны быть только буквы русского или английского алфавита\nПример: Админ или Admin");
                                error = true;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (Regex.Match(color_car, @"^([А-я]+|[A-z]+)$").Success == false)
                            {
                                MessageBox.Show("Введен неверный цвет.\nЦвет должен содержать только буквы русского или английского алфавита\nПример: Желтый или Yellow");
                                error = true;
                            }
                            break;
                        }
                }
                if (error == true) break;
            }

            if (error == false)
            {
                if (password == password2 && login != null)
                {
                    if (Requests.AddDriver(name, surname, login, password, phone, number_car, brand_car, color_car, count_seats, photo))
                    {
                        new ToastContentBuilder().AddText("Уведомление ПУ Администратора").AddText("Водитель добавлен!").Show();
                    }
                    else new ToastContentBuilder().AddText("Уведомление ПУ Администратора").AddText("ОШИБКА! Не удалось добавить водителя!").Show();

                }
                else
                {
                    new ToastContentBuilder().AddText("Уведомление ПУ Администратора").AddText("Данные введены некорректно").Show();
                }
            }
            else
            {
                new ToastContentBuilder().AddText("Уведомление").AddText("Ошибка! Данные водителя введены некорректно").Show();
            }
        }
    }
}
