using Messages.DAL.Models;
using MessagesBLL.Dto;

namespace MessagesBLL.Mappers;

public class MessageMapper
{
    public static MessageDto AsDto(Message message)
    {
        return new MessageDto(message.MessageStatus, message.Context, message.MessageSource, message.Id);
    }
}