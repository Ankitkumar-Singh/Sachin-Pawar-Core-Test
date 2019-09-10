using EmployeeProjectManagement.Repository;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace EmployeeProjectManagement.Models
{
    public class ProjectRepository : IProjectRepository
    {
        //Database object created
        private readonly AppDBContext context;

        #region "ProjectRepository Constructor"
        //ProjectRepository Constructor
        public ProjectRepository(AppDBContext context)
        {
            this.context = context;
        }
        #endregion

        #region "DeleteProject Method to Delete Project"
        //DeleteProject Method to Delete Project
        public Project DeleteProject(int Id)
        {
            Project project = context.Project.FirstOrDefault(e => e.ProjectID == Id);

            if (project != null)
            {
                context.Project.Remove(project);
                context.SaveChanges();
            }
            return project;
        }
        #endregion

        #region "GetProject Returns Project details"
        //GetProject Returns Project details
        public Project GetProject(int Id)
        {
            return context.Project.FirstOrDefault(e => e.ProjectID == Id);
        }
        #endregion

        #region "GetProjectList returns all projects"
        //GetProjectList returns all projects
        public IEnumerable<Project> GetProjectList()
        {
            return context.Project.ToList();
        }
        #endregion

        #region "SaveProject Adds/Edits Project Details"
        //SaveProject Adds/Edits Project Details
        public Project SaveProject(Project project)
        {
            if (project != null)
            {
                if (project.ProjectID == 0)
                {
                    context.Project.Add(project);
                }
                else
                {
                    Project project1 = context.Project.SingleOrDefault(e => e.ProjectID == project.ProjectID);

                    project1.Name = project.Name;
                    project1.Description = project.Description;                 
                }
                context.SaveChanges();
            }
            return project;
        }
        #endregion
    }
}