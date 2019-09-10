using EmployeeProjectManagement.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Models
{
    //EmployeeRepository Class implements IEmployeeRepository.
    public class EmployeeRepository : IEmployeeRepository
    {
        //Database object is created
        private readonly AppDBContext context;

        #region "EmployeeRepository constructor"
        /// <summary>Initializes a new instance of the <see cref="EmployeeRepository"/> class</summary>
        /// <param name="context">The context.</param>
        public EmployeeRepository(AppDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region "GetEmployeeList Method"
        /// <summary>Gets the employee list</summary>
        public IEnumerable<Employee> GetEmployeeList() => context.Employee.Include(e => e.Project);
        #endregion

        #region "GetEmployee Method"
        /// <summary>Gets the employee. </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Employee GetEmployee(int Id)
        {
            return context.Employee.FirstOrDefault(e => e.EmployeeID == Id);
        }
        #endregion

        #region "SaveEmployee Method"
        /// <summary>Saves the employee</summary>
        /// <param name="employeeChanges">The employee changes.</param>
        /// <returns></returns>
        public Employee SaveEmployee(Employee employeeChanges)
        {
            
            if (employeeChanges != null)
            {
                if (employeeChanges.EmployeeID == 0)
                {
                    context.Employee.Add(employeeChanges);
                }
                else
                {
                    Employee employee = context.Employee.SingleOrDefault(e => e.EmployeeID == employeeChanges.EmployeeID);

                    employee.FirstName = employeeChanges.FirstName;
                    employee.LastName = employeeChanges.LastName;
                    employee.Address = employeeChanges.Address;
                    employee.Email = employeeChanges.Email;
                    employee.Contact = employeeChanges.Contact;
                    employee.Gender = employeeChanges.Gender;
                    employee.DateofBirth = employeeChanges.DateofBirth;
                    employee.Department = employeeChanges.Department;
                    employee.ProjectID = employeeChanges.ProjectID;
                    employee.Status = employeeChanges.Status;
                }
                context.SaveChanges();
            }
            return employeeChanges;
        }
        #endregion
        
        #region "DeleteEmployee Method"
        /// <summary>Deletes the employee</summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Employee DeleteEmployee(int Id)
        {
            Employee employee = context.Employee.FirstOrDefault(e => e.EmployeeID == Id);

            if (employee != null)
            {
                context.Employee.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee ProjectList => throw new System.NotImplementedException();
        #endregion

        #region "GetProjectList() Method"
        //GetProjectList() Gets the project list from project table
        public List<SelectListItem> GetProjectList()
        {
            return context.Project.Select(c => new SelectListItem
            {
                Value = c.ProjectID.ToString(),
                Text = c.Name.ToString()
            }).ToList();
        }
        #endregion
    }
}