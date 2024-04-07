using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Todo
{
    public Guid TodoId { get; set; }

    public string Title { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public bool? IsDone { get; set; } = false;
}