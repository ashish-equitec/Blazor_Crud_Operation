#nullable disable
namespace BlazorApp1.Models;

public partial class SkillsTable
{
    public int Id { get; set; }

    public string Skills { get; set; }

    public virtual ICollection<EmpTable> Employees { get; set; } = new List<EmpTable>();
}