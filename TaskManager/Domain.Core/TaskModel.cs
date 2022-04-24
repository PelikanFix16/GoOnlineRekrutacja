using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class TaskModel
    {
        public Guid Id { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset? ExpirationDate { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int CompleteStatus { get; private set; }

        public TaskModel(DateTimeOffset? expirationDate,string title,string description)
        {
            CreatedDate = DateTimeOffset.Now;
            ExpirationDate = expirationDate;
            Title = title;
            Description = description;
            CompleteStatus = 0;
            Id = Guid.NewGuid();
        }

    }
}
