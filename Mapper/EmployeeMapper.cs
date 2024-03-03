using JWTAuthentication.DTOs.Employee;
using JWTAuthentication.Entities;
using Riok.Mapperly.Abstractions;

namespace JWTAuthentication.Mapper
{
    [Mapper]
    public partial class EmployeeMapper
    {
        public partial EmployeeDTO EmployeeToEmployeeDto(Employee employee);
        public partial Employee EmployeeDtoToEmployee(EmployeeDTO employeeDTO);
    }
}
