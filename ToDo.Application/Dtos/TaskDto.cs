using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Dtos
{
    public class TaskDto
    {
        public TaskDto(Guid id,
                       string title,
                       string description,
                       long? deadline,
                       bool completed,
                       long createdAt)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Completed = completed;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }

        public long? Deadline { get; }

        public bool Completed { get; }
        
        public long CreatedAt { get; }
    }
}
