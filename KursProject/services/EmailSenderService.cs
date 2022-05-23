using LightBooking.modelDB;
using LightBooking.viewModel;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LightBooking.services
{
    internal class EmailSenderService
    {
        public static async Task SendFeedback(string userMail, string userTheme, string userMessage)
        {
            try
            {
                MailAddress from = new MailAddress("lightbooking.by@gmail.com", "LightBooking");
                MailAddress to = new MailAddress("lightbooking.by@gmail.com");
                MailMessage message = new MailMessage(from, to);
                message.Subject = $"Обратная связь: {userTheme}";
                message.IsBodyHtml = true;
                message.Body = $"<p style=\"text-align:center; font-size:18px;\"><strong>Письмо с формы обратной связи приложения LightBooking</strong></p><div style=\"font-size:16px;\"><p><strong>Почта для ответа: </strong>{userMail}</p><p><strong>Тема сообщения:</strong> {userTheme}</p></div>";
                message.Body +=$"<div style=\"font-size:16px;\"><p><strong>Текст сообщения</strong></p><hr/><p>{userMessage}</p><hr/><p>Данное сообщение отправлено автоматически! Ответ направлять на почту {userMail}</p></div>";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("lightbooking.by@gmail.com", "vK8db8@$s$");
                smtp.EnableSsl = true;
                smtp.TargetName = "STARTTLS/smtp.gmail.com";
                await (smtp.SendMailAsync(message));
                new ToastContentBuilder().AddText("Уведомление E-Mail").AddText("Сообщение успешно отправлено!").Show();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message},\n{e.StackTrace},\n{e.InnerException},\n{e.Data}");
                new ToastContentBuilder().AddText("Уведомление E-Mail").AddText("ОШИБКА! Сообщение не отправлено! Свжитесь с администратором для устранение ошибки!").Show();
            }
        }
        
        public static async Task SendOrder(DateTime dateOrder, string timeOrder, USER user, FLIGHT flight)
        {

            try
            {
                string date = dateOrder.ToString().Substring(0, dateOrder.ToString().IndexOf(' '));
                string time = timeOrder.Substring(0, 5);
                string dateFlight = flight.date.ToString().Substring(0, dateOrder.ToString().IndexOf(' '));
                string timeFlight = flight.time.ToString().Substring(0, 5);
                MailAddress from = new MailAddress("lightbooking.by@gmail.com", "LightBooking");
                MailAddress to = new MailAddress($"{user.email}");
                MailMessage message = new MailMessage(from, to);
                message.Subject = $"Ваш заказ в приложении LightBooking #{flight.Id}";
                message.IsBodyHtml = true;
                message.Body = $"<p style=\"text-align:center; font-size:18px;\"><strong>Ваш заказ в приложении LightBooking</strong></p><div style=\"font-size:16px;\"><p><strong>Почта заказа: </strong>{user.email}</p><p><strong>Дата заказа:</strong> {date}</p><p><strong>Время заказа:</strong> {time}</p></div>";
                message.Body +=$"<div style=\"font-size:16px;\"><p><strong>Детали заказа</strong></p><hr/><p>Дата рейса: {dateFlight}</p><p>Время отправления: {timeFlight}</p><p>Направление: {flight.direction}</p><p>Имя водителя: {flight.DRIVER.name}</p><p>Фамилия водителя: {flight.DRIVER.surname}</p>";
                message.Body += $"<p>Номер автомобиля: {flight.DRIVER.number_car}</p><p>Номер водителя: {flight.DRIVER.phone_number}</p><hr/><p>Данное сообщение отправлено автоматически! Ответ направлять на почту {user.email}</p></div>";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("lightbooking.by@gmail.com", "vK8db8@$s$");
                smtp.EnableSsl = true;
                smtp.TargetName = "STARTTLS/smtp.gmail.com";
                await (smtp.SendMailAsync(message));
                //new ToastContentBuilder().AddText("Уведомление E-Mail").AddText("Сообщение успешно отправлено!").Show();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message},\n{e.StackTrace},\n{e.InnerException},\n{e.Data}");
                new ToastContentBuilder().AddText("Уведомление E-Mail").AddText("ОШИБКА! Сообщение не отправлено! Свжитесь с администратором для устранение ошибки!").Show();
            }
        }
    }
}
