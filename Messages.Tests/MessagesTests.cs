using Messages.DAL.Models;
using Messages.Services;
using MessagesBLL.Dto;

namespace Messages.Tests;

public class Tests : IDisposable
{
    private readonly CompanyService _service = new ();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AllEntitiesCreateTest()
    {
        CompanyDto a = _service.CreateCompany("abu");

        EmployeeDto chief = _service.CreateEmployee(EmployeeType.Chief, "dabi", "chief", "1234", a.Id);
        EmployeeDto worker = _service.CreateEmployee(EmployeeType.Worker, "biba", "worker", "1234", a.Id);

        MessageDto messageDto = _service.WriteMessageToCompany(a.Id, "zalp", "email");
    }

    public void Dispose()
    {
        _service?.Dispose();
    }
}