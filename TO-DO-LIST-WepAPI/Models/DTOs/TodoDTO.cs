namespace TO_DO_LIST_WepAPI.Models.DTOs;

public class TodoDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
