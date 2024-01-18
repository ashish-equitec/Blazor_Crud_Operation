using BlazorApp1.Models;

namespace BlazorApp1.Data
{
    public class EmployeeService
    {
        private readonly CRUDOPERATIONContext _dbConnection;

        public EmployeeService(CRUDOPERATIONContext dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<List<EmployeeViewResult>> ExecuteStoredProcedureAsync()
        {
            return await _dbConnection.Procedures.EmployeeViewAsync();
        }

        public async Task<int> AddEmployeeAsync(EmployeeViewResult emp)
        {
            int result = await _dbConnection.Procedures.EmployeeAddAsync(emp.Name ?? string.Empty, emp.DOB ?? string.Empty, emp.Location ?? string.Empty, emp.Designation ?? string.Empty, emp.Email_Address ?? string.Empty, emp.Gender ?? string.Empty, true);

            return result;
        }
        public async Task<EmpTable> GetResultAsync(int id)
        {
            var emp = _dbConnection.EmpTables.Where(x => x.Id == id).FirstOrDefault(); ;
            return emp;

        }
        public async Task EditEmployeeAsync(int ID, string Name, string DOB, string Location, string Designation, string Email_Address, bool? deleted, string Gender, OutputParameter<int>? returnValue = null)
        {
            await _dbConnection.Procedures.EmployeeUpdateAsync(ID, Name, DOB, Location, Designation, Email_Address, deleted, Gender);
        }


        public async Task<int> EmployeeDeleteAsync(int Id)
        {
            try
            {
                int result = await _dbConnection.Procedures.EmployeeDeleteByIDAsync(Id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return -1;
            }
        }
        public async Task<List<EmployeeSoftDeleteResult>> SoftDeleteAsync()
        {
            var result = await _dbConnection.Procedures.EmployeeSoftDeleteAsync();
            return result;
        }

        public async Task<int> EmployeeRestoretAsync(int Id)
        {
            int result = await _dbConnection.Procedures.RestoreDAsync(Id); 
            return result;
        }

        public async Task<List<GetEmployeeSkillsResult>> SkillsName(int Id)
        {
            return await _dbConnection.Procedures.GetEmployeeSkillsAsync(Id);
        }

        public async Task<List<GetSkilsResult>> GetSkils()
        {
            return await _dbConnection.Procedures.GetSkilsAsync();
        }
    }
}