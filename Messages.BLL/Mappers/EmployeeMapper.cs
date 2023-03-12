using Messages.DAL.Models;
using MessagesBLL.Dto;

namespace MessagesBLL.Mappers;

public class EmployeeMapper
{
    public static EmployeeDto AsDto(Employee employee)
    {
        return new EmployeeDto(
            employee.EmployeeType,
            employee.Name,
            employee.Login,
            employee.Password,
            employee.Id);
    }
}