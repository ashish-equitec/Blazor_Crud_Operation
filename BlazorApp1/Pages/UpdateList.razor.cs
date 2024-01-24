using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class UpdateList
    {
        List<EmployeeViewResult> employee = new();
        List<GetEmployeeSkillsResult>? employeeSkills;
        public Dictionary<int, string> result = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                employee = await emp.ExecuteStoredProcedureAsync();

                foreach (var item in employee)
                {
                    employeeSkills = await emp.SkillsName(item.ID);

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
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void NavigateToEditEmployee(int id)
        {
            NavigationManager.NavigateTo($"/editemployee/{id}");
        }
    }
}
