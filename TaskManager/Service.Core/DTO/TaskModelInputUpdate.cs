using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DTO
{
    public class TaskModelInputUpdate
    {
        public Guid Id;
        public string Title;
        public string Description;
        public DateTimeOffset? ExpirationDate;
        public int? CompleteStatus;
    }
}
