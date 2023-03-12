using Messages.DAL.Models;

namespace MessagesBLL.Dto;

public class EmployeeDto
{
    public EmployeeDto(EmployeeType employeeType, string name, string login, string password, Guid id)
    {
        this.EmployeeType = employeeType;
        this.Name = name;
        this.Login = login;
        this.Password = password;
        this.Id = id;
    }

    public EmployeeType EmployeeType { get; init; }
    public string Name { get; init; }
    public string Login { get; init; }
    public string Password { get; init; }
    public Guid Id { get; init; }
}