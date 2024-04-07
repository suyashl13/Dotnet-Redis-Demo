using ServiceContracts.DTO;

namespace ServiceContracts;

public interface ITodoService
{
    /// <summary>
    /// Add a new Todo
    /// </summary>
    /// <returns>TodoResponse</returns>
    public TodoResponse AddTodo(AddTodoRequest addTodoRequest);

    /// <summary>
    /// Get Complete Todo list.
    /// </summary>
    /// <returns>List<TodoResponse></returns>
    public List<TodoResponse> GetCompleteTodoList();

    public TodoResponse UpdateTodo(String todoId, UpdateTaskDto updateTaskDto);

    public TodoResponse DeleteTodo(string todoId);
}
