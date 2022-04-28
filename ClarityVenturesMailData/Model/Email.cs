namespace ClarityVenturesMailData.Model;

public class Email
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    

    public Email(int id, DateTime dateTime)
    {
        Id = id;
        DateTime = dateTime;
    }

    public Email()
    {
        
    }
}