using ConstructionManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Application.Abstration
{
    public interface IActivityService
    {
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<IEnumerable<Activity>> GetActivitiesByWorkerIdAsync(int workerId);
        Task<Activity> GetActivityByIdAsync(int id);
        Task<Activity> UpdateActivityAsync(Activity activity);
        Task<bool> DeleteActivityAsync(int id);
        Task<IEnumerable<Activity>> GetAllListAsync();
    }
}
