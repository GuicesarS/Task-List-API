namespace TO_DO_LIST_WepAPI.Models.DTOs;

public class TodoDTO
{
    public string? MyProperty { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    
}
