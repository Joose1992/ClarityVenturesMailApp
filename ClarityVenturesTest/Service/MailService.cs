using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using ApprovalTests;
using ApprovalTests.Reporters;
using ClarityVenturesServices.Model;
using ClarityVenturesServices.Service;
using Xunit;

namespace ClarityVenturesTest.Service;

[UseReporter(typeof(DiffReporter))]
public class MailService
{
    [Fact]
    public void SendEmail()
    {
        var user = new MailRequest() {Body = "hello", From = "josemontanez1992@gmail.com", Subject = "test", To = "jose.montanez1992@yahoo.com"};
        var mail = ClarityVenturesServices.Service.MailService.CreateMessage(user);
        Approvals.Verify(mail);
    }

  
}