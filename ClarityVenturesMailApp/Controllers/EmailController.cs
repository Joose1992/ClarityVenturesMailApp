using ClarityVenturesMailApp.Models;
using ClarityVenturesMailData.Context;
using ClarityVenturesMailData.Model;
using ClarityVenturesServices.Model;
using ClarityVenturesServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClarityVenturesMailApp.Controllers;

public class EmailController : Controller
{
    // GET
    private readonly EmailContext _context;

    public EmailController(EmailContext context)
    {
        this._context = context;
    }
    private readonly IMailService _mailService;

    public EmailController(IMailService mailService)
    {
        this._mailService = mailService;
    }
    
    [HttpGet]
    public IActionResult SendMail()
    {
 
        return View();
    }
    [HttpPost]
    public IActionResult SendMail(MailRequest mailRequest)
    {
        _mailService.SendEmail(mailRequest);
        MailDataViewModel model = new MailDataViewModel(_context);
        Email emailLogs = new Email();
        DateTime dateTime = DateTime.Now;
        emailLogs.DateTime = dateTime;
        
        model.SaveEmail(emailLogs);
        
        
        
        return View("Succesfull");
    }
    
    
    
}