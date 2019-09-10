using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    #region "Project Class"
    //Project Class
    public class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProjectID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Project name cannot be empty")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Project name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Display(Name = "Project Description")]
        [Required(ErrorMessage = "Project description cannot be empty")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Project description must be between 10 and 500 characters")]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
    #endregion
}