using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.Services
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> AddUserAsync(User user);
    }
}
