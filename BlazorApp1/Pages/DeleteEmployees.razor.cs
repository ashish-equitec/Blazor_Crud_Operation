using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class DeleteEmployees
    {
        [Parameter]
        public int Id { get; set; }
        private List<GetEmployeeByIDResult>? employeeResult { get; set; }
        private GetEmployeeByIDResult? employeeResult1 { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                employeeResult = await employeeService.GetDetails(Id);

                foreach (var result in employeeResult)
                {
                    employeeResult1 = result;   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employee details: {ex.Message}");
            }
        }
        private async Task DeleteEmployeetAsync()
        {
            try
            {
                int result = await employeeService.EmployeeDeleteAsync(Id);
                NavigationManager.NavigateTo("/employeedblistdetails");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
            }
        }
        public void OnCancel()
        {
            NavigationManager.NavigateTo("/employeedblistdetails");
        }
    }
}
