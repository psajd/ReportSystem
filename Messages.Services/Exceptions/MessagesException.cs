using System.Runtime.Serialization;

namespace Messages.Services.Exceptions;

public class MessagesException : Exception
{
    public MessagesException()
    {
    }

    protected MessagesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MessagesException(string message) : base(message)
    {
    }

    public MessagesException(string message, Exception innerException) : base(message, innerException)
    {
    }
}