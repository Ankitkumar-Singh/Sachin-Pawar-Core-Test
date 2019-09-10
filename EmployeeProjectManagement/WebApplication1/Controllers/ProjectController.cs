using EmployeeProjectManagement.Models;
using EmployeeProjectManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Controllers
{
    //ProjectController with Attribute Routing
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        //Variable Declaration
        private readonly IProjectRepository _projectRepository;
        private readonly AppDBContext _context;

        #region "ProjectController Constructor"
        //ProjectController Constructor
        public ProjectController(IProjectRepository projectRepository, AppDBContext context)
        {
            _projectRepository = projectRepository;
            this._context = context;
        }
        #endregion

        #region "Index Action Method"
        //Index Action Method Calls GetProjectList() to listing all the Projects
        [Route("[action]")]
        public IActionResult Index()
        {
            IEnumerable<Project> model = _projectRepository.GetProjectList();
            return View(model);
        }
        #endregion

        #region "Details Action Method"
        //Details Action Method Calls the GetProject() to Show Details of Selected Project
        [Route("[action]/{id?}")]
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Project model = _projectRepository.GetProject(id);
            return View(model);
        }
        #endregion

        #region "DeleteProject Action Method"
        //DeleteProject Action Method Calls the DeleteProject() to delete Selected Project
        public IActionResult DeleteProject(int id)
        {
            return RedirectToAction("Index", _projectRepository.DeleteProject(id));
        }
        #endregion

        #region "Create Action Method [HttpGet]"
        //Create Action Method to Add/Edit the Project [HttpGet]
        [Route("[action]/{id?}")]
        [HttpGet("Create")]
        public IActionResult Create(int id)
        {
            Project model = _projectRepository.GetProject(id);

            if (model == null)
                model = new Project();

            return View(model);
        }
        #endregion

        #region "Create Action Method [HttpPost]"
        //Create Action Method to Add/Edit the Project [HttpPost]
        [Route("[action]/{id?}")]
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                if (project != null)
                {
                    Project newProject = _projectRepository.SaveProject(project);
                    return RedirectToAction("index", new { id = newProject.ProjectID });
                }
                return View();
            }
            return View();
        }
        #endregion
    }
}