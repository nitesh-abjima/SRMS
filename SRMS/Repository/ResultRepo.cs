using Dapper;
using SRMS.Context;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Data;

namespace SRMS.Repository
{
    public class ResultRepo : IResultRepo

    {
        private readonly DapperContext _context;

        public ResultRepo(DapperContext context)
        {
            _context = context;
        }

        public void AddResult(Result result)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RollNo", result.RollNo);
                parameters.Add("@Maths", result.Maths);
                parameters.Add("@English", result.English);
                parameters.Add("@Science", result.Science);
                parameters.Add("@History", result.History);
                parameters.Add("@Marks", result.Marks);
                parameters.Add("@Percentage", result.Percentage);
                parameters.Add("@Decision", result.Decision);

                connection.Execute("AddResult", parameters, commandType: CommandType.StoredProcedure);
                //return result;
            }
        }

        public void EditResult(Result result)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", result.Id);
                parameters.Add("@Maths", result.Maths);
                parameters.Add("@English", result.English);
                parameters.Add("@Science", result.Science);
                parameters.Add("@History", result.History);
                parameters.Add("@Marks", result.Marks);
                parameters.Add("@Percentage", result.Percentage);
                parameters.Add("@Decision", result.Decision);
                 connection.Execute("EditResult", parameters, commandType: CommandType.StoredProcedure);
                //return result1;
            }
        }

        public IEnumerable<Result> GetResult()
        {
            using (var connection = _context.CreateConnection())
            {
                var result = connection.Query<Result>("GetResult", commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public Result GetResultById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = connection.QuerySingleOrDefault<Result>("GetResultById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
