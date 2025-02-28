

namespace TaskManagementSystem.TaskManagementSys.API.Dto
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public ICollection<ProjectDTO>? Projects { get; set; }
    }
}
