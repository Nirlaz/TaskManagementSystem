using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User?>> GetAllUser();
        Task<User?> GetUserById(Guid userId);

        Task<string> DeleteUserById(Guid userId);

        Task<bool> AddUser(User user);
    }
}
