using BL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeById(int id);
        void UpdateEmployee(int id, EmployeeDto employee);
        EmployeeDto CreateEmployee(EmployeeDto employee);
        IEnumerable<EmployeeDto> ListEmployees();
        void DeleteEmployee(int id);
    }
}
