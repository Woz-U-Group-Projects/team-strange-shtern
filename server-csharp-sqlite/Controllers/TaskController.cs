using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server_csharp_sqlite.Models;

namespace server_csharp_sqlite.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TaskController : ControllerBase
  {

    private readonly TaskDbContext _context;

    public TaskController(TaskDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public List<Task> getTasks()
    {
      return _context.Tasks.ToList();
    }

    [HttpPost]
    public Task createTask(Task Task)
    {
      _context.Tasks.Add(Task);
      _context.SaveChanges();
      return Task;
    }

  }
}