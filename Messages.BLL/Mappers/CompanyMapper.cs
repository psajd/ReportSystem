using Messages.DAL.Models;
using MessagesBLL.Dto;

namespace MessagesBLL.Mappers;

public class CompanyMapper
{
    public static CompanyDto AsDto(Company company)
    {
        var employeeDtos = company.Workers.Select(EmployeeMapper.AsDto).ToList();
        var reportDtos = company.Reports.Select(ReportMapper.AsDto).ToList();
        var messageDtos = company.Messages.Select(MessageMapper.AsDto).ToList();
        return new CompanyDto(company.Name, company.Id, employeeDtos, messageDtos, reportDtos);
    }
}