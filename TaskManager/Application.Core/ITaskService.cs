using Service.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public interface ITaskService
    {
        TaskModelOutput AddNewTask(TaskModelInput task);
        IEnumerable<TaskModelOutput> RemoveTask(Guid id);
        TaskModelOutput UpdateTask(Guid id,TaskModelInputUpdate task);
        IEnumerable<TaskModelOutput> GetAllTask();
        TaskModelOutput GetTask(Guid id);
        IEnumerable<TaskModelOutput> GetByDate(DateOnly start, DateOnly end);
   


    }
}
