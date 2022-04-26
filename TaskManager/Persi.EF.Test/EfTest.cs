using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using Persistence.EF.DummyData;
using Persistence.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Persi.EF.Test
{
    public class EfTest
    {
        private readonly TaskRepository _repo;
        private readonly IList<TaskModel> _dbSet;
        public EfTest()
        {
            _dbSet = DummyTasks.Get();
            DbContextOptionsBuilder<TaskManagerContext> dbOptions = new DbContextOptionsBuilder<TaskManagerContext>().
                UseInMemoryDatabase(
                Guid.NewGuid().ToString()
                );
            var context = new TaskManagerContext(dbOptions.Options);
            _repo = new TaskRepository(context);
        }

        [Fact]
        public void ShouldAddTaskToMemory()
        {
            var firstTask = _dbSet.First();
            int exceptedValue = 1;
            
            _repo.Create(firstTask);
            var taskInMemory = _repo.GetAll();
            var acctual = taskInMemory.Count();

            Assert.Equal(exceptedValue, acctual);
           
        }

        [Fact]
        public void ShouldDeleteTaskFromMemory()
        {
            int exceptedValue = 2;
            foreach(var item in _dbSet)
            {
                _repo.Create(item);
            }
            _repo.Delete(_dbSet.First());

            var taskCount = _repo.GetAll().Count();
            Assert.Equal(exceptedValue, taskCount);

        }

        [Fact]
        public void ShouldReturnTaskBetweenDate()
        {
            var start = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
            var end =DateOnly.FromDateTime(DateTimeOffset.Now.AddDays(2).DateTime);
            var exceptedValue = 2;

            foreach (var item in _dbSet)
            {
                _repo.Create(item);
            }

            var taskBetweenDate = _repo.GetByDate(start, end).Count();

            Assert.Equal(exceptedValue, taskBetweenDate);

        }

        [Fact]
        public void ShouldNotReturnTaskIfCompleteStatusIsEqual100()
        {
            var start = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
            var end = DateOnly.FromDateTime(DateTimeOffset.Now.AddDays(2).DateTime);
            var exceptedValue = 1;

            foreach (var item in _dbSet)
            {
                
                _repo.Create(item);
            }
            var firstTask = _dbSet.First();
            firstTask.UpdateCompleteStatus(100);
            _repo.Update(firstTask);


            var taskBetweenDate = _repo.GetByDate(start, end).Count();

            Assert.Equal(exceptedValue, taskBetweenDate);

        }

        [Fact]
        public void ShouldreturnTaskById()
        {
            var firstTask = _dbSet.First();

            foreach (var item in _dbSet)
            {
                _repo.Create(item);
            }

            var returnTsk = _repo.GetById(firstTask.Id);

            Assert.Equal(firstTask.Id, returnTsk.Id);
        }

        [Fact]
        public void ShouldUpdateTask()
        {
            var firstTask = _dbSet.First();
            _repo.Create(firstTask);
            firstTask.UpdateTitle("zmiana tytulu");
            var updatedTask = _repo.Update(firstTask);
            Assert.Equal(firstTask.Title, updatedTask.Title);

  

        }
        
    }
}