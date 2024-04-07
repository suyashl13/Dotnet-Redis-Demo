
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

[Route("todo")]
public class TodoController : Controller
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService) { _todoService = todoService; }

    [Route("")]
    [HttpPost]
    public IActionResult CreateTodo([FromBody] AddTodoRequest addTodoRequest)
    {
        return Json(
            _todoService.AddTodo(addTodoRequest)
        );
    }

    [Route("")]
    [HttpGet]
    public IActionResult GetAllTodoList()
    {
        return Json(
            _todoService.GetCompleteTodoList()
        );
    }

    [Route("{todoId}")]
    [HttpDelete]
    public IActionResult DeleteTodo(string todoId)
    {
        return Json(
            _todoService.DeleteTodo(todoId)
        );
    }

    [Route("{todoId}")]
    [HttpPut]
    public IActionResult UpdateTodo([FromBody] UpdateTaskDto updateTaskDto, string todoId)
    {
        return Json(
            _todoService.UpdateTodo(todoId, updateTaskDto)
        );
    }

}