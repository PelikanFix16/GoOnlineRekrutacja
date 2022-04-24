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
        public ActionResult<IEnumerable<TaskModelOutput>> GetAllTasks()
        {
            var taks = _service.GetAllTask().ToList();
            return Ok(taks);
        }

    }
}
