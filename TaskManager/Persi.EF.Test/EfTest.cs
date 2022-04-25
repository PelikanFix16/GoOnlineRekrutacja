using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using Persistence.EF.DummyData;
using Persistence.EF.Repositories;
using System;
using Xunit;

namespace Persi.EF.Test
{
    public class EfTest
    {
        private readonly TaskRepository _repo;
        public EfTest()
        {
            var data = DummyTasks.Get();
            DbContextOptionsBuilder<TaskManagerContext> dbOptions = new DbContextOptionsBuilder<TaskManagerContext>().
                UseInMemoryDatabase(
                Guid.NewGuid().ToString()
                );
            var context = new TaskManagerContext(dbOptions.Options);
            _repo = new TaskRepository(context);
            foreach (var item in data)
            {
                _repo.Create(item);
            }
        }

        [Fact]
        public void Test1()
        {
            var tasks = _repo.GetAll();
            Console.WriteLine("test");
        }
    }
}