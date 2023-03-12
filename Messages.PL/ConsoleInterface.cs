using Messages.DAL.Models;
using Messages.Services;
using MessagesBLL.Dto;
using static System.Console;

namespace Messages.Console;

public class ConsoleInterface
{
    private readonly CompanyService _service;

    public ConsoleInterface(CompanyService service)
    {
        _service = service;
    }

    public void ChoseAdminCommand()
    {
        WriteLine("input cmd");
        string cmd = ReadLine();
        switch (cmd)
        {
            case "1":
                WriteLine("input employee type, name, login, password");
                EmployeeType employeeType = ReadLine() switch
                {
                    "chief" => EmployeeType.Chief,
                    "worker" => EmployeeType.Worker,
                    _ => EmployeeType.NonWorker
                };
                _service.CreateEmployee(employeeType, ReadLine(), ReadLine(), ReadLine(), Guid.NewGuid());
                break;
            case "2":
                WriteLine("input company id, message context and source");
                _service.WriteMessageToCompany(new Guid(ReadLine() ?? throw new InvalidOperationException()), ReadLine(), ReadLine());
                break;
            case "3":
                foreach (CompanyDto serviceCompany in _service.Companies)
                {
                    WriteLine($"\t Company Name = {serviceCompany.Name}\n" +
                              $"\t CompanyId = {serviceCompany.Id}");

                    WriteLine("=============");
                    foreach (EmployeeDto serviceCompanyEmployeeDto in serviceCompany.EmployeeDtos)
                    {
                        WriteLine($"\t \t Employee name = {serviceCompanyEmployeeDto.Name}\n" +
                                  $"\t \t Employee type = {serviceCompanyEmployeeDto.EmployeeType}\n" +
                                  $"\t \t Employee login = {serviceCompanyEmployeeDto.Login}\n" +
                                  $"\t \t Employee password = {serviceCompanyEmployeeDto.Password}\n" +
                                  $"\t \t Employee id  = {serviceCompanyEmployeeDto.Id}");
                    }

                    WriteLine("=============");
                    foreach (MessageDto serviceCompanyMessageDto in serviceCompany.MessageDtos)
                    {
                        WriteLine($"\t \t Message guid = {serviceCompanyMessageDto.Guid}\n" +
                                  $"\t \t Message status = {serviceCompanyMessageDto.MessageStatus}\n" +
                                  $"\t \t Message Text = {serviceCompanyMessageDto.Context}");
                    }

                    WriteLine("=============");
                    foreach (ReportDto serviceCompanyReportDto in serviceCompany.ReportDtos)
                    {
                        WriteLine($"\t \t Report id = {serviceCompanyReportDto.Id}\n" +
                                  $"\t \t Report text = {serviceCompanyReportDto.Text}\n" +
                                  $"\t \t Report text = {serviceCompanyReportDto.DateTime}");
                    }
                }

                break;
        }
    }

    public void ChoseChiefCommand()
    {
        WriteLine("input company id, message id");
        _service.AnswerMessage(new Guid(ReadLine() ?? throw new InvalidOperationException()), new Guid(ReadLine() ?? throw new InvalidOperationException()));
    }

    public void ChoseWorkerCommand()
    {
        WriteLine("input company id");
        _service.MakeReport(new Guid(ReadLine() ?? throw new InvalidOperationException()));
    }
}