using Service.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    /// <summary>
    /// Use cases for task service
    /// If want implement new version of task service implement this interface ant write new class implementing it
    /// </summary>
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
