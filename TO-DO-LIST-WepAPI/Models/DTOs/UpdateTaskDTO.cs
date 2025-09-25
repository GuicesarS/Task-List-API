using System.ComponentModel.DataAnnotations;

namespace TO_DO_LIST_WepAPI.Models.TaskItemDTO;

public class UpdateTaskDTO
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
