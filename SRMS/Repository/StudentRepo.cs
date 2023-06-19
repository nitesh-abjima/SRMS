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

        public Student AddStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@@RollNo", student.RollNo);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DOB", student.DOB);
                parameters.Add("@Class", student.Class);

                connection.Execute("AddStudent", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            using (var connection = _context.CreateConnection())
            {
                var students = connection.Query<Student>("GetAllStudents", commandType: CommandType.StoredProcedure);
                return students;
            }
        }
    }
}
