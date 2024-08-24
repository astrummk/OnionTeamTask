using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.DomainLayer.DTO;
using OnionTeamTask.RepositoryLayer.Interface;
using OnionTeamTask.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.ServiceLayer.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Taskd> _taskRepository;

        public TaskService(IRepository<Taskd> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Taskd> GetAllTasks()
        {
            return _taskRepository.GetAll().ToList();
        }

        public Taskd GetDetailsForTask(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null");
            }

            var task = _taskRepository.Get(id.Value);

            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            
            return task;
        }

        public void CreateNewTask(Taskd task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null");
            }

            _taskRepository.Insert(task);
        }

        public void UpdeteTask(Guid taskId, TaskUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "Task DTO cannot be null");
            }

            _taskRepository.UpdateTask(taskId, dto);
        }


        public void DeleteTask(Guid id)
        {
            var task = _taskRepository.Get(id);

            if (task == null)
            {
                throw new KeyNotFoundException("Task not found");
            }

            _taskRepository.Delete(task);
        }
    }
}
