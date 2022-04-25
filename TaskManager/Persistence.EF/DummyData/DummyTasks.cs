using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.DummyData
{
    public static class DummyTasks
    {
        public static List<TaskModel> Get()
        {
            TaskModel t1 = new TaskModel(DateTimeOffset.Now.AddDays(1),null,"Kupic bulki","Zrobic zakupy w sklepie, koszt bulek 0.40gr");
            TaskModel t2 = new TaskModel(DateTimeOffset.Now.AddDays(2),null, "Natankowac samochod",null);
            TaskModel t3 = new TaskModel(DateTimeOffset.Now.AddDays(8),null, "Napic sie kawy", null);
            List<TaskModel> list = new List<TaskModel>();
            list.Add(t1);
            list.Add(t2);
            list.Add(t3);
            return list;

        } 
    }
}
