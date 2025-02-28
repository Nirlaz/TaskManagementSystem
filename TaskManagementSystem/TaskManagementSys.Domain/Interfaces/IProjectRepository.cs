
using TaskManagementSystem. TaskManagementSys. Domain. Entites;

namespace TaskManagementSystem. TaskManagementSys. Domain. Interfaces
{
    public interface IProjectRepository
    {
        Task<ICollection<Project?>> GetProjectById ( Guid projectId );
        Task<string> AddProject ( Project project );
        Task<string> DeleteProjectById( Guid projectId );


    }
}
