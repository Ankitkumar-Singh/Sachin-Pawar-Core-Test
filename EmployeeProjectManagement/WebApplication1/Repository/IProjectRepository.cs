using System.Collections.Generic;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Repository
{
    #region "IProjectRepository Interface"
    //IProjectRepository Interface
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjectList();
        Project GetProject(int Id);
        Project DeleteProject(int Id);
        Project SaveProject(Project project);
    }
    #endregion
}
