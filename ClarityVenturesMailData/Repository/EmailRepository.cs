using ClarityVenturesMailData.Context;
using ClarityVenturesMailData.Model;

namespace ClarityVenturesMailData.Repository;

public class EmailRepository
{
    private readonly EmailContext _context;

    public EmailRepository(EmailContext context)
    {
        _context = context;
    }
    
    //create
    public int Create(Email email)
    {
        _context.Add(email);
        _context.SaveChanges();
        return email.Id;
    }
    //update
    public void Update(Email email)
    {
        Email existingEmail = _context.Emails.Find(email.Id)!;
        existingEmail.Id = email.Id;
        existingEmail.DateTime = email.DateTime;

        _context.SaveChanges();
    }
    //delete
    public void Delete(int id)
    {
        Email email = _context.Emails.Find(id)!;
        _context.Remove(email);
        _context.SaveChanges();
    }
    //get all
    public List<Email> GetAllEmails()
    {
        List<Email> emailsList = _context.Emails.ToList();
        return emailsList;
    }
    //get by id
    public Email GetEmailById(int id)
    {
        Email emails = _context.Emails.Find(id)!;
        return emails;
    }
}