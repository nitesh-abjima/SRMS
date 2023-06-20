using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IStudent
    {
        Student AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void EditStudent(Student student);
    }
}
