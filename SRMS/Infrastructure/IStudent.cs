using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IStudent
    {
        Task<Student> AddStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task EditStudent(Student student);
    }
}
