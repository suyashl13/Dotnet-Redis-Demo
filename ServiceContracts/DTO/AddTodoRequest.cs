using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceContracts.DTO;

public class AddTodoRequest
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    public bool? IsDone { get; set; } = false;

    public Todo ToTodoEntity() {
        return new Todo() { 
            TodoId = Guid.NewGuid(),
            Description = Description,
            IsDone = IsDone,
            Title = Title
        };
    }
    
}

public static class TodoExtensions
{
    public static TodoResponse ToTodoResponse(this Todo todo) {
        return new TodoResponse() {
            TodoId = todo.TodoId,
            Title = todo.Title,
            Description = todo.Description,
            IsDone = todo.IsDone ?? false
        };
    }
}