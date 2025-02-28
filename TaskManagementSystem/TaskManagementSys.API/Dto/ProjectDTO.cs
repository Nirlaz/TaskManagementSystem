

namespace TaskManagementSystem.TaskManagementSys.API.Dto
{
    public class ProjectDTO
    {
        public Guid ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public Guid UserId { get; set; }

        public ICollection<TaskDTO>? Tasks { get; set; }


    }
}
