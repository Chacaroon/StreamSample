using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamSample.Context;
using StreamSample.Models;

namespace StreamSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private readonly ApplicationContext _applicationContext;

    public TodoListController(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TodoList>> GetAll()
    {
        return Ok(_applicationContext.TodoLists.Include(x => x.Items));
    }

    [HttpGet("{id}")]
    public ActionResult<TodoList> Get(int id)
    {
        return Ok(_applicationContext.TodoLists.Include(x => x.Items).First(x => x.Id == id));
    }

    [HttpPost]
    public ActionResult Create([FromBody] TodoList todoList)
    {
        _applicationContext.TodoLists.Add(todoList);
        _applicationContext.SaveChanges();

        return Ok();
    }

    [HttpPut]
    public ActionResult Update([FromBody] TodoList todoListModel)
    {
        var todoList = _applicationContext.TodoLists.Include(x => x.Items).First(x => x.Id == todoListModel.Id);

        todoList.Name = todoListModel.Name;
        todoList.Tags = todoListModel.Tags;
        todoList.Items = todoListModel.Items;

        _applicationContext.TodoLists.Update(todoList);
        _applicationContext.SaveChanges();

        return Ok();
    }
}
