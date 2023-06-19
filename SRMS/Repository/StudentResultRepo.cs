using Dapper;
using Microsoft.Data.SqlClient;
using SRMS.Context;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Data;

namespace SRMS.Repository
{
    public class StudentResultRepo : IStudentResult
    {
        private readonly DapperContext _context;
        public StudentResultRepo(DapperContext context)
        {
          _context = context;
        }

        public StudentResultModel GetStudentResultByRollNo(int rollNo)
        {
            using (var connection = _context.CreateConnection())
            {

                var result = connection.QueryFirstOrDefault<StudentResultModel>("GetStudentResultByRollNo",
                    new { RollNo = rollNo },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
