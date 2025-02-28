

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagementSystem.TaskManagementSys.Domain.Entites
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? UserName { get; set; }



        public ICollection<Project>? Projects { get; set; }
    }
}
