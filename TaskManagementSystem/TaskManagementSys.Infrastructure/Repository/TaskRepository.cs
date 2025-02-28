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
        private readonly IProjectRepository _projectRepository;
        public TaskRepository ( ApplicationDbContext context , IProjectRepository projectRepository )
        {
            _context = context;
            _projectRepository = projectRepository;
        }
        public async Task<string> AddTask ( Tasks task )
        {
            
            var projectExists = await _projectRepository.GetProjectByProId(task.ProjectId);
            if ( projectExists == null )
            {
                return "Project does not exist! Cannot add task.";
            }
            var existingTask =  await GetTaskById(task.TaskId);
            if ( existingTask != null )
            {
                return "TaskExist";

            }

            // Add Task
            await _context. Taskses. AddAsync( task );
            await _context. SaveChangesAsync ( );

            return "Task Added Successfully";
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
           
            
                return await _context. Taskses. Where ( t => t. ProjectId == task. ProjectId ). ToListAsync ( );
            
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
