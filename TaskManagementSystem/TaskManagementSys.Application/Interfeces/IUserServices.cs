
using TaskManagementSystem.TaskManagementSys.API.Dto;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.Application.Interfeces
{
    public interface IUserServices
    {
        Task<ICollection<UserDTO>> GetAllUser();
        Task<UserDTO?> GetUserById(Guid userId);

        Task<string> DeleteUserById(UserDTO userDTO);

        Task<string> AddUser(UserDTO userDTO);
    }
}
