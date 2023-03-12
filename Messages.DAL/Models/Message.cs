namespace Messages.DAL.Models;

public class Message
{
    public Message()
    {
    }

    public Message(MessageStatus messageStatus, string context, string messageSource, Company company, Guid companyId, Guid id, string answer)
    {
        Context = context;
        MessageSource = messageSource;
        Id = id;
        Answer = answer;
        MessageStatus = messageStatus;
        Company = company;
        CompanyId = companyId;
    }

    public MessageStatus MessageStatus = MessageStatus.New;
    public string Context { get; set; }
    public string Answer { get; set; } = "";
    public string MessageSource { get; set; }
    public virtual Company Company { get; set; }
    public virtual Guid CompanyId { get; set; }
    public Guid Id { get; set; }
}