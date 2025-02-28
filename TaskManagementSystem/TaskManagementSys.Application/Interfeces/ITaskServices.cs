

using TaskManagementSystem.TaskManagementSys.API.Dto;

namespace TaskManagementSystem.TaskManagementSys.Application.Interfeces
{
    public interface ITaskServices
    {
        Task<ICollection<TaskDTO?>> GetTaskByProId ( TaskDTO taskDTO );

        Task<string> AddTaskByProjectId ( TaskDTO taskDTO );

        Task<string> DeleteTaskById ( TaskDTO taskDTO);
        Task<string> UpdateTaskByTaskId(TaskDTO taskDTO);
       

        

        
    }
}
