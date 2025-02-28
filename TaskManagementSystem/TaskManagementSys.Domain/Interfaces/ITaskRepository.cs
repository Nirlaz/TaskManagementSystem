
using TaskManagementSystem. TaskManagementSys. API. Dto;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<string> AddTask ( Tasks task );
        Task<ICollection<Tasks?>> GetAllTaskByProjectId( Tasks task );
        Task<Tasks?> GetTaskById(Guid taskId);
        Task<string> UpdateTaskByTaskId ( Tasks task );
        Task<string> DeleteTaskById(Tasks Task);

      
    }
}
