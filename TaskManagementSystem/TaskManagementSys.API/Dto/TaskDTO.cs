

namespace TaskManagementSystem.TaskManagementSys.API.Dto
{
    public class TaskDTO
    {
        public Guid? TaskId { get; set; }

        public string? TaskName { get; set; }
        public DateTime? DeadLine { get; set; }

        public Guid ProjectId { get; set; }    

    }
}
