

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.TaskManagementSys.Domain.Entites
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public string? ProjectName { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        public Guid UserId { get; set; }

        [JsonIgnore]
        public ICollection<Tasks>? Taskses { get; set; }
    }
}
