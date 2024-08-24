using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.DomainLayer.DTO;
using OnionTeamTask.RepositoryLayer.Interface;

namespace OnionTeamTask.RepositoryLayer.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly TeamTaskManDbContext context;
        private readonly DbSet<T> entities;

        public Repository(TeamTaskManDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(Guid? id)
        {
            return entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void UpdateTask(Guid taskId, TaskUpdateDto taskDto)
        {
            if (taskDto == null)
            {
                throw new ArgumentNullException(nameof(taskDto), "Task DTO cannot be null");
            }

            var entity = entities.Find(taskId);

            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found.");
            }

            // Use reflection to update only the properties that are included in the DTO
            var entry = context.Entry(entity);

            if (taskDto.TaskName != null)
                entry.Property(nameof(Taskd.TaskName)).CurrentValue = taskDto.TaskName;

            if (taskDto.TaskDueDate != default)
                entry.Property(nameof(Taskd.TaskDueDate)).CurrentValue = taskDto.TaskDueDate;

            if (taskDto.CategoryId > 0)
                entry.Property(nameof(Taskd.CategoryId)).CurrentValue = taskDto.CategoryId;

            if (taskDto.StatusId > 0)
                entry.Property(nameof(Taskd.StatusId)).CurrentValue = taskDto.StatusId;

            if (taskDto.TaskDescription != null)
                entry.Property(nameof(Taskd.TaskDescription)).CurrentValue = taskDto.TaskDescription;

            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }


    }
}
