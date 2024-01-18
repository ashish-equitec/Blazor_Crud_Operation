﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models
{
    public partial class CRUDOPERATIONContext
    {
        private ICRUDOPERATIONContextProcedures _procedures;

        public virtual ICRUDOPERATIONContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new CRUDOPERATIONContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ICRUDOPERATIONContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSoftDeleteResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<EmployeeViewResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetEmployeeByIDResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetEmployeeSkillsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetSkilsResult>().HasNoKey().ToView(null);
        }
    }

    public partial class CRUDOPERATIONContextProcedures : ICRUDOPERATIONContextProcedures
    {
        private readonly CRUDOPERATIONContext _context;

        public CRUDOPERATIONContextProcedures(CRUDOPERATIONContext context)
        {
            _context = context;
        }

        public virtual async Task<int> EmployeeAddAsync(string Name, string DOB, string Location, string Designation, string Email_Address, string Gender, bool? Deleted, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Name",
                    Size = 50,
                    Value = Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DOB",
                    Size = 50,
                    Value = DOB ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Location",
                    Size = 100,
                    Value = Location ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Designation",
                    Size = 50,
                    Value = Designation ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Email_Address",
                    Size = 50,
                    Value = Email_Address ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Gender",
                    Size = 10,
                    Value = Gender ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Deleted",
                    Value = Deleted ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[EmployeeAdd] @Name, @DOB, @Location, @Designation, @Email_Address, @Gender, @Deleted", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> EmployeeDeleteByIDAsync(int? ID, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ID",
                    Value = ID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[EmployeeDeleteByID] @ID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<EmployeeSoftDeleteResult>> EmployeeSoftDeleteAsync(OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<EmployeeSoftDeleteResult>("EXEC @returnValue = [dbo].[EmployeeSoftDelete]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> EmployeeUpdateAsync(int? ID, string Name, string DOB, string Location, string Designation, string Email_Address, bool? Deleted, string Gender,  OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ID",
                    Value = ID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Name",
                    Size = 50,
                    Value = Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "DOB",
                    Size = 100,
                    Value = DOB ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Location",
                    Size = 100,
                    Value = Location ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Designation",
                    Size = 50,
                    Value = Designation ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Email_Address",
                    Size = 50,
                    Value = Email_Address ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Gender",
                    Size = 10,
                    Value = Gender ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "Deleted",
                    Value = Deleted ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[EmployeeUpdate] @ID, @Name, @DOB, @Location, @Designation, @Email_Address, @Gender, @Deleted", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<EmployeeViewResult>> EmployeeViewAsync(OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<EmployeeViewResult>("EXEC @returnValue = [dbo].[EmployeeView]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetEmployeeByIDResult>> GetEmployeeByIDAsync(int? ID, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ID",
                    Value = ID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetEmployeeByIDResult>("EXEC @returnValue = [dbo].[GetEmployeeByID] @ID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetEmployeeSkillsResult>> GetEmployeeSkillsAsync(int? id, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "id",
                    Value = id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetEmployeeSkillsResult>("EXEC @returnValue = [dbo].[GetEmployeeSkills] @id", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetSkilsResult>> GetSkilsAsync(OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetSkilsResult>("EXEC @returnValue = [dbo].[GetSkils]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> RestoreDAsync(int? ID, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ID",
                    Value = ID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[RestoreD] @ID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
