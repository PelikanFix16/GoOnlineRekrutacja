using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using Persistence.EF.DummyData;
using Persistence.EF.Repositories;
using Service.Core;
using System;
using Xunit;
using AutoMapper;
using Application.Core.Mapper;
using Service.Core.DTO;
using System.Linq;

namespace Application.Core.Test
{
    public class TaskServiceTest
    {
        private readonly TaskService _taskService;
        private readonly TaskModelInput _inputTask;
    

        public TaskServiceTest()
        {
            DbContextOptionsBuilder<TaskManagerContext> dbOptions = new DbContextOptionsBuilder<TaskManagerContext>().
                UseInMemoryDatabase(
                Guid.NewGuid().ToString()
                );
            var context = new TaskManagerContext(dbOptions.Options);
            var repo = new TaskRepository(context);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();
            _taskService = new TaskService(repo, mapper);
            _inputTask = new TaskModelInput()
            {
                Title = "test",
                Description = "test description",
                ExpirationDate = DateTimeOffset.Now.AddDays(1)
            };

        }


        [Fact]
        public void ShouldCreateTask()
        {
            int exceptedValue = 1;
            _taskService.AddNewTask(_inputTask);

            var taskList = _taskService.GetAllTask();

            Assert.Equal(exceptedValue, taskList.Count());

        }

        [Fact]
        public void ShouldGetAllTasks()
        {
            int exceptedValue = 3;
            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(_inputTask);
            var taskList = _taskService.GetAllTask();
            Assert.Equal(exceptedValue, taskList.Count());

        }

        [Fact]
        public void ShouldGetTaskBetweenDate()
        {
            TaskModelInput inputModel1 = new TaskModelInput()
            {
                Title = "test",
                Description = "test description",
                ExpirationDate = DateTimeOffset.Now.AddDays(2)
            };
            TaskModelInput inputModel2 = new TaskModelInput()
            {
                Title = "test",
                Description = "test description",
                ExpirationDate = DateTimeOffset.Now.AddDays(10)
            };
            DateOnly start = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
            DateOnly end = DateOnly.FromDateTime(DateTimeOffset.Now.AddDays(2).DateTime);
            int exceptedValue = 2;
            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(inputModel1);
            _taskService.AddNewTask(inputModel2);
            var taskList = _taskService.GetByDate(start,end);
            Assert.Equal(exceptedValue, taskList.Count());

        }
        [Fact]
        public void ShouldReturnTaskById()
        {

            _taskService.AddNewTask(_inputTask);
            var tasks = _taskService.GetAllTask();
            var firstTask = tasks.First();

            var taskById = _taskService.GetTask(firstTask.Id);

            Assert.NotNull(taskById);
            Assert.Equal(firstTask.Id, taskById.Id);
        }

        [Fact]
        public void ShouldRemoveTask()
        {

            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(_inputTask);
            _taskService.AddNewTask(_inputTask);
            var tasks = _taskService.GetAllTask();
            _taskService.RemoveTask(tasks.First().Id);
            var tasksAfterRemove = _taskService.GetAllTask();
            Assert.NotEqual(tasks.Count(), tasksAfterRemove.Count());
        }

        [Fact]
        public void ShouldUpdateTaskTitle()
        {

            _taskService.AddNewTask(_inputTask);
            string title = "testNowyModelUpdate";
            var tasks = _taskService.GetAllTask().First();
            TaskModelInputUpdate updateModel = new TaskModelInputUpdate()
            {
                Title = title
            };
            
            var tasksAfterRemove = _taskService.UpdateTask(tasks.Id, updateModel);
            var task = _taskService.GetTask(tasks.Id);

            Assert.Equal(title, task.Title);
        }
        [Fact]
        public void ShouldUpdateCompleteStatus()
        {

            _taskService.AddNewTask(_inputTask);
            int completeStatus = 80;
            var tasks = _taskService.GetAllTask().First();
            TaskModelInputUpdate updateModel = new TaskModelInputUpdate()
            {
                CompleteStatus = completeStatus
            };

            var tasksAfterRemove = _taskService.UpdateTask(tasks.Id, updateModel);
            var task = _taskService.GetTask(tasks.Id);

            Assert.Equal(completeStatus, task.CompleteStatus);
        }

        [Fact]
        public void ShouldNotUpdateCompleteStatus()
        {

            _taskService.AddNewTask(_inputTask);
            int completeStatus = 101;
            var tasks = _taskService.GetAllTask().First();
            TaskModelInputUpdate updateModel = new TaskModelInputUpdate()
            {
                CompleteStatus = completeStatus
            };

            Assert.Throws<InvalidOperationException>(
                ()=>_taskService.UpdateTask(tasks.Id, updateModel));

        }


    }
}