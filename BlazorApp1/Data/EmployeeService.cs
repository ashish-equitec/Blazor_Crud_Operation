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

        public async Task<int> AddEmployeeAsync(string Name, string DOB, string Location, string Designation, string Email_Address, string Gender, List<int>skillIds)
        {
            List <EmployeeViewResult> getResult;
            int result = await _dbConnection.Procedures.EmployeeAddAsync(Name ?? string.Empty, DOB ?? string.Empty, Location ?? string.Empty, Designation ?? string.Empty, Email_Address ?? string.Empty, Gender ?? string.Empty, true);

            int EmpId = 0;
            foreach (var employee in skillIds)
            {
                getResult = await _dbConnection.Procedures.EmployeeViewAsync();

                var employeeId = getResult.Where(emp => emp.Email_Address == Email_Address) 
                  .Select(emp => emp.ID).FirstOrDefault();
                EmpId = employeeId;
                break;
            }
            foreach (var skillId in skillIds)
            {
                await _dbConnection.Procedures.InsertEmployeeSkillsByIdAsync(EmpId, skillId);
            }

            return result;
        }
        public Task<EmpTable> GetResultAsync(int id)
        {
            var emp = _dbConnection.EmpTables.Where(x => x.Id == id).FirstOrDefault(); ;
            return Task.FromResult<EmpTable>(emp);
        }
        public async Task EditEmployeeAsync(int ID, string Name, string DOB, string Location, string Designation, string Email_Address, bool? deleted, string Gender, List<int> skillIds)
        {
            await _dbConnection.Procedures.EmployeeUpdateAsync(ID, Name, DOB, Location, Designation, Email_Address, Gender, deleted);

            List<EmployeeViewResult> getResult;

            int EmpId = 0;
            foreach (var employee in skillIds)
            {
                getResult = await _dbConnection.Procedures.EmployeeViewAsync();

                var employeeId = getResult.Where(emp => emp.Email_Address == Email_Address && emp.DOB==DOB && emp.Designation==Designation && emp.Location==Location && emp.Name==Name)
                  .Select(emp => emp.ID).FirstOrDefault();
                EmpId = employeeId;
                break;
            }
            foreach (var skillId in skillIds)
            {
                await _dbConnection.Procedures.InsertEmployeeSkillsByIdAsync(EmpId, skillId);
            }
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