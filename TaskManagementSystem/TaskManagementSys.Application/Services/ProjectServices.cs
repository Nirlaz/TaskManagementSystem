using System.Diagnostics;
using AutoMapper;
using TaskManagementSystem.TaskManagementSys.API.Dto;

using TaskManagementSystem.TaskManagementSys.Application.Interfeces;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;
using TaskManagementSystem.TaskManagementSys.Domain.Interfaces;

namespace TaskManagementSystem.TaskManagementSys.Application.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        public ProjectServices(IProjectRepository projectRepository,IMapper mapper) {
               _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public Task<string> AddProject(Project project)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddProject(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            project.ProjectId = project.ProjectId == Guid.Empty? Guid.NewGuid() : project.ProjectId;
            Debug.WriteLine(DateTime.Now);
            if ( project. ProjectName == null )
            {
                return "Project Name Required";
            }
            return  await _projectRepository.AddProject(project);

        }

        public async Task<string> DeleteProjectById ( ProjectDTO projectDTO )
        {
            var project = _mapper.Map<Project>(projectDTO);
            return await _projectRepository. DeleteProjectById ( project. ProjectId );

        }
            
            
        public Task<IEnumerable<ProjectDTO>> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProjectDTO?>> GetProjectById(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            var result = await _projectRepository.GetProjectById(project.ProjectId);
            if(result != null)
            {
                return _mapper.Map<ICollection<ProjectDTO>>(result);
            }
            return null;
        }
    }
}
