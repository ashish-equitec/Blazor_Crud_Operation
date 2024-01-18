namespace BlazorApp1.Models
{
    public partial interface ICRUDOPERATIONContextProcedures
    {
        Task<int> EmployeeAddAsync(string Name, string DOB, string Location, string Designation, string Email_Address, string Gender, bool? Deleted, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeDeleteByIDAsync(int? ID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeSoftDeleteResult>> EmployeeSoftDeleteAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeUpdateAsync(int? ID, string Name, string DOB, string Location, string Designation, string Email_Address, bool? Deleted, string Gender, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeViewResult>> EmployeeViewAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetEmployeeByIDResult>> GetEmployeeByIDAsync(int? ID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetEmployeeSkillsResult>> GetEmployeeSkillsAsync(int? id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetSkilsResult>> GetSkilsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> RestoreDAsync(int? ID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
