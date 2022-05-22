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
    }
}
