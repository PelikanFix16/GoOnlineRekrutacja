﻿
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
        IEnumerable<TaskModel> GetByDate(DateOnly start, DateOnly end);
        TaskModel Create(TaskModel model);
        TaskModel Update(TaskModel model);
        void Delete(TaskModel model);


    }
}