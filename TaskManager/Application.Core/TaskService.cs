using AutoMapper;
using Domain.Core;
using Service.Core;
using Service.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    /// <summary>
    /// Class responsible for comunication betwween user interface
    /// This class have implemented comunication for repository using ports and adapters
    /// Have Simple functions CRUD 
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;


        public TaskService(ITaskRepository repository,IMapper mapper)
        {
            _taskRepository = repository;
            _mapper = mapper;
        }

        public TaskModelOutput AddNewTask(TaskModelInput task)
        {
            var entity = _mapper.Map<TaskModel>(task);
            var createdTask = _taskRepository.Create(entity);
            return _mapper.Map<TaskModelOutput>(createdTask);
        }

        public IEnumerable<TaskModelOutput> GetAllTask()
        {
            var allTasks = _taskRepository.GetAll();
            var returnTasks = _mapper.Map<IEnumerable<TaskModelOutput>>(allTasks);
            return returnTasks;
        }

        public IEnumerable<TaskModelOutput> GetByDate(DateOnly start, DateOnly end)
        {
            var tasks = _taskRepository.GetByDate(start,end);
            return _mapper.Map<IEnumerable<TaskModelOutput>>(tasks);
        }

        public TaskModelOutput GetTask(Guid id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskModelOutput>(task);
        }

        public IEnumerable<TaskModelOutput> RemoveTask(Guid id)
        {
            var taskByGuid = _taskRepository.GetById(id);
            _taskRepository.Delete(taskByGuid);
            var availableTasks = _taskRepository.GetAll();
            return _mapper.Map<IEnumerable<TaskModelOutput>>(availableTasks);
        }

        public TaskModelOutput UpdateTask(Guid id,TaskModelInputUpdate task)
        {
            var entity = _taskRepository.GetById(id);
            if(task.CompleteStatus != null)
                entity.UpdateCompleteStatus(task.CompleteStatus.GetValueOrDefault());
            if(String.IsNullOrEmpty(task.Description) == false)
                entity.UpdateDescription(task.Description);
            if (String.IsNullOrEmpty(task.Title) == false)
                entity.UpdateTitle(task.Title);
            if (task.ExpirationDate != null)
                entity.UpdateExpirationDate(task.ExpirationDate);

            var updatedTask = _taskRepository.Update(entity);
            return _mapper.Map<TaskModelOutput>(updatedTask);
        }
    }
}
