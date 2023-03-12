using System.Runtime.Serialization;

namespace Messages.Services.Exceptions;

public class MessagesNullArgumentException : MessagesException
{
    public MessagesNullArgumentException()
    {
    }

    protected MessagesNullArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MessagesNullArgumentException(string message) : base(message)
    {
    }

    public MessagesNullArgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }
}