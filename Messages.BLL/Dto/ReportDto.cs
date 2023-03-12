namespace MessagesBLL.Dto;

public class ReportDto
{
    public ReportDto(string text, int messageCounter, DateTime dateTime, Guid id)
    {
        this.Text = text;
        this.MessageCounter = messageCounter;
        this.DateTime = dateTime;
        this.Id = id;
    }

    public string Text { get; init; }
    public int MessageCounter { get; init; }
    public DateTime DateTime { get; init; }
    public Guid Id { get; init; }
}