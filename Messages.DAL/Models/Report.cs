namespace Messages.DAL.Models;

public class Report
{
    public Report()
    {
    }

    public Report(string text, int messageCounter, DateTime dateTime, Company company, Guid companyId, Guid id)
    {
        Text = text;
        MessageCounter = messageCounter;
        DateTime = dateTime;
        Company = company;
        Id = id;
        CompanyId = companyId;
    }

    public string Text { get; set; }

    public int MessageCounter { get; set; }

    public DateTime DateTime { get; set; }

    public virtual Company Company { get; set; }

    public virtual Guid CompanyId { get; set; }
    public Guid Id { get; set; }
}