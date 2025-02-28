

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.TaskManagementSys.Domain.Entites
{
    public class Tasks
    {

        [Key]
        public Guid TaskId { get; set; }

        public string? TaskName { get; set; }
        public DateTime DeadLine { get; set; }

        [JsonIgnore]
        public Project? Project { get; set; }

        public Guid ProjectId { get; set; }
    }
}
