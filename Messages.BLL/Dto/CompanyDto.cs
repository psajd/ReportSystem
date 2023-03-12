using Messages.DAL.Models;

namespace MessagesBLL.Dto;

public class CompanyDto
{
    public CompanyDto(string name, Guid id, List<EmployeeDto> employeeDtos, List<MessageDto> messageDtos, List<ReportDto> reportDtos)
    {
        this.Name = name;
        this.Id = id;
        EmployeeDtos = employeeDtos;
        MessageDtos = messageDtos;
        ReportDtos = reportDtos;
    }

    public string Name { get; init; }
    public Guid Id { get; init; }
    public List<EmployeeDto> EmployeeDtos { get; init; }
    public List<MessageDto> MessageDtos { get; init; }
    public List<ReportDto> ReportDtos { get; init; }
}