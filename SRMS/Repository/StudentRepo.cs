using Dapper;
using SRMS.Context;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Data;

namespace SRMS.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly DapperContext _context;

        public StudentRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@RollNo", student.RollNo);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DOB", student.DOB);
                parameters.Add("@Class", student.Class);

                await connection.ExecuteAsync("AddStudent", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

        public async Task EditStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", student.Id);
                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DOB", student.DOB);
                parameters.Add("@Class", student.Class);
                await connection.ExecuteAsync("EditStudent", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>("GetAllStudents", commandType: CommandType.StoredProcedure);
                return students;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var student = await connection.QuerySingleOrDefaultAsync<Student>("GetStudentById", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

    }
}
