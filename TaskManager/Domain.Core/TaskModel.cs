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
        public DateTimeOffset? CreatedDate { get; private set; }
        public DateTimeOffset? ExpirationDate { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int CompleteStatus { get; private set; }

        public TaskModel(DateTimeOffset? expirationDate,DateTimeOffset? createdDate, string title,string? description)
        {
            if (createdDate == null)
                CreatedDate = DateTimeOffset.Now;
            else
                CreatedDate = createdDate.GetValueOrDefault();
                
            if(expirationDate != null)
                UpdateExpirationDate(expirationDate);
            Title = title;
            Description = description;
            CompleteStatus = 0;
            Id = Guid.NewGuid();
        }
        public void UpdateCompleteStatus(int status)
        {
            if (status > 100)
                throw new InvalidOperationException("Status cannot be bigger than 100");
            if (status < 0)
                throw new InvalidOperationException("status cannot be smaller than 0");
            CompleteStatus = status;
        }
        public void UpdateTitle(string title)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentException("Title cannot be null or empty");
            Title = title;
        }
        public void UpdateDescription(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty");
            Description = description;
        }
        public void UpdateExpirationDate(DateTimeOffset? date)
        {
            if (date < CreatedDate)
                throw new ArgumentException("Expiration date cannot be smaller than created date");          
            ExpirationDate = date;
        }

    }
}
