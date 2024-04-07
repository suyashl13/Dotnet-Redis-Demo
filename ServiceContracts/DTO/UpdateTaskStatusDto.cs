using System.ComponentModel.DataAnnotations;

public class UpdateTaskDto
{
    public string Title { get; set; } = null!;

    
    public string Description { get; set; } = null!;

    public bool IsDone { get; set; }
}