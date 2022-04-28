using System.Net.Mail;
using System.Text;
using ClarityVenturesServices.Model;
using ClarityVenturesServices.Settings;
using Microsoft.Extensions.Options;

namespace ClarityVenturesServices.Service;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public void SendEmail(MailRequest objModelMail)
    {

        SmtpClient smtp = new SmtpClient();
        smtp.Host = _mailSettings.Host;
        smtp.Port = _mailSettings.Port;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password); // Enter seders User name and password  
        smtp.EnableSsl = true;
        smtp.Send(CreateMessage(objModelMail));
        
    }

    public static MailMessage CreateMessage(MailRequest objModelMail)
    {
                MailMessage mail = new MailMessage();
                mail.To.Add(objModelMail.To);
                mail.From = new MailAddress(objModelMail.From);
                mail.Subject = objModelMail.Subject;
                string body = objModelMail.Body;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                return mail;
    }
}