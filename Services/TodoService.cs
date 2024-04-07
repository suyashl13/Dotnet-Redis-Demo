namespace Services;

using System.Text.Json;
using Entities;
using NRedisStack.RedisStackCommands;
using ServiceContracts;
using ServiceContracts.DTO;
using StackExchange.Redis;

public class TodoService(IDatabase redisDatabase) : ITodoService
{

    public TodoResponse AddTodo(AddTodoRequest addTodoRequest)
    {
        List<Todo> todoList = new List<Todo>();
        RedisValue result = redisDatabase.StringGet("TodoList");
        if (result.IsNullOrEmpty)
        {
            todoList.Add(addTodoRequest.ToTodoEntity());
            redisDatabase.StringSet("TodoList", JsonSerializer.Serialize(todoList));
        } else {
            todoList = JsonSerializer.Deserialize<List<Todo>>(result.ToString())!;
            todoList.Add(addTodoRequest.ToTodoEntity());
            redisDatabase.StringSet("TodoList", JsonSerializer.Serialize(todoList));
        }
        
        return addTodoRequest.ToTodoEntity().ToTodoResponse();
    }

    public List<TodoResponse> GetCompleteTodoList()
    {
        return JsonSerializer.Deserialize<List<TodoResponse>>(redisDatabase.StringGet("TodoList")!)!;
    }

    public TodoResponse UpdateTodo(string todoId, UpdateTaskDto updateTaskDto)
    {
        List <TodoResponse> todoResponses = GetCompleteTodoList();
        
        var todo = todoResponses.Find(x => x.TodoId == Guid.Parse(todoId))!;
        todo.IsDone = updateTaskDto.IsDone;
        todo.Title = updateTaskDto.Title;
        todo.Description = updateTaskDto.Description;
        
        redisDatabase.StringSet("TodoList", JsonSerializer.Serialize(todoResponses));
        return todoResponses.Find(x => x.TodoId == Guid.Parse(todoId))!;
    }


    public TodoResponse DeleteTodo(string todoId)
    {
        List <TodoResponse> todoResponses = GetCompleteTodoList();
        var todo = todoResponses.Find(x => x.TodoId == Guid.Parse(todoId))!;
        todoResponses.Remove(todo);
        redisDatabase.StringSet("TodoList", JsonSerializer.Serialize(todoResponses));
        return todo;
    }

}


