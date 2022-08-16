using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoAPI.Data;
using todoAPI.models;

namespace todoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly TodoDBcontext todoDBcontext;

        public TasksController(TodoDBcontext todoDBcontext)
        {
            this.todoDBcontext = todoDBcontext;
        }
        //get all tasks
        [HttpGet]
        public async Task<IActionResult> GetALlTasks()
        {
           var Ttask= await todoDBcontext.Tasks.ToListAsync();
            return Ok(Ttask);
        }
        //get single task
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetTask")]
        public async Task<IActionResult> GetTask([FromRoute] Guid id)
        {
            var Ttask = await todoDBcontext.Tasks.FirstOrDefaultAsync(x => x.Id==id);
            if (Ttask != null)
            {
                return Ok(Ttask);
            }

            return NotFound("Task not found");
        }

        //Add task
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] taskMain Ttask)
        {
            Ttask.Id = Guid.NewGuid();

            await todoDBcontext.Tasks.AddAsync(Ttask);
            await todoDBcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask),new {id=Ttask.Id }, Ttask);
        }
        //updating Task
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] taskMain Ttask)
        {
                  var runningTask = await todoDBcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (runningTask != null)
            {
                runningTask.topic = Ttask.topic;
                runningTask.description = Ttask.description;
                await todoDBcontext.SaveChangesAsync();
                return Ok(runningTask);
            }
            return NotFound("Task not found");
        }

        //delete Task
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
        {
            var runningTask = await todoDBcontext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (runningTask != null)
            {
                todoDBcontext.Remove(runningTask);
                await todoDBcontext.SaveChangesAsync();
                return Ok(runningTask);
            }
            return NotFound("Task not found");
        }
    }
}
