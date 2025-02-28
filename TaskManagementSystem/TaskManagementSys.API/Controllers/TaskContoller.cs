using Microsoft. AspNetCore. Http;
using Microsoft. AspNetCore. Mvc;
using TaskManagementSystem. TaskManagementSys. API. Dto;
using TaskManagementSystem. TaskManagementSys. Application. Interfeces;

namespace TaskManagementSystem. TaskManagementSys. API. Controllers
{
    [Route ( "[controller]" )]
    [ApiController]
    public class TaskContoller : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        public TaskContoller ( ITaskServices taskServices )
        {
            _taskServices = taskServices;
        }
        [Route ( "GetTasksByProId" )]
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskDTO>>> GetTaskByProId ( [FromBody] TaskDTO taskDTO )
        {
            var result = await _taskServices.GetTaskByProId(taskDTO);
            return result != null ? Ok ( result ) : BadRequest ( );
        }
        [Route ( "AddTaskByProjectId" )]
        [HttpGet]
        public async Task<ActionResult<string>> AddTaskByProjectId ( [FromBody] TaskDTO taskDTO )
        {
            var result = await _taskServices.AddTaskByProjectId(taskDTO);
            return result. Contains ( "Successfull" ) ? Ok ( result ) : BadRequest ( result );
        }
        [Route ( "DeleteTaskByTaskId" )]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteTaskByTaskId ( [FromBody] TaskDTO taskDTO )
        {
            var result = await _taskServices.DeleteTaskById(taskDTO);
            return result. Contains ( "Successfull" ) ? Ok ( result ) : BadRequest ( result );
        }
        [Route ( "UpdateTaskByTaskId" )]
        [HttpPut]
        public async Task<ActionResult<string>> UpdateTaskByTaskId ( [FromBody] TaskDTO taskDTO )
        {
            if ( taskDTO. TaskId == Guid. Empty || taskDTO. ProjectId == Guid. Empty )
            {
                return "Feild missing";
            }
            var result = await _taskServices.UpdateTaskByTaskId(taskDTO);
            return result.Contains ("Succesfull")?Ok(result) : BadRequest ( result );
        }
    }
}
