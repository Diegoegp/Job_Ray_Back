using APIMySQL.Data.Repositories;
using APIMySQL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Ray.Controllers
{
    [Route("api/monitors")]
    [ApiController]
    public class MonitorsController : ControllerBase
    {
        private readonly IMonitorRepository _monitorRepository;

        public MonitorsController(IMonitorRepository monitorRepository)
        {
            _monitorRepository = monitorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMonitors()
        {
            return Ok(await _monitorRepository.GetAllMonitors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailMonitors(int id)
        {
            return Ok(await _monitorRepository.GetDetailMonitor(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMonitor([FromBody] Monitor monitor )
        {
            if (monitor == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _monitorRepository.InsertMonitor(monitor);

            return Created("created", created);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateMonitor([FromBody] Monitor monitor)
        {
            if (monitor == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _monitorRepository.UpdateMonitor(monitor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonitors(int id)
        {
            await _monitorRepository.DeleteMonitor(new Monitor() { Id = id});

            return NoContent();
        }
    }
}
