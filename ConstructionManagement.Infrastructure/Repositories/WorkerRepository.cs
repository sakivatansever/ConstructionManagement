using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Infrastructure.Repositories
{
    public class WorkerRepository : IWorkerService
    {
        private readonly IRepository<Worker> _workerRepository;
        public WorkerRepository(IRepository<Worker> workerrepository)
        {
            _workerRepository= workerrepository;
        }

        public async Task<Worker> CreateWorkerAsync(Worker worker)
        {
            return await _workerRepository.AddAsync(worker);
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            return await _workerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await _workerRepository.GetAllAsync();
        }

        public async Task<Worker> UpdateWorkerAsync(Worker worker)
        {
            return await _workerRepository.UpdateAsync(worker);
        }

        public async Task<bool> DeleteWorkerAsync(int id)
        {
            return await _workerRepository.DeleteAsync(id);
        }
    }
}
