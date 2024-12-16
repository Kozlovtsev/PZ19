using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_19.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly LastBd1Context _context = new LastBd1Context();

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _context.Users.ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (!_context.Users.Local.Any(x => x.UserId == user.UserId))
            {
                _context.Users.Attach(user);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
