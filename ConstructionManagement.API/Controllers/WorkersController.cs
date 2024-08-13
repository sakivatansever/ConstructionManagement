
using ConstructionManagement.Application.Managers;
using ConstructionManagement.Application.Services;
using ConstructionManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagement.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerBussinessService _workerManager;

        public WorkersController(IWorkerBussinessService workerManager)
        {
            _workerManager = workerManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] Worker worker)
        {
            if (worker == null)
            {
                return BadRequest("Worker object cannot be null.");
            }

            var createdWorker = await _workerManager.AddWorkerAsync(worker);
            return CreatedAtAction(nameof(GetWorkerById), new { id = createdWorker.Id }, createdWorker);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkers()
        {
            var workers = await _workerManager.GetAllWorkersAsync();
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkerById(int id)
        {
            var worker = await _workerManager.GetWorkerByIdAsync(id);
            if (worker == null)
            {
                return NotFound($"Worker ID {id} bulunamadı ");
            }

            return Ok(worker);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateWorker(int id, [FromBody] Worker worker)
        {
            if (worker == null || worker.Id != id)
            {
                return BadRequest("Hatalı id veya nesne boş ");
            }

            var existingWorker = await _workerManager.GetWorkerByIdAsync(id);
            if (existingWorker == null)
            {
                return NotFound($"Worker  ID {id} Bulunamadi ");
            }

            await _workerManager.ModifyWorkerAsync(worker);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            var existingWorker = await _workerManager.GetWorkerByIdAsync(id);
            if (existingWorker == null)
            {
                return NotFound($"Worker  {id} Bulunamadi ");
            }

            await _workerManager.RemoveWorkerAsync(id);
            return NoContent();
        }
    }

}