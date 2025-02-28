using System. Runtime. InteropServices;
using Microsoft. EntityFrameworkCore;
using TaskManagementSystem. TaskManagementSys. API. Dto;
using TaskManagementSystem. TaskManagementSys. Domain. Entites;
using TaskManagementSystem. TaskManagementSys. Domain. Interfaces;
using TaskManagementSystem. TaskManagementSys. Infrastructure. Database;

namespace TaskManagementSystem. TaskManagementSys. Infrastructure. Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ProjectRepository _projectRepository;
        public TaskRepository ( ApplicationDbContext context , ProjectRepository projectRepository )
        {
            _context = context;
            _projectRepository = projectRepository;
        }
        public async Task<string> AddTask ( Tasks task )
        {
            var existingTask =  await _context.Taskses.FindAsync(task.TaskId);
            if ( existingTask != null )
            {
                return "TaskExist";
            }
            await _context. Taskses. AddAsync ( task );
            await _context. SaveChangesAsync ( );
            return "Task Added Successfull";
        }

        public async Task<string> DeleteTaskById ( Tasks Task )
        {
            var existingTask = await GetTaskById(Task.TaskId);
            if ( existingTask != null )
            {
                _context. Taskses. Remove ( existingTask );
                await _context. SaveChangesAsync ( );
                return "Task Deleted Succesfull";
            }
            return "Task Didn't Exist";
        }
        public async Task<Tasks?> GetTaskById ( Guid taskId )
        {
            return await _context. Taskses. FindAsync (taskId );
        }
        public async Task<ICollection<Tasks?>> GetAllTaskByProjectId ( Tasks task )
        {
            var existingProject = await _projectRepository.GetProjectById(task.ProjectId);
            if ( existingProject != null )
            {
                return await _context. Taskses. Where ( t => t. ProjectId == task. ProjectId ). ToListAsync ( );
            }
            return null;
        }
        public async Task<string> UpdateTaskByTaskId ( Tasks task )
        {
            var existingTask = await GetTaskById (task.TaskId);
            if ( existingTask != null )
            {
                existingTask. TaskName = task. TaskName;
                existingTask.DeadLine = task.DeadLine;
                _context. Taskses. Update ( existingTask );
                await _context.SaveChangesAsync ( );
                return "Data Updated Succesfull";

            }
            return "Task Don't Exist";

        }
    }
}
