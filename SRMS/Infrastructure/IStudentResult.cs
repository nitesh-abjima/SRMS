using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IStudentResult
    {
        StudentResultModel GetStudentResultByRollNo(int rollNo);
    }
}
