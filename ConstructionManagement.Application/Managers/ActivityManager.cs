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
    public class ActivityManager: IActivityBussiniessService
    {
        private readonly IActivityService _activityService;

        public ActivityManager(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IEnumerable<Activity>>GetAllListActivityAsync()
        {
            return await _activityService.GetAllListAsync();
        }

        public async Task<Activity> AddActivityAsync(Activity activity)
        {
            return await _activityService.CreateActivityAsync(activity);
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _activityService.GetActivityByIdAsync(id);
        }

        public async Task<bool> RemoveActivityAsync(int id)
        {
            return await _activityService.DeleteActivityAsync(id);
        }

        public async Task<Activity> ModifyActivityAsync(Activity activity)
        {
            return await _activityService.UpdateActivityAsync(activity);
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByWorkerIdAsync(int workerId)
        {
            return await _activityService.GetActivitiesByWorkerIdAsync(workerId);
        }
    }
}
