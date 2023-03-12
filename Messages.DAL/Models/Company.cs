namespace Messages.DAL.Models;

public class Company
{
    public Company()
    {
    }

    public Company(string name, List<Employee> workers, List<Message> messages, List<Report> reports, Guid id)
    {
        Name = name;
        Workers = workers;
        Id = id;
        Messages = messages;
        Reports = reports;
    }

    public string Name { get; set; }

    public Guid Id { get; set; }

    public virtual List<Employee> Workers { get; set; } = new ();

    public virtual List<Message> Messages { get; set; } = new ();

    public virtual List<Report> Reports { get; set; } = new ();
}