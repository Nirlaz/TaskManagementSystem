using System. Diagnostics;
using System. Security. Cryptography;
using AutoMapper;
using TaskManagementSystem. TaskManagementSys. API. Dto;

using TaskManagementSystem. TaskManagementSys. Application. Interfeces;
using TaskManagementSystem. TaskManagementSys. Domain. Entites;
using TaskManagementSystem. TaskManagementSys. Domain. Interfaces;

namespace TaskManagementSystem. TaskManagementSys. Application. Services
{
    public class TaskServices : ITaskServices
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        public TaskServices ( ITaskRepository taskRepository , IMapper mapper )
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<string> AddTaskByProjectId ( TaskDTO taskDTO )
        {
            if ( taskDTO. TaskId == Guid. Empty ) // Assign a new GUID if TaskId is empty
            {
                taskDTO. TaskId = Guid. NewGuid ( );
            }

            if ( taskDTO. DeadLine == default ( DateTime ) || taskDTO. DeadLine == DateTime. MinValue ) // Check if DeadLine is not set
            {
                taskDTO. DeadLine = DateTime. Now. AddMonths ( 1 );
            }

            var tasks = _mapper.Map<Tasks>(taskDTO);
            return await _taskRepository. AddTask ( tasks );
        }

        public async Task<string> DeleteTaskById ( TaskDTO taskDTO )
        {
            if ( taskDTO. TaskId == Guid. Empty || taskDTO. ProjectId == Guid. Empty )
            {
                return "Feild Is missing";
            }
            var task = _mapper.Map<Tasks>(taskDTO);
            return await _taskRepository. DeleteTaskById ( task );

        }

        public async Task<ICollection<TaskDTO?>> GetTaskByProId ( TaskDTO taskDTO )
        {
            var tasks = _mapper.Map<Tasks>(taskDTO);
            var taskDTOS = await _taskRepository. GetAllTaskByProjectId ( tasks );
            return _mapper. Map<ICollection<TaskDTO>> ( taskDTOS );
        }

        public async  Task<string> UpdateTaskByTaskId ( TaskDTO taskDTO )
        {
            var tasks = _mapper.Map<Tasks>(taskDTO);
            return await _taskRepository. UpdateTaskByTaskId ( tasks );
            
        }
    }
}
