using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Core;
using Service.Core.DTO;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Todos")]
        public ActionResult<IEnumerable<TaskModelOutput>> GetAllTasks()
        {
            var taks = _service.GetAllTask().ToList();
            return Ok(taks);
        }
        [HttpGet]
        [Route("Todos/{id}")]
        public ActionResult<TaskModelOutput> GetTask(Guid id)
        {
            var task = _service.GetTask(id);
            return Ok(task);
        }
        



    }
}
