using Microsoft.Extensions.Options;
using software.common.Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace software.common.Common
{
    public interface IMailService
    {
        Task SendMail(MailRequest mailRequest);
    }
    public class MailService : IMailService
    {

        private readonly MailSettings _settings;
        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }
        public void Email(string body, string subJect, string mailTO, string mailCC)
        {
            try
            {
                string[] arr_mailTo;
                string[] arr_mailCC;
                mailCC = mailCC ?? "";
                mailTO = mailTO ?? "";
                MailMessage meseage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                meseage.From = new MailAddress(_settings.Mail, _settings.DisplayName);
                if (!string.IsNullOrEmpty(mailTO))
                {
                    arr_mailTo = mailTO.Split(";");
                    foreach (var item in arr_mailTo)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }
                if (!string.IsNullOrEmpty(mailCC))
                {
                    arr_mailCC = mailCC.Split(";");
                    foreach (var item in arr_mailCC)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }

                meseage.Subject = subJect;
                meseage.IsBodyHtml = true;
                meseage.Body = body;
                smtpClient.Port = _settings.Port;
                smtpClient.Host = _settings.Host;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_settings.Mail, _settings.Password);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.SendMailAsync(meseage);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void EmailFile(string body, string filte_path, string subJect, string mailTO, string mailCC)
        {
            try
            {
                string[] arr_mailTo;
                string[] arr_mailCC;
                mailCC = mailCC ?? "";
                mailTO = mailTO ?? "";
                MailMessage meseage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                meseage.From = new MailAddress(_settings.Mail, _settings.DisplayName);
                if (!string.IsNullOrEmpty(mailTO))
                {
                    arr_mailTo = mailTO.Split(";");
                    foreach (var item in arr_mailTo)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }
                if (!string.IsNullOrEmpty(mailCC))
                {
                    arr_mailCC = mailCC.Split(";");
                    foreach (var item in arr_mailCC)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }

                Attachment attachment = new Attachment(filte_path);
                meseage.Attachments.Add(attachment);

                meseage.Subject = subJect;
                meseage.IsBodyHtml = true;
                meseage.Body = body;
                smtpClient.Port = _settings.Port;
                smtpClient.Host = _settings.Host;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_settings.Mail, _settings.Password);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.SendMailAsync(meseage);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void EmailListFile(string body, List<string> list_filte_path, string subJect, string mailTO, string mailCC)
        {
            try
            {
                string[] arr_mailTo;
                string[] arr_mailCC;
                mailCC = mailCC ?? "";
                mailTO = mailTO ?? "";
                MailMessage meseage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                meseage.From = new MailAddress(_settings.Mail, _settings.DisplayName);
                if (!string.IsNullOrEmpty(mailTO))
                {
                    arr_mailTo = mailTO.Split(";");
                    foreach (var item in arr_mailTo)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }
                if (!string.IsNullOrEmpty(mailCC))
                {
                    arr_mailCC = mailCC.Split(";");
                    foreach (var item in arr_mailCC)
                    {
                        meseage.To.Add(new MailAddress(item));
                    }
                }
                foreach (var item in list_filte_path)
                {
                    Attachment attachment = new Attachment(item);
                    meseage.Attachments.Add(attachment);
                }

                meseage.Subject = subJect;
                meseage.IsBodyHtml = true;
                meseage.Body = body;
                smtpClient.Port = _settings.Port;
                smtpClient.Host = _settings.Host;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_settings.Mail, _settings.Password);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.SendMailAsync(meseage);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task SendMail(MailRequest mailRequest)
        {
            try
            {
                Email(mailRequest.body, mailRequest.subJect, mailRequest.toEmail, mailRequest.ccEmail);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task SendMailFile(MailRequest mailRequest)
        {
            try
            {
                EmailFile(mailRequest.body, mailRequest.Attachment, mailRequest.subJect, mailRequest.toEmail, mailRequest.ccEmail);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task SendMailListFile(MailRequest mailRequest)
        {
            try
            {
                EmailListFile(mailRequest.body, mailRequest.Attachments, mailRequest.subJect, mailRequest.toEmail, mailRequest.ccEmail);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
