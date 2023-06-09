using Dapper;
using SRMS.Context;
using SRMS.Infrastructure;
using SRMS.Models;
using System.Data;
using System.Data.Common;

namespace SRMS.Repository
{
    public class UserAccess : IUserAccess
    {
        private readonly DapperContext _context;

        public UserAccess(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginUser(string username, string password, string usertype)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                parameters.Add("@Password", password);
                parameters.Add("@UserType", usertype);
                parameters.Add("@LoginSuccess", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("LoginUser", parameters, commandType: CommandType.StoredProcedure);
                bool loginSuccess = parameters.Get<bool>("@LoginSuccess");

                return loginSuccess;
            }
        }

        public async Task<bool> SignupUser(Users user)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@UserType", user.UserType);
                parameters.Add("@SignupSuccess", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("SignupUser", parameters, commandType: CommandType.StoredProcedure);
                bool signupSuccess = parameters.Get<bool>("@SignupSuccess");

                return signupSuccess;
                
            }   
        }
    }

}
//{
//    var query = "SELECT * FROM Companies";
//    using (var connection = _context.CreateConnection())
//    {
//        var companies = await connection.QueryAsync<Company>(query);
//        return companies.ToList();
//    }
//}