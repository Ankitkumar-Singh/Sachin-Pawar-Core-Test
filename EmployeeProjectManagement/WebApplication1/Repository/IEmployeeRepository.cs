using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Repository
{
    #region "IEmployeeRepository Interface"
    //IEmployeeRepository Interface contains methods declaration
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployee(int Id);
        Employee SaveEmployee(Employee employeeChanges);
        Employee DeleteEmployee(int Id);
        List<SelectListItem> GetProjectList();
    }
    #endregion
}