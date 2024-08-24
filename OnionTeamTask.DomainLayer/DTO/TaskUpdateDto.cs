using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.DomainLayer.DTO
{
    public class TaskUpdateDto
    {
        public string TaskName { get; set; }
        public DateTime TaskDueDate { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string TaskDescription { get; set; }
    }
}
