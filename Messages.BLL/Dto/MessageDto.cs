using Messages.DAL.Models;

namespace MessagesBLL.Dto;

public class MessageDto
{
    public MessageDto(MessageStatus messageStatus, string context, string messageSource, Guid guid)
    {
        this.Context = context;
        this.MessageSource = messageSource;
        this.Guid = guid;
        MessageStatus = messageStatus;
    }

    public MessageStatus MessageStatus { get; init; }
    public string Context { get; init; }
    public string MessageSource { get; init; }
    public Guid Guid { get; init; }
}