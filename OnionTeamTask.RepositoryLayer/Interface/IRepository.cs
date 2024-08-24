using OnionTeamTask.DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.RepositoryLayer.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        void Insert(T entity);
        void Update(T entity);
        void UpdateTask(Guid taskId, TaskUpdateDto taskDto);
        void Delete(T entity);
    }
}
