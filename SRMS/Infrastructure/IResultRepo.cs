using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IResultRepo
    {
        void AddResult(Result result);
        IEnumerable<Result> GetResult();
        Result GetResultById(int id );
        void EditResult(Result result);
    }
}
