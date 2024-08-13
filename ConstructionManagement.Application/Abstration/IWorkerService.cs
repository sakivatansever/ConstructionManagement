using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Abstration
{
    public interface IWorkerService
    {
        Task<Worker> CreateWorkerAsync(Worker worker);
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<IEnumerable<Worker>> GetAllWorkersAsync();
        Task<Worker> UpdateWorkerAsync(Worker worker);
        Task<bool> DeleteWorkerAsync(int id);
    }
}
