using EmployeeProjectManagement.Models;
using EmployeeProjectManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Controllers
{
    //Employee Controller with attribute routing
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        //Private variable declaration
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppDBContext _context;

        #region "EmployeeController Constructor"
        /// <summary>
        /// EmployeeController Constructor Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        /// <param name="context">The context.</param>
        public EmployeeController(IEmployeeRepository employeeRepository, AppDBContext context)
        {
            _employeeRepository = employeeRepository;
            this._context = context;
        }
        #endregion

        #region "Index Action Method"
        //Index Action Method calls GetEmployeeList() to listing all employees
        [Route("[action]")]
        [Route("~/")]
        public IActionResult Index()
        {
            IEnumerable<Employee> model = _employeeRepository.GetEmployeeList();
            return View(model);
        }
        #endregion

        #region "Details Action Method"
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("[action]/{id?}")]
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Employee model = _employeeRepository.GetEmployee(id);
            return View(model);
        }
        #endregion

        #region "Create action method[HttpGet]"
        //Create action method to create the new employee record [HttpGet]
        [Route("[action]/{id?}")]
        [HttpGet("Create")]
        public IActionResult Create(int id)
        {
            ViewBag.Projects = _employeeRepository.GetProjectList();
            Employee model = _employeeRepository.GetEmployee(id);
            if (model == null)
                model = new Employee();

            return View(model);
        }
        #endregion

        #region "Crete action method [HttpPost]"
        //Crete action method  to create new employee record[HttpPost]
        [Route("[action]/{id?}")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ViewBag.Projects = _employeeRepository.GetProjectList();
            if (ModelState.IsValid)
            {
                if (employee != null)
                {
                    Employee newEmployee = _employeeRepository.SaveEmployee(employee);
                    return RedirectToAction("index", new { id = newEmployee.EmployeeID });
                }
                return View();
            }
            return View();
        }
        #endregion

        #region "DeleteEmployee Action Method"
        //DeleteEmployee action method calls to DeleteEmployee() to delete employee record
        public IActionResult DeleteEmployee(int id)
        {
            return RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        }
        #endregion
    }
}