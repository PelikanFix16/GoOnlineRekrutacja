using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DTO
{
    public class TaskModelOutput
    {
        public Guid Id;
        public DateTimeOffset CreatedDate;
        public DateTimeOffset? ExpirationDate;
        public string Title;
        public string Description;
        public int CompleteStatus;
    }
}
