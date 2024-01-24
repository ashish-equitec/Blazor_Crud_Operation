using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class SoftDelete
    {
        List<EmployeeSoftDeleteResult> employee = new();
        public Dictionary<int, string> result = new();
        List<GetEmployeeSkillsResult>? employeeSkills;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                employee = await EmployeeService.SoftDeleteAsync();
                foreach (var item in employee)
                {
                    employeeSkills = await EmployeeService.SkillsName(item.ID);

                    var userSkills = employeeSkills
                        .Where(skill => skill.EmployeeId == item.ID)
                        .Select(skill => skill.Skills)
                        .ToList();

                    var skillsString = string.Join(", ", userSkills);

                    result[item.ID] = skillsString;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }

        public Task NavigateToRestore(int Id)
        {
            NavigationManager.NavigateTo($"/restoreemp/{Id}");
            return Task.CompletedTask;
        }

        public void Backtolist()
        {
            NavigationManager.NavigateTo("/employeedb");
        }
    }
}
