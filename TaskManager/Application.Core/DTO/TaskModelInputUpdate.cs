using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DTO
{
    /// <summary>
    /// Input update dto used for updating tasks
    /// </summary>
    public class TaskModelInputUpdate
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public int? CompleteStatus { get; set; }
    }
}
