using EgorovaMariaKt_31_22.Filters.LessonFilters;
using EgorovaMariaKt_31_22.Interfaces.LessonsIntefaces;
using EgorovaMariaKt_31_22.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EgorovaMariaKt_31_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILogger<LessonsController> _logger;
        private readonly ILessonService _lessonService;

        public LessonsController(ILogger<LessonsController> logger, ILessonService lessonService)
        {
            _logger = logger;
            _lessonService = lessonService;
        }

        [HttpPost(Name = "GetLessonByTeacher")]
        public async Task<IActionResult> GetLessonByTeacherAsync(LessonsTeacherFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _lessonService.GetLessonsByTeacherAsync(filter, cancellationToken);
            return Ok(students);
        }


    }   
}
