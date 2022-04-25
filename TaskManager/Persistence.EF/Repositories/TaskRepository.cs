using Domain.Core;
using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _dbContext;

        public TaskRepository(TaskManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TaskModel Create(TaskModel model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
            return model;
        }

        public void Delete(TaskModel model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();

        }

        public IEnumerable<TaskModel> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        public IEnumerable<TaskModel> GetByDate(DateOnly start,DateOnly end)
        {
            return _dbContext.Tasks.Where(t => 
            DateOnly.FromDateTime(t.ExpirationDate!.Value.DateTime) >= start && 
            DateOnly.FromDateTime(t.ExpirationDate!.Value.DateTime) <= end && 
            t.CompleteStatus != 100).ToList();
        }


        public TaskModel GetById(Guid id)
        {
            return _dbContext.Tasks.First(task => task.Id == id);
        }

        public TaskModel Update(TaskModel model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
            return model;
        }
    }
}
