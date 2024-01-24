using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class EditEmloyess
    {
        private GetEmployeeByIDResult employee = new();
        private EmpTable model = new();

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                int employeeId = Id;
                model = await EmployeeService.GetResultAsync(employeeId);
                employee = new();
                employee.ID = model.Id;
                employee.Name = model.Name;
                employee.DOB = model.Dob;
                employee.Email_Address = model.EmailAddress;
                employee.Location = model.Location;
                employee.Designation = model.Designation;
                employee.Gender = model.Gender;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employee data: {ex.Message}");
            }

            presentSkills = await EmployeeService.GetSkils();
        }

        private async Task UpdateEmployee()
        {
            try
            {
                await EmployeeService.EditEmployeeAsync(
                    employee.ID,
                    employee.Name,
                    employee.DOB,
                    employee.Location,
                    employee.Designation,
                    employee.Email_Address,
                    employee.Deleted = true,
                    employee.Gender,
                    SkillId
              );

                NavigationManager.NavigateTo("/employeedb");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
            }
        }
        private List<GetSkilsResult> presentSkills = new();
        private List<int> SkillId = new();

        private void BoxSkills(int skillId)
        {
            if (SkillId.Contains(skillId))
                SkillId.Remove(skillId);
            else
                SkillId.Add(skillId);
        }
        public void OnCancel()
        {
            NavigationManager.NavigateTo("/employeedblist");
        }
    }
}
