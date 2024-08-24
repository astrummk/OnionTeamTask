using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.ServiceLayer.Interface
{
    public interface ITaskService
    {
        List<Taskd> GetAllTasks();
        Taskd GetDetailsForTask(Guid? id);
        void CreateNewTask(Taskd task);
        void UpdeteTask(Guid taskId, TaskUpdateDto dto);
        void DeleteTask(Guid id);
    }
}
