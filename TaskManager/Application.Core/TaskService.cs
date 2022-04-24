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

        public TaskModelOutput UpdateTask(TaskModelInputUpdate task)
        {
            var entity = _mapper.Map<TaskModel>(task);
            if(task.CompleteStatus != null)
                entity.UpdateCompleteStatus(entity.CompleteStatus);
            var updatedTask = _taskRepository.Update(entity);
            return _mapper.Map<TaskModelOutput>(updatedTask);
        }
    }
}
