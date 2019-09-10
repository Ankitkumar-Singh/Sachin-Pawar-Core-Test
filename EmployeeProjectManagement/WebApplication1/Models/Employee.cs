using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    #region "Employee Class"
    //Employee Class
    public class Employee
    {
        //Field from Employee table
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"([a-zA-Z]{3,20}\s*)+", ErrorMessage = "First name contains only characters between 3 to 20")]
        [Required(ErrorMessage = "First name cannot be empty")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"([a-zA-Z]{3,20}\s*)+", ErrorMessage = "Last name contains only characters between 3 to 20")]
        [Required(ErrorMessage = "Last name cannot be empty")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters")]
        public string Address { get; set; }

        [Display(Name = "Email-ID")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$", ErrorMessage = "Email address should be in the format abc@abc.test.com")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Contact cannot be empty")]
        [RegularExpression(@"^\(?([0-9]{3})\)?([0-9]{3})?([0-9]{4})$", ErrorMessage = "Contact contains only numbers and 10 digits")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? DateofBirth { get; set; }

        [Display(Name = "Status of Employee")]
        [Required(ErrorMessage = "Please select employee status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please select department")]
        public Department Department { get; set; }

        [Display(Name = "Project Title")]
        [Required(ErrorMessage = "Project name cannot be empty")]
        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
    #endregion

    #region "Enum Department"
    //Enum Department
    public enum Department
    {
        Web = 1,
        Mobility = 2,
        Support = 3
    }
    #endregion
}