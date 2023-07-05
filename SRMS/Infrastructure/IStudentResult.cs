using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IStudentResult
    {
        Task<StudentResultModel> GetStudentResultByRollNo(int rollNo);
    }
}
