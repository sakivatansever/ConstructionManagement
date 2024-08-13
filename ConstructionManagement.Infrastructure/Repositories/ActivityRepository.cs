using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagement.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityService
    {
        private readonly IRepository<Activity> _activityRepository;

        public ActivityRepository(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public  async Task<IEnumerable<Activity>> GetAllListAsync()
        {
            return await _activityRepository.GetAllAsync();
        }

        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            activity.Date = DateTime.Now;
            return await _activityRepository.AddAsync(activity);
        }

        public async Task<IEnumerable<Activity>> GetActivitiesByWorkerIdAsync(int workerId)
        {
            return await _activityRepository.FindAsync(a => a.WorkerId == workerId);
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _activityRepository.GetByIdAsync(id);
        }

        public async Task<Activity> UpdateActivityAsync(Activity activity)
        {
            return await _activityRepository.UpdateAsync(activity);
        }

        public async Task<bool> DeleteActivityAsync(int id)
        {
            return await _activityRepository.DeleteAsync(id);
           
        }
    }
}
