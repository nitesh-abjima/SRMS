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

        public void EditStudent(Student student)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", student.Id);
                parameters.Add("@StudentName", student.StudentName);
                parameters.Add("@Gender", student.Gender);
                parameters.Add("@DOB", student.DOB);
                parameters.Add("@Class", student.Class);
                connection.Execute("EditStudent", parameters, commandType: CommandType.StoredProcedure);
                //return Student1;
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

        public Student GetStudentById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var student = connection.QuerySingleOrDefault<Student>("GetStudentById", parameters, commandType: CommandType.StoredProcedure);
                return student;
            }
        }
    }
}
