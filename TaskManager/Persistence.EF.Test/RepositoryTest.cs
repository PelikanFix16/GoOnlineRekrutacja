using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence.EF.DummyData;
using Persistence.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Persistence.EF.Test
{
    


    public class RepositoryTest
    {

        private readonly TaskRepository _repo;

        public RepositoryTest()
        {
            List<TaskModel> data = DummyTasks.Get();

            //foreach(var item in data)
            //{
            //    PropertyInfo[] properties = typeof(TaskModel).GetProperties();
            //    foreach (PropertyInfo property in properties)
            //    {
            //        var property1 = item.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
            //        if (property1 != null)
            //            //property1.SetValue(item,property1, null);
            //            property1.SetValue(item, ", null);

            //    }

            //}

            var qData = data.AsQueryable();
            var mockSet = new Mock<DbSet<TaskModel>>();
            mockSet.As<IQueryable<TaskModel>>().Setup(m => m.Provider).Returns(qData.Provider);
            mockSet.As<IQueryable<TaskModel>>().Setup(m => m.Expression).Returns(qData.Expression);
            mockSet.As<IQueryable<TaskModel>>().Setup(m => m.ElementType).Returns(qData.ElementType);
            mockSet.As<IQueryable<TaskModel>>().Setup(m => m.GetEnumerator()).Returns(qData.GetEnumerator());
            var mockContext = new Mock<TaskManagerContext>();
            mockContext.Setup(x => x.Tasks).Returns(mockSet.Object);

            _repo = new TaskRepository(mockContext.Object);


        }

        [Fact]
        public void ShouldReturnAllTasks()
        {
            _repo.GetAll();
        }
    }
}