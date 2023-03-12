using Messages.Console;
using Messages.DAL.Models;
using Messages.Services;
using MessagesBLL.Dto;

const string adminLogin = "admin";
const string adminPassword = "password";

var companyService = new CompanyService();

CompanyDto a = companyService.CreateCompany("abu");
Console.WriteLine($"company id = {a.Id}");

EmployeeDto chief = companyService.CreateEmployee(EmployeeType.Chief, "dabi", "chief", "1234", a.Id);
Console.WriteLine($"chief id = {chief.Id}");

EmployeeDto worker = companyService.CreateEmployee(EmployeeType.Worker, "biba", "worker", "1234", a.Id);
Console.WriteLine($"chief id = {worker.Id}");

MessageDto messageDto = companyService.WriteMessageToCompany(a.Id, "zalp", "email");
Console.WriteLine($"chief id = {messageDto.Guid}");


Console.WriteLine("write login and password");
var consoleInterface = new ConsoleInterface(companyService);
string login = Console.ReadLine();
string password = Console.ReadLine();

while (true)
{
    if (login == adminLogin && password == adminPassword)
    {
        consoleInterface.ChoseAdminCommand();
    }
    else if (companyService.GetEmployeeType(a.Id, login, password) == EmployeeType.Chief)
    {
        consoleInterface.ChoseChiefCommand();
    }
    else if (companyService.GetEmployeeType(a.Id, login, password) == EmployeeType.Worker)
    {
        consoleInterface.ChoseWorkerCommand();
    }
}