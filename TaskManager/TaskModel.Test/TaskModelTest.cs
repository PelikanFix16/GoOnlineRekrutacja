using Xunit;
using Domain.Core;

namespace TaskModel.Test
{
    public class TaskModelTest
    {
        [Fact]
        public void Create()
        {
            TaskModel taskModel = new TaskModel();
        }
    }
}