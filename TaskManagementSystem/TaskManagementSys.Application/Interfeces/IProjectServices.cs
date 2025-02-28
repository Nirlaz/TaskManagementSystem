
using TaskManagementSystem.TaskManagementSys.API.Dto;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.Application.Interfeces
{
    public interface IProjectServices

    {
        Task<IEnumerable<ProjectDTO>> GetAllProject();
        Task<ICollection<ProjectDTO?>> GetProjectByUserId ( ProjectDTO projectDTO);
        Task<ProjectDTO?> GetProjectByProId ( Guid projectId );

        Task<string> DeleteProjectById(ProjectDTO projectDTO);

        Task<string> AddProject(ProjectDTO projectDTO);
    }
}
