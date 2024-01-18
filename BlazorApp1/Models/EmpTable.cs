
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models;

public partial class EmpTable
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "DOB is required")]
    public string Dob { get; set; }

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Designation is required")]
    public string Designation { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email_Address { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }

    public int Id { get; set; }
    public virtual ICollection<SkillsTable> Skills { get; set; } = new List<SkillsTable>();
}