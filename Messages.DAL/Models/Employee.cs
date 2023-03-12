namespace Messages.DAL.Models;

public class Employee
{
    public Employee()
    {
    }

    public Employee(EmployeeType employeeType, string name, string login, string password, Guid id, Guid companyId, Company company)
    {
        EmployeeType = employeeType;
        Name = name;
        Login = login;
        Password = password;
        Id = id;
        CompanyId = companyId;
        Company = company;
    }

    public EmployeeType EmployeeType { get; set; }
    public string Name { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public Guid Id { get; set; }

    public virtual Company Company { get; set; }
    public virtual Guid CompanyId { get; set; }
}