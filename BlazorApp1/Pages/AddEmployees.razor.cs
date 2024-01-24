using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class AddEmployees
    {
        EmployeeViewResult emp = new();
        private async Task AddEmployee()
        {
            int newEmployee1 = await EmployeeService.AddEmployeeAsync(emp.Name, emp.DOB, emp.Location, emp.Designation, emp.Email_Address, emp.Gender, SkillId);
            NavigationManager.NavigateTo("/employeedb");
        }
        public void Backtolist()
        {
            NavigationManager.NavigateTo("/employeedb");
        }

        private List<GetSkilsResult> presentSkills = new();
        private List<int> SkillId = new();

        protected override async Task OnInitializedAsync()
        {
            presentSkills = await EmployeeService.GetSkils();
        }

        private void BoxSkills(int skillId)
        {
            if (SkillId.Contains(skillId))
                SkillId.Remove(skillId);
            else
                SkillId.Add(skillId);
        }

        public void OnCancel()
        {
            NavigationManager.NavigateTo("/employeedb");
        }
    }
}
