using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IResultRepo
    {
        void AddResult(Result result);
        Task<IEnumerable<Result>> GetResult();
        Task<Result> GetResultById(int id );
        void EditResult(Result result);
    }
}
