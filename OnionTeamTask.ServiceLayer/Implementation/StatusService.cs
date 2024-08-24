using OnionTeamTask.DomainLayer.DomainModels;
using OnionTeamTask.RepositoryLayer.Interface;
using OnionTeamTask.ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTeamTask.ServiceLayer.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly IRepository<Status> _statusRepository;

        public StatusService(IRepository<Status> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public List<Status> GetAllStatuses()
        {
            return _statusRepository.GetAll().ToList();
        }
    }
}
