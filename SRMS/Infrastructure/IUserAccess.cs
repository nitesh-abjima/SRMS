using SRMS.Models;

namespace SRMS.Infrastructure
{
    public interface IUserAccess
    {
        Task<bool> SignupUser(Users user);
        Task<bool> LoginUser(string username, string password, string usertype);

    }
}
