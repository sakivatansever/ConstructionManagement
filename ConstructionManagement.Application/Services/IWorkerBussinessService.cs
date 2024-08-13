using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Services
{
    public interface IWorkerBussinessService
    {
          Task<Worker> AddWorkerAsync(Worker worker);


          Task<Worker> GetWorkerByIdAsync(int id);


          Task<IEnumerable<Worker>> GetAllWorkersAsync();


          Task<Worker> ModifyWorkerAsync(Worker worker);


          Task<bool> RemoveWorkerAsync(int id);
    
    }
}
