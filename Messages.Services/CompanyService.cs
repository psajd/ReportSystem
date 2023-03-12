using System.Text;
using Messages.DAL.Models;
using Messages.Services.Exceptions;
using MessagesBLL.Dto;
using MessagesBLL.Mappers;
using Microsoft.EntityFrameworkCore;
using AppContext = Messages.DAL.AppContext;

namespace Messages.Services;

public class CompanyService : IDisposable
{
    public readonly AppContext AppContext = new (new DbContextOptions<AppContext>());

    public CompanyService()
    {
    }

    public List<CompanyDto> Companies => AppContext.Companies.Select(CompanyMapper.AsDto).ToList();

    public CompanyDto CreateCompany(string name)
    {
        if (name == null)
        {
            throw new MessagesNullArgumentException();
        }

        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = name,
        };
        AppContext.Companies.Add(company);
        AppContext.SaveChanges();

        return CompanyMapper.AsDto(company);
    }

    public EmployeeDto CreateEmployee(EmployeeType employeeType, string name, string login, string password, Guid companyId)
    {
        if (name == null)
        {
            throw new MessagesNullArgumentException();
        }

        if (login == null)
        {
            throw new MessagesNullArgumentException();
        }

        if (password == null)
        {
            throw new MessagesNullArgumentException();
        }

        Company company = AppContext.Companies.FirstOrDefault(x => x.Id.Equals(companyId));
        if (company == null)
        {
            throw new MessagesNullArgumentException();
        }

        var employee = new Employee
        {
            EmployeeType = employeeType,
            Name = name,
            Login = login,
            Password = password,
            Company = company,
            CompanyId = companyId,
            Id = Guid.NewGuid()
        };

        company.Workers.Add(employee);
        AppContext.Update(company);
        AppContext.Employees.Add(employee);
        AppContext.SaveChanges();

        return EmployeeMapper.AsDto(employee);
    }

    public MessageDto WriteMessageToCompany(Guid companyId, string context, string source)
    {
        if (context == null)
        {
            throw new MessagesNullArgumentException();
        }

        if (source == null)
        {
            throw new MessagesNullArgumentException();
        }

        Company company = AppContext.Companies.FirstOrDefault(x => x.Id.Equals(companyId));
        if (company == null)
        {
            throw new MessagesNullArgumentException();
        }

        var message = new Message
        {
            MessageSource = source,
            Company = company,
            CompanyId = companyId,
            Context = context,
            Id = Guid.NewGuid()
        };

        company.Messages.Add(message);
        AppContext.Update(company);
        AppContext.Messages.Add(message);
        AppContext.SaveChanges();

        return MessageMapper.AsDto(message);
    }

    public ReportDto MakeReport(Guid companyId)
    {
        Company company = AppContext.Companies.FirstOrDefault(x => x.Id.Equals(companyId));
        if (company == null)
        {
            throw new MessagesNullArgumentException();
        }

        var report = new Report
        {
            Company = company,
            CompanyId = companyId,
            DateTime = DateTime.Now,
            Id = Guid.NewGuid(),
        };
        var stringBuilder = new StringBuilder();
        int c = 0;
        foreach (Message message in company.Messages.Where(message => message.MessageStatus == MessageStatus.Processed))
        {
            c++;
            stringBuilder.Append($"{message.Context} {message.MessageSource} {message.Answer}\n");
        }

        report.MessageCounter = c;
        report.Text = stringBuilder.ToString();

        company.Reports.Add(report);
        AppContext.Update(company);
        AppContext.Reports.Add(report);
        AppContext.SaveChanges();


        return ReportMapper.AsDto(report);
    }

    public EmployeeType GetEmployeeType(Guid companyId, string login, string password)
    {
        Company company = AppContext.Companies.FirstOrDefault(x => x.Id.Equals(companyId));
        if (company == null)
        {
            throw new MessagesNullArgumentException();
        }

        Employee employee = company.Workers.FirstOrDefault(x => x.Login == login && x.Password == password);
        return employee?.EmployeeType ?? EmployeeType.NonWorker;
    }

    public void AnswerMessage(Guid companyId, Guid messageId)
    {
        Company company = AppContext.Companies.FirstOrDefault(x => x.Id.Equals(companyId));
        if (company == null)
        {
            throw new MessagesNullArgumentException();
        }

        Message message = company.Messages.FirstOrDefault(x => x.Id.Equals(messageId));
        if (message == null)
        {
            throw new MessagesNullArgumentException();
        }

        AppContext.Update(message);
        AppContext.SaveChanges();
    }

    public void Dispose()
    {
        AppContext.Dispose();
    }
}