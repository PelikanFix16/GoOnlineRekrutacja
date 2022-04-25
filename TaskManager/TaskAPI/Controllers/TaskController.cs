using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Core;
using Service.Core.DTO;


namespace TaskAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAllTasks")]
        [Route("task")]

        public ActionResult<IEnumerable<TaskModelOutput>> GetAllTasks()
        {
            var taks = _service.GetAllTask().ToList();
            return Ok(taks);
        }
        [HttpGet]
        [ActionName("GetTaskById")]
        [Route("task/{id}")]
        public ActionResult<TaskModelOutput> GetTaskById([FromRoute]Guid id)
        {
            var task = _service.GetTask(id);
            return Ok(task);
        }
        [HttpGet]
        [ActionName("GetTaskByDate")]
        [Route("task/{start}&{end}")]
        public ActionResult<IEnumerable<TaskModelOutput>> GetByDate([FromRoute]string start,[FromRoute]string end)
        {
            var startDate = DateOnly.Parse(start);
            var endDate = DateOnly.Parse(end);
            var tasks = _service.GetByDate(startDate, endDate);
            return Ok(tasks);
        }

        [HttpPost]
        [ActionName("CreateTask")]
        [Route("task")]

        public ActionResult<TaskModelOutput> CreateTask(TaskModelInput taskModel)
        {
            var createdTask = _service.AddNewTask(taskModel);
            return Ok(createdTask);
        }

        [HttpPut]
        [ActionName("UpdateTask")]
        [Route("task/{id}")]
        public ActionResult<TaskModelOutput> UpdateTask(Guid id, TaskModelInputUpdate model)
        {
            var updatedTask = _service.UpdateTask(id, model);
            return Ok(updatedTask);
        }


    }
}
