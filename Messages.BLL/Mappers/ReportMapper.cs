using Messages.DAL.Models;
using MessagesBLL.Dto;

namespace MessagesBLL.Mappers;

public class ReportMapper
{
    public static ReportDto AsDto(Report report)
    {
        return new ReportDto(report.Text, report.MessageCounter, report.DateTime, report.Id);
    }
}