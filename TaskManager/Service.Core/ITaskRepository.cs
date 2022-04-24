using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAll();
        TaskModel GetById(Guid id);
        IEnumerable<TaskModel> GetByDate(DateTimeOffset date);
        TaskModel Create(TaskModel model);
        TaskModel Update(TaskModel model);
        IEnumerable<TaskModel> Delete(Guid id);


    }
}
