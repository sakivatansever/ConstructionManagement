using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Services
{
    public interface IActivityBussiniessService
    {
        Task<IEnumerable<Activity>> GetAllListActivityAsync();

        Task<Activity> AddActivityAsync(Activity activity);


        Task<Activity> GetActivityByIdAsync(int id);


        Task<bool> RemoveActivityAsync(int id);


        Task<Activity> ModifyActivityAsync(Activity activity);


        Task<IEnumerable<Activity>> GetActivitiesByWorkerIdAsync(int workerId);
      
    }
}
