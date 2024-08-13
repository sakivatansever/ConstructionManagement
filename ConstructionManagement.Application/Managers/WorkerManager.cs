using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Application.Services;
using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Managers
{
    public class WorkerManager : IWorkerBussinessService
    {
        private readonly IWorkerService _workerService;

        public WorkerManager(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
            if (worker == null)
            {
                throw new ArgumentNullException(nameof(worker), "Worker cannot be null");
            }

            return await _workerService.CreateWorkerAsync(worker);
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            return await _workerService.GetWorkerByIdAsync(id);
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await _workerService.GetAllWorkersAsync();
        }

        public async Task<Worker> ModifyWorkerAsync(Worker worker)
        {
            if (worker == null)
            {
                throw new ArgumentNullException(nameof(worker), "Worker cannot be null");
            }

            return await _workerService.UpdateWorkerAsync(worker);
        }

        public async Task<bool> RemoveWorkerAsync(int id)
        {
            return await _workerService.DeleteWorkerAsync(id);
        }
    }

}
