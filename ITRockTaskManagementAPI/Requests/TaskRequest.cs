using System.ComponentModel.DataAnnotations;

namespace ITRockTaskManagementAPI.Requests
{
    public class TaskCreateRequest
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }
    }

}
