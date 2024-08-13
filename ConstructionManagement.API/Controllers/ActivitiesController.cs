using ConstructionManagement.Application.Abstration;
using ConstructionManagement.Application.Managers;
using ConstructionManagement.Application.Services;
using ConstructionManagement.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagement.API.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityBussiniessService _activityManager;

        public ActivitiesController(IActivityBussiniessService activityManager)
        {
            _activityManager = activityManager;
        }


 
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest("Activity object is null.");
            }
            await _activityManager.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activityManager.GetAllListActivityAsync();
            return Ok(activities);
        }

   
        [HttpGet("worker/{workerId}")]
        public async Task<IActionResult> GetActivitiesByWorkerId(int workerId)
        {
            var activities = await _activityManager.GetActivitiesByWorkerIdAsync(workerId);
            if (activities == null || !activities.Any())
            {
                return NotFound("Bulunamadı");
            }
            return Ok(activities);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityManager.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound($"İlgili  {id} activty yok") ;
            }
            return Ok(activity);
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            if (activity == null || activity.Id != id)
            {
                return BadRequest("Kimlik hatası veya boş ");
            }

            var existingActivity = await _activityManager.GetActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return NotFound($"{id} bulunamadı ");
            }

            await _activityManager.ModifyActivityAsync(activity);
            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var existingActivity = await _activityManager.GetActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return NotFound($"Aktivity id : {id} bulunamadı .");
            }

            await _activityManager.RemoveActivityAsync(id);
            return NoContent();
        }
    }
}
