using EgorovaMariaKt_31_22.Filters.WorkTimeFilter;
using EgorovaMariaKt_31_22.Interfaces.WorkTimesInterfaces;
using EgorovaMariaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EgorovaMariaKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkTimesController : ControllerBase
    {
        private readonly ILogger<WorkTimesController> _logger;
        private readonly IWorkTimeService _workTimeService;

        public WorkTimesController(ILogger<WorkTimesController> logger, IWorkTimeService workTimeService)
        {
            _logger = logger;
            _workTimeService = workTimeService;
        }


        [HttpPost("filter")]
        public async Task<IActionResult> GetWorkTimes([FromBody] WorkTimesFilter filter, CancellationToken cancellationToken)
        {
            var workTimes = await _workTimeService.GetWorkTimesAsync(filter, cancellationToken);
            return Ok(workTimes);
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkTime([FromBody] int workTimeHours, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workTimeService.AddWorkTimeAsync(workTimeHours, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkTime(int id, [FromBody] int workTimeHours, CancellationToken cancellationToken)
        {
            var result = await _workTimeService.UpdateWorkTimeAsync(id, workTimeHours, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkTime(int id, CancellationToken cancellationToken)
        {
            await _workTimeService.DeleteWorkTimeAsync(id, cancellationToken);
            return NoContent();
        }
    }
}


