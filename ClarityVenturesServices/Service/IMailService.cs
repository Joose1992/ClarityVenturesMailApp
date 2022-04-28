using ClarityVenturesServices.Model;

namespace ClarityVenturesServices.Service;

public interface IMailService
{
    public void SendEmail(MailRequest mailRequest);
}