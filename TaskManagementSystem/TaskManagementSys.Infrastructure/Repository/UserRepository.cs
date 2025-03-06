using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;
using TaskManagementSystem.TaskManagementSys.Domain.Interfaces;
using TaskManagementSystem.TaskManagementSys.Infrastructure.Database;

namespace TaskManagementSystem.TaskManagementSys.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string> DeleteUserById(Guid userId)
        {
           
                var user = await GetUserById(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return "Data Deleted Succesfully";
                }
                return "Data Dont Exist";

            
        }

        public async Task<ICollection<User?>> GetAllUser()
        {
            return await _context.Users
                      .Include(u => u.Projects)
                      .ThenInclude(u => u.Taskses)
                      .ToListAsync();
        }

        public async Task<User?> GetUserById(Guid userId)
        {
  
            var userData = await _context.Users.Include(u => u.Projects).ThenInclude(u => u.Taskses).FirstOrDefaultAsync(u => u.UserId == userId);
    
            return userData;


        }

        public async Task<string> UpdateUserById ( User user )
        {
            var userData = await _context.Users.FirstOrDefaultAsync(u=>u.UserId==user.UserId);
            if ( userData != null )
            {
                userData. UserName = user. UserName;
                _context. Users. Update ( userData );
                await _context. SaveChangesAsync ( );
                return "User Updated Succesfully";

            }
            return "User don't exist";
        }
    }
}
