using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.DTO
{
    /// <summary>
    /// Output dto for getting results from service 
    /// we do not want return Task model
    /// </summary>
    public class TaskModelOutput
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CompleteStatus { get; set; }
    }
}
