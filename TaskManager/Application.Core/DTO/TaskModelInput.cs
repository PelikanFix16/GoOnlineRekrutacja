using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DTO
{
    /// <summary>
    /// Input DTO that be pssed to service
    /// </summary>
    public class TaskModelInput
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }

        public DateTimeOffset? CreatedDate { get; private set; }

    }
}
