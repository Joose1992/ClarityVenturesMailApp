using ClarityVenturesMailData.Context;
using ClarityVenturesMailData.Model;
using ClarityVenturesMailData.Repository;

namespace ClarityVenturesMailApp.Models;

public class MailDataViewModel
{
    private readonly EmailRepository _repo;
    public List<Email> EmailList { get; set; }
    public Email CurrentEmail { get; set; }
    

    public MailDataViewModel(EmailContext context)
    {
        _repo = new EmailRepository(context);
        EmailList = GetAllEmails();
        CurrentEmail = EmailList.FirstOrDefault()!;
    }

    public MailDataViewModel(EmailContext context, int id)
    {
        _repo = new EmailRepository(context);
        EmailList = GetAllEmails();
        CurrentEmail = id > 0 ? GetEmail(id) : new Email();
    }

    public void SaveEmail(Email email)
    {
        if (email.Id > 0)
        {
            _repo.Update(email);
        }
        else
        {
            email.Id = _repo.Create(email);
        }

        EmailList = GetAllEmails();
        CurrentEmail = GetEmail(email.Id);
    }

    public void RemoveEmail(int id)
    {
        _repo.Delete(id);
        EmailList = GetAllEmails();
        CurrentEmail = EmailList.FirstOrDefault()!;
    }
    
    private List<Email> GetAllEmails()
    {
        return _repo.GetAllEmails();
    }
    
    private Email GetEmail(int id)
    {
        return _repo.GetEmailById(id);
    }
}